public class recursionfibonacci{
static int fib(int n){
if(n==1 || n==2)
return 1;
else
return fib(n-1)+fib(n-2);
}
public static void main(String[] args){
int n=10;
System.out.println("The fibonacci number of "+ n + " is : " + fib(n));
}
}
