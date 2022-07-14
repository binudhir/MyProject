import java.util.*;
//import java.lang.*;
public class naturalnumber{
public static void main(String[] args){
    System.out.println("Enter the Number : ");    
    Scanner sc = new Scanner(System.in);
    int n = sc.nextInt();
    naturalnumber obj = new naturalnumber();
    obj.natural(n,1);
    sc.close();
}
    int natural(int y, int i){
    if (i<=y){
    System.out.print(i + " ");
    return(natural(y,i++));
    }
    return 1;
    }
}
