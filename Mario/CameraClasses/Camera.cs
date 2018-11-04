using System;
using Game1;
using Mario.XMLRead;
using Microsoft.Xna.Framework;

namespace Mario.CameraClasses
{
    public class Camera : ICamera
    {
        public Vector2 Location { get; set; }
        public Rectangle InnerBox { get; set; }
        public Matrix Transform { get; private set; }
        public Camera()
        {
            Location = new Vector2(0, 0);      
			Transform = Matrix.CreateTranslation(new Vector3(-Location.X, -Location.Y, 0));
            InnerBox = new Rectangle();
        }

        public void MoveRight(float distance)
        {
            Location = new Vector2(Location.X + distance, Location.Y);
            Transform = Matrix.CreateTranslation(new Vector3(-Location.X, -Location.Y, 0));
        }
        public bool offLeftRightScreen(Rectangle box)
        {
            if ((box.Right <= InnerBox.Left) || (box.Left >= InnerBox.Left + 1440))
            {
                return true;
            }
            else return false;
        }
        public bool offUpDownScreen(Rectangle box)
        {
            if ((box.Top <= 0) || (box.Bottom >= 900))
            {
                return true;
            }
            else return false;
        }
        public void ResetCamera(Rectangle box)
        {
            Location = Vector2.UnitX*(box.Location.X - 450);


        }
    }
}