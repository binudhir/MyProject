//Print odd or even in given number
import java.util.*;
public class oddeven{
	public static void main(String[] args){
		System.out.println("Please input the Number :");
		Scanner sc = new Scanner(System.in);
		int n = sc.nextInt();
		if (n % 2 == 0)
			System.out.println("This is a Even Number.");
		else
			System.out.println("This is an Odd Number");
		sc.close();			
	}
}