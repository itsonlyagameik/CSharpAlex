
using System.Linq;

class Car{
    #region Fields
    //carModels ( Brand name -> Model -> Price in $ )
    public static Dictionary<String, Dictionary<String, int>> carModels = new Dictionary<string, Dictionary<String, int>>{
        ["Fort"] = new Dictionary<string, int>{
            ["Forkis"] = 22500,
            ["GD"] = 100000
        },
        ["Mercedus"] = new Dictionary<string, int>{
            ["Ji el Sí"] = 60000,
            ["WF Trac"] = 500000
        },
        ["HDonda"] = new Dictionary<string, int>{
            ["Rural"] = 22000,
        },
        ["ToeYoeDoe"] = new Dictionary<string, int>{
            ["Corona"] = 70000,
            ["Paris"] = 50000
        },
        ["Lamp-O-Genie"] = new Dictionary<string, int>{
            ["Tractory"] = 80000,
            ["350 GD"] = 25000,
            ["350 GDW"] = 30000,
            ["400 GD Bonza"] = 45000
        },
        ["Flat"] = new Dictionary<string, int>{
            ["Multiple"] = 235000,
            ["Koala"] = 33000
        }
    };
    public string Name;
    public string Brand = "";
    public string CarModel = "";
    public float Price;

    #endregion

    #region Constructors

    //Name = BrandCar()
    public Car(string BrandParameter, string _CarModel, float _Price){
        this.CarModel = _CarModel;//Sivic
        this.Brand = BrandParameter;//Honda
        this.Name = Brand+" "+CarModel;//Honda Sivic
        this.Price = _Price;
        //Console.WriteLine("Car constructed / Instantiated "+this.Name);
    }

    #endregion

    #region Methods
    public static List<Car> GenerateCarList(int length, int variancePercent){    
        Random RandomNumber = new Random();
        List<Car> Out = new List<Car>();
        String[] Brands = carModels.Keys.ToArray();
        for(int i = 0; i < length; i++){
            int index = RandomNumber.Next(0,Brands.Count()-1);
            String Brand = Brands[index];
            String[] Models = carModels[Brand].Keys.ToArray();
            int index2 = RandomNumber.Next(0,Models.Count()-1);
            String Model = Models[index2];
            float Price = carModels[Brand][Model];
            Price = Price * (100 + new Random().Next(-variancePercent, variancePercent)) / 100;
            Out.Add(new Car(Brand, Model, Price));
        }
        
        return Out;
    }

    #endregion
}
