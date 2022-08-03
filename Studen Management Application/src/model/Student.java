package model;

public class Student {
    private int rollnum;
    private String name;
    private String clgname;
    private String city;
    private int mark;
    private double percentage;


    public Student(){

    }

    public Student(String name, String clgname, String city, int mark, double percentage) {
        this.name = name;
        this.clgname = clgname;
        this.city = city;
        this.mark = mark;
        this.percentage = percentage;
    }
    public Student(int rollnum, String name, String clgname, String city, int mark, double percentage) {
        this.rollnum = rollnum;
        this.name = name;
        this.clgname = clgname;
        this.city = city;
        this.mark = mark;
        this.percentage = percentage;
    }
    public int getRollnum() {
        return rollnum;
    }
    public void setRollnum(int rollnum) {
        this.rollnum = rollnum;
    }
    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public String getClgname() {
        return clgname;
    }
    public void setClgname(String clgname) {
        this.clgname = clgname;
    }
    public String getCity() {
        return city;
    }
    public void setCity(String city) {
        this.city = city;
    }
    public int getMark() {
        return mark;
    }
    public void setMark(int mark) {
        this.mark = mark;
    }
    public double getPercentage() {
        return percentage;
    }
    public void setPercentage(double percentage) {
        this.percentage = percentage;
    }

    @Override
    public String toString() {
        return "Student [city=" + city + ", clgname=" + clgname + ", mark=" + mark + ", name=" + name + ", percentage="
                + percentage + ", rollnum=" + rollnum + "]";
    }

    

}
