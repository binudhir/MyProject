//import java.lang.*;
import java.util.*;

public class searcharray {
    public static void main(String[] args) {
       System.out.println("Enter Test Cases: ");
        Scanner sc = new Scanner(System.in);
        int T=sc.nextInt();
        for(int j=0; j<T; j++){
            int n=sc.nextInt();
            int A[]=new int[n];
            for(int i=0; i<n; i++){
            A[i]=sc.nextInt();
            }
            System.out.println("Enter the Search Number: ");
            int B=sc.nextInt();
            int found=0;
            for(int i=0; i<n; i++){
            if (A[i]==B)
            found=1;
            }
            if (found==0)
            System.out.println("Not Found");
            else
            System.out.println("Found");
        }
        sc.close();
    }
}
