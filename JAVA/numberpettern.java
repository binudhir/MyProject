//Print the Number Pattern
//import java.lang.*;
import java.util.*;

public class numberpettern{
public static void main(String[] args){
    System.out.println("Enter the Number:");
    Scanner sc = new Scanner(System.in);
    int n = sc.nextInt();
    for (int i=0; i<n; i++){
    int p=1;
    for (int j=0; j<=i; j++){
        System.out.print(p + " ");
        p++;    
        }    
        System.out.println();
    }
    sc.close(); 
 }
}
