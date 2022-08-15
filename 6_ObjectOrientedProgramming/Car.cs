
class Car{
    #region Fields
    
    public string Brand = ""; 
    protected int CurrentGear = 0;
    private float _speed = 0f;
    internal int _revolutions = 0;
    
    public List<Door> Doors = new List<Door>();
    public List<Tire> Tires;

    #endregion

    #region Constructors

    //Name = BrandCar()
    public Car(string brandParamater){
        this.Brand = brandParamater;
        Tires = new List<Tire>();
        //Brand = brand;
        Doors.Add(new Door());
        Doors.Add(new Door());

        for(int i = 0; i < 4; i++){
            Tires.Add(new Tire());
        }
        GetIn(Doors[0]);
        Console.WriteLine("Car constructed / Instantiated");
    }

    public Car(string brandParamater, int amountOfDoors, int amountOfTires, int tireSize){
        this.Brand = brandParamater;
        Tires = new List<Tire>();
        for(int i = 0; i < amountOfTires; i++){
            Tires.Add(new Tire(tireSize));
        }
        for(int i = 0; i < amountOfDoors; i++){
            Doors.Add(new Door());
        }
        GetIn(Doors[0]);
        Console.WriteLine("Car constructed / Instantiated");
    }

    #endregion

    #region Methods
    
    void Break(){
        _speed = 0f;
    }

    void Accelerate(float forceParameter){
        _speed = _speed + forceParameter;
    }
    
    int ChangeGear(int amount){
        CurrentGear += amount;
        return CurrentGear;
    }

    void GetIn(Door doorParameter){
        doorParameter.Open();
        Console.WriteLine("Got inside " + Brand);
        doorParameter.Close();
    }

    #endregion
}
