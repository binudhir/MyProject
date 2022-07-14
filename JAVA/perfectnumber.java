import java.util.*;
public class perfectnumber{
	public static void main(String[] args){
		System.out.println("Enter the Number :");
		Scanner sc = new Scanner(System.in);
        int N = sc.nextInt();
        int A=0,sum=0;
        for(int i=0; i<N; i++){
            A = sc.nextInt();
            sum = 0;
            for(int j=1; j<A; j++){
                if (A%j==0){
                    sum=sum+j;
                }
            }
            if (sum==A)
            System.out.println("YES");
            else
            System.out.println("NO");
        }
        sc.close();
	}
}
