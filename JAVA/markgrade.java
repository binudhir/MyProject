import java.util.*;
//import java.lang.*;
public class markgrade{
public static void main(String[] args){
System.out.println("Enter the 5 Marks : ");
Scanner sc = new Scanner(System.in);
int a = sc.nextInt();
int b = sc.nextInt();
int c = sc.nextInt();
int d = sc.nextInt();
int e = sc.nextInt();
int mark = (a + b + c + d + e)/5;
    if (mark>=90)
    System.out.println(mark + " A");
    else if (mark>=80)
    System.out.println(mark + " B");
    else if(mark>=70)
    System.out.println(mark + " C");
    else if (mark>=60)
    System.out.println(mark + " D");
    else if (mark>=40)
    System.out.println(mark + " E");
    else
    System.out.println(mark + " F");
    sc.close();
  }
}
