//Given a string A of size N.Return the string A after reversing the string word by word.
import java.util.*;
//import java.lang.*;
public class reversestring{
static String revstr(String A){ 
    String[] words=A.trim().split(" +");
    String ans="";
    int n=words.length;
    for(int i=n-1; i>=0; i--){
        if(i==0){
        ans+=words[i];
        }
        else{
        ans+=words[i] + " ";
        }
    }
return ans;
}
public static void main(String[] args){
System.out.println("Enter a word or Sentence.");
Scanner sc=new Scanner(System.in);
String s=sc.nextLine();
System.out.println("The Reverse String is : " + revstr(s));
sc.close();
}
}
