import java.util.Scanner;

public class areaCircle{
    static Scanner sc=new Scanner(System.in);
interface shape{
    void input();
    void area();
}
static class Circle implements shape{
    int r=0;
    double pi=3.14,ar=0;
    @Override
    public void input() {
        // TODO Auto-generated method stub
        System.out.println("Enyter the Radious :");
        r=sc.nextInt();
    }
    @Override
    public void area() {
        // TODO Auto-generated method stub
        ar=pi*r*r;
        System.out.println("Area of Circle : " + ar);
    }    
}

static class Rectangle extends Circle{
    int l=0, b=0;
    double ar;
    public void input(){
        super.input();
        System.out.println("Enter the length :");
        l=sc.nextInt();
        System.out.println("Enter the Width :");
        b=sc.nextInt();
    }
    public void area(){
        super.area();
        ar=l*b;
        System.out.println("Area of the rectangle is :" + ar);
    }
}

public static void main(String[] args) {
    Rectangle obj = new Rectangle();
    obj.input();
    obj.area();
}

}