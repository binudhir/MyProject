import java.util.*;
//import java.lang.*;
public class fullpyramid{
public static void main(String[] args){
    System.out.println("Enter the Number:");
    int n,k=0,i,count=0,count1=0;    
    try (Scanner sc = new Scanner(System.in)) {
        n = sc.nextInt();
        for (i=1; i<=n; i++){
            for (int j=1; j<=n-i; j++){
            System.out.print(0 + " ");
            count++;
            }
            while (k!=2* i-1){
                if (count<=n-1){
                    System.out.print((i+k) + " ");
                    count++;
                }
                else{
                    count1++;
                    System.out.print((i+k)-(2*count1) + " ");
                }
            k++;
            }
            for (int j=1; j<=n-i; j++){
            if (j<0)        
            System.out.print(0);
            else
            System.out.print(0 + " ");
            count++;
            }
            count1=count=k=0;        
            System.out.println();
        }
        sc.close();
    }
}
}
