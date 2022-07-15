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
        li.remove(5);
        System.out.println(li);
        li.remove("is");
        li.remove(3);
        System.out.println(li);
        li.add("is");
        li.add("a");
        li.add("good");
        li.add("Person");
        System.out.println(li);
        for(int i=0; i<li.size(); i++){
            System.out.print(li.get(i) + " ");
        }
        System.out.println();
        for(String str : li){
            System.out.print(str + " ");
        }
        System.out.println();
    }
}