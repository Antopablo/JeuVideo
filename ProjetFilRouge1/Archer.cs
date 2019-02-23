using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFilRouge1
{
    class Archer : Personnage
    {

        public Archer(string nom) : base(nom)
        {
        this.ATK += 10;
        this.VIT += 10;
        this.HP -= 15;
        }
    }

}
