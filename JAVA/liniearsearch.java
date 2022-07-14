//import java.util.*;
public class liniearsearch{
public static int lsearch(int[] arr, int key){
    for(int i=0; i<arr.length; i++){
        if(arr[i]==key){
        return i;        
        }
    }
    return -1;    
}
public static void main(String a[]){
    int[] a1 = {10,20,30,50,70,90};
    int num = 50;
    System.out.println(num+" is found at index: "+lsearch(a1,num));
} 

}
