<<<<<<< HEAD
package classes;

import java.util.Scanner;

class SQRT{
    
    double[] numbers;
	double[] sum;
	double[] values;
	int q = 0;
	int s = 0;
	int num = 0;
	Scanner enter = new Scanner(System.in);
	
    SQRT(int n)
    {
    	numbers = new double[n];
    	num = n;
		for (int i = 0; i < numbers.length; i++) 
		{
			numbers[i] = i;
		}
		
		s = (int) Math.ceil(Math.sqrt(numbers.length));
		sum = new double [s];
		values = new double[s];
		
		
		for (int i = 0; i < s; i++)
		{
			for (int j = 0; j < s; j++)
			{
				if (q < n)
				{
				sum[i] = sum[i] + numbers[q];
				}
				q++;
			}
		}
    }
    
    
    public void EditAtPoint() 
    {
		boolean flag = true;
		int a = 0;
		for (int i = 0; i < 50; ++i) System.out.println();
		while (flag == true)
		{
			PrintArray(true);
			System.out.print("¬ведите точку, которую хотите изменить:");
			a = enter.nextInt();
			if ((a < 0) | (a >= num))
			{
				for (int i = 0; i < 50; ++i) System.out.println();
				System.out.println("¬ведено некорректное значение");
			}
			else flag = false;
		}
		System.out.print("¬ведите новое значение в точке:");
		numbers[a] = enter.nextDouble();
		for (int i = 0; i < 50; ++i) System.out.println();
		System.out.println("«начение в точке " + a + " изменено на " + numbers[a]);
		int pos = (a + 1) / s;
		if ((a + 1) % s != 0) pos++;
		pos--;
		sum[pos] = 0;
		for (int i = pos * s; i < pos * s + s; i++)
		{
			if (i < num) sum[pos] = sum[pos] + numbers[i];
			else break;
		}
    }
    
    public void ChangeOnInterval()
    {
		for (int i = 0; i < 50; ++i) System.out.println();
		boolean flag = true;
		int a = 0,b = 0;
		double c = 0;
		for (int i = 0; i < 50; ++i) System.out.println();
		while (flag == true)
		{
			PrintArray(true);
			System.out.print("¬ведите первое значение интервала:");
			a = enter.nextInt();
			PrintArray(true);
			System.out.print("¬ведите второе значение интервала:");
			b = enter.nextInt();
			if ((b < a) | (b < 0) | (a < 0) | (a >= num) | (b >= num) | (a == b))
			{
				for (int i = 0; i < 50; ++i) System.out.println();
				System.out.println("¬ведены некорректные значени€");
			}
			else flag = false;
		}
		
		for (int i = 0; i < 50; ++i) System.out.println();
		PrintArray(true);
		System.out.print("¬ведите добавочное значение на интервале:");
		c = enter.nextDouble();
		for (int i = 0; i < 50; ++i) System.out.println();
		
		int posa = (a + 1) / s;
		if ((a + 1) % s != 0) posa++;
		posa--;
		
		int posb = (b + 1) / s;
		if ((b + 1) % s != 0) posb++;
		posb--;
		
			for (int i = posa + 1; i < posb; i++)
			{
				values[i] = values[i] + c;
			}
			sum[posa] = 0;
			sum[posb] = 0;
			
			for (int i = a; i < posa * s + s; i++)
				numbers[i] = numbers[i] + c;
			for (int i = posa * s; i < posa * s + s; i++)
				sum[posa] = sum[posa] + numbers[i];
			if (posa != posb)
			{
				for (int i = posb * s; i <= b; i++)
					numbers[i] = numbers[i] + c;
				for (int i = posb * s; i < posb * s + s; i++)
				{
					if (i < num) sum[posb] = sum[posb] + numbers[i];
					else break;
				}
			}
    }
    
    public void SummOnInterval()
    {
		boolean flag = true;
		int a = 0,b = 0;
		for (int i = 0; i < 50; ++i) System.out.println();
		while (flag == true)
		{
			System.out.print("¬ведите первое значение интервала:");
			a = enter.nextInt();
			System.out.print("¬ведите второе значение интервала:");
			b = enter.nextInt();
			if ((b < a) | (b < 0) | (a < 0) | (a >= num) | (b >= num))
			{
				for (int i = 0; i < 50; ++i) System.out.println();
				System.out.println("¬ведены некорректные значени€");
			}
			else flag = false;
		}
		for (int i = 0; i < 50; ++i) System.out.println();
		double summ = 0;
		
		int posa = (a + 1) / s;
		if ((a + 1) % s != 0) posa++;
		posa--;
		
		int posb = (b + 1) / s;
		if ((b + 1) % s != 0) posb++;
		posb--;
		
		if (posa == posb)
			for (int i = a; i <= b; i++)
				summ = summ + numbers[i];
		else
		{
			for (int i = posa + 1; i < posb; i++)
			{
				summ = summ + sum[i] + (values[i] * s);
			}
			for (int i = a; i < posa * s + s; i++)
			{
				summ = summ + numbers[i] + values[posa];
			}
			for (int i = posb * s; i <= b; i++)
			{
				summ = summ + numbers[i] + values[posb];
			}
		}
		
		System.out.println("—умма на интервале [" + a + "," + b + "] = " + summ);
    }
    
    public void PrintArray(boolean bol)
    {
		int k = 0;
		int j = 0;
		if (bol)
		for (int i = 0; i < 50; ++i) System.out.println();
		System.out.print("ћассив: ");
    	for (int i = 0; i < num; i++) 
    	{
    		if (k == 5) 
    			{
    				j++;
    				k = 0;
    			}
    		System.out.print((numbers[i] + values[j]) + " ");
    		k++;
    	}
    	System.out.println();
    }
=======
package classes;

import java.util.Scanner;

class SQRT{
    
