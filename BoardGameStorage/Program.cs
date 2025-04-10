namespace BoardGameStorage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            bool mainMenu = true;

            

            //Main Menu
            while (mainMenu)
            {
                Console.WriteLine("------- Main Menu -------");
                Console.WriteLine("1. See List of Games");
                Console.WriteLine("2. Manage Games");
                Console.WriteLine("3. Manage Inquiry");
                Console.WriteLine("0. Exit Program");
                Console.WriteLine(new string('-', 25));

                int mainMenuInput = IntInputHandler("Choose an option: ",4);

                switch (mainMenuInput)
                {
                    //1. See List of Games
                    case 1:
                        storage.PrintGameDetails();
                        break;
                    //2. Manage Games
                    case 2:
                        Console.WriteLine("---- Manage Game Menu ----");
                        Console.WriteLine("1. Add Game");
                        Console.WriteLine("2. Remove Game");
                        Console.WriteLine("3. Search Game");
                        Console.WriteLine("0. Go Back");

                        int manageGameInput = IntInputHandler("Choose an option: ", 3);

                        switch (manageGameInput)
                        {
                            //2.1. Add Game
                            case 1:
                                //Game Name
                                Console.Write("Game Name: ");
                                string gameName = Console.ReadLine();

                                //Game Condition
                                Console.WriteLine("Condition: ");
                                Console.WriteLine("1. Like-New");
                                Console.WriteLine("2. Good");
                                Console.WriteLine("3. Decent");
                                Console.WriteLine("4. Acceptable");

                                int gameConditionInput = IntInputHandler("Choose an option: ",4);

                                //Game Price
                                Console.Write("Price: ");
                                double gamePrice = DoubleInputHandler("");

                                //Game Min Player
                                Console.Write("Min Player Amount: ");
                                int gameMinPlayer = IntInputHandler("");

                                //Game Max Player
                                Console.Write("Max Player Amount: ");
                                int gameMaxPlayer = IntInputHandler("");

                                //Game Category
                                Console.WriteLine("Categories: ");
                                Console.WriteLine("1. Strategy");
                                Console.WriteLine("2. Family");
                                Console.WriteLine("3. Party");
                                Console.WriteLine("4. Cooperative");
                                Console.WriteLine("5. Puzzle");
                                Console.WriteLine("6. Card Game");
                                Console.WriteLine("7. Social Deduction");

                                int gameCategoryInput = IntInputHandler("Choose an option: ",7);

                                storage.AddGame(gameName, gameConditionInput, gamePrice, gameMinPlayer, gameMaxPlayer, gameCategoryInput);
                                break;
                            //2.2. Remove Game
                            case 2:
                                Console.WriteLine("Input Game ID to Remove Game");
                                int removeGameId = IntInputHandler("");
                                storage.RemoveGame(removeGameId);
                                break;
                            //2.3 Search Game
                            case 3:
                                Console.WriteLine("Input Game Name To Search: ");
                                string gameNameInput = Console.ReadLine();
                                storage.SearchGameByName(gameNameInput);
                                break;
                            //2.0 Go Back
                            case 0:
                                break;
                        }

                        break;
                    //3. Manage Inquiry
                    case 3:
                        Console.WriteLine("---- Manage Inquiry Menu ----");
                        Console.WriteLine("1. Create Inquiry");
                        Console.WriteLine("2. Remove Inquiry");
                        Console.WriteLine("3. Search Inquiry");
                        Console.WriteLine("0. Go Back");

                        int manageInquiryInput = IntInputHandler("Choose an Option: ", 3);

                        switch (manageInquiryInput)
                        {
                            //3.1 Create Inquiry
                            case 1:
                                Console.WriteLine("Input Customer Info");
                                Console.Write("First Name: ");
                                string customerFirstName = Console.ReadLine();

                                Console.Write("Last Name: ");
                                string customerLastName = Console.ReadLine();

                                Console.Write("Game Wish: ");
                                string gameWish = Console.ReadLine();

                                Console.WriteLine("Desired Condition: ");
                                Console.WriteLine("1. Like-New");
                                Console.WriteLine("2. Good");
                                Console.WriteLine("3. Decent");
                                Console.WriteLine("4. Acceptable");
                                int conditionWish = IntInputHandler("Choose An Option: ",4);

                                Console.WriteLine("Description / Additional Info: ");
                                string description = Console.ReadLine();

                                Console.Write("Customer Email: ");
                                string customerEmail = Console.ReadLine();

                                Console.Write("Customer Phone Number: ");
                                int customerPhoneNumber = IntInputHandler("");

                                storage.CreateInquiry(customerFirstName, customerLastName, customerEmail, customerPhoneNumber, description, gameWish, conditionWish);                        
                                break;
                            //3.2 Remove Inquiry
                            case 2:
                                Console.WriteLine("Input Inquiry ID to Remove: ");
                                int inquiryRemoveInput = IntInputHandler("");
                                storage.RemoveInquiryById(inquiryRemoveInput);
                                break;
                            //3.3 Search Inquiry
                            case 3:
                                Console.WriteLine("Input Inquiry ID to Search: ");
                                int inquirySearchInput = IntInputHandler("");
                                storage.searchInquiryById(inquirySearchInput);
                                break;
                            //3.0 Go Back
                            case 0:
                                break;
                        }
                        break;
                    //0. Exit
                    case 0:
                        storage.SaveAllData();
                        mainMenu = false;
                        break;
                }
            }
        }
        //Method for validating user input as in
        public static int IntInputHandler(string message, int maxOption)
        {
            int intInput;

            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out intInput))
                {
                    if (intInput >= 0 && intInput <= maxOption)
                    {
                        return intInput;
                    }
                }

                Console.WriteLine("Invalid Input. Try Again.");
            }
        }
        //Overloaded IntInputHandler for more basic checks
        public static int IntInputHandler(string message)
        {
            int intInput;

            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out intInput))
                {
                    if (intInput >= 0)
                    {
                        return intInput;
                    }
                }

                Console.WriteLine("Invalid Input. Try Again.");
            }
        }

        //Method for validating user input as double
        public static double DoubleInputHandler(string message)
        {
            double doubleInput;

            while (true)
            {
                Console.Write(message);

                if (double.TryParse(Console.ReadLine(), out doubleInput))
                {
                    return doubleInput;
                }

                Console.WriteLine("Invalid Input. Try Again.");
            }
        }
    }
}
