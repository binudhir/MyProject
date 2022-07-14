import java.util.*;
//import java.lang.*;

public class factorialzero{
static int findTrailingZeros(int n)
    {
        if (n < 0) // Negative Number Edge Case
            return -1;
 
        // Initialize result
        int count = 0;
 
        // Keep dividing n by powers
        // of 5 and update count
        for (int i = 5; n / i >= 1; i *= 5)
            count += n / i;
 
        return count;
    }
 
    // Driver Code
    public static void main(String[] args)
    {
        System.out.println("Enter the Number: ");
        Scanner sc = new Scanner(System.in);
        int n=sc.nextInt();
        System.out.println("Count of trailing 0s in " + n + "! is " + findTrailingZeros(n));
        sc.close();
    }


}
