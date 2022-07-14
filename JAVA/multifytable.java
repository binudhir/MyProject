import java.util.*;
//import java.lang.*;
public class multifytable{
  public static void main(String[] args){
  System.out.println("Enter the Number :");
  Scanner sc = new Scanner(System.in);
  int n = sc.nextInt();
    for (int i=1; i<=10;i++){
    System.out.println(n + " * " + i + " = " + (n*i));  
    }
    sc.close();
  }
}
