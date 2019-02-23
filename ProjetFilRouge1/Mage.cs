using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetFilRouge1
{
    class Mage : Personnage
    {
        private Stats BonusClasseVit;

        public Stats GetSetBonusClasseVit
        {
            get { return BonusClasseVit; }
            set { BonusClasseVit = value; }
        }

        public Mage(string nom) : base(nom)
        {
            this.ATK += 15;
            this.DEF -= 5;
            this.HP -= 10;

        }
    }
}
