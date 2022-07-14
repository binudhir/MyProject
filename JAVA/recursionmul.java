import java.util.*;
public class recursionmul{
static int mul(int a, int b){
if(a<b)//Check if A less thyen B then Swap
return mul(b,a);
else if(b!=0)//if B Not eqal to Zero then iterate B time A sum
return (a+mul(a,b-1));
else
return 0;
}
public static void main(String[] args){
System.out.println("Enter the Number for Multiplication");
Scanner sc=new Scanner(System.in);
int n=sc.nextInt();
int m=sc.nextInt();
System.out.println(n + " X " + m + " = " + mul(n,m));
sc.close();
}
}
