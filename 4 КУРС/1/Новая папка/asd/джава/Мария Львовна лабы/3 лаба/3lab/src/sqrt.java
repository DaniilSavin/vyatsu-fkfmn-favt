<<<<<<< HEAD
import java.util.Random;
import java.util.Scanner;

class sqrt{
    
    double[] numbers;
	double[] sum;
	double[] values;
	int q = 0;
	int s = 0;
	int num = 0;
	int ran;
	Scanner enter = new Scanner(System.in);
	final Random random = new Random();
	
    sqrt(int n)
    {
    	numbers = new double[n];
    	num = n;
		for (int i = 0; i < numbers.length; i++) 
		{
			ran = random.nextInt(100);
			numbers[i] = (double) ran;
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
    
    
    public void EditAtPoint(int Position, double Value) 
    {
		int a = Position;
		numbers[a] = Value;
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
    
    
    public boolean ChangeOnInterval(int Posa, int Posb, double Value)
    {
		int a = Posa,b = Posb;
		double c = Value;
			if ((b < a) | (b < 0) | (a < 0) | (a >= num) | (b >= num) | (a == b)) 
				return false;
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
			return true;
    }
    
    public double ReturnSumm()
    {
    	return summ;
    }
    
	double summ = 0;
	
    public boolean SummOnInterval(int Posa, int Posb)
    {
    	summ = 0;
		int a = Posa,b = Posb;
		
			if ((b < a) | (b < 0) | (a < 0) | (a >= num) | (b >= num))
			{
				return false;
			}

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
		
		return true;
    }
    
    public double[] ReturnArray(boolean bol)
    {
    	double[] myArray = new double[num];
		int k = 0;
		int j = 0;
		if (bol)
    	for (int i = 0; i < num; i++) 
    	{
    		if (k == s) 
    			{
    				j++;
    				k = 0;
    			}
    		myArray[i] = numbers[i] + values[j];
    		k++;
    	}
    	return myArray;
    }
=======
import java.util.Random;
import java.util.Scanner;

class sqrt{
    
    double[] numbers;
	double[] sum;
	double[] values;
	int q = 0;
	int s = 0;
	int num = 0;
	int ran;
	Scanner enter = new Scanner(System.in);
	final Random random = new Random();
	
    sqrt(int n)
    {
    	numbers = new double[n];
    	num = n;
		for (int i = 0; i < numbers.length; i++) 
		{
			ran = random.nextInt(100);
			numbers[i] = (double) ran;
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
    
    
    public void EditAtPoint(int Position, double Value) 
    {
		int a = Position;
		numbers[a] = Value;
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
    
    
    public boolean ChangeOnInterval(int Posa, int Posb, double Value)
    {
		int a = Posa,b = Posb;
		double c = Value;
			if ((b < a) | (b < 0) | (a < 0) | (a >= num) | (b >= num) | (a == b)) 
				return false;
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
			return true;
    }
    
    public double ReturnSumm()
    {
    	return summ;
    }
    
	double summ = 0;
	
    public boolean SummOnInterval(int Posa, int Posb)
    {
    	summ = 0;
		int a = Posa,b = Posb;
		
			if ((b < a) | (b < 0) | (a < 0) | (a >= num) | (b >= num))
			{
				return false;
			}

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
		
		return true;
    }
    
    public double[] ReturnArray(boolean bol)
    {
    	double[] myArray = new double[num];
		int k = 0;
		int j = 0;
		if (bol)
    	for (int i = 0; i < num; i++) 
    	{
    		if (k == s) 
    			{
    				j++;
    				k = 0;
    			}
    		myArray[i] = numbers[i] + values[j];
    		k++;
    	}
    	return myArray;
    }
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
}