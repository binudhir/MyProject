//import java.lang.*;
import java.util.*;
public class sumdigit{
public static void main(String[] args){
int n,o,p=0;    
System.out.println("Enter the Test case number :");
    Scanner sc = new Scanner(System.in);
    int t = sc.nextInt();
    for (int i=0; i<t; i++){
        n = sc.nextInt();
        while (n>0){
        o = n%10;
        p=p+o;
        n=n/10;
        }
        System.out.println(p);
        p = 0;
    }
    sc.close(); 
  }
}
