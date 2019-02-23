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
            Item epee = new Item(10, Stats.attaque, "épée de fer");
            Item slip = new Item(5, Stats.defense, "slip");
            Item baton = new Item(15, Stats.attaque, "bâton de feu");
            Item arc = new Item(10, Stats.attaque, "arc de bois");

            List<Personnage> ListeTeam = CreationTeam();
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
            Random rnd = new Random();
            List<Personnage> ListTeam = new List<Personnage>();
            Console.WriteLine("Combien de personnage voulez-vous dans la team ?");
            int nbCrea = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Nous allons creer " + nbCrea + " personnages");

            for (int i = 0; i < nbCrea; i++)
            {

                Console.WriteLine("Que voulez-vous créer ? Guerrier / Mage / Archer ");
                string choix = Console.ReadLine().ToUpper();
                switch (choix)
                {
                    case "GUERRIER":
                        Console.WriteLine("Un guerrier est créé, comment l'appeler ?");
                        string nomG = Console.ReadLine();
                        Guerrier guerrier = new Guerrier(nomG);
                        ListTeam.Add(guerrier);
                        Console.WriteLine(nomG + " a été créé \r\n");
                        break;

                    case "MAGE":
                        Console.WriteLine("Un mage est créé, comment l'appeler ?");
                        string nomM = Console.ReadLine();
                        ListTeam.Add(new Mage(nomM));
                        Console.WriteLine(nomM + " a été créé \r\n");
                        break;
                    case "ARCHER":
                        Console.WriteLine("Un archer est créé, comment l'appeler?");
                        string nomA = Console.ReadLine();
                        ListTeam.Add(new Archer(nomA));
                        Console.WriteLine(nomA + " a été créé \r\n");
                        break;
                }


            }

            return ListTeam;
        }

    }
}