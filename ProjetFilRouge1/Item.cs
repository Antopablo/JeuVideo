using System;

namespace ProjetFilRouge1
{
    class Item
    {
        private int _bonus;
        protected string _nomItem;

        public int Bonus
        {
            get { return _bonus; }
            private set { _bonus = value; }
        }

        private Stats _nomCarac;

        public Stats NomCarac
        {
            get { return _nomCarac; }
            private set { _nomCarac = value; }
        }

        public Item(int bonus, Stats nomCarac, string nomItem)
        {
            Bonus = bonus;
            NomCarac = nomCarac;
            this._nomItem = nomItem;
        }

        public override string ToString()
        {
            return "L'objet " + _nomItem + " ajoute " + _bonus + " à la caracteristique " + _nomCarac;
        }
    }
}
