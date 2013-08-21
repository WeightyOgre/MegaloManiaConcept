using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Mega
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameWorld theGameWorld;

        int screenResolutionWidth = 1920;
        int screenResolutionHeight = 1080;

        int elapsedTime;
        int minWaitTime;

        Color aColor;

        TextDisplay debugText;

        TextDisplay buildingDetails;

        TextDisplay macroResources;

        TextDisplay buildingInformation;

        TextDisplay AgricultureInformation;

        TextDisplay FarmerInformation;

        GameArt gameArt;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //set up the viewport to match screen resolution and set to full screen
            graphics.PreferredBackBufferWidth = screenResolutionWidth;
            graphics.PreferredBackBufferHeight = screenResolutionHeight;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            this.IsMouseVisible = true;
 
            //set time to zero
            elapsedTime = 0;
            
            minWaitTime = 200;

            aColor = Color.White;

            debugText = new TextDisplay(this.Content, "test", new Vector2(0, 0));
            buildingDetails = new TextDisplay(this.Content, "test", new Vector2(310, 260));
            macroResources = new TextDisplay(this.Content, "test", new Vector2(1010, 260));
            buildingInformation = new TextDisplay(this.Content, "test", new Vector2(1010, 900));
            AgricultureInformation = new TextDisplay(this.Content, "test", new Vector2(1030, 600));
            FarmerInformation = new TextDisplay(this.Content, "test", new Vector2(1430, 600));

            gameArt = new GameArt(this.Content);

            theGameWorld = new GameWorld(AgricultureInformation, FarmerInformation);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);



            theGameWorld.LoadMainGameArea();
            theGameWorld.LoadInformationArea();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) == true)
            {
                this.Exit();
            }

            // TODO: Add your update logic here

            if(minimumWaitTime(gameTime))
            {
                theGameWorld.updateResources();
                theGameWorld.updateBuildings();
                if (aColor == Color.White)
                {
                    //aColor = Color.Black;
                }
                else
                {
                    //aColor = Color.White;
                }
            }

            debugText.stringValue = Convert.ToString(gameTime.TotalGameTime);
            buildingDetails.stringValue = theGameWorld.getBuildingDetails();
            macroResources.stringValue = getMacroResources();
            buildingInformation.stringValue = "People in building " + theGameWorld.getBuildingPeople();
            

            theGameWorld.UpdateUI();

            base.Update(gameTime);
        }

        public string getMacroResources()
        {
            return Convert.ToString("Food " + theGameWorld.Agriculture + "\r\n" + "Materials " + theGameWorld.Industrial + "\r\n" + "Knowledge " + theGameWorld.Research);
        }

        public bool minimumWaitTime(GameTime gameTime)
        {
            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedTime > minWaitTime)
            {
                elapsedTime = 0;
                return true;
            }
            else
            {
                return false;
            }

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(gameArt.BackGroundTexture, new Vector2(0,0), aColor);
            //mainGameArea.Draw(spriteBatch);
            //informationArea.Draw(spriteBatch);
            //draw the icons
            spriteBatch.Draw(gameArt.UIAgricultureTexture, theGameWorld.getAgricultureIconPosition(), Color.White);
            spriteBatch.Draw(gameArt.UIIndustrialTexture, theGameWorld.getIndustrialIconPosition(), Color.White);
            spriteBatch.Draw(gameArt.UIResearchTexture, theGameWorld.getResearchIconPosition(), Color.White);
            //draw the background for information area
            if (theGameWorld.getUIState(0) == 1)
            {
                spriteBatch.Draw(gameArt.UIAgricultureBackgroundTexture, theGameWorld.getAgricultureBackgroundPosition(), Color.White);
                spriteBatch.Draw(gameArt.LeftArrowIconTexture, theGameWorld.getLeftArrowIconPosition(), Color.White);
                spriteBatch.Draw(gameArt.RightArrowIconTexture, theGameWorld.getRightArrowIconPosition(), Color.White);
            }
            if (theGameWorld.getUIState(1) == 1)
            {
                spriteBatch.Draw(gameArt.UIIndustrialBackgroundTexture, theGameWorld.getIndustrialBackgroundPosition(), Color.White);
                spriteBatch.Draw(gameArt.LeftArrowIconTexture, theGameWorld.getLeftArrowIconPosition(), Color.White);
                spriteBatch.Draw(gameArt.RightArrowIconTexture, theGameWorld.getRightArrowIconPosition(), Color.White);
            }
            if (theGameWorld.getUIState(2) == 1)
            {
                spriteBatch.Draw(gameArt.UIResearchBackgroundTexture, theGameWorld.getResearchBackgroundPosition(), Color.White);
                spriteBatch.Draw(gameArt.LeftArrowIconTexture, theGameWorld.getLeftArrowIconPosition(), Color.White);
                spriteBatch.Draw(gameArt.RightArrowIconTexture, theGameWorld.getRightArrowIconPosition(), Color.White);
            }

            for (int i = 0; i <= theGameWorld.getBound0(); i++)
            {
                for (int j = 0; j <= theGameWorld.getBound1(); j++)
                {
                    spriteBatch.Draw(gameArt.TileTexture, theGameWorld.getTilePosition(i,j), Color.White);
                    for (int k = theGameWorld.getBuildingCount() - 1; k >= 0; k--)
                    {
                        spriteBatch.Draw(gameArt.BuildingTexture, theGameWorld.getBuildingPosition(k), Color.White);
                    }
                }
            }  

            spriteBatch.End();
            DrawText();            
            base.Draw(gameTime);
        }

        public void DrawText()
        {
            SpriteBatch fontBatch = new SpriteBatch(GraphicsDevice);
            debugText.DrawFont(fontBatch);
            buildingDetails.DrawFont(fontBatch);
            macroResources.DrawFont(fontBatch);
            buildingInformation.DrawFont(fontBatch);
            
            if (theGameWorld.getUIState(0) == 1)
            {
                AgricultureInformation.stringValue = Convert.ToString(theGameWorld.getBuildingPeople());
                AgricultureInformation.DrawFont(fontBatch);
                FarmerInformation.stringValue = Convert.ToString(theGameWorld.Farmers);
                FarmerInformation.DrawFont(fontBatch);
            }

        }

    }
}
