import java.util.*;

public class arrayrotation{
public static void main(String[] args){
    System.out.println("Enter the Size of Array: ");
    Scanner sc = new Scanner(System.in);
    int n=sc.nextInt();
    int[] arr = new int[n];
    int[] arr1 = new int[n];
    // Accept the Array  
    for(int t=0; t<n; t++){
    arr[t]=sc.nextInt();    
    }
    // Print the Array
    System.out.println("The Array is : ");
    for (int i=0; i<n; i++){  
    System.out.print(arr[i]+ " ");  
    }  
    // Rotate the Array
    for(int i=0; i<n; i++){
        int j = (i+3)%n;
        arr1[j]=arr[i];    
    }
    // Print the Array after rotation
    System.out.println("The Final Array after rotation is : ");
    for (int i=0; i<n; i++){  
    System.out.print(arr1[i]+ " ");  
    }
      
    sc.close();
}
}
