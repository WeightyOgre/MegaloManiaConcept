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

            theGameWorld = new GameWorld(AgricultureInformation, FarmerInformation);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //load the games background image
            theGameWorld.BackGroundTexture = Content.Load<Texture2D>("background1920x1080");
            theGameWorld.BackGroundTexturePosition = new Vector2(0,0);

            //load the tile image for mapping out main game area
            theGameWorld.TileTexture = Content.Load<Texture2D>("brick40x40");
            theGameWorld.BuildingTexture = Content.Load<Texture2D>("BPH");

            theGameWorld.UIAgricultureTexture = Content.Load<Texture2D>("AgricultureIcon80x80");
            theGameWorld.UIIndustrialTexture = Content.Load<Texture2D>("IndustrialIcon80x80");
            theGameWorld.UIResearchTexture = Content.Load<Texture2D>("ResearchIcon80x80");

            theGameWorld.UIAgricultureBackgroundTexture = Content.Load<Texture2D>("InformationAgriculturalBackground600x320");
            theGameWorld.UIIndustrialBackgroundTexture = Content.Load<Texture2D>("InformationIndustryBackground600x320");
            theGameWorld.UIResearchBackgroundTexture = Content.Load<Texture2D>("InformationResearchBackground600x320");

            //load the textures for the UI Icons
            theGameWorld.LeftArrowIconTexture = Content.Load<Texture2D>("LeftArrow40x40");
            theGameWorld.RightArrowIconTexture = Content.Load<Texture2D>("RightArrow40x40");

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
            SpriteBatch fontBatch = new SpriteBatch(GraphicsDevice);

            spriteBatch.Begin();
            theGameWorld.Draw(spriteBatch, aColor);
            spriteBatch.End();
            theGameWorld.DrawText(fontBatch);
            debugText.DrawFont(fontBatch);
            buildingDetails.DrawFont(fontBatch);
            macroResources.DrawFont(fontBatch);
            buildingInformation.DrawFont(fontBatch);
            theGameWorld.DrawText(fontBatch);

            
            base.Draw(gameTime);
        }
    }
}
