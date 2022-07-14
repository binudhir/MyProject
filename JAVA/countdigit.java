//import java.lang.*;
import java.util.*;
public class  countdigit{
public static void main(String[] args){
    System.out.println("Enter the Number: ");
    int count=1;
    Scanner sc = new Scanner(System.in);
    int t = sc.nextInt();
    for (int i=0; i<t; i++){
        long n = sc.nextLong();
        if (n!=0)        
        count=0;
        while (n != 0) {
        // n = n/10
        n /= 10;
        ++count;
        }
        System.out.println(count);
        }
        sc.close(); 
  }
}
