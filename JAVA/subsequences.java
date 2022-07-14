//You have given a string A having Uppercase English letters. You have to find that how many times subsequence "AG" is there in the given string.
import java.util.*;
public class subsequences{
static int result(String S){
int ans=0,cnt=0;
for(int i=S.length()-1; i>=0; i--){
    char c=S.charAt(i);
    if(c=='G'){
        cnt++;
    }
    if(c=='A'){
        ans+=cnt;
    }
}
return ans;
}
public static void main(String[] args){
System.out.println("Enter a String which have A and G");
Scanner sc=new Scanner(System.in);
String s=sc.next();
System.out.println(result(s) + " times the A and G is found.");
sc.close();
}
}

