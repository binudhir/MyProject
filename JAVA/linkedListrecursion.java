import java.util.Scanner;

import org.w3c.dom.html.HTMLFieldSetElement;

// Recursive Java program to reverse
// a linked list
public class linkedListrecursion {
    static Node head;  //Head of List
    static class Node{
        int data;
        Node next;
        Node (int d)    {data=d; next=null;}      
    }

    //Inser new Node to the LinkedList
    static void push(int data){
        Node temp=new Node(data);
        temp.next=head;
        head=temp;
    }

    //Function to Print Linkedlist
    static void print(Node head){
        Node temp=head;
        while(temp!=null){
            System.out.print(temp.data + " ");
            temp=temp.next;
        }
        System.out.println();
    }

    //Reverse the Linkedlist
    static Node reverselist(Node head){
        if (head==null || head.next==null) return head;
            // reverse the rest list and put the first element at the end
            Node rest=reverselist(head.next);
            head.next.next=head;
            
            //Tricky Step
            head.next=null;

            //fix the head pointer
            return rest;
    }

    public static void main(String[] args) {
        //Start with Empty List
        System.out.println("Enter the Number of Node for the LinkedList :");
        Scanner sc=new Scanner(System.in);
        int n=sc.nextInt();
        while(n!=0){
            int ll=sc.nextInt();
            push(ll);
            n--;
        }
        System.out.println("Given Linked List :");
        print(head);

        head=reverselist(head);
        System.out.println("After Reverse the List :");
        print(head);
    }

}
