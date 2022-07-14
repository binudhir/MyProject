import java.util.*;
public class perfectsqure{
	public static void main(String[] args){
		System.out.println("Enter the Number :");
		Scanner sc = new Scanner(System.in);
        int N = sc.nextInt();
        double sqr;
        sqr = Math.sqrt(N);
        System.out.println(sqr);        
        if (sqr*sqr==N)
        System.out.println("Perfect");
        else
        System.out.println("Not Perfect");
        sc.close();
	}
}
