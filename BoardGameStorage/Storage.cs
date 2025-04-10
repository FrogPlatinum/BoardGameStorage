using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BoardGameStorage.Game;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace BoardGameStorage
{
    internal class Storage
    {
        //Public List properties. Instantiated and Initialized as empty
        public List<Game> gameList {  get; set; } = new List<Game>();
        public List<Inquiry> inquiryList { get; set; } = new List<Inquiry>();
        public List<int> usedGameIds { get; set; } = new List<int>();
        public List<int> usedInquiryIds { get; set; } = new List<int>();

        Random random = new Random();

        //Constructor
        public Storage()
        {
            LoadAllData();
        }

        //Print Game Details
        public void PrintGameDetails()
        {
            LoadAllData();
            foreach (Game game in gameList)
            {
                Console.WriteLine(new string('-', 25));
                Console.WriteLine($"Game Name: {game.Name}");
                Console.WriteLine($"ID: {game.Id}");
                Console.WriteLine($"Condition: {game.Condition}");
                Console.WriteLine($"Players: {game.MinPlayer}-{game.MaxPlayer}");
                Console.WriteLine($"Category: {game.Category}");
                Console.WriteLine($"Price: {game.Price}");
            }
        }

        //Add Game Method
        public void AddGame(string name, int condition, double price, int minPlayer, int maxPlayer, int category)
        {
            //Setting condition
            ConditionLevel gameCondition = ConditionLevel.Decent;
            bool validCondition = false;

            while (!validCondition)
            {
                switch (condition)
                {
                    case 1: 
                        gameCondition = Game.ConditionLevel.Like_New; 
                        validCondition = true; 
                        break;
                    case 2: 
                        gameCondition = Game.ConditionLevel.Good; 
                        validCondition = true; 
                        break;
                    case 3: 
                        gameCondition = Game.ConditionLevel.Decent; 
                        validCondition = true; 
                        break;
                    case 4: 
                        gameCondition = Game.ConditionLevel.Acceptable; 
                        validCondition = true; 
                        break;
                    default: 
                        Console.WriteLine("Invalid input. Try Again"); 
                        continue;
                }
            }

            //Setting category
            GameCategory gameCategory = GameCategory.Party;
            bool validCategory = false;

            while (!validCategory)
            {
                switch (category)
                {
                    case 1: 
                        gameCategory = Game.GameCategory.Strategy; 
                        validCategory = true; 
                        break;
                    case 2: 
                        gameCategory = Game.GameCategory.Family; 
                        validCategory = true; 
                        break;
                    case 3: 
                        gameCategory = Game.GameCategory.Party; 
                        validCategory = true; 
                        break;
                    case 4: 
                        gameCategory = Game.GameCategory.Cooperative; 
                        validCategory = true; 
                        break;
                    case 5: 
                        gameCategory = Game.GameCategory.Puzzle; 
                        validCategory = true; 
                        break;
                    case 6: 
                        gameCategory = Game.GameCategory.Card_Game; 
                        validCategory = true; 
                        break;
                    case 7: 
                        gameCategory = Game.GameCategory.Social_Deduction; 
                        validCategory = true; 
                        break;
                    default: 
                        Console.WriteLine("Invalid input. Try Again"); 
                        continue;
                }
            }

            //Generating Id
            int gameId = GenerateGameId();

            //Creating game object
            Game newGame = new Game(name, gameCondition,gameId, price, minPlayer, maxPlayer, gameCategory);

            //Confirmation
            Console.WriteLine(new string('-', 25));
            Console.WriteLine($"{name} Successfully Added");
            Console.WriteLine(new string('-', 25));

            //Adding game to list
            gameList.Add(newGame);

            //Saving Data
            SaveGameData();
        }
        
        //Remove Game Method
        public void RemoveGame(int gameIdInput)
        {
            Game gameToRemove = null;

            foreach (Game game in gameList)
            {
                if(game.Id == gameIdInput)
                {
                    gameToRemove = game;
                    break;
                }
            }

            if (gameToRemove != null)
            {
                gameList.Remove(gameToRemove);
                Console.WriteLine($"{gameToRemove} Successfully Removed");
                SaveGameData();
            }
            else
            {
                Console.WriteLine("Game Not Found");
            }
        }

        //Search Game By Name
        public void SearchGameByName(string gameName)
        {
            LoadGameData();

            bool found = false;

            foreach (Game game in gameList)
            {
                if (gameName == game.Name)
                {
                    Console.WriteLine(new string('-', 25));
                    Console.WriteLine($"Game Name: {game.Name}");
                    Console.WriteLine($"ID: {game.Id}");
                    Console.WriteLine($"Condition: {game.Condition}");
                    Console.WriteLine($"Players: {game.MinPlayer}-{game.MaxPlayer}");
                    Console.WriteLine($"Category: {game.Category}");
                    Console.WriteLine($"Price: {game.Price}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Game Not Found");
            }
        }

        //Method for random id generation
        public int GenerateGameId()
        {
            int randomGameId;

            do
            {
                randomGameId = random.Next(1000,9999);
            }while (usedGameIds.Contains(randomGameId));

            usedGameIds.Add(randomGameId);
            return randomGameId;
        }

        //Create Inquiry
        public void CreateInquiry(string customerFirstName, string customerLastName, string email, int phoneNumber, string description, string gameWish, int conditionWish)
        {
            //Storing customer name
            Customer c = new Customer(customerFirstName, customerLastName, email, phoneNumber);

            //Temp condition wish variable
            Inquiry.GameCondition gameConditionWish = Inquiry.GameCondition.Decent;
            bool validWishCondition = false;

            //Setting valid condition to enum
            while (!validWishCondition)
            {
                switch (conditionWish)
                {
                    case 1:
                        gameConditionWish = Inquiry.GameCondition.Like_New;
                        validWishCondition = true;
                        break;
                    case 2:
                        gameConditionWish = Inquiry.GameCondition.Good;
                        validWishCondition = true;
                        break;
                    case 3:
                        gameConditionWish = Inquiry.GameCondition.Decent;
                        validWishCondition = true;
                        break;
                    case 4:
                        gameConditionWish = Inquiry.GameCondition.Acceptable;
                        validWishCondition = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Try Again");
                        continue;
                }
            }

            //Generate Unique Inquiry ID
            int inquiryId = GenerateInquiryId();

            //Create Inquiry
            Inquiry inquiry = new Inquiry(c,inquiryId,description,gameWish,gameConditionWish);

            //Add Inquiry to list
            inquiryList.Add(inquiry);

            //Saving Inquiry
            SaveInquiryData();

            //Confirmation
            Console.WriteLine($"Inquiry {inquiryId} Successfully Added");
        }

        //Remove Inquiry
        public void RemoveInquiryById(int inquiryId)
        {
            Inquiry inquiryToRemove = null;

            foreach (Inquiry inquiry in inquiryList)
            {
                if (inquiryId == inquiry.Id)
                {
                    inquiryToRemove = inquiry;
                }
            }

            if (inquiryToRemove != null)
            {
                inquiryList.Remove(inquiryToRemove);
                Console.WriteLine($"Inquiry {inquiryToRemove.Id} Successfully Removed");
                SaveInquiryData();
            }
            else 
            { 
                Console.WriteLine("Inquiry Not Found"); 
            } 
        }

        //Search Inquiry
        public void searchInquiryById(int inquiryId)
        {
            LoadInquiryData();
            foreach (Inquiry inquiry in inquiryList)
            {
                if (inquiryId == inquiry.Id)
                {
                    Console.WriteLine($"Customer Name: {inquiry.CustomerFirstName} {inquiry.CustomerLastName}");
                    Console.WriteLine($"Inquiry ID: {inquiryId}");
                    Console.WriteLine($"Description: {inquiry.Description}");
                    Console.WriteLine($"Game Wish: {inquiry.GameWish}");
                    Console.WriteLine($"Condition Wish: {inquiry.ConditionWish}");
                }
            }
        }

        //Show All Inquiries
        public void PrintAllInquiries()
        {
            foreach (Inquiry inquiry in inquiryList)
            {
                Console.WriteLine(new string('-', 25));
                Console.WriteLine($"Inquiry ID: {inquiry.Id}");
                Console.WriteLine($"Customer Name: {inquiry.CustomerFirstName} {inquiry.CustomerLastName}");
                Console.WriteLine($"Email: {inquiry.CustomerEmail}");
                Console.WriteLine($"Phone Number: {inquiry.CustomerPhoneNumber}");
                Console.WriteLine($"Game Wish: {inquiry.GameWish}");
                Console.WriteLine($"Condition Wish: {inquiry.ConditionWish}");
                Console.WriteLine($"Description: {inquiry.Description}");
            }
        }

        //Generate Inquiry ID
        public int GenerateInquiryId()
        {
            int randomInquiryId;

            do
            {
                randomInquiryId = random.Next(1000, 9999);
            } while (usedInquiryIds.Contains(randomInquiryId));

            usedInquiryIds.Add(randomInquiryId);
            return randomInquiryId;
        }

        //Save Game Data
        public void SaveGameData()
        {
            string filePath = "games.json";
            string json = JsonSerializer.Serialize(gameList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        //Save Inquiry Data
        public void SaveInquiryData()
        {
            string filePath = "inquiries.json";
            string json = JsonSerializer.Serialize(inquiryList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        //Load Game Data
        public List<Game> LoadGameData()
        {
            string json = File.ReadAllText("games.json");
            return JsonSerializer.Deserialize<List<Game>>(json);
        }

        //Load Inquiry Data
        public List<Inquiry> LoadInquiryData()
        {
            string json = File.ReadAllText("inquiries.json");
            return JsonSerializer.Deserialize<List<Inquiry>>(json);
        }

        //Save All Data
        public void SaveAllData()
        {
            SaveGameData();
            SaveInquiryData();
        }

        //Load All Data
        public void LoadAllData()
        {
            gameList = LoadGameData();
            inquiryList = LoadInquiryData();
        }
    }
}
