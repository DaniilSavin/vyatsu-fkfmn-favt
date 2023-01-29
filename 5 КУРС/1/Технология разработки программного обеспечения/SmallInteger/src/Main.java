import SmallInteger_Class.SmallInteger;

import java.math.BigInteger;

public class Main {
    public static void main(String[] args) throws Exception
    {
        SmallInteger num1 = new SmallInteger("10000");
        SmallInteger num2 = new SmallInteger("1");

        System.out.println(num1 + " + " + num2 + " = " + num1.add(num2));
        System.out.println(num1 + " - " + num2 + " = " + num1.subtract(num2));
        System.out.println(num1 + " * " + num2 + " = " + num1.multiply(num2));
        System.out.println(num1 + " / " + num2 + " = " + num1.divide(num2));
        System.out.println(num1 + " % " + num2 + " = " + num1.remainderOfDivision(num2));


        for (int i = (int) Math.pow(10, 4); i > 0; i--)
        {
            SmallInteger n1 = new SmallInteger(Integer.toString(i));
            for (int j = 1; j <= Math.pow(10, 4); j++)
            {
                SmallInteger n2 = new SmallInteger(Integer.toString(j));
                if (n1.add(n2).toInteger() != i + j)
                {
                    System.out.println(n1 + " + " + n2 + " = " + n1.add(n2));
                    System.out.println("CORRECT: " + (i + j));
                    throw new Exception("add error");
                }
                //System.out.println(n1 + " - " + n2 );
                if (n1.subtract(n2).toInteger() != Math.abs(i - j))
                {
                    System.out.println(n1 + " - " + n2 + " = " + n1.subtract(n2));
                    System.out.println("CORRECT: " + Math.abs(i - j));
                    throw new Exception("subtract error");
                }

                if (n1.multiply(n2).toInteger() != (i * j))
                {
                    System.out.println(n1 + " * " + n2 + " = " + n1.multiply(n2));
                    System.out.println("CORRECT: " + (i * j));
                    throw new Exception("multiply error");
                }

                if (n1.divide(n2).toInteger() != (i / j))
                {
                    System.out.println(n1 + " / " + n2 + " = " + n1.divide(n2));
                    System.out.println("CORRECT: " + (i / j));
                    throw new Exception("divide error");
                }

            }
        }
    }
}