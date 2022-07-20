import java.util.Scanner;

public class MainClass {

    public static void main(String[] args) {
        AtmOperationInterf op = new AtmOperationImpl();
        int atmnumber=12345678;
        int atmpin=1234;
        Scanner in = new Scanner(System.in);
        System.out.println("Welcome to Binu's ATM Machine !!!");
        System.out.println("Enter ATM Number :");
        int atmnum=in.nextInt();      
        System.out.println("Enter the ATM PIN :");
        int pin=in.nextInt();
        if(atmnumber == atmnum && atmpin == pin){
            //System.out.println("Validation Done.");            
            while(true){
                System.out.println("1.View Available Balance\n2.Withdraw Amount\n3.Diposit Amount\n4.View Ministatement\n5.Exit");
                System.out.println("Enter Your Choice :");
                int ch=in.nextInt();
                if(ch==1){
                  op.viewBalance();  
                }
                else  if(ch==2){
                    System.out.println("Enter Amount to Withdraw :");
                    double withdrawamt = in.nextDouble();
                    op.withdrawAmount(withdrawamt);
                }
                else  if(ch==3){
                    System.out.println("Enter Amount to Deposit :");
                    double depoamt = in.nextDouble();                    
                    op.depositAmount(depoamt);
                }
                else  if(ch==4){
                    op.viewMiniStatement();
                }
                else  if(ch==5){
                    System.out.println("Collect Your ATM Card !\nThank you for using ATM Machine !!\nVisit Again !!!");
                    System.exit(0);
                }
                else{
                    System.out.println("Please Enter Correct Choice.");
                }
            }
        }
        else{
            System.out.println("Incorrect ATM Number or PIN.");
            System.exit(0);
        }
        in.close();

    }
    
}
