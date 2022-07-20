import java.util.HashMap;
import java.util.HashSet;
import java.util.Scanner;

public class EmployeeService {
    HashSet<Employee> empset= new HashSet<Employee>();
    
    Employee emp1=new Employee(101, "Binod", 34, "IT", "Sys Admin", 55000);
    Employee emp2=new Employee(102, "Josef", 28, "LAB", "Microbiologist", 45000);
    Employee emp3=new Employee(103, "Pushpa", 27, "Office", "Clerk", 35000);
    Employee emp4=new Employee(104, "Puja", 24, "Store", "Manager", 55000);
    Employee emp5=new Employee(105, "Mukesh", 20, "IT", "Marketing", 75000);
    Employee emp6=new Employee(106, "Debabrata", 35, "Office", "Marketing Executive", 95000);

    Scanner sc=new Scanner(System.in);
    boolean found =false;
    int id;
    String name;
    int age;
    String department;
    String designation;
    double sal;

    public EmployeeService(){
        empset.add(emp1);
        empset.add(emp2);
        empset.add(emp3);
        empset.add(emp4);
        empset.add(emp5);
        empset.add(emp6);
    }

    //View all Employee
    public void viewAllEmps(){
        for(Employee emp:empset){
            System.out.println(emp);
        }
    }

    //view employee based on their ID
    public void viewemp(){        
        System.out.println("Enter Employee ID :");
        id=sc.nextInt();
        for(Employee emp:empset){
            if(emp.getId()==id){
                System.out.println(emp);
                found=true;
            }
        }
        if(!found){
            System.out.println("Employee with this id Not Found.");
        }
    }

    //Update the Employee
    public void updateEmp(){
        System.out.println("Enter the Employee ID :");
        id=sc.nextInt();
        boolean found=false;
        for(Employee emp:empset){
            if(emp.getId()==id){
                System.out.println("Enter correct name :");
                name=sc.next();
                System.out.println("Enter correct age :");
                age=sc.nextInt();
                System.out.println("Enter correct Department :");
                department=sc.next();
                System.out.println("Enter correct Designation :");
                designation=sc.next();
                System.out.println("Enter correct Salary :");
                sal=sc.nextDouble();

                emp.setName(name);
                emp.setAge(age);
                emp.setDept(department);
                emp.setDesg(designation);
                emp.setSalary(sal);

                System.out.println("Updated details of Employee are: ");
                System.out.println(emp);
                found=true;
            }           
        }
        if(!found){
            System.out.println("Employee is not found.");
        }
        else{
            System.out.println("Employee details Updated Successfully !!");
        }
    }

    //Delete Employee
    public void DeleteeMP(){
        boolean found=false;
        System.out.println("Enter Employee ID :");
        id=sc.nextInt();
        Employee empdelete=null;
        for(Employee emp:empset){
            if(emp.getId()==id){
                empdelete=emp;
                found=true;
            }
        }
        if(!found){
            System.out.println("Employee is not found.");
        }
        else{
            empset.remove(empdelete);
            System.out.println("Employee Deleted Successfully.");
        }
    }

    //add Employee
    public void addEmp(){
        System.out.println("Enter ID :");
        id=sc.nextInt();
        System.out.println("Enter name :");
        name=sc.next();
        System.out.println("Enter age :");
        age=sc.nextInt();
        System.out.println("Enter Department :");
        department=sc.next();
        System.out.println("Enter Designation :");
        designation=sc.next();
        System.out.println("Enter Salary :");
        sal=sc.nextDouble();

        Employee emp=new Employee(id, name, age, department, designation, sal);
        empset.add(emp);
        System.out.println(emp);
        System.out.println("Employee Added Successfully");
    }
}
