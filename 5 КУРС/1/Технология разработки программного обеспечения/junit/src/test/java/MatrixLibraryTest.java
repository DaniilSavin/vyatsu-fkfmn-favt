import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;
import static org.junit.jupiter.api.Assertions.assertArrayEquals;

class MatrixLibraryTest
{
    @Test
    void getDeterminant()
    {
        float [][]A = { {1,7,3}, {-4,9,4}, {0,3,2} };
        double det = MatrixLibrary.GetDeterminant(A);
        assertEquals(26, det);
    }

    @Test
    void transpose()
    {
        float [][]A = { {1,7,3}, {-4,9,4}, {0,3,2} };
        float [][]A_transpose = { {1,-4,0},{7,9,3},{3,4,2} };
        assertArrayEquals(A_transpose, MatrixLibrary.Transpose(A));
    }

    @Test
    void jordan_Gauss() throws Exception
    {
        float [][]A = { {1,7,3}, {-4,9,4}, {0,3,2} };
        float[][] invMat = MatrixLibrary.Jordan_Gauss(A, true);
        float[][] result = {{(float) 0.231, (float) -0.192, (float) 0.038},{(float) 0.308, (float) 0.077, (float) -0.615},{(float) -0.462, (float) -0.115, (float) 1.423}};
        assertArrayEquals(result, invMat);
    }

    @Test
    void multiplyMatrix() throws Exception
    {
        float [][]A = { {1,7,3}, {-4,9,4}, {0,3,2} };
        float [][] result = {{-27, 79, 37},{-40, 65,32},{-12,33,16}};
        assertArrayEquals(result, MatrixLibrary.MultiplyMatrix(A, A));
    }

    @Test
    void solveSLAU() throws Exception
    {
        float [][]A = { {1,7,3}, {-4,9,4}, {0,3,2} };
        float [][]B = { {-1}, {0}, {6} };

        double det = MatrixLibrary.GetDeterminant(A);
        float[][] invMat = MatrixLibrary.Jordan_Gauss(A, true);
        float[][] matrixC = MatrixLibrary.MultiplyMatrix(invMat, B);
        System.out.println();
        float[][] result = {{0},{-4},{9}};

        assertArrayEquals(result, matrixC);

    }
}