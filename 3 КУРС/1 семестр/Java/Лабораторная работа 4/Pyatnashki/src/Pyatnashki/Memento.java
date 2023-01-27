package Pyatnashki;
import java.util.Arrays;
public class Memento implements Cloneable
{
    final private int [][]numbers;

    public Memento(int numbers[][])
    {
        this.numbers=Arrays.stream(numbers)
                .map(int[]::clone)
                .toArray(int[][]::new);

    }
    public int[][] getState()
    {
        return this.numbers;
    }
    @Override
    protected Memento clone() throws CloneNotSupportedException {
        Memento clone = (Memento) super.clone();
        return new Memento(numbers.clone());
    }
}
