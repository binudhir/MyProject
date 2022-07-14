import java.util.*;
//import java.lang.*;
public class pallindrome{
public static void main(String[] args){
    System.out.println("Enter the number : ");
    long sum = 0,temp,r;
    Scanner sc = new Scanner(System.in);
    long a = sc.nextLong();
    temp=a; //Store the given value in  a Temporary variable
    while (a>0){
    r = a%10; //Getting Reminder
    sum = (sum*10)+r;
    a=a/10;
    }
    if (temp==sum)
    System.out.println("It is a Peliondromic Number.");
    else
    System.out.println("It is not Pallindromic."); 
    sc.close();
  }
}
