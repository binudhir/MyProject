public class minmax{

public static void main(String[] args){
        int A[]={-15,-45,43,23,-63,69,35,19,37,-52};
        int minval=Integer.MAX_VALUE,maxval=Integer.MIN_VALUE;
        for(int i=0; i<A.length; i++){
            if (A[i]%2==0)
            {
                maxval=Math.max(maxval,A[i]);
                //if(A[i]>max){
                //max=A[i];
                //}
            }
            if (A[i]%2!=0)
            {
                minval=Math.min(minval,A[i]);
                //if(A[i] < min){
                //min=A[i];
                //}
            }
        }
        System.out.println("Max of Even :" + maxval);
        System.out.println("Min of Odd :" + minval);
        System.out.println(maxval-minval);
}

}
