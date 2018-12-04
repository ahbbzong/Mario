using Game1;
using Mario.Collections;
using Mario.GameObjects;
using Microsoft.Xna.Framework;

namespace Mario.CameraClasses
{
	internal class CameraController : ICameraController
    {
        private ICamera camera;
        private int count = 0;

        public CameraController(ICamera cameraInput)
        {
            camera = cameraInput;
        }

        public void Update()
        {
            count++;
			Vector2 marioPosition = GameObjectManager.Instance.Mario.Position;
            IEnemy miniBoss = (IEnemy)GameObjectManager.Instance.GameObjectList.GameObjectEnumeratorByKeyAndValue(typeof(IEnemy), typeof(MiniBoss));
            if (camera.IsOffSideOfScreen(GameObjectManager.Instance.Mario.Box))
            {
                camera.ResetCameraLocation(GameObjectManager.Instance.Mario.Box);
            }
            if (marioPosition.X > camera.Location.X + CameraUtil.cameraOffset)
            {
                camera.MoveRight(CameraUtil.cameraFive);
            }
            if (miniBoss.Position.X < camera.Location.X + CameraUtil.resolutionWidth&& miniBoss.Position.X> camera.Location.X)
            {
                    if (count % 2 == 0)
                        camera.MoveUp(CameraUtil.cameraFive * 2);
                    else
                        camera.MoveDown(CameraUtil.cameraFive * 2);
            }

            camera.InnerBox = new Rectangle((int)camera.Location.X-CameraUtil.cameraTen, (int)marioPosition.Y, CameraUtil.cameraTen, CameraUtil.cameraFourHundred);
        }
    }

}
