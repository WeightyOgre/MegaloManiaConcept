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

        public List<Building> buildings;

        Vector2 startingPosition;



        Texture2D agricultureIconTexture;
        public Texture2D AgricultureIconTexture
        {
            get { return agricultureIconTexture; }
            set { agricultureIconTexture = value; }
        }

        Vector2 agricultureIconPosition;
        public Vector2 AgricultureIconPosition
        {
            get { return agricultureIconPosition; }
            set { agricultureIconPosition = value; }
        }
        
        Texture2D industrialIconTexture;
        public Texture2D IndustrialIconTexture
        {
            get { return industrialIconTexture; }
            set { industrialIconTexture = value; }
        }

        Vector2 industrialIconPosition;
        public Vector2 IndustrialIconPosition
        {
            get { return industrialIconPosition; }
            set { industrialIconPosition = value; }
        }
        
        
        Texture2D researchIconTexture;
        public Texture2D ResearchIconTexture
        {
            get { return researchIconTexture; }
            set { researchIconTexture = value; }
        }

        Vector2 researchIconPosition;
        public Vector2 ResearchIconPosition
        {
            get { return researchIconPosition; }
            set { researchIconPosition = value; }
        }

        //UI background texture and position
        Texture2D agricultureBackgroundTexture;
        public Texture2D AgricultureBackgroundTexture
        {
            get { return agricultureBackgroundTexture; }
            set { agricultureBackgroundTexture = value; }
        }

        Vector2 agricultureBackgroundPosition;
        public Vector2 AgricultureBackgroundPosition
        {
            get { return agricultureBackgroundPosition; }
            set { agricultureBackgroundPosition = value; }
        }

        Texture2D industrialBackgroundTexture;
        public Texture2D IndustrialBackgroundTexture
        {
            get { return industrialBackgroundTexture; }
            set { industrialBackgroundTexture = value; }
        }

        Vector2 industrialBackgroundPosition;
        public Vector2 IndustrialBackgroundPosition
        {
            get { return industrialBackgroundPosition; }
            set { industrialBackgroundPosition = value; }
        }

        Texture2D researchBackgroundTexture;
        public Texture2D ResearchBackgroundTexture
        {
            get { return researchBackgroundTexture; }
            set { researchBackgroundTexture = value; }
        }

        Vector2 researchBackgroundPosition;
        public Vector2 ResearchBackgroundPosition
        {
            get { return researchBackgroundPosition; }
            set { researchBackgroundPosition = value; }
        }

        //UI Icons
        Texture2D leftArrowIconTexture;
        public Texture2D LeftArrowIconTexture
        {
            get { return leftArrowIconTexture; }
            set { leftArrowIconTexture = value; }
        }

        Vector2 leftArrowIconPosition;
        public Vector2 LeftArrowIconPosition
        {
            get { return leftArrowIconPosition; }
            set { leftArrowIconPosition = value; }
        }

        Texture2D rightArrowIconTexture;
        public Texture2D RightArrowIconTexture
        {
            get { return rightArrowIconTexture; }
            set { rightArrowIconTexture = value; }
        }

        Vector2 rightArrowIconPosition;
        public Vector2 RightArrowIconPosition
        {
            get { return rightArrowIconPosition; }
            set { rightArrowIconPosition = value; }
        }

        public MainView(Texture2D tileTexture, Vector2 startingPosition, int blocksAcross, int blocksDown)
        {

            this.blocksAcross = blocksAcross;
            this.blocksDown = blocksDown;

            theMainView = new Block[blocksAcross, blocksDown];

            bound0 = theMainView.GetUpperBound(0);
            bound1 = theMainView.GetUpperBound(1);

            this.startingPosition = startingPosition;

            for (int i = 0; i <= bound0; i++)
            {
                for (int j = 0; j <= bound1; j++)
                {
                    
                    Vector2 position = new Vector2(startingPosition.X + i * blockWidth, startingPosition.Y + j * blockHeight);
                    theMainView[i, j] = new Block(tileTexture,position);
                                    
                }
            }

            buildings = new List<Building>();

        }

        public void PlaceUIBackground(Texture2D agricultureBackgroundTexture, Vector2 agricultureBackgroundPosition, Texture2D industrialBackgroundTexture, Vector2 industrialBackgroundPosition, Texture2D researchBackgroundTexture, Vector2 researchBackgroundPosition, Texture2D LeftArrowIconTexture, Vector2 leftArrowIconPosition, Texture2D rightArrowIconTexture, Vector2 rightArrowIconPosition)
        {
            this.agricultureBackgroundTexture = agricultureBackgroundTexture;
            this.agricultureBackgroundPosition = agricultureBackgroundPosition;

            this.LeftArrowIconTexture = LeftArrowIconTexture;
            this.leftArrowIconPosition = leftArrowIconPosition;

            this.rightArrowIconTexture = rightArrowIconTexture;
            this.rightArrowIconPosition = rightArrowIconPosition;


            this.industrialBackgroundTexture = industrialBackgroundTexture;
            this.industrialBackgroundPosition = industrialBackgroundPosition;

            this.researchBackgroundTexture = researchBackgroundTexture;
            this.researchBackgroundPosition = researchBackgroundPosition;
        }

        public void placeIcons(Texture2D agricultureIconTexture, Vector2 agricultureIconPosition, Texture2D industrialIconTexture, Vector2 industrialIconPosition, Texture2D researchIconTexture, Vector2 researchIconPosition)
        {
            this.agricultureIconTexture = agricultureIconTexture;
            this.agricultureIconPosition = agricultureIconPosition;

            this.industrialIconTexture = industrialIconTexture;
            this.industrialIconPosition = industrialIconPosition;

            this.researchIconTexture = researchIconTexture;
            this.researchIconPosition = researchIconPosition;
        }

        public void AddBuilding(Texture2D buildingTexture)
        {
            //add a building
            int numberOfPeople = 2;
            Building aBuilding = new Building(buildingTexture, new Vector2(startingPosition.X + (40 * 5), startingPosition.Y + (40 * 4)), 0.10f, 0.10f, 0.10f, numberOfPeople);
            buildings.Add(aBuilding);
        }

        public string getBuildingDetails()
        {

            string buildingDetails = Convert.ToString("A " + buildings[0].Agriculture + "\r\n" + "I " + buildings[0].Industrial + "\r\n" + "R " + buildings[0].Research);

            return buildingDetails;
        }

        public float getBuildingAgriculture()
        {
            return buildings[0].Agriculture;
        }

        public float getBuildingIndustry()
        {
            return buildings[0].Industrial;
        }

        public float getBuildingResearch()
        {
            return buildings[0].Research;
        }

        public int getBuildingPeople()
        {
            return buildings[0].People;
        }

        public void AddPeople()
        {

                buildings[0].People += 1;
        }

        public void RemovePeople()
        {
            buildings[0].People -= 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i <= bound0; i++)
            {
                for (int j = 0; j <= bound1; j++)
                {
                    spriteBatch.Draw(theMainView[i, j].TileTexture, theMainView[i, j].TileTexturePosition, Color.White);
                    for (int k = buildings.Count - 1; k >= 0; k--)
                    {
                        spriteBatch.Draw(buildings[k].BuildingTexture, buildings[k].BuildingTexturePosition, Color.White);
                    }
                }
            }           
        }

    }
}
