public class Employee {
    private int id;
    private String name;
    private int age;
    private String dept;
    private String desg;    
    private double salary;


    public int getId() {
        return id;
    }
    public void setId(int id) {
        this.id = id;
    }
    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public int getAge() {
        return age;
    }
    public void setAge(int age) {
        this.age = age;
    }
    public String getDept() {
        return dept;
    }
    public void setDept(String dept) {
        this.dept = dept;
    }
    public String getDesg() {
        return desg;
    }
    public void setDesg(String desg) {
        this.desg = desg;
    }    
    public double getSalary() {
        return salary;
    }
    public void setSalary(double salary) {
        this.salary = salary;
    }
    @Override
    public String toString() {
        // TODO Auto-generated method stub
        return "Employee [id= "+ id +",name="+ name +",age="+ age +",department="+ dept 
        +",designation="+ desg +",salary="+ salary +" ]";
    }

    public Employee(int id, String name, int age, String department,String desiganation,  double salary) {
		super();
		this.id = id;
		this.name = name;
		this.age = age;
        this.dept = department;
		this.desg = desiganation;	
		this.salary = salary;
	}

    

}
