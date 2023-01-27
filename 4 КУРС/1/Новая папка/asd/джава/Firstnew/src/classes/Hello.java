<<<<<<< HEAD
package classes;
import java.util.Scanner;

/**
 * 
 * @author ������
 *
 */

public class Hello 
{
	
	/**
	 * ����� �����
	 * @param args ��������� ��������� ������
	 */
	
	public static void main(String[] args) 
	{
		int Command = 0;
		boolean ExitChoice = true;
		boolean PrintChoice = true;
		Scanner Enter = new Scanner(System.in);
		
		System.out.print("������� ���������� ���������:");
		int Size = Enter.nextInt();
		
		SQRT Example = new SQRT(Size);

		while (ExitChoice == true)
		{
			if (PrintChoice) Example.PrintArray(true);
			else Example.PrintArray(false);
			
			System.out.println("�������� ��������");
			System.out.println("1 - �������� �������� � �����");
			System.out.println("2 - �������� �������� �� ���������");
			System.out.println("3 - ���������� ����� �������� �� ���������");
			System.out.println("4 - ��������� ������");
			System.out.print("������� �������:");
			
			Command = Enter.nextInt();
			switch (Command)
			{
			case 1:
				{
					PrintChoice = true;
					Example.EditAtPoint();
					break;
				}
			case 2:
				{
					PrintChoice = true;
					Example.ChangeOnInterval();
					break;
				}
			case 3:
				{
					PrintChoice = false;
					Example.SummOnInterval();
					break;
				}
			case 4:
				{
					ExitChoice = false;
					break;
				}
			}

		}
		Enter.close();
	}

}
=======
package classes;
import java.util.Scanner;

/**
 * 
 * @author ������
 *
 */

public class Hello 
{
	
	/**
	 * ����� �����
	 * @param args ��������� ��������� ������
	 */
	
	public static void main(String[] args) 
	{
		int Command = 0;
		boolean ExitChoice = true;
		boolean PrintChoice = true;
		Scanner Enter = new Scanner(System.in);
		
		System.out.print("������� ���������� ���������:");
		int Size = Enter.nextInt();
		
		SQRT Example = new SQRT(Size);

		while (ExitChoice == true)
		{
			if (PrintChoice) Example.PrintArray(true);
			else Example.PrintArray(false);
			
			System.out.println("�������� ��������");
			System.out.println("1 - �������� �������� � �����");
			System.out.println("2 - �������� �������� �� ���������");
			System.out.println("3 - ���������� ����� �������� �� ���������");
			System.out.println("4 - ��������� ������");
			System.out.print("������� �������:");
			
			Command = Enter.nextInt();
			switch (Command)
			{
			case 1:
				{
					PrintChoice = true;
					Example.EditAtPoint();
					break;
				}
			case 2:
				{
					PrintChoice = true;
					Example.ChangeOnInterval();
					break;
				}
			case 3:
				{
					PrintChoice = false;
					Example.SummOnInterval();
					break;
				}
			case 4:
				{
					ExitChoice = false;
					break;
				}
			}

		}
		Enter.close();
	}

}
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
