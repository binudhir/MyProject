import java.util.*;
public class excelnumber{
static int exceltonumber(String A){
    int n=A.length();
    int ans=0;
    for(int i=0; i<n; i++){
        ans*=26;
        ans+=A.charAt(i)-'A'+1;
    }
    return ans;
}

public static void main(String[] args){
System.out.println("Enter the Excel Column Index :");
Scanner sc=new Scanner(System.in);
String s=sc.next();
System.out.println("The Excel Cell number is " + exceltonumber(s));
sc.close();
}
}
