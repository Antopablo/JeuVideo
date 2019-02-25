using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetFilRouge1
{
    class Boss : Mob
    {
        Random rnd = new Random();
        public Boss(string nom) : base(nom)
        {
            this.ATK = rnd.Next(40, 50);
            this.DEF = rnd.Next(5, 15);
            this.VIT = rnd.Next(5, 10);
            this.HP = rnd.Next(70, 100);
        }
    }
}
