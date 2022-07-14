import java.util.*;
//import java.lang.*;
public class electricbill{
	public static void main(String[] args){
		System.out.println("Enter the Electric Unit :");
		Scanner sc = new Scanner(System.in);
		int unt = sc.nextInt();
		double bill=0;
		if (unt <= 50)
			bill = unt * 0.5;
		else if (unt > 50 && unt <= 150)
			bill = 50 * 0.5 + (unt - 50) * 0.75;
		else if (unt > 150 && unt <= 250)
			bill = 50 * 0.5 + 100 * 0.75 + (unt - 150) * 1.20;
		else
			bill = 50 * 0.5 + 100 * 0.75 + 100 * 1.20 + (unt - 250) * 1.50;
		double tot = bill + (bill * 0.20);
		int itot = (int) tot;
		System.out.println("Total Bill to be Pay : " + itot);
		sc.close();
	}
}