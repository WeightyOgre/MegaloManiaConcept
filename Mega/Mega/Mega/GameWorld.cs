using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mega
{
    class GameWorld
    {
        //background image
        Texture2D backGroundTexture;
        public Texture2D BackGroundTexture
        {
            get { return backGroundTexture; }
            set { backGroundTexture = value; }
        }
        Vector2 backGroundTexturePosition;
        public Vector2 BackGroundTexturePosition
        {
            get { return backGroundTexturePosition; }
            set { backGroundTexturePosition = value; }
        }
        //tile image
        Texture2D tileTexture;
        public Texture2D TileTexture
        {
            get { return tileTexture; }
            set { tileTexture = value; }
        }

        //object for main game content
        MainView mainGameArea;
        MainView informationArea;

        public GameWorld()
        {
            
        }

        public void LoadMainGameArea()
        {
            int blocksAcross = 20;
            int blocksDown = 20;
            Vector2 startingPosition = new Vector2(100, 100);
            mainGameArea = new MainView(tileTexture, startingPosition, blocksAcross, blocksDown);
        }

        public void LoadInformationArea()
        {
            int blocksAcross = 15;
            int blocksDown = 20;
            Vector2 startingPosition = new Vector2(1000, 100);
            informationArea = new MainView(tileTexture, startingPosition, blocksAcross, blocksDown);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackGroundTexture, BackGroundTexturePosition, Color.White);
            mainGameArea.Draw(spriteBatch);
            informationArea.Draw(spriteBatch);
        }

    }
}
