// Write a program to input three numbers(A, B & C) from user and print the maximum element among A, B & C in each line.
//import java.lang.*;
import java.util.*;

public class greatest{
	public static void main (String[] args){
		int a, b, c;
        System.out.println("Enter three Numbers :");
        Scanner sc = new Scanner(System.in);
        a=sc.nextInt();
        b=sc.nextInt();
        c=sc.nextInt();
	// Check the a
    if (a>=b && a>=c)
		System.out.println(a);
    // Check the b
    else if (b>=c && b>=a)
        System.out.println(b);
    else
        System.out.println(c);
        sc.close();
	}
}
