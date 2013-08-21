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
                Rectangle agricultureIconRectangle = new Rectangle((int)informationArea.AgricultureIconPosition.X, (int)informationArea.AgricultureIconPosition.Y, 40, 40);
                //check if the current mouse is clicking on the icon
                if (mouseRectangle.Intersects(agricultureIconRectangle))
                {
                    UIState[0] = 1;
                    UIState[1] = 0;
                    UIState[2] = 0;
                    UIState[3] = 0;
                }

                Rectangle industryIconRectangle = new Rectangle((int)informationArea.IndustrialIconPosition.X, (int)informationArea.IndustrialIconPosition.Y, 40, 40);
                if (mouseRectangle.Intersects(industryIconRectangle))
                {
                    UIState[0] = 0;
                    UIState[1] = 1;
                    UIState[2] = 0;
                    UIState[3] = 0;
                }

                Rectangle researchIconRectangle = new Rectangle((int)informationArea.ResearchIconPosition.X, (int)informationArea.ResearchIconPosition.Y, 40, 40);
                if (mouseRectangle.Intersects(researchIconRectangle))
                {
                    UIState[0] = 0;
                    UIState[1] = 0;
                    UIState[2] = 1;
                    UIState[3] = 0;
                }

                Rectangle leftArrowIconRectangle = new Rectangle((int)informationArea.LeftArrowIconPosition.X, (int)informationArea.LeftArrowIconPosition.Y, 40, 40);
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

                Rectangle rightArrowIconRectangle = new Rectangle((int)informationArea.RightArrowIconPosition.X, (int)informationArea.RightArrowIconPosition.Y, 40, 40);
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
            mainGameArea = new MainView(startingPosition, blocksAcross, blocksDown);
            mainGameArea.AddBuilding();
        }

        public void LoadInformationArea()
        {
            int blocksAcross = 15;
            int blocksDown = 20;
            Vector2 startingPosition = new Vector2(1000, 100);
            informationArea = new MainView(startingPosition, blocksAcross, blocksDown);
            informationArea.placeIcons(new Vector2(1000 + (40 * 0), 100 + (40 * 6)), new Vector2(1000 + (40 * 1), 100 + (40 * 6)), new Vector2(1000 + (40 * 2), 100 + (40 * 6)));
            informationArea.PlaceUIBackground(new Vector2(1000 + (40 * 0), 100 + (40 * 7)), new Vector2(1000 + (40 * 0), 100 + (40 * 7)), new Vector2(1000 + (40 * 0), 100 + (40 * 7)), new Vector2(1000 + (40 * 4), 100 + (40 * 10)), new Vector2(1000 + (40 * 9), 100 + (40 * 10)));
            
        }

        public Vector2 getAgricultureIconPosition()
        {
            return informationArea.AgricultureIconPosition;
        }

        public Vector2 getIndustrialIconPosition()
        {
            return informationArea.IndustrialIconPosition;
        }

        public Vector2 getResearchIconPosition()
        {
            return informationArea.ResearchIconPosition;
        }

        public int getUIState(int i)
        {
            return UIState[i];
        }

        public Vector2 getAgricultureBackgroundPosition()
        {
            return informationArea.AgricultureBackgroundPosition;
        }

        public Vector2 getIndustrialBackgroundPosition()
        {
            return informationArea.IndustrialBackgroundPosition;
        }

        public Vector2 getResearchBackgroundPosition()
        {
            return informationArea.ResearchBackgroundPosition;
        }

        public Vector2 getLeftArrowIconPosition()
        {
            return informationArea.LeftArrowIconPosition;
        }

        public Vector2 getRightArrowIconPosition()
        {
            return informationArea.RightArrowIconPosition;
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

        public int getBound0()
        {
            return mainGameArea.Bound0;
        }

        public int getBound1()
        {
            return mainGameArea.Bound1;
        }

        public Vector2 getTilePosition(int i, int j)
        {
            return mainGameArea.getTileTexturePosition(i,j);
        }

        public int getBuildingCount()
        {
            return mainGameArea.getBuildingCount();
        }

        public Vector2 getBuildingPosition(int k)
        {
            return mainGameArea.getBuildingPosition(k);
        }
    }
}
