import java.util.*;
//import java.lang.*;
public class volumesphere{
public static void main(String[] args){
    System.out.println("Enter the Radious :");
    Scanner sc = new Scanner(System.in);
    int a = sc.nextInt();
    double pie = Math.acos(-1);
    double volume = ((4.0/3.0)*pie*a*a*a);
    System.out.println("Volume of the sphere="+Math.ceil(volume));
    sc.close();
  }
}
