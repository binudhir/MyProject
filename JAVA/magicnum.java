//Given an integer A, find and return the Ath magic number.
import java.util.*;
public class magicnum{
static int num(int A){
int x=1, ans=0;
while(A>0){
x=x*5;
if(A%2==1)
ans+=x;
A/=2;
}
return ans;
}
public static void main(String[] args){
System.out.println("Enter the Number :");
Scanner sc=new Scanner(System.in);
int N=sc.nextInt();
System.out.println("The magic number of "+N+" is " + num(N));
sc.close();
}
}
