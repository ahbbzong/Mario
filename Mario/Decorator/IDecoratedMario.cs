namespace Mario.Decorator
{
    abstract class IDecoratedMario : IMario 
    {

        private Mario decoratedMario;

        public IDecoratedMario(Mario mario)
        {
            decoratedMario = mario; 
        }

        public virtual void Damage()
        {
            decoratedMario.Damage();
        }
        public virtual void PowerUp()
        {

        }

        public virtual void IsSuperMario()
        {
          
        }

        public virtual void IsNormalMario()
        {

        }
        public virtual void IsFireMario()
        {

        }

        public virtual void IsStarMario()
        {

        }

        public virtual bool IsDead()
        {
            return true; // temp input
        }

        public virtual bool Isfalling()
        {

            return true;//temp input
        }
        public virtual bool IsLeft()
        {
            return true;//temp input
        }
        public virtual bool IsRight()
        {
            return true;//temp input
        }

    }
}
