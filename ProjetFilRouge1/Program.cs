using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFilRouge1
{
    enum Stats
    {
        attaque,
        defense,
        vitesse,
        pv
    }

    class Program
    {
        static void Main(string[] args)
        {


            Random randomCalc = new Random();
            

            List<Personnage> ListeTeam = CreationTeam();
            Console.WriteLine("Commençons l'aventure ..");
            Console.WriteLine("Il faut d'abord équiper notre équipe");


            List<Mob> ListeDennemi = CreationEnnemi();
            int nbEnnemi = ListeDennemi.Count;
            int nbTeam = ListeTeam.Count;
            Random gen = new Random();
            bool continu = true;
            int randomEnnemi = randomCalc.Next(0, nbEnnemi);
            int randomTeam = randomCalc.Next(0, nbTeam);

            do
            {
                // team attaque
                while (continu == true && nbEnnemi > 0)
                {
                    randomEnnemi = randomCalc.Next(0, nbEnnemi);
                    randomTeam = randomCalc.Next(0, nbTeam);
                    Console.WriteLine("\r\n");
                    ListeTeam[randomTeam].Attaquer(ListeDennemi[randomEnnemi]);
                    Console.WriteLine("\r\n");
                    if (ListeDennemi[randomEnnemi].HP == 0)
                    {
                        ListeDennemi.Remove(ListeDennemi[randomEnnemi]);
                        nbEnnemi--;
                    }
                    continu = gen.Next(100) < 60 ? true : false;   //60% de chance de refaire une attaque
                    Console.WriteLine("il reste " + nbEnnemi + " ennemi");

                    if (nbEnnemi == 0)
                    {
                        Console.WriteLine("Bravo, vous avez gagné");
                        Environment.Exit(0);
                    }
                }

                // ennemi attaque
                while (continu == false && nbTeam > 0)
                {
                    randomEnnemi = randomCalc.Next(0, nbEnnemi);
                    randomTeam = randomCalc.Next(0, nbTeam);
                    Console.WriteLine("\r\n");
                    ListeDennemi[randomEnnemi].Attaquer(ListeTeam[randomTeam]);
                    Console.WriteLine("\r\n");
                    if (ListeTeam[randomTeam].HP == 0)
                    {
                        ListeTeam.Remove(ListeTeam[randomTeam]);
                        nbTeam--;
                    }
                    continu = gen.Next(100) < 30 ? true : false;   //70% de chance de refaire une attaque
                    Console.WriteLine("il reste " + nbTeam + " personnage dans la team");

                    if (nbTeam == 0)
                    {
                        Console.WriteLine("Nul, tu as perdu");
                        Environment.Exit(0);
                    }
                }
            } while (nbEnnemi > 0 || nbTeam > 0);


        }

        static List<Mob> CreationEnnemi()
        {
            Random rnd = new Random();
            List<Mob> ListMob = new List<Mob>();
            int crea = rnd.Next(2, 11);
            for (int i = 0; i < crea; i++)
            {
                ListMob.Add(new Mob("Aibat" + (i + 1)));
            }
            foreach (var x in ListMob)
            {
                Console.WriteLine("Un Aibat sauvage apparait !");
                Console.WriteLine(x);
            }
            Console.WriteLine("Il y a " + ListMob.Count + " ennemi");

            return ListMob;
        }



        static List<Personnage> CreationTeam()
        {
            Item epee = new Item(10, Stats.attaque, "épée de fer");
            Item slip = new Item(5, Stats.defense, "slip");
            Item baton = new Item(15, Stats.attaque, "bâton de feu");
            Item arc = new Item(10, Stats.attaque, "arc de bois");


            Random rnd = new Random();
            List<Personnage> ListTeam = new List<Personnage>();
            Console.WriteLine("Combien de personnage voulez-vous dans la team ?");
            int nbCrea = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Nous allons creer " + nbCrea + " personnages");

            for (int i = 0; i < nbCrea; i++)
            {
                string choixEquip;
                Console.WriteLine("Que voulez-vous créer ? Guerrier / Mage / Archer ");
                string choix = Console.ReadLine().ToUpper();
                switch (choix)
                {
                    case "GUERRIER":
                        Console.WriteLine("Bienvenue au nouveau guerrier !! Comment s'appelle t-il ?");
                        string nomG = Console.ReadLine();
                        Guerrier guerrier = new Guerrier(nomG);
                        ListTeam.Add(guerrier);
                        Console.WriteLine("voulez-vous lui donner un équipement? oui/non");
                        choix = Console.ReadLine().ToUpper();
                        if (choix == "OUI")
                        {
                            do
                            {
                                Console.WriteLine("que voulez-vous lui donner ? épée / baton / arc / slip / rien");
                                choixEquip = Console.ReadLine().ToUpper();
                                switch (choixEquip)
                                {
                                    case "EPEE":
                                        guerrier.AjouterEquipement(epee);
                                        break;
                                    case "BATON":
                                        guerrier.AjouterEquipement(baton);
                                        break;
                                    case "ARC":
                                        guerrier.AjouterEquipement(arc);
                                        break;
                                    case "SLIP":
                                        guerrier.AjouterEquipement(slip);
                                        break;
                                    case "RIEN":
                                        Console.WriteLine("l'ajout d'équipement de ce personnage est terminé");
                                        break;
                                }

                                Console.WriteLine("voulez-vous donner un autre équipement ? oui/non");
                                choix = Console.ReadLine().ToUpper();

                            } while (choix == "OUI");
                        }
                        Console.WriteLine(nomG + " a bien rejoint notre équipe \r\n");
                        Console.WriteLine(guerrier);
                        break;

                    case "MAGE":
                        Console.WriteLine("Un Mage vient d'apparaitre ! Quel est son nom ?");
                        string nomM = Console.ReadLine();
                        Mage mage = new Mage(nomM);
                        ListTeam.Add(mage);
                        Console.WriteLine("voulez-vous lui donner un équipement? oui/non");
                        choix = Console.ReadLine().ToUpper();
                        if (choix == "OUI")
                        {
                            do
                            {
                                Console.WriteLine("que voulez-vous lui donner ? épée / baton / arc / slip / rien");
                                choixEquip = Console.ReadLine().ToUpper();
                                switch (choixEquip)
                                {
                                    case "EPEE":
                                        mage.AjouterEquipement(epee);
                                        break;
                                    case "BATON":
                                        mage.AjouterEquipement(baton);
                                        break;
                                    case "ARC":
                                        mage.AjouterEquipement(arc);
                                        break;
                                    case "SLIP":
                                        mage.AjouterEquipement(slip);
                                        break;
                                    case "RIEN":
                                        Console.WriteLine("l'ajout d'équipement de ce personnage est terminé");
                                        break;
                                }

                                Console.WriteLine("voulez-vous donner un autre équipement ? oui/non");
                                choix = Console.ReadLine().ToUpper();

                            } while (choix == "OUI");
                        }
                        Console.WriteLine(nomM + " a bien rejoint notre équipe \r\n");
                        Console.WriteLine(mage);
                        break;
                    case "ARCHER":
                        Console.WriteLine("Un archer rejoint les rangs !! Comment va-t-on l'appeler ?");
                        string nomA = Console.ReadLine();
                        Archer archer = new Archer(nomA);
                        ListTeam.Add(archer);
                        Console.WriteLine("voulez-vous lui donner un équipement? oui/non");
                        choix = Console.ReadLine().ToUpper();
                        if (choix == "OUI")
                        {
                            do
                            {
                                Console.WriteLine("que voulez-vous lui donner ? épée / baton / arc / slip / rien");
                                choixEquip = Console.ReadLine().ToUpper();
                                switch (choixEquip)
                                {
                                    case "EPEE":
                                        archer.AjouterEquipement(epee);
                                        break;
                                    case "BATON":
                                        archer.AjouterEquipement(baton);
                                        break;
                                    case "ARC":
                                        archer.AjouterEquipement(arc);
                                        break;
                                    case "SLIP":
                                        archer.AjouterEquipement(slip);
                                        break;
                                    case "RIEN":
                                        Console.WriteLine("l'ajout d'équipement de ce personnage est terminé");
                                        break;
                                }

                                Console.WriteLine("voulez-vous donner un autre équipement ? oui/non");
                                choix = Console.ReadLine().ToUpper();

                            } while (choix == "OUI");
                        }
                        Console.WriteLine(nomA + " a bien rejoint notre équipe \r\n");
                        Console.WriteLine(archer);
                        break;
                }
            }
            return ListTeam;
        }

    }
}