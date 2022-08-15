//Un-comment below code and fix the issues
//Push to github


int RecursiveFibonacci(int first, int second, int count)
{
    count--;
    int nextValue = first + second;
    if(count == 0) {
        return nextValue;
    }else{
        //Since it is a recursive function we want to return the next values for the next iteration.
        //This means first would become second and second would become third (which would be first + second)
        return RecursiveFibonacci(second, nextValue, count);
    }
}

// 0 + 0 == 0
//  1
// 0 + 1 == 1
// 1 + 1 == 2 (First fibonacchi number it gets)
// 1 + 2 == 3 ()
// 2 + 3 == 5
// 3 + 5 == 8

int lastFibo = RecursiveFibonacci(1,1,5);
Console.WriteLine("Last fibo number was " + lastFibo);
Console.ReadLine(); 
