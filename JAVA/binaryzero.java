import java.util.*;
//import java.lang.*;

public class binaryzero{
static int CountTrailingZeros(int n)
    {  
        String bit = Integer.toBinaryString(n);
        StringBuilder bit1 = new StringBuilder();
        bit1.append(bit);
        bit1=bit1.reverse();
        int zero = 0;
      
        for (int i = 0; i < 64; i++) {
            if (bit1.charAt(i) == '0')
                zero++;
            // if '1' comes then break
            else
                break;
        }
      
        return zero;
    }




public static void main(String[] args){
System.out.println("Enter the Number: ");
Scanner sc = new Scanner(System.in);
int n=sc.nextInt();
int ans= CountTrailingZeros(n);
System.out.println(ans);
sc.close();
}
}
