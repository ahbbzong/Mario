
using Game1;
using Microsoft.Xna.Framework;

namespace Mario.GameObjects.Decorators
{
	abstract class MarioSpecialEventDecorator : MarioDecorator
	{
		protected MarioSpecialEventDecorator(IMario mario) : base(mario)
		{
		}

		public override Rectangle Box => base.Box;

		public override void TakeDamage()
		{
			//NO-OP
		}

		public override void Update()
		{

		}

		public virtual void RemoveSelf()
		{
			GameObjectManager.Instance.GameObjectListsByType[typeof(IMario)][0] = this.DecoratedMario;
		}
	}
}
