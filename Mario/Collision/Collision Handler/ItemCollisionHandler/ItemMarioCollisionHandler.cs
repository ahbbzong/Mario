using Game1;

namespace Mario.Collision.ItemCollisionHandler
{
	public class ItemMarioCollisionHandler : IItemCollisionHandler
    {
        public ItemMarioCollisionHandler()
        {
        }
        public void HandleCollision(IItem item)
        {
            GameObjectManager.Instance.GameObjectListsByType[typeof(IItem)].Remove(item);
        }
    }
}
