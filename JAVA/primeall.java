//import java.lang.*;
import java.util.*;
public class primeall{
public static void main(String[] args){
    System.out.println("Enter the number :");
    Scanner sc = new Scanner(System.in);
    int n = sc.nextInt();
    if (n>0){    
        for (int num=2; num<=n; num++){
        boolean isPrime = true;
            for (int i=2; i<=num/2; i++){        
            if (num % i == 0) {
            isPrime = false;
            break;
            }        
            }
    
        if ( isPrime == true )
        System.out.print(num + " ");
        }
    }
    else {
    System.out.println("There are no prime numbers less than" + n);
    }
    sc.close();
  }
}
