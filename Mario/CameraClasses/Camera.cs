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
    }
}