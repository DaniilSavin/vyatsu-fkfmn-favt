package in.ex.ivy;
import java.util.Scanner;
import org.apache.commons.lang.StringUtils;

public class MainClass 
{
	
	public static void main(String[] args) 
	{
		Scanner enter = new Scanner(System.in);
		System.out.print("Введите количество элементов:");
		int num = enter.nextInt();
		for (int i = 0; i < 50; ++i) System.out.println();
		
		SQRT tom = new SQRT(num);

		int f = 0;
		boolean bool = true;
		boolean print = true;
		while (bool == true)
		{
			if (print) tom.PrintArray(true);
			else tom.PrintArray(false);
			
			System.out.println("Выберите действие");
			System.out.println("1 - Изменить значение в точке");
			System.out.println("2 - Изменить значения на интервале");
			System.out.println("3 - Определить сумму значений на интервале");
			System.out.println("4 - Закончить работу");
			System.out.print("Введите команду:");
			
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
					for (int i = 0; i < 50; ++i) System.out.println();
					bool = false;
					break;
				}
			}

		}
		enter.close();
	}

}
