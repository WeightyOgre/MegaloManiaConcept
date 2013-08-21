using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Mega
{
    class GameArt
    {
        //background image
        Texture2D backGroundTexture;
        public Texture2D BackGroundTexture
        {
            get { return backGroundTexture; }
            set { backGroundTexture = value; }
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

        ContentManager content;

        public GameArt(ContentManager content)
        {
            this.content = content;
            //load the games background image
            BackGroundTexture = content.Load<Texture2D>("background1920x1080");
            
            //load the tile image for mapping out main game area
            TileTexture = content.Load<Texture2D>("brick40x40");
            BuildingTexture = content.Load<Texture2D>("BPH");

            UIAgricultureTexture = content.Load<Texture2D>("AgricultureIcon80x80");
            UIIndustrialTexture = content.Load<Texture2D>("IndustrialIcon80x80");
            UIResearchTexture = content.Load<Texture2D>("ResearchIcon80x80");

            UIAgricultureBackgroundTexture = content.Load<Texture2D>("InformationAgriculturalBackground600x320");
            UIIndustrialBackgroundTexture = content.Load<Texture2D>("InformationIndustryBackground600x320");
            UIResearchBackgroundTexture = content.Load<Texture2D>("InformationResearchBackground600x320");

            //load the textures for the UI Icons
            LeftArrowIconTexture = content.Load<Texture2D>("LeftArrow40x40");
            RightArrowIconTexture = content.Load<Texture2D>("RightArrow40x40");
        }
    }
}
