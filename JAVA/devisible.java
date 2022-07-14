//Print a number if it is divisible both 11 and 5 
//import java.lang.*;
import java.util.*;

public class devisible{
	public static void main (String[] args){
		System.out.println("Enter the Number :");
		Scanner sc = new Scanner(System.in);
		int a = sc.nextInt();
		if (a % 5 == 0  && a % 11 == 0)
			System.out.println("Divided by 5 and 11");
		else
			System.out.println("Not Devided");
			sc.close();
		
	}
	
} 