import java.util.*;
class factorial{
    static int fact(int a){
        if (a!=0){ //termination condition
            return (a * fact(a-1)); //recursive call
        }    
        else {
            return 1;
        }
    }
    public static void main(String[] args){
    System.out.println("Enter the Numer : ");
    Scanner sc = new Scanner(System.in);
    int num = sc.nextInt();
    int result = fact(num);
    System.out.println("The Factorial of " + num + " is " + result);
    sc.close();
    }
}
