import java.util.*;

public class LinkedListReverse {
    Node head; //Head of the List

    /* Linked list Node*/
    class Node{
        int data;
        Node next;
        Node (int d) {data=d; next=null;}
    }

    /* Inserts a new Node at front of the list. */
    public void push(int new_data){
        /* 1 & 2: Allocate the Node & Put in the data*/
        Node new_node=new Node(new_data);

        /* 3. Make next of new Node as head */
        new_node.next=head;

         /* 4. Move the head to point to new Node */
         head=new_node;
    }

    /* Utility Functions */
    /* function to print the elements of the linked list*/
    void printList(Node head){
        Node curr=head;
        while(curr!=null){
            System.out.print(curr.data + " -> ");
            curr=curr.next;
        }
        System.out.println();
    }
    /* Function to print reverse of linked list */
    void revereseList(Node head){
        Stack<Integer> st=new Stack<>();
        Node curr=head;
        while(curr!=null){
            st.push(curr.data);
            curr=curr.next;
        }
        while(st.empty()==false){
            System.out.print(st.peek() + " -> ");
            st.pop();
        }
    }

    public static void main(String[] args) {
        LinkedListReverse llist = new LinkedListReverse();
        System.out.println("Enter a Number :");
        Scanner sc=new Scanner(System.in);
        int n=sc.nextInt();
        while(n!=0){
            llist.push(n);
            n--;
        }
       llist.printList(llist.head);
       llist.revereseList(llist.head);
       sc.close();
    }
}
