//import java.lang.*;
import java.util.*;
public class bankbal{
public static void main(String[] args){
System.out.println("Enter the Opening Balance :");
long n = 0, i=0;
Scanner sc = new Scanner(System.in);
n = sc.nextLong();
long m = sc.nextLong();
    while (i<m){
    long t = sc.nextLong();
    long amt = sc.nextLong();
    if (t == 1)
    n=n+amt;
    else if (t==2)
    n=n-amt;
    else
    System.out.println("Invalid Entry");
    if (n > 0){
    System.out.println(n);
    }
    else
    {
    System.out.println("Insufficient Funds");
    n=n+amt;
    }
    i++;
    } 
    sc.close();
  }
}
