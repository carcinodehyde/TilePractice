using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilePractice.GameObjects
{
    class Sprite
    {
        private Vector2 Position { get; set; }
        private Texture2D Texture { get; set; }

        public Sprite(Texture2D texture, Vector2 position)
        {

            Texture = texture;
            Position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