    double[] numbers;
	double[] sum;
	double[] values;
	int q = 0;
	int s = 0;
	int num = 0;
	Scanner enter = new Scanner(System.in);
	
    SQRT(int n)
    {
    	numbers = new double[n];
    	num = n;
		for (int i = 0; i < numbers.length; i++) 
		{
			numbers[i] = i;
		}
		
		s = (int) Math.ceil(Math.sqrt(numbers.length));
		sum = new double [s];
		values = new double[s];
		
		
		for (int i = 0; i < s; i++)
		{
			for (int j = 0; j < s; j++)
			{
				if (q < n)
				{
				sum[i] = sum[i] + numbers[q];
				}
				q++;
			}
		}
    }
    
    
    public void EditAtPoint() 
    {
		boolean flag = true;
		int a = 0;
		for (int i = 0; i < 50; ++i) System.out.println();
		while (flag == true)
		{
			PrintArray(true);
			System.out.print("¬ведите точку, которую хотите изменить:");
			a = enter.nextInt();
			if ((a < 0) | (a >= num))
			{
				for (int i = 0; i < 50; ++i) System.out.println();
				System.out.println("¬ведено некорректное значение");
			}
			else flag = false;
		}
		System.out.print("¬ведите новое значение в точке:");
		numbers[a] = enter.nextDouble();
		for (int i = 0; i < 50; ++i) System.out.println();
		System.out.println("«начение в точке " + a + " изменено на " + numbers[a]);
		int pos = (a + 1) / s;
		if ((a + 1) % s != 0) pos++;
		pos--;
		sum[pos] = 0;
		for (int i = pos * s; i < pos * s + s; i++)
		{
			if (i < num) sum[pos] = sum[pos] + numbers[i];
			else break;
		}
    }
    
    public void ChangeOnInterval()
    {
		for (int i = 0; i < 50; ++i) System.out.println();
		boolean flag = true;
		int a = 0,b = 0;
		double c = 0;
		for (int i = 0; i < 50; ++i) System.out.println();
		while (flag == true)
		{
			PrintArray(true);
			System.out.print("¬ведите первое значение интервала:");
			a = enter.nextInt();
			PrintArray(true);
			System.out.print("¬ведите второе значение интервала:");
			b = enter.nextInt();
			if ((b < a) | (b < 0) | (a < 0) | (a >= num) | (b >= num) | (a == b))
			{
				for (int i = 0; i < 50; ++i) System.out.println();
				System.out.println("¬ведены некорректные значени€");
			}
			else flag = false;
		}
		
		for (int i = 0; i < 50; ++i) System.out.println();
		PrintArray(true);
		System.out.print("¬ведите добавочное значение на интервале:");
		c = enter.nextDouble();
		for (int i = 0; i < 50; ++i) System.out.println();
		
		int posa = (a + 1) / s;
		if ((a + 1) % s != 0) posa++;
		posa--;
		
		int posb = (b + 1) / s;
		if ((b + 1) % s != 0) posb++;
		posb--;
		
			for (int i = posa + 1; i < posb; i++)
			{
				values[i] = values[i] + c;
			}
			sum[posa] = 0;
			sum[posb] = 0;
			
			for (int i = a; i < posa * s + s; i++)
				numbers[i] = numbers[i] + c;
			for (int i = posa * s; i < posa * s + s; i++)
				sum[posa] = sum[posa] + numbers[i];
			if (posa != posb)
			{
				for (int i = posb * s; i <= b; i++)
					numbers[i] = numbers[i] + c;
				for (int i = posb * s; i < posb * s + s; i++)
				{
					if (i < num) sum[posb] = sum[posb] + numbers[i];
					else break;
				}
			}
    }
    
    public void SummOnInterval()
    {
		boolean flag = true;
		int a = 0,b = 0;
		for (int i = 0; i < 50; ++i) System.out.println();
		while (flag == true)
		{
			System.out.print("¬ведите первое значение интервала:");
			a = enter.nextInt();
			System.out.print("¬ведите второе значение интервала:");
			b = enter.nextInt();
			if ((b < a) | (b < 0) | (a < 0) | (a >= num) | (b >= num))
			{
				for (int i = 0; i < 50; ++i) System.out.println();
				System.out.println("¬ведены некорректные значени€");
			}
			else flag = false;
		}
		for (int i = 0; i < 50; ++i) System.out.println();
		double summ = 0;
		
		int posa = (a + 1) / s;
		if ((a + 1) % s != 0) posa++;
		posa--;
		
		int posb = (b + 1) / s;
		if ((b + 1) % s != 0) posb++;
		posb--;
		
		if (posa == posb)
			for (int i = a; i <= b; i++)
				summ = summ + numbers[i];
		else
		{
			for (int i = posa + 1; i < posb; i++)
			{
				summ = summ + sum[i] + (values[i] * s);
			}
			for (int i = a; i < posa * s + s; i++)
			{
				summ = summ + numbers[i] + values[posa];
			}
			for (int i = posb * s; i <= b; i++)
			{
				summ = summ + numbers[i] + values[posb];
			}
		}
		
		System.out.println("—умма на интервале [" + a + "," + b + "] = " + summ);
    }
    
    public void PrintArray(boolean bol)
    {
		int k = 0;
		int j = 0;
		if (bol)
		for (int i = 0; i < 50; ++i) System.out.println();
		System.out.print("ћассив: ");
    	for (int i = 0; i < num; i++) 
    	{
    		if (k == 5) 
    			{
    				j++;
    				k = 0;
    			}
    		System.out.print((numbers[i] + values[j]) + " ");
    		k++;
    	}
    	System.out.println();
    }
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
}