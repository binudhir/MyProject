//Using recursion solve the Tower of Hanoi Steps.
import java.util.*;

public class TowerofHanoi{
    static int count=1;
static void TOH(int n,char source, char destination, char temp){
    //count--;
if (n==0){
    return;
}
TOH(n-1, source, temp, destination);
System.out.println("Step-"+ (count++) +"  Move Disk "+n+ " from Tower "+source+" To "+ destination);
TOH(n-1, temp, destination, source);

}
    public static void main(String[] args) {
        System.out.println("Enter the No of Disk :");
        Scanner sc = new Scanner(System.in);      
        int n=sc.nextInt();
        TOH(n, 'A', 'C', 'B');
        sc.close();
    }
}