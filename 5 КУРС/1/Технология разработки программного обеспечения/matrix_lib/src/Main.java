import java.util.Random;

import static java.lang.System.out;

public class Main
{
    // SLAU
    //   x1  + 7x2 + 3x3 =-1
    // -4x1  + 9x2 + 4x3 = 0
    //  0x1  + 3x2 + 2x3 = 6
    static float [][]A = { {1,7,3}, {-4,9,4}, {0,3,2} };
    static float [][]B = { {-1}, {0}, {6} };
    static Random random = new Random();

    public static void main(String[] args) throws Exception
    {
        MatrixLibrary.SCALE = 5;
        float[][] invMat = MatrixLibrary.InverseMatrix(A, true);
        float[][] J_G = MatrixLibrary.Jordan_Gauss(A, true);

        out.println("invMat");
        showMatrix(invMat);

        out.println("J_G");
        showMatrix(J_G);

        showMatrix(MatrixLibrary.MultiplyMatrix(invMat, B));

        showMatrix(MatrixLibrary.MultiplyMatrix(J_G, B));

    }

    public static void showMatrix(float [][]matrix)
    {
        for (float[] doubles : matrix)
        {
            for (int j = 0; j < matrix[0].length; j++)
            {
                out.print(doubles[j] + " ");
            }
            out.println();
        }
        out.println();
    }
    public static float [][] fillMatrix (float [][]matrix)
    {
        for (int i=0; i< matrix.length; i++)
        {
            for (int j=0; j<matrix[0].length; j++)
                matrix[i][j] = random.nextInt(100);
        }
        return matrix;
    }
}