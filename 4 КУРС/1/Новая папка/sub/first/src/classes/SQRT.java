package classes;
import java.util.Scanner;

/**
 * 
 * @author ������
 *
 */

public class SQRT{
    
    double[] ArraySQRT;
	double[] SumOnInterval;
	double[] AdditionalValue;
	int RootSQRT = 0;
	int ArraySizeSQRT = 0;
	int Size;
	Scanner Enter = new Scanner(System.in);
	
	/**
	 * ����������� ������ SQRT
	* @param n ���������� ��������� �������
	*/
	
    SQRT(int Size)
    {
    	this.Size = Size;
    	ArraySQRT = new double[this.Size];
    	ArraySizeSQRT = this.Size;
    	
		for (int i = 0; i < ArraySQRT.length; i++) { ArraySQRT[i] = i; }
		
		RootSQRT = (int) Math.ceil(Math.sqrt(ArraySQRT.length));
		SumOnInterval = new double [RootSQRT];
		AdditionalValue = new double[RootSQRT];
		
		int ArrayElementSQRT = 0;
		
		for (int i = 0; i < RootSQRT; i++)
			Enumeration(i, ArrayElementSQRT);
    }
    
    private void Enumeration (int i, int ArrayElementSQRT)
    {
		for (int j = 0; j < RootSQRT; j++)
		{
			if (ArrayElementSQRT < Size)
				SumOnInterval[i] = SumOnInterval[i] + ArraySQRT[ArrayElementSQRT];
			ArrayElementSQRT++;
		}
    }
    
	/**
	* ��������� �������� � �����
	*/

    public void EditAtPoint() 
    {
		boolean CorrectData = true;
		int Point = 0;
		
		SkipLines();
		
		while (CorrectData == true)
		{
			PrintArray(true);
			System.out.print("������� �����, ������� ������ ��������:");
			Point = Enter.nextInt();
			if ((Point < 0) | (Point >= ArraySizeSQRT))
			{
				SkipLines();
				System.out.println("������� ������������ ��������");
			}
			else CorrectData = false;
		}
		
		System.out.print("������� ����� �������� � �����:");
		ArraySQRT[Point] = Enter.nextDouble();
		
		SkipLines();
		
		System.out.println("�������� � ����� " + Point + " �������� �� " + ArraySQRT[Point]);
		
		int PosPoint = (Point + 1) / RootSQRT;
		if ((Point + 1) % RootSQRT != 0) PosPoint++;
		PosPoint--;
		SumOnInterval[PosPoint] = 0;
		
		for (int i = PosPoint * RootSQRT; i < PosPoint * RootSQRT + RootSQRT; i++)
		{
			if (i < ArraySizeSQRT) SumOnInterval[PosPoint] = SumOnInterval[PosPoint] + ArraySQRT[i];
			else break;
		}
    }
    
	/**
	* ��������� �������� �� ���������
	*/
    
