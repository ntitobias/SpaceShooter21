using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SpaceShooter
{
    class GoldCoin : PhysicalObject
    {
        double timeToDie; //Hur länge guldmyntet lever kvar.

        public GoldCoin(Texture2D image, float X, float Y, GameTime gameTime) : base(image, X, Y, 0, 2f)
        {
            timeToDie = gameTime.TotalGameTime.TotalMilliseconds + 5000;
        }

        public void Update(GameTime gameTime)
        {
            if (timeToDie < gameTime.TotalGameTime.TotalMilliseconds)
                IsAlive = false;
        }
    }

}