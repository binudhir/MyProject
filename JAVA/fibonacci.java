//The problem is, given an integer N, task is to find the Nth fibonacci Number using Recursion.
import java.util.*;
public class fibonacci{
    public static void main(String[] args){
    System.out.println("Enter the Number : ");
    Scanner sc = new Scanner(System.in);        
    int n = sc.nextInt();
    System.out.println("F(n) = " + fib(n));
    sc.close();
    }

     // Function to find the nth Fibonacci number
    static int fib(int n)
    {
        if (n <= 1) {
            return n;
        }
        return fib(n - 1) + fib(n - 2);
    }
}
