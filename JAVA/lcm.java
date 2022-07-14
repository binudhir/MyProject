//Write a function that takes to positive integers A and B and returns their LCM.
import java.util.*;
public class lcm{
// Recursive method to return gcd of a and b
static int gcd(int a, int b){
if(a==0)
return b;
return gcd(b%a,a);
}
// method to return LCM of two numbers
static int findlcm(int a, int b){
return (a/gcd(a,b))*b;
}
public static void main(String[] args){
System.out.println("Enter two Number :");
Scanner sc=new Scanner(System.in);
int A=sc.nextInt();
int B=sc.nextInt();
System.out.println("The LCM of " +A+ " and "+B+" is " + findlcm(A,B));
sc.close();
}
}
