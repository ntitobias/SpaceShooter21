using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    class Player: PhysicalObject
    {
        int points;
        public int Points { get { return points; } set { points = value; } }
        public Player(Texture2D image, float X, float Y, float speedX, float speedY) : base(image, X, Y, speedX, speedY)
        {
         
        }

        public void Update(GameWindow window)
        {
            //Fråga efter tangentbordets status
            KeyboardState keyboardState = Keyboard.GetState();

            //Händelser utifrån vilka tangenter som har tryckts ned
            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                position.X += speed.X;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                position.X -= speed.X;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                position.Y += speed.Y;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                position.Y -= speed.Y;
            }
            //Flytta tillbaka skeppet om det hamnar utanför banan
            if (position.X > window.ClientBounds.Width - image.Width)
            {
                position.X = window.ClientBounds.Width - image.Width;
            }
            if (position.X < 0)
            {
                position.X = 0;
            }
            if (position.Y > window.ClientBounds.Height - image.Height)
            {
                position.Y = window.ClientBounds.Height - image.Height;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
            }
        }
    }

}
