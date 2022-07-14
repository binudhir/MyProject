//The problem is, given an integer N, task is to check whether the given number exist in fibonacci sequence or not.
import java.util.*;
public class fibonaccinum{
    public static void main(String[] args){
    System.out.println("Enter the Number : ");
    Scanner sc = new Scanner(System.in);        
    int n = sc.nextInt();
    if(fib(n)==1)
    System.out.println(n + " is found  in fibonacci Series");
    else
    System.out.println(n + " is not found  in fibonacci Series");
    sc.close();
    }

     // Function to find the Fibonacci number
    static int fib(int n)
    {
        int a=0,b=1,c=0,fib=0;
        if(n==0 || n==1) {fib=1;}
        for(int i=0; i<=n; i++){
        c=a+b;
        a=b;
        b=c;
        if(b==n)
        fib=1;
        }
    return fib;
    }
}
