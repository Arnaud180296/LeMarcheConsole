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

        if (fruitBasket.Length > BASKETFRUITLIMIT - 1)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Le panier est plein, \"{fruit}\" n'a donc pas été ajouté au panier");
            Console.BackgroundColor = ConsoleColor.Black;
            return fruitBasket;
        }

        if (IsDuplicate(fruitBasket, fruit))
        {
            Console.WriteLine($"Seule une occurence de \"{fruit}\" peut etre acheté à la fois, par conséquent \"{fruit}\" ne sera pas ajouté au panier");
            return fruitBasket;
        }

        //===============CopyOldTabValuesToNewTab=========================
        //Ceci doit etre factoriser dans la methode CopyOldTabValuesToNewTab(fruitBasket);
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

    public static string[] CopyOldTabValuesToNewTab(string[] fruitBasket)
    {
        string[] newFruitBasket = new string[fruitBasket.Length + 1];   
        return newFruitBasket;
    }
    public static void DisplayFruitBasket(string[] fruitBasket)
    {
        if (IsFruitBasketEmpty(fruitBasket))
            return;

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
            Console.WriteLine($"\t+ {element}");
            i++;
        }
    }
    public static void DisplayMenu(string[] menuOptions)
    {
        Console.WriteLine("[_Options disponible_]");
        Foo(menuOptions);
        Console.ResetColor();
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
                Console.WriteLine($"{fruitToFind} a déjà été acheté");
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

    public static bool IsDuplicate(string[] fruitBasket, string fruit)
    {
        //TODO : ...
        return false;
    }

    public static bool IsFruitBasketEmpty(string[] fruitBasket)
    {
        if (fruitBasket.Length == 0)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Aucun fruit trouvé dans le panier...");
            Console.BackgroundColor = ConsoleColor.Black;
            return true;
        }
        return false;
    }

    public static string[] RemoveFruit(string[] fruitBasket, string fruitToRemove)
    {
        if (fruitBasket.Length < 1)
            return fruitBasket;

        foreach (string fruit in fruitBasket)
        {
            if (fruit == fruitToRemove)
            {
                //etape de suppression
                Console.WriteLine($"\"{fruitToRemove}\" a été retiré du panier");
            }
        }
     
        return fruitBasket;
    }

    public static void Main(string[] args)
    {
        Console.Title = "Jeu du marché";
        bool loop = true;
        string[] menuOptions = ["[A]fficher", "[Aj]outer", "[R]echercher", "[S]upprimer", "[Q]uitter"];
        const int BASKETFRUITLIMIT = 5;
        string[] fruitBasket = new string[0];
        string? choice;
        string fruit;

        //LIRE CECI POUR INTEGRER LA GESTION DU CLAVIER
        //https://learn.microsoft.com/fr-fr/dotnet/api/system.consolekey?view=net-8.0
        //https://learn.microsoft.com/fr-fr/dotnet/api/system.consolekeyinfo?view=net-8.0
        //https://learn.microsoft.com/fr-fr/dotnet/api/system.consolekeyinfo?view=net-8.0

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
                    DisplayFruitBasket(fruitBasket);
                    break;

                case "ajouter" or "aj":
                    //Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    fruit = InputFruit();
                    fruitBasket = AddFruit(fruitBasket, fruit, BASKETFRUITLIMIT);
                    break;

                case "rechercher" or "r":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    fruit = InputFruit();
                    FindFruitBasket(fruitBasket, fruit);
                    break;

                case "supprimer" or "s":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
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