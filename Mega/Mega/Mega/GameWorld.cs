using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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
        //building image
        Texture2D buildingTexture;
        public Texture2D BuildingTexture
        {
            get { return buildingTexture; }
            set { buildingTexture = value; }
        }
        //UI Icons
        Texture2D uiAgricultureTexture;
        public Texture2D UIAgricultureTexture
        {
            get { return uiAgricultureTexture; }
            set { uiAgricultureTexture = value; }
        }
        Texture2D uiIndustrialTexture;
        public Texture2D UIIndustrialTexture
        {
            get { return uiIndustrialTexture; }
            set { uiIndustrialTexture = value; }
        }
        Texture2D uiResearchTexture;
        public Texture2D UIResearchTexture
        {
            get { return uiResearchTexture; }
            set { uiResearchTexture = value; }
        }

        //UI Backgrounds
        Texture2D uiAgricultureBackgroundTexture;
        public Texture2D UIAgricultureBackgroundTexture
        {
            get { return uiAgricultureBackgroundTexture; }
            set { uiAgricultureBackgroundTexture = value; }
        }

        Texture2D uiIndustrialBackgroundTexture;
        public Texture2D UIIndustrialBackgroundTexture
        {
            get { return uiIndustrialBackgroundTexture; }
            set { uiIndustrialBackgroundTexture = value; }
        }

        Texture2D uiResearchBackgroundTexture;
        public Texture2D UIResearchBackgroundTexture
        {
            get { return uiResearchBackgroundTexture; }
            set { uiResearchBackgroundTexture = value; }
        }
        //UI Icons
        Texture2D leftArrowIconTexture;
        public Texture2D LeftArrowIconTexture
        {
            get { return leftArrowIconTexture; }
            set { leftArrowIconTexture = value; }
        }

        Texture2D rightArrowIconTexture;
        public Texture2D RightArrowIconTexture
        {
            get { return rightArrowIconTexture; }
            set { rightArrowIconTexture = value; }
        }

        //object for main game content
        MainView mainGameArea;
        MainView informationArea;

        //a players resourcs comprise
        float agriculture;
        public float Agriculture
        {
            get { return agriculture; }
            set { agriculture = value; }
        }
        float industrial;
        public float Industrial
        {
            get { return industrial; }
            set { industrial = value; }
        }
        float research;
        public float Research
        {
            get { return research; }
            set { research = value; }
        }

        //agriculture tab
        int farmers;
        public int Farmers
        {
            get { return farmers; }
            set { farmers = value; }
        }

        int[] UIState;

        MouseState mouseState;

        TextDisplay AgricultureInformation;
        TextDisplay FarmerInformation;

        public GameWorld(TextDisplay AgricultureInformation, TextDisplay FarmerInformation)
        {
            this.AgricultureInformation = AgricultureInformation;
            this.FarmerInformation = FarmerInformation;

            agriculture = 0;
            industrial = 0;
            research = 0;
            UIState = new int[4];

            for (int i = 0; i <= UIState.Length-1; i++)
            {
                UIState[i] = 0;
            }
            //UIState[1] = 1;
            farmers = 0;
        }

        public void UpdateUI()
        {
            mouseState = Mouse.GetState();

            //left mouse button click
            if (mouseState.LeftButton == ButtonState.Pressed && mouseState.RightButton == ButtonState.Released)
            {
                //two rectangles
                //first is the mouse
                Rectangle mouseRectangle = new Rectangle(mouseState.X, mouseState.Y, 5,5);
                //second is the ui icons
                Rectangle agricultureIconRectangle = new Rectangle((int)informationArea.AgricultureIconPosition.X, (int)informationArea.AgricultureIconPosition.Y, informationArea.AgricultureIconTexture.Width, informationArea.AgricultureIconTexture.Height);
                //check if the current mouse is clicking on the icon
                if (mouseRectangle.Intersects(agricultureIconRectangle))
                {
                    UIState[0] = 1;
                    UIState[1] = 0;
                    UIState[2] = 0;
                    UIState[3] = 0;
                }

                Rectangle industryIconRectangle = new Rectangle((int)informationArea.IndustrialIconPosition.X, (int)informationArea.IndustrialIconPosition.Y, informationArea.IndustrialIconTexture.Width, informationArea.IndustrialIconTexture.Height);
                if (mouseRectangle.Intersects(industryIconRectangle))
                {
                    UIState[0] = 0;
                    UIState[1] = 1;
                    UIState[2] = 0;
                    UIState[3] = 0;
                }

                Rectangle researchIconRectangle = new Rectangle((int)informationArea.ResearchIconPosition.X, (int)informationArea.ResearchIconPosition.Y, informationArea.ResearchIconTexture.Width, informationArea.ResearchIconTexture.Height);
                if (mouseRectangle.Intersects(researchIconRectangle))
                {
                    UIState[0] = 0;
                    UIState[1] = 0;
                    UIState[2] = 1;
                    UIState[3] = 0;
                }

                Rectangle leftArrowIconRectangle = new Rectangle((int)informationArea.LeftArrowIconPosition.X, (int)informationArea.LeftArrowIconPosition.Y, informationArea.LeftArrowIconTexture.Width, informationArea.LeftArrowIconTexture.Height);
                if (mouseRectangle.Intersects(leftArrowIconRectangle))
                {
                    if (UIState[0] == 1)
                    {
                        if (farmers <= 0)
                        {

                        }
                        else
                        {
                            farmers--;
                            mainGameArea.AddPeople();
                        }
                    }
                }

                Rectangle rightArrowIconRectangle = new Rectangle((int)informationArea.RightArrowIconPosition.X, (int)informationArea.RightArrowIconPosition.Y, informationArea.RightArrowIconTexture.Width, informationArea.RightArrowIconTexture.Height);
                if (mouseRectangle.Intersects(rightArrowIconRectangle))
                {
                    if (UIState[0] == 1)
                    {
                        if (mainGameArea.getBuildingPeople() <= 0)
                        {

                        }
                        else
                        {
                            farmers++;
                            mainGameArea.RemovePeople();
                        }
                    }
                }

            }

        }

        public void LoadMainGameArea()
        {
            int blocksAcross = 20;
            int blocksDown = 20;
            Vector2 startingPosition = new Vector2(100, 100);
            mainGameArea = new MainView(tileTexture, startingPosition, blocksAcross, blocksDown);
            mainGameArea.AddBuilding(buildingTexture);
        }

        public void LoadInformationArea()
        {
            int blocksAcross = 15;
            int blocksDown = 20;
            Vector2 startingPosition = new Vector2(1000, 100);
            informationArea = new MainView(tileTexture, startingPosition, blocksAcross, blocksDown);
            informationArea.placeIcons(uiAgricultureTexture, new Vector2(1000 + (40 * 0), 100 + (40 * 6)), uiIndustrialTexture, new Vector2(1000 + (40 * 1), 100 + (40 * 6)), uiResearchTexture, new Vector2(1000 + (40 * 2), 100 + (40 * 6)));
            informationArea.PlaceUIBackground(uiAgricultureBackgroundTexture, new Vector2(1000 + (40 * 0), 100 + (40 * 7)), uiIndustrialBackgroundTexture, new Vector2(1000 + (40 * 0), 100 + (40 * 7)), uiResearchBackgroundTexture, new Vector2(1000 + (40 * 0), 100 + (40 * 7)), leftArrowIconTexture, new Vector2(1000 + (40 * 4), 100 + (40 * 10)), rightArrowIconTexture, new Vector2(1000 + (40 * 9), 100 + (40 * 10)));
            
        }

        public void updateResources()
        {
            this.agriculture += mainGameArea.getBuildingAgriculture() * (1 + farmers) ;
            this.industrial += mainGameArea.getBuildingIndustry();
            this.research += mainGameArea.getBuildingResearch();
        }

        public void updateBuildings()
        {
            if (agriculture >= 100)
            {
                agriculture = 0;
                mainGameArea.AddPeople();
            }
            
        }

        public string getBuildingDetails()
        {
            return mainGameArea.getBuildingDetails();
        }

        public string getBuildingPeople()
        {
            return Convert.ToString(mainGameArea.getBuildingPeople());
        }

        public void Draw(SpriteBatch spriteBatch, Color aColor)
        {
            spriteBatch.Draw(BackGroundTexture, BackGroundTexturePosition, aColor);
            mainGameArea.Draw(spriteBatch);
            //informationArea.Draw(spriteBatch);
            //draw the icons
            spriteBatch.Draw(informationArea.AgricultureIconTexture, informationArea.AgricultureIconPosition, Color.White);
            spriteBatch.Draw(informationArea.IndustrialIconTexture, informationArea.IndustrialIconPosition, Color.White);
            spriteBatch.Draw(informationArea.ResearchIconTexture, informationArea.ResearchIconPosition, Color.White);
            //draw the background for information area
            if (UIState[0] == 1)
            {
                spriteBatch.Draw(informationArea.AgricultureBackgroundTexture, informationArea.AgricultureBackgroundPosition, Color.White);
                spriteBatch.Draw(informationArea.LeftArrowIconTexture, informationArea.LeftArrowIconPosition, Color.White);
                spriteBatch.Draw(informationArea.RightArrowIconTexture, informationArea.RightArrowIconPosition, Color.White);
            }
            if (UIState[1] == 1)
            {
                spriteBatch.Draw(informationArea.IndustrialBackgroundTexture, informationArea.IndustrialBackgroundPosition, Color.White);
                spriteBatch.Draw(informationArea.LeftArrowIconTexture, informationArea.LeftArrowIconPosition, Color.White);
                spriteBatch.Draw(informationArea.RightArrowIconTexture, informationArea.RightArrowIconPosition, Color.White);
            }
            if (UIState[2] == 1)
            {
                spriteBatch.Draw(informationArea.ResearchBackgroundTexture, informationArea.ResearchBackgroundPosition, Color.White);
                spriteBatch.Draw(informationArea.LeftArrowIconTexture, informationArea.LeftArrowIconPosition, Color.White);
                spriteBatch.Draw(informationArea.RightArrowIconTexture, informationArea.RightArrowIconPosition, Color.White);
            }
        }

        public void DrawText(SpriteBatch fontBatch)
        {
            if (UIState[0] == 1)
            {

                AgricultureInformation.stringValue = Convert.ToString(mainGameArea.getBuildingPeople());
                AgricultureInformation.DrawFont(fontBatch);
                FarmerInformation.stringValue = Convert.ToString(farmers);
                FarmerInformation.DrawFont(fontBatch);
            }
        }

    }
}
