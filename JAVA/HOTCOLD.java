/* package codechef; // don't place package name! */

import java.util.*;
// import java.lang.*;
// import java.io.*;

/* Name of the class has to be "Main" only if the class is public. */
class Codechef
{
	public static void main (String[] args) throws java.lang.Exception
	{
		// your code goes here
		Scanner sc=new Scanner(System.in);
		int T=sc.nextInt();
		while(T!=0){
		    int C=sc.nextInt();
		    if(C>20)
		        System.out.println("HOT");
		    else
		        System.out.println("COLD");
		T--;
		}
		sc.close();
		
	}
}
