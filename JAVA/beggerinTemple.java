public class beggerinTemple {
    public static int[] solve(int A, int[][] B) {
        int[] coins=new int[A];
        for(int i=0;i<A;i++)coins[i]=0;
        for(int i = 0; i < B.length; i++) {
        int leftIndex = B[i][0] - 1, rightIndex = B[i][1] - 1; 
        int donationByDevotee = B[i][2];
        coins[leftIndex] += donationByDevotee;
        if ((rightIndex + 1) < A) coins[rightIndex + 1] -= donationByDevotee;
    }
    for(int i = 1; i < A; i++){
        coins[i] += coins[i - 1];
    }        
    return coins;
    }


    public static void main(String[] args) {
        int n=5;
        int[][] A={{1, 2, 10}, {2, 3, 20}, {2, 5, 25}};
        int[] B = solve(n, A);
        for(int i=0; i<B.length; i++){
           System.out.print(B[i] + " ");        
        }
        System.out.println();
    }
}
