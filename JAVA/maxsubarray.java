//import java.lang.*;
public class maxsubarray{
public static void main(String[] args){
int ar[]={1, 2, 4, 4, 5, 5, 5, 7, 5 };
int n=ar.length;
int B=14;
int maxsum=ar[0];
    for(int i=0; i<n; i++){
        int sum=0;        
        for(int j=i; j<n; j++){
            sum+=ar[j];
            //maxsum=Math.max(maxsum,sum);
            if(maxsum<sum && sum<=B){
               maxsum=sum;
               System.out.print(j +" ");
            }
        }
    }
    System.out.println("Max Sum is " + maxsum);
}
}
