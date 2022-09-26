class CarDealer : Person{
    public Queue<Buyer> customers = new Queue<Buyer>();

    public CarDealer(string _name) : base(_name, 50000){
        CarsOwned = Car.GenerateCarList(1, 0);//Starting car amount
    }

    public void BuyCar(Car Car, Seller Seller, float Price){
        //int Price = Car.Price;
        Seller.SendCar(this, Car, false);
        this.SendMoney(Seller,Price);
    }

    public void SellCar(Car Car, Buyer Buyer){
        float Price = Car.Price;
        this.SendCar(Buyer,Car, true);
        Buyer.SendMoney(this,Price);
    }

    public void AddCustomer(Buyer Buyer){
        customers.Enqueue(Buyer);
    }

    public void NextCustomer(){
        customers.Dequeue();
    }
}

