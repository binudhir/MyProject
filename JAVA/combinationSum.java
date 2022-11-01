public class combinationSum {
    static int result(int[] num, int target){
        int[] dp = new int[target + 1];
        dp[0] = 1;
        for (int i = 1; i <= target; i++)
            for (int nums : num)
                if (nums <= i) dp[i] += dp[i-nums];
        return dp[target];
    }

    public static void main(String[] args) {
        int[] arr={1,2,3};
        int t=4;
        System.out.println(result(arr, t));
    }
}
