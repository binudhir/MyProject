//Given a string A of size N, find and return the longest palindromic substring in A.Substring of string A is A[i...j] where 0 <= i <= j < len(A).
import java.util.*;
public class pallindromstring1{
static int longestPalindrome(String s) {
        if (s == null || s.length() < 1) return s.length();
        int start = 0, end = 0;
        for (int i = 0; i < s.length(); i++) {
            int len1 = expandAroundCenter(s, i, i);
            int len2 = expandAroundCenter(s, i, i + 1);
            int len = Math.max(len1, len2);
            if (len > end - start) {
                start = i - (len - 1) / 2;
                end = i + len / 2;
            }
        }
        return end - start + 1;
}
static int expandAroundCenter(String s, int left, int right) {
        int L = left, R = right;
        while (L >= 0 && R < s.length() && s.charAt(L) == s.charAt(R)) {
            L--;
            R++;
        }
        return R - L - 1;
}
public static void main(String[] args){
System.out.println("Enter the Words :");
Scanner sc=new Scanner(System.in);
String str=sc.next();
str=str.toLowerCase();//Convert to Lower case
System.out.println("Longest Pallindrome is :" + longestPalindrome(str));
sc.close();
}
}
