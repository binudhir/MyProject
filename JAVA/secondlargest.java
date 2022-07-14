import java.util.*;

public class secondlargest{
public static void main(String[] args){
    System.out.println("Enter Test Cases :");
    Scanner sc = new Scanner(System.in);
    int t=sc.nextInt();
    while(t>0){
        int n=sc.nextInt();
        int A[]=new int[n];
        for(int i=0; i<n; i++){
            A[i]=sc.nextInt();
        }
        int lrg=-1,slrg=-1,j=0;
        for(int i=0; i<n; i++){
            if(A[i]>lrg){
                lrg=A[i];
                j=i;
            }
        }
        for(int i=0; i<n; i++){
            if(j!=i)
                if(A[i]>slrg)
                slrg=A[i];
        }
    if(slrg!=-1)    
    System.out.println("The 1st Largest is "+ lrg + " and the Second Largest is " + slrg);
    else
    System.out.println("The second largest number Not Found.");    
    t--;
    }
    sc.close();
}
}
