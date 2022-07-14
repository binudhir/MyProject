import java.util.*;
//import java.lang.*;
public class power{
public static void main(String[] args){
System.out.println("Enter the Base Number :");
long power=1;
Scanner sc = new Scanner(System.in);
int a = sc.nextInt();
System.out.println("Enter the Power :");
int b = sc.nextInt();
    for (int i = 0; i<b; i++){
        power = power * a;
    }
    System.out.println("The result is " + power);
    sc.close();
  }
}
