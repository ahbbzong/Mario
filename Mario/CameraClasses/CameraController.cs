using Game1;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.CameraClasses
{
    internal class CameraController : ICameraController
    {
        private ICamera camera;

        public CameraController(ICamera cameraInput)
        {
            this.camera = cameraInput;
        }

        public void Update() //this should be the xPosition of Mario
        {
            float xPosition = ItemManager.Instance.Mario.Getposition().X;
            if (xPosition > camera.Location.X + 450/* add an offset here, maybe half the width of the screen */)
            {
                camera.MoveRight(5/* choose a number. Maybe 5 */);
            }
            camera.InnerBox = new Rectangle((int)camera.Location.X-10, (int)camera.Location.Y, 10, 40);
        }
    }

}
