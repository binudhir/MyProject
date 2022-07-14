public class reverse{
	public static void main(String[] args){
		int number = 23456754, reverse=0;
		//Using the While loop
		while(number!=0){
			int reminder=number%10;
			reverse = reverse *10 + reminder;
			number = number/10;
		}
	System.out.println("The Reverse Number is : " + reverse);
	}
	
}