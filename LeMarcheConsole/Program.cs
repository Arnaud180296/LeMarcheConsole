using System.Runtime.InteropServices;

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

        fruitBasket[fruitBasket.Length - 1] = fruit;
        return fruitBasket;
    }

    public static void ChangeColors(string choice)
    {
        if (choice == "a" || choice == "afficher")
            Console.WriteLine("blanc");
        else if (choice == "aj" || choice == "ajouter")
            Console.ForegroundColor = ConsoleColor.Green;
        else if (choice == "r" || choice == "rechercher")
            Console.ForegroundColor = ConsoleColor.Yellow;
        else if (choice == "s" || choice == "supprimer")
            Console.ForegroundColor = ConsoleColor.Red;
    }

    public static void ConfirmAddBeep()
    {
        ///<summary>
        /// Emet deux bips sonores, si l'application est executée dans un environnement Windows.
        ///</summary>
      
        if (OperatingSystem.IsWindows())
        {
            Console.Beep(2100, 200);
            Console.Beep(2100, 200);
        }
        return;
    }
    public static string[] CopyOldTabValuesToNewTab(string[] fruitBasket)
    {
        ///<summary>
        /// Copie les éléments d'un tableau de string dans un second tableau de string avant de le renvoyer.
        ///</summary>
        ///<param name="fruitBasket"> Tableau à une dimension de chaine de caracteres qui doit etre copié</param>
        ///<returns>Renvoie un tableau de string, servant à représenter le panier à fruit, après ajout d'un nouvel élément</returns>
        string[] newFruitBasket = new string[fruitBasket.Length + 1];

        for (int i = 0; i < fruitBasket.Length; i++)
        {
            newFruitBasket[i] = fruitBasket[i];
        }

        return newFruitBasket;
    }
    public static void DisplayFruitBasket(string[] fruitBasket)
    {
        Console.WriteLine("Voici le contenu du panier : ");
        SetAlternateBackgroundColor(fruitBasket);
        
        Console.ResetColor();

        GoBackMainMenu();

        Console.Clear();
        return;
    }
    
    public static void DisplayMenu(string[] menuOptions)
    {   
        Console.WriteLine("[_Options disponible_]");
        SetAlternateBackgroundColor(menuOptions);
        Console.ResetColor();
        return;
    }

    #region FindMethods
    public static void FindFruitBasket(string[] fruitBasket, params string[] fruitsToFind)
    {
        //TODO faire une surcharge de methode pour rechercher plus de 1 fruit à la fois.
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
    #endregion FindMethods

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

    #region CheckMethods
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
            Thread.Sleep(750);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            return true;
        }
        return false;
    }

    public static bool IsFruitBasketFull(string[] fruitBasket, string fruit, int BASKETFRUITLIMIT = 5)
    {
        if (fruitBasket.Length > BASKETFRUITLIMIT - 1)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Le panier est plein, \"{fruit}\" n'a donc pas été ajouté au panier");
            Console.BackgroundColor = ConsoleColor.Black;
            Thread.Sleep(2000);
            return true;
        }
        return false;
    }
    #endregion CheckMethods

    public static string[] RemoveFruit(string[] fruitBasket, string fruitToRemove)
    {
        foreach (string fruit in fruitBasket)
        {
            if (fruit == fruitToRemove)
            {
                //TODO : etape de suppression (j'ai besoin de refactoriser la methode addFruit et CopyOld... avant d'implementer la suppression)
                Console.WriteLine($"Le fruit \"{fruitToRemove}\" a été retiré du panier");
                return fruitBasket;
            }
        }
        Console.WriteLine($"\"{fruitToRemove}\" ne se trouve pas dans le panier");
        GoBackMainMenu();

        return fruitBasket;
    }

    public static void SetAlternateBackgroundColor(string[] elements)
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

    public static void Main()
    {
        string apple = "\U0001F34F";
        string banana = "\U0001F34C";
        Console.Title = $" {apple} Bienvenue au marché {banana}";

        bool loop = true;
        string[] menuOptions = ["[A]fficher", "[Aj]outer", "[R]echercher", "[S]upprimer", "[Q]uitter"];
        const int BASKETFRUITLIMIT = 5;
        string[] fruitBasket = new string[0];
        string? choice;
        string fruit;

        /* TODO
         * 1 : Implementer CopyOldTabValuesToNewTab() ✅
         * 2 : Implementer RemoveFruit()
         * 3 : Penser à regrouper les changements de couleurs
         * 4 : Tenter de surcharcher FindFruitBasket() pour quelle puisse accepter plusieurs valeurs.
         * 5 : Respecter le principe de single responsability et mettre le methode dans les cases.
         * **/

        while (loop)
        {
            Console.ResetColor();
            
            DisplayMenu(menuOptions);

            Console.Write("Saisir l'option souhaitée : ");
            choice = (Console.ReadLine() ?? "").ToLower();
            if (choice == null || choice == "")
            {
                Console.Clear();
                continue;
            }

            switch (choice)
            {
                case "afficher" or "a":
                    Console.Clear();
                    if (IsFruitBasketEmpty(fruitBasket))
                        continue;
                    DisplayFruitBasket(fruitBasket);
                    break;

                case "ajouter" or "aj":
                    ChangeColors(choice);
                    fruit = InputFruit();
                    
                    Console.Clear();
                    
                    if(IsDuplicate(fruitBasket, fruit))
                        continue;
                    
                    if (!IsFruitBasketFull(fruitBasket, fruit))
                    {
                        fruitBasket = CopyOldTabValuesToNewTab(fruitBasket);
                        fruitBasket = AddFruit(fruitBasket, fruit, BASKETFRUITLIMIT);
                        ConfirmAddBeep();
                    }
                   
                    Console.Clear();
                    break;

                case "rechercher" or "r":
                    Console.Clear();
                    ChangeColors(choice);
                    if (IsFruitBasketEmpty(fruitBasket))
                        continue;
                    fruit = InputFruit();
                    FindFruitBasket(fruitBasket, fruit);
                    break;

                case "supprimer" or "s":
                    Console.Clear();
                    ChangeColors(choice);
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