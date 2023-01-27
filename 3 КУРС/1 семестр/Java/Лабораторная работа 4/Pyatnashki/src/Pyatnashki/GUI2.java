package Pyatnashki;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;


public class GUI2 extends JFrame
{
    public static JPanel panel = new JPanel(new GridLayout(4, 4, 2, 2));
    public static int[][] numbers = new int[4][4];
    public static CareTaker saves=new CareTaker();
    static JLabel  count=new JLabel(" Ходов: ");
    public static void main(String[] args)
    {
        JFrame app = new GUI2();
        app.setVisible(true);
    }

    public GUI2()
    {
        super("Пятнашки");
        setBounds(200, 200, 300, 300);
        setResizable(false);
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        createMenu();
        Container container = getContentPane();
        panel.setDoubleBuffered(true);
        container.add(panel);
        Pyatnashki.generate(numbers);
        repaintField(numbers);
        saves.Save(new Memento(numbers));
    }
    public static void repaintField(int[][] numbers)
    {
        panel.removeAll();
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                JButton button = new JButton(Integer.toString(numbers[i][j]));
                button.setFocusable(false);
                panel.add(button);
                if (numbers[i][j] == 0) {
                    button.setVisible(false);
                } else
                    button.addActionListener(new ClickListener());
            }
        }
        panel.validate();
        panel.repaint();
    }

    public void createMenu()
    {
        JMenuBar menu = new JMenuBar();
        JMenu fileMenu = new JMenu("File");
        JButton CancelB=new JButton("Cancel");

        ActionListener actionListener = new TestActionListener();
        CancelB.addActionListener(actionListener);
        for (String fileItem : new String [] { "New", "Exit" })
        {
            JMenuItem item = new JMenuItem(fileItem);
            item.setActionCommand(fileItem.toLowerCase());
            item.addActionListener(new NewMenuListener());
            fileMenu.add(item);
        }
        fileMenu.insertSeparator(1);

        menu.add(fileMenu);
        setJMenuBar(menu);
        menu.add(CancelB);
        count.setText(" Ходов: "+Pyatnashki.counter);
        menu.add(count);
    }

    public static void setCount()
    {
        count.setText(" Ходов: "+Pyatnashki.counter);
    }

    public int[][] getNumbers()
    {
        return numbers;
    }

    public void setNumbers(int[][] numbers)
    {
        this.numbers = numbers;
    }

    private class NewMenuListener implements ActionListener
    {
        public void actionPerformed(ActionEvent e)
        {
            String command = e.getActionCommand();
            if ("exit".equals(command))
            {
                System.exit(0);
            }
            if ("new".equals(command))
            {
                Pyatnashki.generate(numbers);
                repaintField(numbers);
            }

        }
    }

    private static class ClickListener implements ActionListener
    {

        public void actionPerformed(ActionEvent e)
        {
            saves.Save(new Memento(numbers));
            JButton button = (JButton) e.getSource();
            button.setVisible(false);
            String name = button.getText();
            Pyatnashki.change(Integer.parseInt(name));

        }
    }
    public static void restore()
    {
        numbers = saves.Restore().getState();
    }

    public static class TestActionListener implements ActionListener
    {
        @Override
        public void actionPerformed(ActionEvent e)
        {
            Pyatnashki.Cancel();
        }
    }
}
