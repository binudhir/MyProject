import java.util.*;
//import java.lang.*;
public class vowel{
public static void main(String[] args){
    System.out.println("Enter the Letter: ");
    Scanner sc = new Scanner(System.in);
    char c = sc.next().charAt(0);
    if (c=='a' || c=='e' || c=='i' || c=='o' || c=='u')
    System.out.println(c + " is a Vowel.");
    else
    System.out.println(c + " is a Consonant.");
    sc.close();   
  }
}
