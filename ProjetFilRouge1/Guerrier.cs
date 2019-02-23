using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetFilRouge1
{
    class Guerrier : Personnage
    {
        public Guerrier(string nom) : base(nom)
        {
            this.DEF += 10;
            this.VIT -= 5;
            this.HP += 20;
        }
    }
}
