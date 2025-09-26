using System.Runtime.InteropServices;

internal class Program
{
    public static string[] AddFruit(string[] fruitBasket, string fruit)
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
        ///<summary>Modifie la couleur du texte de la console selon l'etat du programme</summary>
        ///<param name="choice">Paramètre de type string, représentant l'option choisi</param>
        if (choice == "a" || choice == "afficher")
            Console.WriteLine("blanc");
        else if (choice == "aj" || choice == "ajouter")
            Console.ForegroundColor = ConsoleColor.Green;
        else if (choice == "r" || choice == "rechercher" || choice == "s" || choice == "supprimer")
            Console.ForegroundColor = ConsoleColor.Yellow;
        else
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
        ///<summary>Se charge d'afficher le contenu du panier</summary>
        Console.WriteLine("Voici le contenu du panier : ");
        SetAlternateBackgroundColor(fruitBasket);
        return;
    }
    
    public static void DisplayMenu(string[] menuOptions)
    {
        ///<summary>Se charge d'afficher le menu d'options disponible</summary>
        Console.WriteLine("[_Options disponible_]");
        SetAlternateBackgroundColor(menuOptions);
        Console.ResetColor();
        return;
    }

    #region FindMethods
    public static bool FindFruitBasket(string[] fruitBasket, params string[] fruitsToFind)
    {
        //TODO faire une surcharge de methode pour rechercher plus de 1 fruit à la fois.
        foreach (var fruit in fruitsToFind)
        {
            
        }
        return false;
    }
    public static bool FindFruitBasket(string[] fruitBasket, string fruitToFind = "fruitTest")
    {
        ///<summary>Recherche la presence d'un element de type string sans un tableau string</summary>
        ///<param name="fruitBasket">Tableau à une dimension de chaine de caracteres</param>
        ///<param name="fruitToFind">Chaine de caractères à ajouter</param>
        foreach (string fruit in fruitBasket)
        {
            if (fruit == fruitToFind)
                return true;
        }
        return false;
    }
    #endregion FindMethods

    public static void GoBackMainMenu()
    {
        ///<summary>Attends la saisie de la touche Enter.</summary>
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Red;
        do
        {
            Console.WriteLine($"Appuyer sur la touche \"{ConsoleKey.Enter}\" du clavier pour retourner au menu...");
        } while ((Console.ReadKey().Key != ConsoleKey.Enter));

        Console.Clear();
        
        return;
    }

    public static string InputFruit()
    {
        ///<summary>Recupère l'entre utilisateur à l'aide du clavier</summary>
        ///<returns>Renvoie une chaine de caractères</returns>
        Console.Write("Saisir le nom du fruit en question : ");
        string? input = (Console.ReadLine() ?? "").ToLower();

        if (input != null && input != "")
            return input;

        return InputFruit();
    }

    #region CheckMethods
    public static bool IsDuplicate(string[] fruitBasket, string fruitToCheck)
    {
        ///<summary>Recherche la presence d'un doublons de type string dans un tableau string</summary>
        ///<param name="fruitBasket">Tableau à une dimension de chaine de caracteres</param>
        ///<param name="fruitToCheck">Chaine de caractères à rechercher</param>
        ///<returns>Renvoie un boolean</returns>
     
        Console.ForegroundColor = ConsoleColor.Yellow;
        foreach (string fruit in fruitBasket)
        {
            if (fruitToCheck == fruit)
            {
                return true;
            }
        }
        return false;
    }

    public static bool IsFruitBasketEmpty(string[] fruitBasket)
    {
        ///<summary>Verifie que le tableau comporte au moins un element</summary>
        ///<param name="fruitBasket">Tableau à une dimension de chaine de caracteres</param>
        ///<returns>Renvoie un boolean</returns>
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

    public static bool IsFruitBasketFull(string[] fruitBasket, int BASKETFRUITLIMIT)
    {
        ///<summary>Verifie que le tableau ne dépasse pas la limite maximale</summary>
        ///<param name="fruitBasket">Tableau à une dimension de chaine de caracteres</param>
        ///<param name="BASKETFRUITLIMIT">Limite de maximale de type entier</param>
        ///<returns>Renvoie un boolean</returns>
        if (fruitBasket.Length > BASKETFRUITLIMIT - 1)
            return true;
        
        return false;
    }
    #endregion CheckMethods

    public static string[] RemoveFruit(string[] fruitBasket, string fruitToRemove)
    {
        ///<summary>Retire un element du tableau d'entree.</summary>
        ///<param name="fruitBasket">Tableau à une dimension de chaine de caracteres</param>
        ///<param name="fruitToRemove">chaine de caractère représentant l'element cible à retire du tableau</param>
        ///<returns>Renvoie un tableau de chaine de caractere contenant les données du tableau d'entree "fruitBasket" moins l'element à retirer "fruitToRemove"</returns>

        string[] newFruitBasket = new string[fruitBasket.Length - 1];
        int j = 0;
        for (int i = 0; i < fruitBasket.Length; i++) {
            //si l'element courant est different de fruitToRemove alors tu l'ajoutes au newFruitBasket.
            //mais si l'element courant est egal à fruitToRemove, il faut ignorer afin de ne pas l'ajouter à newFruitBasket(effet de suppression)
            //DU COUP le probleme est que I continue de s'incrementer, et donc newFruitBasket se retrouve avec une valeur vide.
            //donc il faut continuer à parcourir fruitBasket tout en bloquant le parcours de newFruitBasket...
            if (fruitBasket[i] != fruitToRemove) 
            {
                newFruitBasket[j] = fruitBasket[i];
                j++;
            }
        }

        return newFruitBasket;
    }

    public static void SetAlternateBackgroundColor(string[] elements)
    {
        int i = 0;
        foreach (string element in elements)
        {
            if (i % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
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
         * 2 : Implementer RemoveFruit() ✅
         * 3 : Penser à regrouper les changements de couleurs ✅
         * 4 : Tenter de surcharcher FindFruitBasket() pour quelle puisse accepter plusieurs valeurs.
         * 5 : Respecter le principe de single responsability et mettre le methode dans les cases. ✅
         * **/

        
        while (loop)
        {
            Console.ResetColor();
            Console.Clear();
            
            DisplayMenu(menuOptions);

            Console.Write("\nChoix > ");
            choice = (Console.ReadLine() ?? "").ToLower();
            if (choice == null || choice == "")
            {
                Console.Clear();
                continue;
            }

            switch (choice)
            {
                case "afficher" or "a":
                    if (IsFruitBasketEmpty(fruitBasket))
                        continue;
                    Console.Clear();
                    DisplayFruitBasket(fruitBasket);
                    
                    Console.ResetColor();
                    GoBackMainMenu();
                    break;

                case "ajouter" or "aj":
                    ChangeColors(choice);
                    fruit = InputFruit();
                    
                    if(IsDuplicate(fruitBasket, fruit))
                    {
                        Console.Clear();
                        Console.WriteLine($"Seule une occurence de \"{fruit}\" peut etre acheté à la fois,\npar conséquent \"{fruit}\" ne sera pas ajouté au panier");
                        GoBackMainMenu();
                        continue;
                    }
                        
                    
                    if (!IsFruitBasketFull(fruitBasket, BASKETFRUITLIMIT))
                    {
                        fruitBasket = CopyOldTabValuesToNewTab(fruitBasket);
                        fruitBasket = AddFruit(fruitBasket, fruit);
                        //ConfirmAddBeep();
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Le panier est plein, \"{fruit}\" n'a donc pas été ajouté au panier");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Thread.Sleep(2000);
                    }
                        break;

                case "rechercher" or "r":
                    ChangeColors(choice);
                    if (IsFruitBasketEmpty(fruitBasket))
                        continue;
                    fruit = InputFruit();
                    Console.Clear();
                    if (FindFruitBasket(fruitBasket, fruit))
                        Console.WriteLine($"Le fruit : \"{fruit}\" est bel et bien dans la panier");
                    else
                        Console.WriteLine($"\"{fruit}\" n'existe pas dans le panier");

                    GoBackMainMenu();
                    break;

                case "supprimer" or "s":
                    ChangeColors(choice);
                    if (IsFruitBasketEmpty(fruitBasket))
                        continue;
                    fruit = InputFruit();
                    Console.Clear();

                    if (FindFruitBasket(fruitBasket, fruit))
                    {
                        fruitBasket = RemoveFruit(fruitBasket, fruit);
                        Console.WriteLine($"Le fruit \"{fruit}\" a été retiré du panier");
                    }
                    else
                    {
                        Console.WriteLine($"\"{fruit}\" ne se trouve pas dans le panier");
                    }
                    GoBackMainMenu();
                    break;

                case "quitter" or "q":
                    loop = false;
                    break;

                default:
                    ChangeColors(choice);
                    Console.WriteLine($"La commande : \"{choice}\" n'est pas implémenté...");
                    Thread.Sleep(850);
                    break;
            }
        }
        Console.WriteLine("Fin du programme...");
        return;
    }
}