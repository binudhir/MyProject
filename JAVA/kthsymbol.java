//Given row A and index B, return the Bth indexed symbol in row A. (The values of B are 1-indexed.) (1 indexed).
import java.util.*;
public class kthsymbol{
static int result(int n, int k){
if(n==0)
return 0;
int parent=result(n-1,(k/2+k%2));
int kodd=k%2;
//System.out.println("parent " + parent);
//System.out.println("kodd " + kodd);
if(parent==1)
    if(kodd==1)
    return 1;
    else
    return 0; 
else
    if(kodd==1)
    return 0;
    else
    return 1;
}
public static void main(String[] args){
System.out.println("Enter the two Number :");
Scanner sc=new Scanner(System.in);
int A=sc.nextInt();
int B=sc.nextInt();
System.out.println("The number found in "+A+"th Row and "+B+"th Position is " +result(A,B));
sc.close();
}
}
