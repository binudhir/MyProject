public class carryforward{
public static void main(String[] args){
    int ar[]={7, 3, 2, -1, 6, 8, 2, 3};
for(int i=0; i<ar.length; i++){
    int sum=0;
    for(int j=i; j<ar.length; j++){
    sum=sum+ar[j];
    System.out.print(sum + " ");
    }
System.out.println();
}
}
}
