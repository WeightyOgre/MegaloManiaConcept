using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mega
{
    class MainView
    {
        Block[,] theMainView;

        int blocksAcross;
        int blocksDown;

        public int bound0;
        public int bound1;

        //values of the size of the textures used for making tiles
        int blockWidth = 40;
        int blockHeight = 40;



        public MainView(Texture2D tileTexture, Vector2 startingPosition, int blocksAcross, int blocksDown)
        {

            this.blocksAcross = blocksAcross;
            this.blocksDown = blocksDown;

            theMainView = new Block[blocksAcross, blocksDown];

            bound0 = theMainView.GetUpperBound(0);
            bound1 = theMainView.GetUpperBound(1);

            for (int i = 0; i <= bound0; i++)
            {
                for (int j = 0; j <= bound1; j++)
                {
                    
                    Vector2 position = new Vector2(startingPosition.X + i * blockWidth, startingPosition.Y + j * blockHeight);
                    theMainView[i, j] = new Block(tileTexture,position);
                                    
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i <= bound0; i++)
            {
                for (int j = 0; j <= bound1; j++)
                {
                    spriteBatch.Draw(theMainView[i, j].TileTexture, theMainView[i, j].TileTexturePosition, Color.White);
                }
            }

        }

    }
}
