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
            camera = cameraInput;
        }

        public void Update()
        {
			Vector2 marioPosition = GameObjectManager.Instance.Mario.Position;
            if (camera.IsOffSideOfScreen(GameObjectManager.Instance.Mario.Box))
            {
                camera.ResetCameraLocation(GameObjectManager.Instance.Mario.Box);
            }
            if (marioPosition.X > camera.Location.X + CameraUtil.cameraOffset)
            {
                camera.MoveRight(CameraUtil.cameraFive);
            }
            camera.InnerBox = new Rectangle((int)camera.Location.X-CameraUtil.cameraTen, (int)marioPosition.Y, CameraUtil.cameraTen, CameraUtil.cameraFourHundred);
        }
    }

}
