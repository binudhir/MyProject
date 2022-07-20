import java.util.Scanner;

public class MainEmp{
    static boolean ordering=true;
    public static void menu() {
        System.out.println("**********Welcome To Employee Management System********** "
        + "\n1. Add Employee "
        + "\n2. View Employee"
        + "\n3. Update Employee"
        + "\n4. Delete Employee"
        + "\n5. View All Employee"
        + "\n6. Exit ");
    }
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        EmployeeService empservice=new EmployeeService();
        do{
            menu();
            System.out.println("Enter your Choice :");
            int ch=sc.nextInt();
            switch(ch){
                case 1:
                System.out.println("Add Employee");
                empservice.addEmp();
                break;
                case 2:
                System.out.println("View Employee");
                empservice.viewemp();
                break;
                case 3:
                System.out.println("Update Employee");
                empservice.updateEmp();
                break;
                case 4:
                System.out.println("Delete Employee");
                empservice.DeleteeMP();
                break;
                case 5:
                System.out.println("View All Employee");
                empservice.viewAllEmps();
                break;
                case 6:
                System.out.println("Thank you for using the Application");
                System.exit(0);
                default:
                System.out.println("Please Enter a Valid Choice");
                break;
            }
        }while(ordering);
       sc.close();
    }
}