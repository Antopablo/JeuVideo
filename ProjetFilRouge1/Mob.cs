using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetFilRouge1
{
    class Mob : Personnage
    {
        Random rnd = new Random();
        public Mob(string nom) : base(nom)
        {
            this.ATK = rnd.Next(10, 20);
            this.DEF = rnd.Next(5, 10);
            this.VIT = rnd.Next(5, 10);
            this.HP = rnd.Next(40, 70);
        }
    }
}
