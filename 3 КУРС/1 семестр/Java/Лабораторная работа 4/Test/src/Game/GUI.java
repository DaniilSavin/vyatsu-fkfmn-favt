package Game;

//import javafx.scene.control.Labeled;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.JTable.*;

public class GUI extends JFrame
{
    public static String[] headers= {
            "Ход", "Число", "Бык", "Корова"
    };

    public static String[][] data=new String[100][100];

    public static int count=0;
    public static int val=0;

    //private JPanel panel1;
    public static JLabel firstLab=new JLabel();

    public static JTable table1=new JTable(data, headers);

    public  JPanel rootPanel;
    private JPanel panel1;
    public static JTextField text=new JTextField(5);
    public static JFrame form2 =new JFrame();
    public static JFrame form3 =new JFrame();
    public JLabel lab=new JLabel("Введите значение: ");
    public JLabel lab2=new JLabel("Вы побелили!");
    public static JButton ok=new JButton("Ok");
    public static JButton ok2=new JButton("Ok");
    public static JFrame frame4=new JFrame();
    public static JTextField nameT=new JTextField(10);
    public static JButton ok3=new JButton("Ok");
    public static JLabel num = new JLabel();
    public GUI()
    {
        super("Коровы и Быки");

        setBounds(500, 250, 340, 510);
        setLayout(new FlowLayout());
        setResizable(false);
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        createMenu();
        JScrollPane scroll = new JScrollPane(table1);
        table1.setPreferredScrollableViewportSize(new Dimension(300, 350));

        add(firstLab);
        add(scroll);
        add(rootPanel);

        frame4.setTitle("Введите ваше имя:");
        frame4.setBounds(900, 250, 500 ,100);
        frame4.setLayout(new FlowLayout());
        frame4.add(nameT);
        frame4.add(ok3);

        frame4.setVisible(true);

        ActionListener actionListener3 = new TestActionListener4();
        ok3.addActionListener(actionListener3);

        JButton button = new JButton("Ввести число");
        add(button);

        ActionListener actionListener = new TestActionListener();
        button.addActionListener(actionListener);
        ActionListener actionListener1 = new TestActionListener2();
        ok.addActionListener(actionListener1);
        ActionListener actionListener2 = new TestActionListener3();
        ok2.addActionListener(actionListener2);

        form2.setTitle("");
        form2.setBounds(800, 250, 200, 100);
        form2.setLayout(new FlowLayout());
        form2.add(lab);
        form2.add(text);
        form2.add(ok);

        form3.setTitle("");
        form3.setBounds(800, 250, 200, 100);
        form3.setLayout(new FlowLayout());

        Engine.setPlannedNumber();

        num.setText(String.valueOf(Engine.plannedNum));
        form3.add(num);
        form3.add(ok2);

    }
    public void createMenu()
    {
        JMenuBar menu = new JMenuBar();
        JMenu fileMenu = new JMenu("File");

        for (String fileItem : new String [] { "New", "Num" ,"Exit" })
        {
            JMenuItem item = new JMenuItem(fileItem);
            item.setActionCommand(fileItem.toLowerCase());
            item.addActionListener(new NewMenuListener());
            fileMenu.add(item);
        }
        fileMenu.insertSeparator(1);
        menu.add(fileMenu);
        setJMenuBar(menu);

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
                newGame();
            }
            if ("num".equals(command))
            {
                form3.setVisible(true);

            }

        }
    }
    public static void newGame()
    {
        for (int i=0; i<100; i++)
        {
            for (int j=0; j<100; j++)
            {
                data[i][j]=null;
            }
        }

        Engine.i=0;
        count=0;
        table1.repaint();
        Engine.setPlannedNumber();
        num.setText(String.valueOf(Engine.plannedNum));
        frame4.setVisible(true);
    }
    public static class TestActionListener implements ActionListener
    {
        @Override
        public void actionPerformed(ActionEvent e)
        {
            form2.setVisible(true);
        }
    }

    public static class TestActionListener2 implements ActionListener
    {
        @Override
        public void actionPerformed(ActionEvent e)
        {
                val = Integer.parseInt(text.getText());
                Engine.addValue(val);
                text.setText("");
                val=-1;
                table1.repaint();
                form2.dispose();
        }
    }

    public static class TestActionListener3 implements ActionListener
    {
        @Override
        public void actionPerformed(ActionEvent e)
        {
            form3.dispose();
        }
    }
    public static class TestActionListener4 implements ActionListener
    {
        @Override
        public void actionPerformed(ActionEvent e)
        {
            firstLab.setText(nameT.getText());
            frame4.dispose();
        }
    }

    public static void win()
    {
        JOptionPane.showMessageDialog(null, "YOU WIN!", "Congratulations", JOptionPane.INFORMATION_MESSAGE);
        newGame();
    }



}
