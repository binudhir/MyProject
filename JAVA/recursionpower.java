import java.util.*;
public class recursionpower{
static int pow(int A,int B, int C){
if(A==0 && B==0)
return 0;
if(B==0)
return 1;
long power=pow(A,B/2,C);
long modpower=(power%C * power%C)%C;
if(B%2==1){
modpower=(modpower%C * A%C)%C;
}
modpower=(modpower+C)%C;
return (int) modpower;
}
public static void main(String[] args){
System.out.println("Enter the Base Value :");
Scanner sc=new Scanner(System.in);
int a=sc.nextInt();
System.out.println("Enter the Power Value :");
int b=sc.nextInt();
System.out.println("Enter the Mod Value :");
int c=sc.nextInt();
System.out.println("Output for "+a+"^"+b+"%"+c+"="+ pow(a,b,c));
sc.close();
}
}
