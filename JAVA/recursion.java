import java.util.*;
public class recursion{  
    public static void main(String[] args) {
    System.out.println("Enter the Number :");
    Scanner sc = new Scanner(System.in);        
    int a = sc.nextInt();
    display(a); 
    sc.close();   
    }
     
    // print 1 to n
    private static void display(int n) {
        if (n > 1) {
            display(n - 1);
        }
        System.out.print(n + " ");
    }
}
