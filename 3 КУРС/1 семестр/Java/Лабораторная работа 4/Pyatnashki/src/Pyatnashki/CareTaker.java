package Pyatnashki;

import java.util.*;

public class CareTaker
{
    Stack<Memento> numbers;

    public CareTaker()
    {
        this.numbers=new Stack<>();
    }
    public void Save(Memento state)
    {
        try {
            numbers.push(state.clone());
        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
        }
    }
    public Memento Restore()
    {
        if (!numbers.empty())
        {
            return numbers.pop();

        }
        else
            throw new EmptyStackException();

    }


}
