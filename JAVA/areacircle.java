import java.util.*;
//import java.lang.*;
public class areacircle{
public static void main(String[] args){
    System.out.println("Enter the Radious :");
    Scanner sc = new Scanner(System.in);
    int a = sc.nextInt();
    double pie=Math.acos(-1);
    double area = pie*a*a;
    System.out.println("Volume of the sphere="+Math.ceil(area));
    sc.close();
  }
}
