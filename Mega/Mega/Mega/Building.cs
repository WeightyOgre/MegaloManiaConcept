using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mega
{
    class Building
    {
        //a building will generate
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

        //a Building texture and position
        Vector2 buildingTexturePosition;
        public Vector2 BuildingTexturePosition
        {
            get { return buildingTexturePosition; }
            set { buildingTexturePosition = value; }
        }

        //buildings can generate/and/or contain civilians/non-combat/non-working etc etc 
        int people;
        public int People
        {
            get { return people; }
            set { people = value; }
        }

        public Building(Vector2 buildingTexturePosition, float agriculture, float industrial, float research, int people)
        {
            
            this.buildingTexturePosition = buildingTexturePosition;
            this.agriculture = agriculture;
            this.industrial = industrial;
            this.research = research;
            this.people = people;
        }

    }
}
