import java.util.*;
public class recursionevensum{
static int SumEven(int A){
//if(A>B)
//return 0;
//return (A+SumEven(A+2,B));
if(A%2==1) return SumEven(A+1);
return A + SumEven(A+2);
}
public static void main(String[] args){
System.out.println("Enter the Number :");
Scanner sc=new Scanner(System.in);
//int num1=2;
int num2=sc.nextInt();
System.out.println("Sum of Even Numbers of " + num2+ " is " + SumEven(num2));
sc.close();
}
}
