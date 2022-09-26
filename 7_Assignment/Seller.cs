class Seller : Person
{
    public Seller(string _name) : base(_name, 0)
    {   
        CarsOwned = Car.GenerateCarList(5, 30);
    }
}