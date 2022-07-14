//import java.lang.*;
import java.util.*;
public class reversenum{
public static void main(String[] args){
    System.out.println("Enter the Number: ");
    Scanner sc = new Scanner(System.in);
    int t = sc.nextInt();
    for (int i=0; i<t; i++){
    long n = sc.nextLong();
    long rev=0, rem=0; 
    while(n!=0){
			rem=n%10;
			rev = rev *10 + rem;
			n = n/10;
		}
	System.out.println(rev);    
    }
    sc.close();
  }
}
