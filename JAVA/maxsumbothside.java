public class maxsumbothside{
static int msxsum(int[]A, int B){
    int n=A.length;
    int i=0, j=n-1;
    int sum=0, b2=B;
    while(B>0){
        sum += A[i++];
        B--;
    }
    int ans=sum;
    while(b2>0){
        sum -= A[--i];
        sum += A[j--];
        ans=Math.max(ans,sum);
        b2--;
    }
return ans;

}

public static void main(String[] args){
int arr[]={5, -2, 3 , 1, 2};
int b=3;
System.out.println(msxsum(arr,b));

}
}
