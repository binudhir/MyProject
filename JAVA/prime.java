import java.util.*;
public class prime{
	public static void main(String[] args){
		System.out.println("Enter the Number :");
		Scanner sc = new Scanner(System.in);
		int a = sc.nextInt();
		int b = 0;
		for (int i = 2; i <= a / 2; i++){
			if (a % i == 0) {
				b = 1;
			break ;
            }
		}
		if (b == 0)
			System.out.println( a + " is a Prime Number" );
		else
			System.out.println( a + " is Not a Prime Number");
		sc.close();
	}
}
