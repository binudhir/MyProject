//Given a binary string A. It is allowed to do at most one swap between any 0 and 1. Find and return the length of the longest consecutive 1’s that can be achieved.
//import java.lang.*;
import java.util.*;
public class consecutive{
static int result(String A){
    int st=0,z=0,j=1,ans=0,onecnt=0;
    for(int i=0; i<A.length(); i++){
        if(A.charAt(i)=='1'){
        onecnt++;//Count all 1
        }
        if(A.charAt(i)=='0'){
        z++;//Count all 0
        }
        while(z>j){
            if(A.charAt(st)=='0'){
            z--;
            }
        st++;//Start Count
        }
        
    ans=Math.max(ans, i-st+1);
    }
    return Math.min(ans,onecnt);
}
public static void main(String[] args){
System.out.println("Enter a Binary Number");
Scanner sc=new Scanner(System.in);
String s=sc.next();
System.out.println("Length of the longest consecutive 1 is : " + result(s));
sc.close();
}
}
