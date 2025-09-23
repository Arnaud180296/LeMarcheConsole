internal class Program
{
    public static string[] AddFruit(string[] fruitBasket, string fruit, int BASKETFRUITLIMIT)
    {
        ///<summary>
        /// Ajoute un element de type string à un tableau de type string.
        ///</summary>
        ///<param name="fruitBasket"> Tableau à une dimension de chaine de caracteres permettant le stockage de fruits</param>
        ///<param name="fruit"> Chaine de caractères représentant un fruit à ajouter au panier</param>
        ///<param name="BASKETFRUITLIMIT"> Constante de type entier definissant la taille maximale du panier</param>
        ///<returns>Renvoie un tableau de string, servant à représenter le panier à fruit, après ajout d'un nouvel élément</returns>

        if(IsFruitBasketFull(fruitBasket, fruit, BASKETFRUITLIMIT))
            return fruitBasket;

        //===============CopyOldTabValuesToNewTab=========================
        //Ceci doit etre factorisé dans la methode CopyOldTabValuesToNewTab(fruitBasket);
        string[] newFruitBasket = new string[fruitBasket.Length + 1];
        //Console.WriteLine(newFruitBasket.Length);
        if (fruitBasket.Length > 0)
        {
            for (int i = 0; i < fruitBasket.Length; i++)
            {
                //Console.WriteLine("TEST : Je n'entre pas dans la boucle la premiere fois...");
                newFruitBasket[i] = fruitBasket[i];
            }
        }
        newFruitBasket[fruitBasket.Length] = fruit;
        Console.Beep(2100, 200);
        Console.Beep(2100, 200);
        //=====================
        Console.ResetColor();
        Console.Clear();
        return newFruitBasket;
    }

    public static bool IsFruitBasketFull(string[] fruitBasket, string fruit, int BASKETFRUITLIMIT)
    {
        if (fruitBasket.Length > BASKETFRUITLIMIT - 1)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Le panier est plein, \"{fruit}\" n'a donc pas été ajouté au panier");
            Console.BackgroundColor = ConsoleColor.Black;
            return true;
        }
        return false;
    }

    public static string[] CopyOldTabValuesToNewTab(string[] fruitBasket)
    {
        string[] newFruitBasket = new string[fruitBasket.Length + 1];   
        return newFruitBasket;
    }
    public static void DisplayFruitBasket(string[] fruitBasket)
    {
        Console.WriteLine("Voici le contenu du panier : ");
        Foo(fruitBasket);
        
        Console.ResetColor();

        GoBackMainMenu();

        Console.Clear();
        return;
    }
    
    public static void Foo(string[] elements) //TODO : Trouver un nom de methode plus adequat
    {
        int i = 0;
        foreach (string element in elements)
        {
            if (i % 2 == 0)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine($"\t> {element}");
            i++;
        }
        
        return;
    }
    public static void DisplayMenu(string[] menuOptions)
    {   
        Console.WriteLine("[_Options disponible_]");
        Foo(menuOptions);
        Console.ResetColor();
        return;
    }

    public static void FindFruitBasket(string[] fruitBasket, params string[] fruitsToFind)
    {
        //TODO faire une surcharge de methode pour que si plus de 1 fruit est recherché
        //la surcharge est appelée. Pour gerer les parametres multiple UTILISER ...nomParam
        foreach (var fruit in fruitsToFind)
        {
            
        }
    }
    public static void FindFruitBasket(string[] fruitBasket, string fruitToFind = "fruitTest")
    {
        foreach (string fruit in fruitBasket)
        {
            if (fruit == fruitToFind)
            {
                Console.WriteLine($"Le fruit : \"{fruitToFind}\" est bel et bien dans la panier");
                GoBackMainMenu();
                return;
            }
        }
        Console.WriteLine($"\"{fruitToFind}\" n'existe pas dans le panier");

        GoBackMainMenu();

        return;
    }

    public static void GoBackMainMenu()
    {
        Console.WriteLine("");
        do
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Appuyer sur la touche \"{ConsoleKey.Enter}\" du clavier pour retourner au menu...");
        } while ((Console.ReadKey().Key != ConsoleKey.Enter));

        Console.Clear();
        
        return;
    }

    public static string InputFruit()
    {
        Console.Write("Saisir le nom du fruit en question : ");
        string? input = (Console.ReadLine() ?? "").ToLower();

        if (input != null && input != "")
            return input;

        return InputFruit();
    }

    public static bool IsDuplicate(string[] fruitBasket, string fruitToCheck)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        foreach (string fruit in fruitBasket)
        {
            if (fruitToCheck == fruit)
            {
                Console.WriteLine($"Seule une occurence de \"{fruit}\" peut etre acheté à la fois,\npar conséquent \"{fruit}\" ne sera pas ajouté au panier");
                GoBackMainMenu();
                return true;
            }
        }
        return false;
    }

    public static bool IsFruitBasketEmpty(string[] fruitBasket)
    {
        if (fruitBasket.Length < 1)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Le panier est vide...");
            Console.BackgroundColor = ConsoleColor.Black;
            return true;
        }
        return false;
    }

    public static string[] RemoveFruit(string[] fruitBasket, string fruitToRemove)
    {
        foreach (string fruit in fruitBasket)
        {
            if (fruit == fruitToRemove)
            {
                //etape de suppression
                Console.WriteLine($"Le fruit \"{fruitToRemove}\" a été retiré du panier");
                return fruitBasket;
            }
        }
        Console.WriteLine($"\"{fruitToRemove}\" ne se trouve pas dans le panier");
        GoBackMainMenu();

        return fruitBasket;
    }

    public static void Main(string[] args)
    {
        string apple = "\U0001F34F";
        string banana = "\U0001F34C";
        Console.Title = $" {apple} Jeu du marché {banana}";

        bool loop = true;
        string[] menuOptions = ["[A]fficher", "[Aj]outer", "[R]echercher", "[S]upprimer", "[Q]uitter"];
        const int BASKETFRUITLIMIT = 5;
        string[] fruitBasket = new string[0];
        string? choice;
        string fruit;

        /*
         * *
         * Voir pour regrouper certains changement de couleur en fonction de l'etat des methode de controle
         */

        while (loop)
        {
            Console.ResetColor();
            
            DisplayMenu(menuOptions);

            Console.Write("Saisir l'option souhaitée : ");
            choice = (Console.ReadLine() ?? "").ToLower();
            if (choice == null || choice == "")
                continue;

            switch (choice)
            {
                case "afficher" or "a":
                    Console.Clear();
                    if (IsFruitBasketEmpty(fruitBasket))
                        continue;
                    DisplayFruitBasket(fruitBasket);
                    break;

                case "ajouter" or "aj":
                    //Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    fruit = InputFruit();
                    if(IsDuplicate(fruitBasket, fruit))
                        continue;
                    fruitBasket = AddFruit(fruitBasket, fruit, BASKETFRUITLIMIT);
                    break;

                case "rechercher" or "r":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (IsFruitBasketEmpty(fruitBasket))
                        continue;
                    fruit = InputFruit();
                    FindFruitBasket(fruitBasket, fruit);
                    break;

                case "supprimer" or "s":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (IsFruitBasketEmpty(fruitBasket))
                        continue;
                    fruit = InputFruit();
                    fruitBasket = RemoveFruit(fruitBasket, fruit);
                    break;

                case "quitter" or "q":
                    loop = false;
                    break;

                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"La commande : \"{choice}\" n'est pas implémenté...");
                    break;
            }
        }
        Console.WriteLine("Fin du programme...");
        return;
    }
}