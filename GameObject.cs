using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SpaceShooter
{
    class GameObject
    {
        protected Texture2D image;
        protected Vector2 position;

        public GameObject(Texture2D image, float X, float Y)
        {
            this.image = image;
            this.position = new Vector2(X, Y);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, Color.White);
        }

        public float X { get { return position.X; } }
        public float Y { get { return position.Y; } }
        public float Width { get { return image.Width; } }
        public float Height { get { return image.Height; } }

    }

    class MovingObject : GameObject
    {
        protected Vector2 speed;

        public MovingObject(Texture2D image, float X, float Y, float speedX, float speedY) : base(image, X, Y)
        {
            speed = new Vector2(speedX, speedY);
        }
    }

    abstract class PhysicalObject : MovingObject
    {
        bool isAlive = true;

        public PhysicalObject(Texture2D image, float X, float Y, float speedX, float speedY) : base(image, X, Y, speedX, speedY)
        {

        }

        public bool CheckCollision(PhysicalObject other)
        {
            Rectangle myRect = new Rectangle(Convert.ToInt32(X), Convert.ToInt32(Y), Convert.ToInt32(Width), Convert.ToInt32(Height));
            Rectangle otherRect = new Rectangle(Convert.ToInt32(other.X), Convert.ToInt32(other.Y), Convert.ToInt32(other.Width), Convert.ToInt32(other.Height));

            return myRect.Intersects(otherRect);

        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

    }
}
