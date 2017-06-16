using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRunner
{
    public static class PlayField
    {
        static int viewPortWidth;
        static int viewPortHeight;

        static bool isDirty = false;

        static Dictionary<GameObject, Point> gameObjects = new Dictionary<GameObject, Point>();


        public static void Init(int width, int height)
        {
            viewPortWidth = width;
            viewPortHeight = height;

            Console.SetBufferSize(viewPortWidth, viewPortHeight);
            Console.SetWindowSize(viewPortWidth + 2, viewPortHeight + 2);
            
        }



        public static bool IsColliding(Point loc1, Point loc2, Point box2)
        {
            return loc1.X >= loc2.X
                && loc1.X <  loc2.X + box2.X
                && loc1.Y >= loc2.Y
                && loc1.Y <  loc2.Y + box2.Y;
        }

        public static bool IsColliding(Point loc1, Point box1, Point loc2, Point box2)
        {
            return loc1.X < loc2.X + box2.X
                && loc1.X + box1.X > loc2.X
                && loc1.Y < loc2.Y + box2.Y
                && loc1.Y + box1.Y > loc2.Y;
        }

        public static bool TrySetGameObjectLocation(GameObject gameObject, Point location)
        {
            if( location.X < 0 
                || location.X >= viewPortWidth
                || location.Y < 0
                || location.Y >= viewPortHeight
                )
            {
                return false;
            }

            foreach(GameObject obj in gameObjects.Keys)
            {
                if(gameObject != obj && IsColliding(location,gameObject.BoundingBox,gameObjects[obj],obj.BoundingBox))
                {
                    return false;
                }
            }

            if(gameObjects.Keys.Contains(gameObject))
            {
                // Invalidate the region previously occupied by the gameObject
                InvalidateRender(gameObjects[gameObject], gameObject.BoundingBox);
            }

            gameObjects[gameObject] = location;

            isDirty = true;

            return true;
        }

        public static bool TryMoveGameObject(GameObject gameObject, Point offset)
        {
            Point newLocation = gameObjects[gameObject].Offset(offset);

            return TrySetGameObjectLocation(gameObject, newLocation);
        }

        public static Point GetGameObjectLocation(GameObject gameObject)
        {
            return gameObjects[gameObject];
        }


        public static void InvalidateRender(Point location, Point size)
        {
            string invalidLine = new String(' ', size.X);
            for (int y = 0; y < size.Y; y++)
            {
                Console.SetCursorPosition(location.X, location.Y + y);
                Console.Write(invalidLine);
            }
        }

        public static void RenderPlayField()
        {
            if(isDirty)
            {
                foreach (GameObject obj in gameObjects.Keys)
                {
                    string[] rendering = obj.getRendering(0);
                    for (int i = 0; i < rendering.Length; i++)
                    {
                        Console.SetCursorPosition(gameObjects[obj].X, gameObjects[obj].Y + i);
                        Console.Write(rendering[i]);
                    }
                }

                isDirty = false;
            }
        }
    }
}
