import java.util.Scanner;
public class reverse2{
	public static void reversenumber(int number){
		if (number < 10){
			//Print the same number if the number is bellow 10
			System.out.println(number);
			return;
		}				
		else{
			System.out.print(number%10);
			reversenumber(number/10);
		}
	}
		public static void main(String[] args){
			System.out.println("Enter the number you want to reverse : ");
			Scanner sc = new Scanner(System.in);
			int num = sc.nextInt();
			System.out.print("The Reverse of the given number is : " );
			//Method calling
			reversenumber(num);
			sc.close();
		}
}