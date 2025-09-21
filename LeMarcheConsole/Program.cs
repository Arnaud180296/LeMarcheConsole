internal class Program
{
    public static string[] AddFruit(string[] fruitBasket, string fruit, int BASKETFRUITLIMIT)
    {
        ///<summary>
        /// Ajoute un element de type string à un tableau de type string.
        ///</summary>
        ///<param name="fruitBasket"> Tableau à une dimension permettant le stockage de chaine de caractères</param>
        ///<returns>Renvoie ...</returns>
        
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
            Console.WriteLine($"Seule une occurence de {fruit} peut etre acheté à la fois");
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
        //=====================

        return newFruitBasket;
    }

    public static string[] CopyOldTabValuesToNewTab(string[] fruitBasket)
    {
        string[] newFruitBasket = new string[fruitBasket.Length + 1];   
        return newFruitBasket;
    }
    public static void DisplayFruitBasket(string[] fruitBasket)
    {
        if (fruitBasket.Length == 0)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Aucun fruit trouvé dans le panier...");
            Console.BackgroundColor = ConsoleColor.Black;
            return;
        }
        Console.WriteLine("Voici le contenu du panier : ");
        foreach (string fruit in fruitBasket)
            Console.WriteLine($"\t- {fruit}");
    }
    public static void DisplayMenu(string[] menuOptions)
    {
        foreach (string option in menuOptions)
        {
            Console.WriteLine($"* {option}");
        }
        Console.WriteLine("");
    }

    public static void FindFruitBasket(string[] fruitBasket, string fruitToFind = "fruitTest")
    {
        foreach (string fruit in fruitBasket)
        {
            if (fruit == fruitToFind)
            {
                Console.WriteLine($"{fruitToFind} a déjà été acheté");
                return;
            }
        }
        Console.WriteLine($"\"{fruitToFind}\" n'existe pas dans le panier");
        return;
    }

    public static string InputFruit()
    {
        Console.Write("Saisir le nom du fruit en question : ");
        return Console.ReadLine().ToLower();
    }

    public static bool IsDuplicate(string[] fruitBasket, string fruit)
    {
        return false;
    }

    public static string[] RemoveFruit(string[] fruitBasket, string fruit)
    {
        //controller le fait de ne pas pouvoir supprimer un fruit qui n'est pas dans le panier
        // controller le fait de ne pas pouvoir descendre en dessous de 0 element dans le panier
        Console.WriteLine($"\"{fruit}\" a été retiré du panier");
        return fruitBasket;
    }

    public static void Main(string[] args)
    {
        bool loop = true;
        string[] menuOptions = ["Afficher", "Ajouter", "Rechercher", "Supprimer", "Quitter"];
        const int BASKETFRUITLIMIT = 5;
        string[] fruitBasket = new string[0];
        string choice;
        string fruit;


        while (loop)
        {
            Console.ForegroundColor = ConsoleColor.White;
            
            Console.WriteLine("[...Jeu du marché...]");
            DisplayMenu(menuOptions);

            Console.Write("Saisir l'option souhaitée : ");
            choice = Console.ReadLine().ToLower();
            if (choice == null || choice == "")
                continue;

            switch (choice)
            {
                case "afficher":
                    Console.Clear();
                    DisplayFruitBasket(fruitBasket);
                    break;

                case "ajouter":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    fruit = InputFruit();
                    fruitBasket = AddFruit(fruitBasket, fruit, BASKETFRUITLIMIT);
                    break;

                case "rechercher":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    fruit = InputFruit();
                    FindFruitBasket(fruitBasket, fruit);
                    break;

                case "supprimer":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    fruit = InputFruit();
                    fruitBasket = RemoveFruit(fruitBasket, fruit);
                    break;

                case "quitter":
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
    }
}