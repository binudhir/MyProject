import java.util.*;
//import java.lang.*;
public class hcf{
public static void main(String[] args){
    System.out.println("Enter the Number :");
    Scanner sc = new Scanner(System.in);
    int t = sc.nextInt();
    while (t>0){
    int a = sc.nextInt();
    int b = sc.nextInt();
    hcfresult(a,b);
    t--;
    }
    sc.close();
}
    static void hcfresult(int a, int b){
        while (a>0){
        int temp = b;
        b=a;
        a=temp%a;    
        }
    System.out.println(b);
    }
    
}
