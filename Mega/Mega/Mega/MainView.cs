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

        int bound0;
        public int Bound0
        {
            get { return bound0; }
            set { bound0 = value; }
        }
        int bound1;
        public int Bound1
        {
            get { return bound1; }
            set { bound1 = value; }
        }

        //values of the size of the textures used for making tiles
        int blockWidth = 40;
        int blockHeight = 40;

        public List<Building> buildings;

        Vector2 startingPosition;

        Vector2 agricultureIconPosition;
        public Vector2 AgricultureIconPosition
        {
            get { return agricultureIconPosition; }
            set { agricultureIconPosition = value; }
        }

        Vector2 industrialIconPosition;
        public Vector2 IndustrialIconPosition
        {
            get { return industrialIconPosition; }
            set { industrialIconPosition = value; }
        }

        Vector2 researchIconPosition;
        public Vector2 ResearchIconPosition
        {
            get { return researchIconPosition; }
            set { researchIconPosition = value; }
        }

        //UI background texture and position
        Vector2 agricultureBackgroundPosition;
        public Vector2 AgricultureBackgroundPosition
        {
            get { return agricultureBackgroundPosition; }
            set { agricultureBackgroundPosition = value; }
        }

        Vector2 industrialBackgroundPosition;
        public Vector2 IndustrialBackgroundPosition
        {
            get { return industrialBackgroundPosition; }
            set { industrialBackgroundPosition = value; }
        }

        Vector2 researchBackgroundPosition;
        public Vector2 ResearchBackgroundPosition
        {
            get { return researchBackgroundPosition; }
            set { researchBackgroundPosition = value; }
        }

        //UI Icons
        Vector2 leftArrowIconPosition;
        public Vector2 LeftArrowIconPosition
        {
            get { return leftArrowIconPosition; }
            set { leftArrowIconPosition = value; }
        }

        Vector2 rightArrowIconPosition;
        public Vector2 RightArrowIconPosition
        {
            get { return rightArrowIconPosition; }
            set { rightArrowIconPosition = value; }
        }

        public MainView(Vector2 startingPosition, int blocksAcross, int blocksDown)
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
                    theMainView[i, j] = new Block(position);
                                    
                }
            }

            buildings = new List<Building>();

        }

        public void PlaceUIBackground(Vector2 agricultureBackgroundPosition, Vector2 industrialBackgroundPosition, Vector2 researchBackgroundPosition, Vector2 leftArrowIconPosition, Vector2 rightArrowIconPosition)
        {
            
            this.agricultureBackgroundPosition = agricultureBackgroundPosition;

            
            this.leftArrowIconPosition = leftArrowIconPosition;

            
            this.rightArrowIconPosition = rightArrowIconPosition;


            
            this.industrialBackgroundPosition = industrialBackgroundPosition;

            
            this.researchBackgroundPosition = researchBackgroundPosition;
        }

        public void placeIcons(Vector2 agricultureIconPosition, Vector2 industrialIconPosition, Vector2 researchIconPosition)
        {
            
            this.agricultureIconPosition = agricultureIconPosition;

            
            this.industrialIconPosition = industrialIconPosition;

            
            this.researchIconPosition = researchIconPosition;
        }

        public void AddBuilding()
        {
            //add a building
            int numberOfPeople = 2;
            Building aBuilding = new Building(new Vector2(startingPosition.X + (40 * 5), startingPosition.Y + (40 * 4)), 0.10f, 0.10f, 0.10f, numberOfPeople);
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

        public Vector2 getTileTexturePosition(int i, int j)
        {
            return theMainView[i, j].TileTexturePosition;
        }

        public int getBuildingCount()
        {
            return buildings.Count;
        }

        public Vector2 getBuildingPosition(int k)
        {
            return buildings[k].BuildingTexturePosition;
        }

    }
}
