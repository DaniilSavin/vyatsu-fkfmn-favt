//----------------------------------------------------------------------------------------
//	Copyright © 2006 - 2019 Tangible Software Solutions, Inc.
//	This class can be used by anyone provided that the copyright notice remains intact.
//
//	This class includes methods to convert C++ rectangular arrays (jagged arrays
//	with inner arrays of the same length).
//----------------------------------------------------------------------------------------
internal static class RectangularArrays
{
    public static double[][] RectangularDoubleArray(int size1, int size2)
    {
        double[][] newArray = new double[size1][];
        for (int array1 = 0; array1 < size1; array1++)
        {
            newArray[array1] = new double[size2];
        }

        return newArray;
    }
}