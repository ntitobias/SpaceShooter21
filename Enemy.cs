using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    abstract class Enemy : PhysicalObject
    {
        public Enemy(Texture2D image, float X, float Y, float speedX, float speedY) : base(image, X, Y, speedX, speedY)
        {
        }

        public abstract void Update(GameWindow window);
        
    }

    class Mine : Enemy
    {
        public Mine(Texture2D image, float X, float Y) : base(image, X, Y, 6f, 0.3f)
        {
        }

        public override void Update(GameWindow window)
        {
            //Flytta på fienden
            position += speed;

            // Vad händer när den åker utanför kanten?
            //Höger och vänster kant
            if (position.X > window.ClientBounds.Width - image.Width ||
                position.X < 0)
            {
                speed.X *= -1;
            }
            if (position.Y > window.ClientBounds.Height)
            {
                IsAlive = false;
            }
        }
    }

    class Tripod : Enemy
    {
        public Tripod(Texture2D image, float X, float Y) : base(image, X, Y, 0f, 3f)
        {
        }

        public override void Update(GameWindow window)
        {
            //Flytta på fienden
            position += speed;

            // Vad händer när den åker utanför kanten?
            if (position.Y > window.ClientBounds.Height)
            {
                IsAlive = false;
            }
        }
    }

}
