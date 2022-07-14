//Given a String. Return the opposit case. If Lowercase then return the upper case.
import java.util.*;
public class stringcase{
public static void main(String[] args){
    System.out.println("Enter a word or Sentence.");
    Scanner sc=new Scanner(System.in);
    String s=sc.nextLine();
    char strArr[] = s.toCharArray();
    for (int i = 0; i < strArr.length; i++) {
    // here is the actual logic
        if (strArr[i] >= 'a' && strArr[i] <= 'z')
        strArr[i] = (char) ((int) strArr[i] - 32);
        else if (strArr[i] >= 'A' && strArr[i] <= 'Z')
        strArr[i] = (char) ((int) strArr[i] + 32);
    }
    // print the string array
    for (int i = 0; i < strArr.length; i++) {
    System.out.print(strArr[i]);
    }
     System.out.println();
     sc.close();
}
}
