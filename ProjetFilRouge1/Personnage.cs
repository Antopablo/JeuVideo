using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetFilRouge1
{
    class Personnage
    {
        public string Nom;
        private int _atk;
        Personnage ennemi;
        int degats;

        public int ATK
        {
            get { return _atk + GetBonus(Stats.attaque); }
            set { _atk = value; }
        }

        private int _def;

        public int DEF
        {
            get { return _def + GetBonus(Stats.defense); }
            set { _def = value; }
        }

        private int _vit;

        public int VIT
        {
            get { return _vit + GetBonus(Stats.vitesse); }
            set { _vit = value; }
        }

        private int _hp;

        public int HP
        {
            get { return _hp + GetBonus(Stats.pv); }
            set
            {
                try
                {
                    if (value > 0)
                    {
                        _hp = value;
                    }
                    else if (value <= 0)
                    {
                        _hp = 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Points de vie < 0");
                }

            }
        }
        private List<Item> _equipement;

        public Personnage(string nom)
        {
            Nom = nom;
            ATK = 10;
            DEF = 10;
            VIT = 10;
            HP = 50;

            _equipement = new List<Item>();
        }

        public void AjouterEquipement(Item item)
        {
            _equipement.Add(item);
        }

        public void SupprimerEquipement(Item item)
        {
            _equipement.Remove(item);
        }

        private int GetBonus(Stats nomCarac)
        {
            int bonus = 0;
            foreach (Item item in _equipement)
            {
                if (item.NomCarac == nomCarac)
                {
                    bonus += item.Bonus;
                }
            }

            return bonus;
        }

        public override string ToString()
        {
            string txt = Nom + " atk: " + ATK + " def: " + DEF + " vit: " + VIT + " hp: " + HP + "\r\n";
            foreach (Item item in _equipement)
            {
                txt += item + "\r\n";
            }
            return txt;
        }

        public void Attaquer(Personnage ennemi) // ennemi en paramètre
        {
            this.ennemi = ennemi;
            this.degats = (ATK - ennemi.DEF);
            if (degats < 0)
            {
                this.degats = 1;
                this.ennemi.HP -= degats;
            }
            else
            {
                this.ennemi.HP -= degats;
            }
            Console.WriteLine(Nom + " a attaqué " + ennemi.Nom + " et lui a enlevé " + degats + " points de vie");
            Console.WriteLine("Il reste " + ennemi.HP + " PV a " + ennemi.Nom);

            if (ennemi.HP == 0)
            {
                Console.WriteLine(ennemi.Nom + " est mort");
                ennemi = null;
            }

        }
    }
}
