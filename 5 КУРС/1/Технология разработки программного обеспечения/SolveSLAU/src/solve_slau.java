import javax.swing.*;
import javax.swing.event.DocumentEvent;
import javax.swing.event.DocumentListener;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

public class solve_slau extends JFrame
{
    private JPanel panel1;
    private JTextArea textArea1;
    private JButton calculate;
    private JTextArea textArea2;
    private JButton multiply;

    public solve_slau()
    {
        List<Double[]> mA = new ArrayList<>();
        List<Double[]> mulMatB = new ArrayList<>();
        List<double[]> mB = new ArrayList<>();

        setContentPane(panel1);

        setVisible(true);
        setSize(500, 300);
        setLocation(500, 400);
        String value = "1 7 3 = -1";
        String value2 = "1 7 3";
        textArea1.setToolTipText("<html>Пример ввода матрицы:<br>" +value+"<br>" +value+"<br>" +value+ "<br><br>Или для умножения:<br>" +
                value2+"<br>" +value2+"<br>" +value2+"</html>");
        textArea2.setToolTipText("<html>Для умножения:<br>" +
                value2+"<br>" +value2+"<br>" +value2+"</html>");


        textArea1.setText("1 7 3 = -1\n-4 9 4 = 0\n0 3 2 = 6");
        //textArea1.setText("1 7 3\n-4 9 4\n0 3 2");
        //textArea2.setText("1 7 3\n-4 9 4\n0 3 2");

        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        calculate.addActionListener(new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e)
            {
                try
                {
                    if (!Objects.equals(textArea1.getText(), ""))
                    {
                        String[] secondMatrix = textArea1.getText().split("\n");

                        for (String matrix : secondMatrix)
                        {
                            String[] a = matrix.split("=");
                            mB.add(new double[]{Double.parseDouble(a[1])});
                            List<Double> _ar = new ArrayList<Double>();
                            String[] ar = a[0].split(" ");
                            for (String s : ar)
                            {
                                _ar.add(Double.parseDouble(s));
                            }
                            mA.add(_ar.toArray(new Double[0]));
                        }
                    }
                    float[][] matrixA = new float[mA.size()][mA.size()];
                    float[][] matrixB = new float[mB.size()][1];
                    for (int i = 0; i < mA.size(); i++)
                    {
                        for (int j = 0; j < mA.size(); j++)
                        {
                            matrixA[i][j] = Float.parseFloat(String.valueOf(mA.get(i)[j]));
                        }
                    }

                    for (int i = 0; i < mB.size(); i++)
                    {
                        for (int j = 0; j < 1; j++)
                        {
                            matrixB[i][j] = Float.parseFloat(String.valueOf(mB.get(i)[j]));
                        }
                    }


                    double det = MatrixLibrary.GetDeterminant(matrixA);
                    float[][] invMat = MatrixLibrary.Jordan_Gauss(matrixA, true);
                    float[][] matrixC = MatrixLibrary.MultiplyMatrix(invMat, matrixB);
                    String res = showMatrix(matrixC);

                    textArea1.append("\n\ndeterminant=" + det + "\nResult:\n" + res);
                    calculate.setEnabled(false);
                    mA.clear();
                    mB.clear();

                } catch (Exception ex)
                {
                    textArea1.append("\n\n" + String.valueOf(ex));

                    //throw new RuntimeException(ex);
                }
            }
        });

        textArea1.getDocument().addDocumentListener(new DocumentListener()
        {
            @Override
            public void removeUpdate(DocumentEvent e)
            {
                calculate.setEnabled(true);
            }

            @Override
            public void insertUpdate(DocumentEvent e)
            {
                calculate.setEnabled(true);
            }

            @Override
            public void changedUpdate(DocumentEvent arg0)
            {
                calculate.setEnabled(true);
            }
        });
        textArea2.getDocument().addDocumentListener(new DocumentListener()
        {
            @Override
            public void removeUpdate(DocumentEvent e)
            {
                multiply.setEnabled(true);
            }

            @Override
            public void insertUpdate(DocumentEvent e)
            {
                multiply.setEnabled(true);
            }

            @Override
            public void changedUpdate(DocumentEvent arg0)
            {
                multiply.setEnabled(true);
            }
        });

        multiply.addActionListener(new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e)
            {
                if (!Objects.equals(textArea2.getText(), "") && !Objects.equals(textArea2.getText(), ""))
                {
                    try
                    {
                        String[] secondMatrix = textArea2.getText().split("\n");
                        String[] firstMatrix = textArea2.getText().split("\n");
                        for (String matrix : secondMatrix)
                        {
                            String[] a = matrix.split(" ");
                            //mB.add(new double[]{Double.parseDouble(a[1])});
                            List<Double> _ar = new ArrayList<Double>();
                            //String[] ar = a[0].split(" ");
                            for (String s : a)
                            {
                                _ar.add(Double.parseDouble(s));
                            }
                            mulMatB.add(_ar.toArray(new Double[0]));
                        }
                        for (String matrix : firstMatrix)
                        {
                            String[] a = matrix.split(" ");
                            //mB.add(new double[]{Double.parseDouble(a[1])});
                            List<Double> _ar = new ArrayList<Double>();
                            //String[] ar = a[0].split(" ");
                            for (String s : a)
                            {
                                _ar.add(Double.parseDouble(s));
                            }
                            mA.add(_ar.toArray(new Double[0]));
                        }
                        float[][] matrixA = new float[mA.size()][mA.get(0).length];
                        float[][] matrixB = new float[mulMatB.size()][mulMatB.get(0).length];
                        for (int i = 0; i < mA.size(); i++)
                        {
                            for (int j = 0; j < mA.get(0).length; j++)
                            {
                                matrixA[i][j] = Float.parseFloat(String.valueOf(mA.get(i)[j]));
                            }
                        }
                        for (int i = 0; i < mulMatB.size(); i++)
                        {
                            for (int j = 0; j < mulMatB.get(0).length; j++)
                            {
                                matrixB[i][j] = Float.parseFloat(String.valueOf(mulMatB.get(i)[j]));
                            }
                        }
                        float[][] matrixC = MatrixLibrary.MultiplyMatrix(matrixA, matrixB);
                        String res = showMatrix(matrixC);

                        textArea2.append("\n\nResult:\n" + res);
                        multiply.setEnabled(false);
                        mA.clear();
                        mB.clear();
                    } catch (Exception ex)
                    {
                        textArea2.append("\n\n" + String.valueOf(ex));
                        //throw new RuntimeException(ex);
                    }

                }
            }
        });
    }
    public static void main(String[] args) {

        new solve_slau();
    }
    private static String showMatrix(float [][]matrix)
    {
        StringBuilder res = new StringBuilder();
        for (float[] doubles : matrix)
        {
            for (int j = 0; j < matrix[0].length; j++)
            {
                res.append(doubles[j]).append(" ");
            }
            res.append("\n");
        }
        return res.toString();
    }
    private void createUIComponents() {}
}
