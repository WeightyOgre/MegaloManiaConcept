using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mega
{
    class Block
    {
        //a Block
        Texture2D tileTexture;
        public Texture2D TileTexture
        {
            get { return tileTexture; }
            set { tileTexture = value; }
        }
        Vector2 tileTexturePosition;
        public Vector2 TileTexturePosition
        {
            get { return tileTexturePosition; }
            set { tileTexturePosition = value; }
        }

        public Block(Texture2D tileTexture, Vector2 tileTexturePosition)
        {
            this.tileTexture = tileTexture;
            this.tileTexturePosition = tileTexturePosition;
        }

    }
}
