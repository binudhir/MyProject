//Using recursion print the sum of the n Number.
import java.util.Scanner;

public class recursionsum{

static int sum(int n){
if(n==1)
return 1;
else
return sum(n-1)+n;
}
public static void main(String[] args){
    System.out.println("Enter a Number:");
    Scanner sc=new Scanner(System.in);
    int n=sc.nextInt();
    System.out.println("Sum of "+ n +" is " + sum(n));
    sc.close();
}
}
