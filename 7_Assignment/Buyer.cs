class Buyer : Person{
    
    public float SpendableMoney = 0f;//% of their total money

    public int DesiredAmountOfCars = 0;

    public Buyer(string _name, int _money) : base(_name, _money){
        SpendableMoney = new Random().Next(30, 100) / 100f;
    }

    //Desired qualities, Specs, color, materials

    public Buyer(string _name, int _money, float _spendableMoney) : base(_name, _money){
        SpendableMoney = _spendableMoney;
    }

    public float GetSpendableMoney(){
        return Money*(SpendableMoney);
    }
}



//New buy (name, money)