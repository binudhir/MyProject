//Using recursion print the output.
public class recursion1{
static int count=0;
static void ex(){
count++;
if(count<=20){ //Condition to Break the Recursion
System.out.println(count + ".Hello, I am Binod Google Java Programmer.");
ex();
}
}
public static void main(String[] args){
ex();
}
}
