<<<<<<< HEAD
import java.util.Scanner;

public class Hello 
{
	
	public static void main(String[] args) 
	{
		Scanner enter = new Scanner(System.in);
		System.out.println("Enter the number of items :");
		int num; 
		num = enter.nextInt();
		SQRT tom = new SQRT(num);

		int f = 0;
		boolean bool = true;
		boolean print = true;
		while (bool == true)
		{
			if (print) tom.PrintArray(true);
			else tom.PrintArray(false);
			
			System.out.println("Select an action");
			System.out.println("1 - Change the value at a point");
			System.out.println("2 - Change the values on the interval");
			System.out.println("3 - Determine the sum of the values on the interval");
			System.out.println("4 - Finish the job");
			System.out.print("Enter the command:");
			
			f = enter.nextInt();
			switch (f)
			{
			case 1:
				{
					print = true;
					tom.EditAtPoint();
					break;
				}
			case 2:
				{
					print = true;
					tom.ChangeOnInterval();
					break;
				}
			case 3:
				{
					print = false;
					tom.SummOnInterval();
					break;
				}
			case 4:
				{
					bool = false;
					break;
				}
			}

		}
		enter.close();
	}

}
=======
import java.util.Scanner;

public class Hello 
{
	
	public static void main(String[] args) 
	{
		Scanner enter = new Scanner(System.in);
		System.out.println("Enter the number of items :");
		int num; 
		num = enter.nextInt();
		SQRT tom = new SQRT(num);

		int f = 0;
		boolean bool = true;
		boolean print = true;
		while (bool == true)
		{
			if (print) tom.PrintArray(true);
			else tom.PrintArray(false);
			
			System.out.println("Select an action");
			System.out.println("1 - Change the value at a point");
			System.out.println("2 - Change the values on the interval");
			System.out.println("3 - Determine the sum of the values on the interval");
			System.out.println("4 - Finish the job");
			System.out.print("Enter the command:");
			
			f = enter.nextInt();
			switch (f)
			{
			case 1:
				{
					print = true;
					tom.EditAtPoint();
					break;
				}
			case 2:
				{
					print = true;
					tom.ChangeOnInterval();
					break;
				}
			case 3:
				{
					print = false;
					tom.SummOnInterval();
					break;
				}
			case 4:
				{
					bool = false;
					break;
				}
			}

		}
		enter.close();
	}

}
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
