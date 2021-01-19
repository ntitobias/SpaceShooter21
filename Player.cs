using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace SpaceShooter
{
    class Player: PhysicalObject
    {
        int points;
        List<Bullet> bullets;
        Texture2D bulletGfx;
        double timeSinceLastBullet = 0;

        public int Points { get { return points; } set { points = value; } }
        public List<Bullet> Bullets { get { return bullets; } }

        public Player(Texture2D image, float X, float Y, float speedX, float speedY, Texture2D bulletTexture) : base(image, X, Y, speedX, speedY)
        {
            bullets = new List<Bullet>();
            this.bulletGfx = bulletTexture;
        }

        public void Update(GameWindow window, GameTime gameTime)
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

            //Spelaren vill skjuta
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                //Kontrollera om spelaren får skjuta
                if(gameTime.TotalGameTime.TotalMilliseconds > timeSinceLastBullet + 200)
                {
                    //Skapa skottet
                    Bullet temp = new Bullet(bulletGfx, position.X + image.Width / 2, position.Y);
                    bullets.Add(temp);

                    //Sätt time since last bullet till detta ögonblick
                    timeSinceLastBullet = gameTime.TotalGameTime.TotalMilliseconds;
                }
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
        
            //Flytta skotten
            foreach(Bullet b in bullets.ToList())
            {
                b.Update();
                if (!b.IsAlive)
                    bullets.Remove(b);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, Color.White);
            foreach(Bullet b in bullets)
            {
                b.Draw(spriteBatch);
            }
        }
    }

    class Bullet : PhysicalObject
    {
        public Bullet(Texture2D image, float X, float Y) : base(image, X, Y, 0, 3f)
        {  

        }

        public void Update()
        {
            position.Y -= speed.Y;

            //Ta bort skottet när det hamnar ovanför bildskärmen
            if (position.Y < 0)
            {
                IsAlive = false;
            }
        }
    }
}
