//import java.lang.*;
import java.util.*;
public class binarytodec{
public static void main(String[] args){
   System.out.println("Enter the Number :");
    Scanner sc = new Scanner(System.in);
    long a = sc.nextLong();
    long res=0;
    int count=0;
    while (a!=0){
    int pow=1;
        for(int i=1; i<=count; i++){
        pow*=2;        
        }
        res=res+pow*(a%10);
        a/=10;
        count++;    
    }    
    System.out.println(res);
    sc.close();
  }
}
