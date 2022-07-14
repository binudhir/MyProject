//Write a program to input three numbers(A, B & C) from user and print the maximum element among A, B & C in each line.
import java.util.*;
public class mini{
	public static void main(String[] args){
		System.out.println("Enter two number :");
		Scanner sc = new Scanner(System.in);
		int a = sc.nextInt();
		int b = sc.nextInt();
		if (a <= b){
			System.out.println(a);
		}			
		else{
			System.out.println(b);
		}			
		sc.close();
	}
}