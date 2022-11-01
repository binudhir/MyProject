import java.util.*;

import dao.StudentDao;
import dao.StudentDaoInterface;
import model.Student;

public class Client{
    public static void main(String[] args) {
        StudentDaoInterface dao=new StudentDao();
        try (Scanner sc = new Scanner(System.in)) {
            System.out.println("Welcome to Student management System.");
            while(true){
                System.out.println("\n1. Add Student" +
                "\n2. Show All Student" +
                "\n3. Get Student using Roll Number" +
                "\n4. Delete Student" +
                "\n5. Update Student" +
                "\n6. Exit");
                System.out.println("Enter your choice :");
                int ch=sc.nextInt();
                switch (ch) {
                    case 1:                       
                        System.out.println("*****************Add Student*****************");
                        sc.nextLine();
                        System.out.println("Enter Student Name :");
                        String stdnm=sc.nextLine();
                        System.out.println("Enter Student's College Name :");
                        String clgnm=sc.nextLine();
                        System.out.println("Enter City :");
                        String citynm=sc.nextLine();
                        System.out.println("Enter Mark :");
                        int stdmark=sc.nextInt();
                        System.out.println("Enter Percentage :");
                        double stdper=sc.nextDouble();
                        Student st=new Student(stdnm, clgnm, citynm, stdmark, stdper);
                        boolean ans=dao.insertStudent(st);
                        if(ans){
                            System.out.println("Record Inserted Successfully...");
                        }
                        else
                        System.out.println("Something went Wrong. Please try Again.");
                        break;
                    case 2:
                        System.out.println("*****************Show All Student*****************");
                        dao.showAllStudent();
                        break;
                    case 3:
                        System.out.println("*****************Get Student Based on roll Number*****************");
                        System.out.println("Enter Roll Number :");
                        int roll=sc.nextInt();
                        boolean f = dao.showStudentById(roll);
                        if(!f)
                            System.out.println(roll + " is not found in System.");
                                             
                        break;
                    case 4:
                        System.out.println("*****************Delete Student*****************");
                        System.out.println("Enter Roll Number to delete");
                        int droll = sc.nextInt();
                        Boolean ff = dao.deleteStudednt(droll);
                        if(ff)
                        System.out.println("Record Deleted Successfully...");
                        else 
                        System.out.println("Something went Wrong.");
                        break;
                    case 5:
                        System.out.println("*****************Update the Student*****************");                       
                        System.out.println("Enter the Roll Number :");
                        int uroll=sc.nextInt();
                        System.out.println("\n1.Update Name\n2.Update College Name\n3.Update City\n4.Update Mark\n5.Update Percentage");
                        System.out.println("Enter Your Choice to update");
                        int choice=sc.nextInt();
                        boolean flag=false;
                        Student std=new Student();
                        sc.nextLine();
                        if(choice==1){
                            System.out.println("Enter new Name :");
                            String sname=sc.nextLine();                           
                            std.setName(sname);
                             flag = dao.updateStudent(uroll, sname, choice, std);
                            if(flag)
                            System.out.println("Name Updated Successfully...");
                            //else
                            //System.out.println("Something went Wrong");                        
                        }
                        else if(choice==2){
                            System.out.println("Enter new College Name :");
                            String clg_nm=sc.nextLine();                            
                            std.setClgname(clg_nm);
                             flag =dao.updateStudent(uroll, clg_nm, choice, std);
                            if(flag)
                            System.out.println("College Name Updated Successfully...");
                            //else
                            //System.out.println("Something went Wrong");      
                        }
                        else if(choice==3){
                            System.out.println("Enter updated City :");
                            String city_nm=sc.nextLine();
                            std.setCity(city_nm);
                            flag=dao.updateStudent(uroll, city_nm, choice, std);
                            if(flag)
                            System.out.println("City Updated Successfully...");
                        }
                        else if(choice==4){
                            System.out.println("Enter updated mark :");
                            int mrk=sc.nextInt();
                            std.setMark(mrk);
                            String std_mrk=String.valueOf(mrk);
                            flag=dao.updateStudent(uroll, std_mrk, choice, std);
                            if(flag)
                            System.out.println("Mark Updated Successfully...");
                        }
                        else if(choice==5){
                            System.out.println("Enter updated Percentage :");
                            Double per=sc.nextDouble();
                            std.setPercentage(per);
                            String std_per=String.valueOf(per);
                            flag=dao.updateStudent(uroll, std_per, choice, std);
                            if(flag)
                            System.out.println("Percentage Updated Successfully...");
                        }
                        else{
                            System.out.println("Not a Valid choice");
                            break;
                        }
                        if(!flag)
                        System.out.println("Something went Wrong.");
                        break;
                    case 6:
                        System.out.println("Thank you for Using Student Management Application.");
                        System.exit(0);
                    default:
                        System.out.println("Please Enter Valid Choice. Thank you");
                                        
                }
            }
        }
    }
}