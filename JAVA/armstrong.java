import java.util.*;
public class armstrong{
	public static void main(String[] args){
        int num=0, arm=0, result=0, chk;
        System.out.println("Enter the Number : ");        
        Scanner sc = new Scanner(System.in);		
        num = sc.nextInt();
        chk=num;
		//Using the While loop
		while(num!=0){
			arm=num%10;
			num = num/10;
            arm=arm*arm*arm;
            result=result + arm;
		}
        if (result==chk)
	    System.out.println(chk + " is an Armstrong Number.");
        else
        System.out.println(chk + " is not an Armstrong Number.");
        sc.close();
	}
	
}
