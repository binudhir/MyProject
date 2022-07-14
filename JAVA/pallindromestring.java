//Program to check whether a string is a Palindrome
import java.util.*;
public class pallindromestring{
static boolean ispalindrome(String s){
int i=0, j=s.length()-1;
while(i<j){
if(s.charAt(i)!=s.charAt(j))
return false;//if there is any Mismatch
i++;
j--;
}
return true;//Given String is Palindrome
}
public static void main(String[] args){
System.out.println("Enter the Words :");
Scanner sc=new Scanner(System.in);
String str=sc.next();
str=str.toLowerCase();//Convert to Lower case
if(ispalindrome(str))
System.out.println(str + " is a pallindrome.");
else
System.out.println(str + " is not a pallindrome.");
sc.close();
}
}
