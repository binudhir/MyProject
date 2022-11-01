/* package codechef; // don't place package name! */

import java.util.*;
import java.lang.*;
import java.io.*;

/* Name of the class has to be "Main" only if the class is public. */
class Codechef
{
	public static void main (String[] args) throws java.lang.Exception
	{
		// your code goes here
		Scanner sc = new Scanner(System.in);
		int N = sc.nextInt();
		for(int i=0; i<N; i++){
		    int a = sc.nextInt();
		    int b = sc.nextInt();
		    int c = sc.nextInt();
		    if((a>b && a<c) || (a>c && a<b))
		    System.out.println(a);
		    else if((b>c && b<a) || (b>a && b<c))
		    System.out.println(b);
		    else if((c>a && c<b) || (c>b && c<a))
		    System.out.println(c);
		}
	}
}
