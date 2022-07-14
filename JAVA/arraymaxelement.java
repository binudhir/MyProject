import java.util.*;

public class arraymaxelement{
public static void main(String[] args){
    System.out.println("Enter the size of Array: ");
    Scanner sc = new Scanner(System.in);
    int n = sc.nextInt();  // Declare Array Size
    int A[]=new int[n];
    for(int i=0; i<n; i++){ // Input the Array
    A[i]=sc.nextInt();
    }
    System.out.println("Enter the Finding Number: ");
    int b=sc.nextInt();  //Input the Search Number
    int flg=0, cnt=0;
    for(int i=0; i<n; i++){  //Find the Number
    if(A[i]==b)
        flg=1;
    if(A[i]>b)
    cnt++;
    }
    if(flg==0)
    System.out.println("The number not Match with Array Data.");
    else
    System.out.println("The number become maximum after remove " + cnt + " numbers.");    
sc.close();

}
}
