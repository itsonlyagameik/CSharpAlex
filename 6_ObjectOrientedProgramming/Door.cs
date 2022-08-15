class Door{

    bool IsOpen = false;

    public void Open(){
        if(IsOpen == true){
            Console.WriteLine("Door already open");
        }else{
            Console.WriteLine("Door opened");
            IsOpen = true;
        }
    }

    public void Close(){
        if(IsOpen == false){
            Console.WriteLine("Door already is close");
        }else{
            Console.WriteLine("Door closed");
            IsOpen = false;
        }
    }
}
