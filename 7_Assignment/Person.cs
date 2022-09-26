using System.Collections;

class Person{
    public static String[] FirstNames = new String[]{
        "John",
        "Billy",
        "Joe",
        "Sam",
        "Hilly",
        "Nelly",
        "Bobby",
        "Guy",
        "McGoof",
        "Mac",
        "M.C.",
        "Matty",
        "Witty",
        "Cindy",
        "Mindy",
        "Linda",
        "Slim",
        "Old man",
        "Supa",
        "Dr.",
        "Mr.",
        "Ms.",
        "Mrs."
    };

    public static String[] LastNames = new String[]{
        "McGucket",
        "Bob",
        "Blue",
        "McDusty",
        "McKaylee",
        "Hot Fire",
        "Shady",
        "Drew",
        "McAndCheese",
        "McPorridge",
        "N.Gine",
        "Ravioli",
        "Bucket"
    };

    public static String GenerateName(){
        return FirstNames[new Random().Next(0, FirstNames.Count()-1)]+ " " + LastNames[new Random().Next(0,LastNames.Count()-1)];
    }

    public static int GenerateMoney(){
        return new Random().Next(20000, 500000);
    }

    public String Name;
    public float Money = 0f;//Dollars
    //Favorite color
    public List<Car> CarsOwned = new List<Car>();

    public Person(String _name, int _money){
        Name = _name;
        Money = _money;
    }

    public void SendMoney(Person Receiver, float Amount){
        if(Money >= Amount){
            Receiver.Money += Amount;
            Money -= Amount;
        }else{
            Console.WriteLine("You hear a VROOM as the car leaves your possession.. Without its payment.. ");
        }
    }

    public void SendCar(Person Receiver, Car SentCar, bool keepPrice){
        this.RemoveCar(SentCar);
        if(!keepPrice){
            SentCar.Price = Car.carModels[SentCar.Brand][SentCar.CarModel];
        }
        Receiver.AddCar(SentCar);
    }

    public void AddCar(Car NewCar){
        CarsOwned.Add(NewCar);
    }

    public void RemoveCar(Car RemovedCar){
        CarsOwned.Remove(RemovedCar);
    }

    public List<Car> GetCarsOwned(){
        return CarsOwned;
    }

    public void ListCars(bool showPrice){
        int i = 0;
        foreach(Car Car in CarsOwned){
            i++;
            if(showPrice){
                Console.WriteLine("["+i+"] "+Car.Name+": "+Car.Price);
            }else{
                Console.WriteLine("["+i+"] "+Car.Name);
            }
        }
    }
}