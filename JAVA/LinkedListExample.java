// Java program to add elements 
// to a LinkedList
import java.util.*; 
public class LinkedListExample{
    public static void main(String[] args) {
        LinkedList <String> li=new LinkedList<>();
        li.add("Binod");
        li.add("Dhir");
        li.add(1,"Bihari");
        System.out.println(li);
        li.add("is");
        li.add("Good");
        li.add("Good.");
        System.out.println("Initial Linkedlist" + li);
        li.set(5, "Programmer.");
        System.out.println("Updated Linkedlist" + li);
    }
}