    public void ChangeOnInterval()
    {
		boolean CorrectData = true;
		int StartInterval = 0, EndInterval = 0;
		double Value = 0;
		
		SkipLines();
		
		while (CorrectData == true)
		{
			PrintArray(true);
			System.out.print("������� ������ �������� ���������:");
			StartInterval = Enter.nextInt();
			PrintArray(true);
			System.out.print("������� ������ �������� ���������:");
			EndInterval = Enter.nextInt();
			if ((EndInterval < StartInterval) | (EndInterval < 0) | (StartInterval < 0) | (StartInterval >= ArraySizeSQRT) | (EndInterval >= ArraySizeSQRT))
				SkipLines();
			else CorrectData = false;
		}
		
		SkipLines();
		
		PrintArray(true);
		
		System.out.print("������� ���������� �������� �� ���������:");
		Value = Enter.nextDouble();
		
		SkipLines();
		
		int PosStart = (StartInterval + 1) / RootSQRT;
		if ((StartInterval + 1) % RootSQRT != 0) PosStart++;
		PosStart--;
		
		int PosEnd = (EndInterval + 1) / RootSQRT;
		if ((EndInterval + 1) % RootSQRT != 0) PosEnd++;
		PosEnd--;
		
		for (int i = PosStart + 1; i < PosEnd; i++)
			AdditionalValue[i] = AdditionalValue[i] + Value;
			
		SumOnInterval[PosStart] = 0;
		SumOnInterval[PosEnd] = 0;
			
		for (int i = StartInterval; i < PosStart * RootSQRT + RootSQRT; i++)
			ArraySQRT[i] = ArraySQRT[i] + Value;
			
		for (int i = PosStart * RootSQRT; i < PosStart * RootSQRT + RootSQRT; i++)
			SumOnInterval[PosStart] = SumOnInterval[PosStart] + ArraySQRT[i];
			
		if (PosStart != PosEnd)
		{
			for (int i = PosEnd * RootSQRT; i <= EndInterval; i++)
				ArraySQRT[i] = ArraySQRT[i] + Value;
				
			for (int i = PosEnd * RootSQRT; i < PosEnd * RootSQRT + RootSQRT; i++)
			{
				if (i < ArraySizeSQRT) SumOnInterval[PosEnd] = SumOnInterval[PosEnd] + ArraySQRT[i];
				else break;
			}
		}
    }
    
	/**
	* ����������� ����� �� ���������
	*/
    
    public void SummOnInterval()
    {
		boolean CorrectData = true;
		int StartInterval = 0, EndInterval = 0;
		double PrivateSum = 0;
		
		SkipLines();
		
		while (CorrectData == true)
		{
			System.out.print("������� ������ �������� ���������:");
			StartInterval = Enter.nextInt();
			System.out.print("������� ������ �������� ���������:");
			EndInterval = Enter.nextInt();
			if ((EndInterval < StartInterval) | (EndInterval < 0) | (StartInterval < 0) | (StartInterval >= ArraySizeSQRT) | (EndInterval >= ArraySizeSQRT))
			{
				SkipLines();
				System.out.println("������� ������������ ��������");
			}
			else CorrectData = false;
		}
		
		SkipLines();
		
		int PosStart = (StartInterval + 1) / RootSQRT;
		if ((StartInterval + 1) % RootSQRT != 0) PosStart++;
		PosStart--;
		
		int PosEnd = (EndInterval + 1) / RootSQRT;
		if ((EndInterval + 1) % RootSQRT != 0) PosEnd++;
		PosEnd--;
		
		if (PosStart == PosEnd)
			for (int i = StartInterval; i <= EndInterval; i++)
				PrivateSum = PrivateSum + ArraySQRT[i];
		else
		{
			for (int i = PosStart + 1; i < PosEnd; i++)
				PrivateSum = PrivateSum + SumOnInterval[i] + (AdditionalValue[i] * RootSQRT);
			
			for (int i = StartInterval; i < PosStart * RootSQRT + RootSQRT; i++)
				PrivateSum = PrivateSum + ArraySQRT[i] + AdditionalValue[PosStart];
			
			for (int i = PosEnd * RootSQRT; i <= EndInterval; i++)
				PrivateSum = PrivateSum + ArraySQRT[i] + AdditionalValue[PosEnd];
		}
		
		System.out.println("����� �� ��������� [" + StartInterval + "," + EndInterval + "] = " + PrivateSum);
    }
    
	/**
	* ��������� ������ �������
	* @param bol ���� true, ���������� 50 ������� ��� ������� ����������� ����
	*/
    
    public void PrintArray(boolean CorrectLines)
    {
		int Step = 0, j = 0;
		if (CorrectLines) SkipLines();
		System.out.print("������: ");
		
    	for (int i = 0; i < ArraySizeSQRT; i++) 
    	{
    		if (Step == RootSQRT) {j++; Step = 0;}
    		System.out.print((ArraySQRT[i] + AdditionalValue[j]) + " ");
    		Step++;
    	}
    	
    	System.out.println();
    }
    
    public void SkipLines() {for (int i = 0; i < 50; ++i) System.out.println();}
    
}
