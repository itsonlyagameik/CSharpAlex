//Create a CarDealer program
//Minimum requirements:
//The CarDealer must have a list of available cars for sale
//The CarDealer must have public Buy/Sell methods
//These methods must be accessiable via console input/output
//These methods must change the car dealers available cars
//Make use of atleast 5 classes.
//These classes must have atleast 1 Field variable each
//Make use of atleast 10 methods
//5 of these methods must use paramaters
//Methods usually describes verbs (udsagnsord, at/jeg foran)
//Buy, Sell, Accelerate, Move


// Suggestion to get started on user interaction in the console
/*

CarDealer dealer = new CarDealer(); //This class you need to create yourself!
while(true){

    Console.WriteLine("Write an action [buy, sell, exit]");
    string input = Console.ReadLine();

    switch (input)
    {
        case "buy":
            //Car myNewCar = dealer.buy(...);
            break;
        case "sell":
            break;
        case "exit":
            return;
        default:
            return;
    }
}
*/

//5 new classes ✓
// 10 new methods (AddCar, Sendmoney, RemoveCar, SendCar) 4/10

/*README
You are a car dealer ready to make money, start your journey towards becoming a succesful businessman NOW!
*/

internal class Program
{
    private static void Main(string[] args){
        Console.WriteLine("What is your name?");
        Boolean ActionTaken = true;
        string Name = "";
        while (Name.Length == 0){
            Name = Console.ReadLine() + "";
        }
        CarDealer Dealer = new CarDealer(Name);
        Console.WriteLine("DEALER NAME: " + Dealer.Name+Environment.NewLine);
        Seller NewSeller = null;
        while (true){
            if(ActionTaken || NewSeller == null){
                if(new Random().Next(1, 2) == 1 || Dealer.customers.Peek() == null)
                {
                    String NewName = Person.GenerateName();
                    int NewMoney = Person.GenerateMoney();
                    Console.WriteLine(NewName+" has entered your store"+Environment.NewLine);
                    Dealer.AddCustomer(new Buyer(NewName, NewMoney));
                }
                Console.WriteLine("- "+Dealer.customers.Peek().Name+" is waiting to buy a car");
                String NewSellerName = Person.GenerateName();
                NewSeller = new Seller(NewSellerName);
                Console.WriteLine("- "+NewSellerName+" wants to sell a car"+Environment.NewLine);
            }
            ActionTaken = true;
            string Input = "";
            Console.WriteLine("Write an action for "+ Dealer.Name +": [Buy, Sell, View Cars, View Bank, Exit]");
            while(!new string[]{"buy", "sell", "view cars", "view bank", "exit"}.Contains(Input)){
                if(!Input.Equals("")){
                    Console.WriteLine(Dealer.Name+" does not know how to "+Input);
                }
                Input = (Console.ReadLine() + "").ToLower();
            }
            Console.WriteLine();
            Thread.Sleep(300);
            switch (Input){
                case "buy":
                    if(NewSeller == null){
                        break;
                    }
                    Console.WriteLine(NewSeller.Name+" has the following cars for sale: ");
                    NewSeller.ListCars(true);
                    int exitIndex = NewSeller.GetCarsOwned().Count()+1;
                    Console.WriteLine("["+exitIndex+"] Exit");
                    Console.WriteLine();
                    Console.WriteLine("You have "+Dealer.Money+"$ cash on hand");
                    Console.WriteLine("Select your desired car by index.");
                    int buyIndex = -1;
                    while (buyIndex == -1){
                        string buyInput = (Console.ReadLine() + "").ToLower();
                        Thread.Sleep(300);
                        Int32 s;
                        if(int.TryParse(buyInput, out s)){
                            if(int.Parse(buyInput) <= NewSeller.GetCarsOwned().Count() && int.Parse(buyInput) > 0){
                                buyIndex = int.Parse(buyInput) - 1;
                                Car selectedCar = NewSeller.GetCarsOwned()[buyIndex];
                                if(Dealer.Money >= selectedCar.Price){
                                    Dealer.BuyCar(selectedCar, NewSeller,selectedCar.Price);
                                    Console.WriteLine("Added "+selectedCar.Name);
                                }else{
                                    buyIndex = -1;
                                    Console.WriteLine("You don't have enough money to buy the "+selectedCar.Name+" :(");
                                }
                            }else if(int.Parse(buyInput) == exitIndex){
                                buyIndex = 0;
                                Console.WriteLine("You tell "+NewSeller.Name+" to bug off."+Environment.NewLine);
                            }else{
                                Console.WriteLine("'"+buyInput+"' is not a valid index.");
                            }
                        }
                        else{
                            Console.WriteLine("'"+buyInput+"' is not a valid index.");
                        }
                    }

                    break;
                case "sell":
                    Buyer buyer = Dealer.customers.Dequeue();
                    float Money = buyer.GetSpendableMoney();
                    Boolean FoundCar = false;
                    if(Dealer.CarsOwned.Count() > 0){
                        Car LowestPriceCar = Dealer.CarsOwned[0];
                        //
                        for(int i = 0;i<Dealer.CarsOwned.Count();i++){
                            if(!FoundCar && Dealer.CarsOwned[i].Price <= Money || (LowestPriceCar != null && FoundCar && Dealer.CarsOwned[i].Price < LowestPriceCar.Price)){
                                FoundCar = true;
                                LowestPriceCar = Dealer.CarsOwned[i];
                            }
                        }
                        if(FoundCar){
                            string answer = "";
                            do{
                                float Variance = (new Random().Next(0, 60)-25)/100f; // A range of -0.25; 0.35
                                float IncreasedBasePrice = LowestPriceCar.Price * 1.05f; // 5% Increase from the market price
                                float CalculatedNewPrice;//Calculates a variance in price that would be what the buyer wants to buy the car for (Varied from an increased base price)
                                if (Variance < 0){
                                    Variance *= -1;
                                    CalculatedNewPrice = IncreasedBasePrice - IncreasedBasePrice * Variance;
                                }else{
                                    CalculatedNewPrice = IncreasedBasePrice + IncreasedBasePrice * Variance;
                                }
                                Console.WriteLine("Buyer wants to buy "+LowestPriceCar.Name+" for the price of: "+CalculatedNewPrice+"$");
                                Console.WriteLine("Do you comply?");
                                while(!new string[]{"yes", "no"}.Contains(answer)){
                                        Console.WriteLine("Answer 'yes' or 'no'");
                                        answer = (Console.ReadLine() + "").ToLower();
                                        Thread.Sleep(300);
                                }
                                if(answer.Equals("no")){
                                    if(new Random().Next(1, 100) <= 35){
                                        break;
                                    }else{
                                        answer = "";
                                    }
                                }
                            }while(!answer.Equals("yes"));
                            if(answer.Equals("yes")){
                                Dealer.SellCar(LowestPriceCar,buyer);
                                Console.WriteLine(buyer.Name+" buys the "+LowestPriceCar.Name+" and leaves.");
                            }else{
                                Console.WriteLine(buyer.Name+" has had enough and leaves.");
                            }
                        }else{
                            Console.WriteLine("Buyer "+buyer.Name+" couldn't afford any car");
                        }
                    }else{
                         Console.WriteLine(Dealer.Name+", you don't have any more cars for sale");
                    }
                    
                    //Check what car the buyer can buy

                    //Remove car from list of sellers cars

                    //Add car to list of sellable cars with an added premium so the cardealer gets paid

                    //Once sold give money to the dealership and to the seller
                    break;
                case "view cars":
                    Console.WriteLine("You take a look at your inventory:");
                    Dealer.ListCars(false);
                    Console.WriteLine();
                    Console.WriteLine("[ENTER] to continue");
                    Console.ReadLine();
                    ActionTaken = false;
                    break;
                case "view bank":
                    Console.WriteLine("You take a look at your bank account:");
                    Console.WriteLine("You have: "+Dealer.Money+"$ in your bank account"+Environment.NewLine);
                    Console.WriteLine("[ENTER] to continue");
                    Console.ReadLine();
                    ActionTaken = false;
                    break;
                case "exit":
                    // Remove from list of customers
                    return;
                default:
                    break;
            }
            Thread.Sleep(1500);
            Console.WriteLine("__________________________________________________________"+Environment.NewLine);
        }
    }
}