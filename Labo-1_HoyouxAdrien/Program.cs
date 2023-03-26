using ClassLibrary;
using MathUtil;

namespace MyNamespace
{
    class Programme
    {
        static void Main(string[] args)
        
		{
           // Création et affichage de 2 objets de chaque sorte

            // Coordonnées

            Coordonnee p= new Coordonnee(3,2);

            // Carre
            Carre car1= new Carre();
            Carre car2= new Carre(5,0,4);

            car1.Affiche();
            car2.Affiche();
            Console.WriteLine(" 4) Le point est dedans ? :" + car2.CoordonneeEstDans(p));
            Console.WriteLine(" 5) Nbr sommet : " + car2.nbSommet);

            // Cercle 

            Cercle c1 = new Cercle();
            Cercle c2 = new Cercle(5, 0, 4);

            c1.Affiche();
            c2.Affiche();
            Console.WriteLine(" 4) Le point est dedans ? :" + car2.CoordonneeEstDans(p));

            // Rectangle 

            Rectangle r1 = new Rectangle();
            Rectangle r2 = new Rectangle(5,3,0,0);

            r1.Affiche();
            r2.Affiche();

            Console.WriteLine(" 4) Le point est dedans ? :" + r2.CoordonneeEstDans(p));
            Console.WriteLine(" 5) Nbr sommet : " + r2.nbSommet);
            
            // Création de la liste des formes

            List<Forme> list = new List<Forme>();
            list.Add(car1);
            list.Add(car2);
            list.Add(c1);
            list.Add(c2);
            list.Add(r1);
            list.Add(r2);

            Console.WriteLine("Voici ma liste de forme : \n");
            int i = 0;
            foreach(Forme forme in list)
            {    
                Type typedeforme = forme.GetType();
                Console.WriteLine( "index["+ i +"] : " + typedeforme.Name);
                i++;
            }

            // Affichage de la liste des obets implémantant l'interface ISommets
            Console.WriteLine("\nVoici ma liste de forme implémentant Isommet : \n");
            i = 0;
            foreach (Forme forme in list)
            {
                Type typedeforme = forme.GetType();
                
                if (forme is ISommets)
                {
                    Console.WriteLine("index[" + i + "] : " + typedeforme.Name);
                }
                i++;
            }

            // Affichage de la liste des obets n'implémantant pas l'interface ISommets
            Console.WriteLine("\nVoici ma liste de forme n'implémentant pas Isommet : \n");
            i = 0;
            foreach (Forme forme in list)
            {
                Type typedeforme = forme.GetType();

                if (forme is not ISommets)
                {
                    Console.WriteLine("index[" + i + "] : " + typedeforme.Name);
                }
                i++;
            }

            Console.WriteLine("\nVoici une lise de carré :\n");
            List<Carre> listCarre = new List<Carre>()
            { new Carre(5,1,0),
              new Carre(2,8,0),
              new Carre(3,7,0),
              new Carre(4,9,0),
              new Carre(6,3,0)
            };

            i = 0;
            foreach (Carre car in listCarre)
            {
                Type typedeforme = car.GetType();
                Console.WriteLine("index[" + i + "] : " + typedeforme.Name + " ==> Longueur :" + car.longueur);
                i++;
            }

            // Voici ma liste carré trié par taille de coté
            Console.WriteLine("\nVoici la même liste de carré triée :\n");
            listCarre.Sort();
            i = 0;  
            foreach (Carre car in listCarre)
            {
                Type typedeforme = car.GetType();
                Console.WriteLine("index[" + i + "] : " + typedeforme.Name + " ==> Longueur :" + car.longueur);
                i++;
            }

            // Voici ma liste carré trié par ordre croissant d'abscisse
            Console.WriteLine("\nVoici la même liste de carré triée mais sur l'axe des abscisse :\n");
            i = 0;
            FormeAbssiceComparer abssiceComparer= new FormeAbssiceComparer();
            listCarre.Sort(abssiceComparer);

            foreach (Carre car in listCarre)
            {
                Type typedeforme = car.GetType();
                Console.WriteLine("index[" + i + "] : " + typedeforme.Name + " ==> Longueur :" + car.longueur + " ==> axe x = " + car.coord.x);
                i++;
            }

            // Comparaison d'un carré de référence avec les carré de  la liste 

            Console.WriteLine("\nComparaison dans la liste avec un carré de référence : \n");
            Carre carRef= new Carre(5,0,0);
            Console.WriteLine("\nExists : carré avec longuer [5] : ");
            listCarre.Find(i => i.longueur == carRef.longueur).Affiche(); 
            
            listCarre.Add(new Carre(5,2,3));

            Console.WriteLine("\nListe de tous les carré ayant la longueur du carré de référence : \n");
            List<Carre> carreRef = listCarre.FindAll(i => i.longueur == carRef.longueur);
            foreach (Carre ca in carreRef)
                ca.Affiche();

            FormeSurfaceComparer surComp = new FormeSurfaceComparer();
            list.Sort(surComp);
            Console.WriteLine("Toutes les formes triées par la surface : ");
            foreach (Forme f in list)
                f.Affiche();


        }
    }
}
