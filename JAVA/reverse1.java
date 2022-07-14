public class reverse1{
public static void main (String[] args){
	int number = 123456789, reverse=0;
	//We are using the for loop and not memntion the initialization for the loop
	for (;number!=0;number=number/10){
		int reminder=number%10;
		reverse=reverse*10 + reminder;
		}
		System.out.println("The Reverse number comes after the for loop is " + reverse);
	}
}