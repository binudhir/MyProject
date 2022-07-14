//You are given values of coefficients A, B and C of a quadratic equation : A * X2 + B * X + C = 0.
import java.util.*;
public class rootsquadratic{
public static void main(String[] args){
        System.out.println("Enter the 3 Numbers :");        
        Scanner s = new Scanner(System.in);
        int A=s.nextInt();
        int B=s.nextInt();
        int C=s.nextInt();
        int ans=(B*B)-(4*A*C);
        if(ans>0)
        System.out.println(1);
        else if(ans==0)
        System.out.println(0);
        else
        System.out.println(-1); 
        s.close();
}
}
