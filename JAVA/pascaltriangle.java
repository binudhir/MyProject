//Write a program to input an integer N from user and print pascal triangle up to N rows
import java.util.*;
public class pascaltriangle{
static void pascal(int n){
for(int l=1; l<=n; l++){
    for(int j=0; j<=n-l; j++){
        System.out.print(" ");
    }
    int c=1;
    for(int i=1; i<=l; i++){
        System.out.print(c + " ");
        c=c*(l-i)/i;
    }
System.out.println();
}
}
public static void main(String[] args){
System.out.println("Enter a Number :");
Scanner sc=new Scanner(System.in);
int n=sc.nextInt();
pascal(n);
sc.close();
}
}
