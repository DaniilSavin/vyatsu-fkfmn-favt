<<<<<<< HEAD
package pack;
import javax.swing.*;
import javax.swing.text.AttributeSet;
import javax.swing.text.BadLocationException;
import javax.swing.text.PlainDocument;
import javax.swing.text.StyledDocument;

import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.*;
import java.text.*;

public class secondmod extends JFrame {
	JFrame Frame = new JFrame();
	JPanel Panel = new JPanel();
	JTextArea TextArea = new JTextArea(1,48);
	JTextPane TextPane = new JTextPane()
	{
        @Override
        public Color getSelectionColor() {
            return Color.GREEN;
        }

        @Override
        public Color getSelectedTextColor() {
            return Color.DARK_GRAY;
        }
    }
	;
	StyledDocument doc = TextPane.getStyledDocument();
	JScrollPane ScrollPane = new JScrollPane(TextPane);
	JScrollPane ScrollPane2 = new JScrollPane(TextArea);
	JLabel Label1_1 = new JLabel("Операции:");
	JLabel Label2 = new JLabel("Массивчик:");
	JButton Button1_1 = new JButton("Применить");
	JButton Button2_1 = new JButton("Применить");
	JButton Button3_1 = new JButton("Применить");
	JButton Button1 = new JButton("Изменить значение в точке");
	JButton Button2 = new JButton("Изменить значения на интервале");
	JButton Button3 = new JButton("Определить сумму значений на интервале");
	GroupLayout grpLayout = new GroupLayout(Panel);
	double[] myArray;
	String Mass = "";
	sqrt tom;
	JComboBox comboBox;
	String[] items;
	boolean flag = true;
    SimpleDateFormat formatForDateNow = new SimpleDateFormat("'['HH:mm:ss'] '");
	 
	 
	
	public secondmod(int Size) 
	{
        
        ActionListener actionListener = new TestActionListener();
        Button1.addActionListener(actionListener);
        Button2.addActionListener(actionListener);
        Button3.addActionListener(actionListener);
        Button1_1.addActionListener(actionListener);
        Button2_1.addActionListener(actionListener);
        Button3_1.addActionListener(actionListener);
    	tom = new sqrt(Size);
    	items = new String[Size];

	   	 for (int i = 0; i < items.length; i++) { items[i] = Integer.toString(i); }
		comboBox = new JComboBox(items);
    	
		TextPane.setEditable(false);
		TextArea.setEditable(false);
		TextArea.setFont(new Font("Dialog", Font.PLAIN, 16));
		TextPane.setFont(new Font("Dialog", Font.PLAIN, 16));
		myArray = new double[Size];
		myArray = tom.ReturnArray(true);
		PrintArray();
		Frame.add(Panel);
		Panel.setLayout(grpLayout);
		Panel.revalidate();
		ScrollPane2.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_NEVER);
		ScrollPane2.setHorizontalScrollBarPolicy(JScrollPane.HORIZONTAL_SCROLLBAR_ALWAYS);
		SetLayout();
		Build();
		
	}
	
	public void PrintArray()
	{
		for (int i = 0; i < myArray.length; i++) 
    	{
			Mass = Mass + "[" + i + "]" + String.valueOf(myArray[i]) + "      ";
    	}
		TextArea.setText(String.valueOf(Mass));
	}
	
	public void StringProve(JTextField TextField)
	{
        ((JTextField) TextField).setDocument(new PlainDocument()
        {
            String chars = "0123456789.-";
            @Override
            public void insertString(int offs, String str, AttributeSet a) throws BadLocationException 
            {
                if((chars.indexOf(str)!=-1) & (offs < 8)){
                    super.insertString( offs, str, a);
                }
            }            
        });
	}
	
	
	public void SetLayout() 
	{
		grpLayout.setHorizontalGroup(grpLayout.createParallelGroup()
		.addGroup(grpLayout.createSequentialGroup()
		.addGap(10)
		.addComponent(Label2)
		.addGap(10))
		.addGroup(grpLayout.createSequentialGroup()
		.addGap(10)
		.addComponent(ScrollPane2)
		.addGap(10))
		.addGroup(grpLayout.createSequentialGroup()	
		.addGap(10)
		.addComponent(Button1)
		.addGap(20)
		.addComponent(Button2)
		.addGap(20)
		.addComponent(Button3)
		.addGap(10))
		.addGroup(grpLayout.createSequentialGroup()
		.addGap(10)
		.addComponent(Label1_1))
		.addGroup(grpLayout.createSequentialGroup()
		.addGap(10)
		.addComponent(ScrollPane)
		.addGap(10)));
		grpLayout.setVerticalGroup(grpLayout.createSequentialGroup()
		.addGap(15)
		.addComponent(Label2)
		.addGap(5)
		.addComponent(ScrollPane2)
		.addGap(20)
		.addGroup(grpLayout.createParallelGroup()
		.addComponent(Button1)
		.addComponent(Button2)
		.addComponent(Button3))
		.addGap(15)
		.addComponent(Label1_1)
		.addGap(5)
		.addGroup(grpLayout.createParallelGroup()
		.addComponent(ScrollPane)
		.addGap(250))
		.addGap(10));
	}
	
	public void Build() 
	{
		setContentPane(Panel);
		pack();
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setLocationRelativeTo(null);
		setTitle("SQRT декомпозиция");
		setVisible(true);
	}
	
	
	
	class TestActionListener implements ActionListener 
	{
		
		JDialog d;
		JTextField TextField1 = new JTextField(15);
		JTextField TextField2_1 = new JTextField(5);
		JTextField TextField2_2 = new JTextField(10);
		JTextField TextField2_3 = new JTextField(5);
		JTextField TextField3 = new JTextField(6);
		JTextField TextField3_1 = new JTextField(6);
		JPanel Panel = new JPanel();
		JLabel Label1_1 = new JLabel("Введите новое значение:");
		JLabel Label1_2 = new JLabel("Выберите элемент:");
		JLabel Label1_3 = new JLabel("Введено некорректное значение");
		JLabel Label2_1 = new JLabel("Введите добавочное значение:");
		JLabel Label2_2 = new JLabel("Введите интервал x1 x2:");
		JLabel Label2_3 = new JLabel("Введены некорректные данные");
		JLabel Label3_1 = new JLabel("Введите интервал x1 x2:");
		JLabel Label3_2 = new JLabel("Введено некорректное значение");
		
		int Position, Posa, Posb;
		double Value, Sum;
		
		public void actionPerformed (ActionEvent e) 
		{
			
			if(e.getSource() == Button1)
			{
				Label1_1.setVisible(true);
				Label1_2.setVisible(true);
				Label1_3.setVisible(false);
				comboBox.setVisible(true);
				TextField1.setVisible(true);
				Button1_1.setVisible(true);
				
				Label2_1.setVisible(false);
				Label2_2.setVisible(false);
				Label2_3.setVisible(false);
				TextField2_1.setVisible(false);
				TextField2_2.setVisible(false);
				TextField2_3.setVisible(false);
				Button2_1.setVisible(false);
				
				Label3_1.setVisible(false);
				Label3_2.setVisible(false);
				TextField3.setVisible(false);
				TextField3_1.setVisible(false);
				Button3_1.setVisible(false);	
				
		        Label1_3.setForeground(Color.red);
				GroupLayout grpLayout = new GroupLayout(Panel);
				d = new JDialog(Frame, "Изменить значения в точке", true);
				d.add(Panel);
				d.setResizable(false);
				
				Panel.setLayout(grpLayout);
				Panel.revalidate();
				
		        StringProve(TextField1);
				
				grpLayout.setHorizontalGroup(grpLayout.createParallelGroup()
						.addGroup(grpLayout.createSequentialGroup()
						.addGap(10)
						.addComponent(Label1_2)
						.addGap(10)
						.addComponent(comboBox)
						.addGap(10))
						.addGroup(grpLayout.createSequentialGroup()
						.addGap(10)
						.addComponent(Label1_1)
						.addGap(10)
						.addComponent(TextField1)
						.addGap(10))
						.addGroup(grpLayout.createSequentialGroup()
						.addGap(10)	
						.addComponent(Button1_1)
						.addGap(30)	
						.addComponent(Label1_3)));
				
				grpLayout.setVerticalGroup(grpLayout.createSequentialGroup()
						.addGap(10)
						.addGroup(grpLayout.createParallelGroup()
						.addComponent(Label1_2)
						.addComponent(comboBox))
						.addGap(10)
						.addGroup(grpLayout.createParallelGroup()
						.addComponent(Label1_1)
						.addComponent(TextField1))
						.addGap(10)
						.addGroup(grpLayout.createParallelGroup()
						.addComponent(Button1_1)
						.addComponent(Label1_3))
						.addGap(10))
						;
				
				d.setContentPane(Panel);
				d.pack();
				d.setLocationRelativeTo(null);
				d.setTitle("Изменить значение в точке");
				d.setVisible(true);
			}
			
			if(e.getSource() == Button2)
			{
				
				Label1_1.setVisible(false);
				Label1_2.setVisible(false);
				Label1_3.setVisible(false);
				comboBox.setVisible(false);
				TextField1.setVisible(false);
				Button1_1.setVisible(false);
				
				Label2_1.setVisible(true);
				Label2_2.setVisible(true);
				Label2_3.setVisible(false);
				TextField2_1.setVisible(true);
				TextField2_2.setVisible(true);
				TextField2_3.setVisible(true);
				Button2_1.setVisible(true);
				
				Label3_1.setVisible(false);
				Label3_2.setVisible(false);
				TextField3.setVisible(false);
				TextField3_1.setVisible(false);
				Button3_1.setVisible(false);	
				
		        Label2_3.setForeground(Color.red);
				GroupLayout grpLayout2 = new GroupLayout(Panel);
				d = new JDialog(Frame, "Изменить значения на интервале", true);
				d.add(Panel);
				d.setResizable(false);
				
				Panel.setLayout(grpLayout2);
				Panel.revalidate();
				
		        StringProve(TextField2_1);
		        StringProve(TextField2_2);
		        StringProve(TextField2_3);
		        
				
		        grpLayout2.setHorizontalGroup(grpLayout2.createParallelGroup()
						.addGroup(grpLayout2.createSequentialGroup()
						.addGap(10)
						.addComponent(Label2_2)
						.addGap(10)
						.addComponent(TextField2_1)
						.addGap(10)
						.addComponent(TextField2_3)
						.addGap(10))
						.addGroup(grpLayout2.createSequentialGroup()
						.addGap(10)
						.addComponent(Label2_1)
						.addGap(10)
						.addComponent(TextField2_2)
						.addGap(10))
						.addGroup(grpLayout2.createSequentialGroup()
						.addGap(10)	
						.addComponent(Button2_1)
						.addGap(20)	
						.addComponent(Label2_3)));
				
		        grpLayout2.setVerticalGroup(grpLayout2.createSequentialGroup()
						.addGap(10)
						.addGroup(grpLayout2.createParallelGroup()
						.addComponent(Label2_2)
						.addComponent(TextField2_1)
						.addComponent(TextField2_3))
						.addGap(10)
						.addGroup(grpLayout2.createParallelGroup()
						.addComponent(Label2_1)
						.addComponent(TextField2_2))
						.addGap(10)
						.addGroup(grpLayout2.createParallelGroup()
						.addComponent(Button2_1)
						.addComponent(Label2_3))
						.addGap(10))
						;
				
				d.setContentPane(Panel);
				d.pack();
				d.setLocationRelativeTo(null);
				d.setTitle("Изменить значения на интервале");
				d.setVisible(true);
			}
			
			if(e.getSource() == Button3)
			{
				Label1_1.setVisible(false);
				Label1_2.setVisible(false);
				Label1_3.setVisible(false);
				comboBox.setVisible(false);
				TextField1.setVisible(false);
				Button1_1.setVisible(false);
				
				Label2_1.setVisible(false);
				Label2_2.setVisible(false);
				Label2_3.setVisible(false);
				TextField2_1.setVisible(false);
				TextField2_2.setVisible(false);
				TextField2_3.setVisible(false);
				Button2_1.setVisible(false);
				
				Label3_1.setVisible(true);
				Label3_2.setVisible(false);
				TextField3.setVisible(true);
				TextField3_1.setVisible(true);
				Button3_1.setVisible(true);	
		        Label3_2.setForeground(Color.red);
				GroupLayout grpLayout = new GroupLayout(Panel);
				d = new JDialog(Frame, "Определить сумму значений на интервале", true);
				d.add(Panel);
				d.setResizable(false);
				
				Panel.setLayout(grpLayout);
				Panel.revalidate();
				
		        StringProve(TextField3);
		        StringProve(TextField3_1);
				
				grpLayout.setHorizontalGroup(grpLayout.createParallelGroup()
						.addGroup(grpLayout.createSequentialGroup()
						.addGap(10)
						.addComponent(Label3_1)
						.addGap(10)
						.addComponent(TextField3)
						.addGap(10)
						.addComponent(TextField3_1)
						.addGap(10))
						.addGroup(grpLayout.createSequentialGroup()
						.addGap(10)	
						.addComponent(Button3_1)
						.addGap(15)	
						.addComponent(Label3_2)));
				
				grpLayout.setVerticalGroup(grpLayout.createSequentialGroup()
						.addGap(10)
						.addGroup(grpLayout.createParallelGroup()
						.addComponent(Label3_1)
						.addComponent(TextField3)
						.addComponent(TextField3_1))
						.addGap(10)
						.addGroup(grpLayout.createParallelGroup()
						.addComponent(Button3_1)
						.addComponent(Label3_2))
						.addGap(10))
						;
				
				d.setContentPane(Panel);
				d.pack();
				d.setLocationRelativeTo(null);
				d.setTitle("Определить сумму значений на интервале");
				d.setVisible(true);
			}
			
			if(e.getSource() == Button1_1)
			{
				try
				{
					Position = Integer.parseInt((String) comboBox.getSelectedItem());
					Value = Double.parseDouble(TextField1.getText());
					tom.EditAtPoint(Position,Value);
					myArray = tom.ReturnArray(true);
					Mass = "";
					PrintArray();
					d.dispose();
				    Date dateNow = new Date();
				    doc.insertString(0, formatForDateNow.format(dateNow) + "Значение в точке " + Position + " изменено на " + Value + "\n", null );

				}
				catch (Exception t1)
				{
					Label1_3.setVisible(true);
				}
			}
			
			if(e.getSource() == Button2_1)
			{
				try
				{
					Posa = Integer.parseInt(TextField2_1.getText());
					Posb = Integer.parseInt(TextField2_3.getText());
					Value = Double.parseDouble(TextField2_2.getText());
					boolean Prove = tom.ChangeOnInterval(Posa, Posb, Value);
					if (Prove)
					{
						myArray = tom.ReturnArray(true);
						Mass = "";
						PrintArray();
						d.dispose();
					    Date dateNow = new Date();
					    doc.insertString(0, formatForDateNow.format(dateNow) + "Добавочное значение на интервале [" + Posa + "," + Posb + "] изменено на " + Value + "\n", null );
					}
					else Label2_3.setVisible(true);
					
				}
				catch (Exception t2)
				{
					Label2_3.setVisible(true);
				}
			}
			
			if(e.getSource() == Button3_1)
			{
				try
				{
					Posa = Integer.parseInt(TextField3.getText());
					Posb = Integer.parseInt(TextField3_1.getText());
					boolean Prove = tom.SummOnInterval(Posa,Posb);
					if (Prove)
					{
						Sum = tom.ReturnSumm();
						myArray = tom.ReturnArray(true);
						Mass = "";
						PrintArray();
						d.dispose();
					    Date dateNow = new Date();
					    doc.insertString(0, formatForDateNow.format(dateNow) + "Сумма на интервале [" + Posa + "," + Posb + "] = " + Sum + "\n", null );
					}
					else Label3_2.setVisible(true);
					
				}
				catch (Exception t3)
				{
					Label3_2.setVisible(true);
				}
				
			}
		}
		
	}
	

=======
package pack;
import javax.swing.*;
import javax.swing.text.AttributeSet;
import javax.swing.text.BadLocationException;
import javax.swing.text.PlainDocument;
import javax.swing.text.StyledDocument;

import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.*;
import java.text.*;

public class secondmod extends JFrame {
	JFrame Frame = new JFrame();
	JPanel Panel = new JPanel();
	JTextArea TextArea = new JTextArea(1,48);
	JTextPane TextPane = new JTextPane()
	{
        @Override
        public Color getSelectionColor() {
            return Color.GREEN;
        }

        @Override
        public Color getSelectedTextColor() {
            return Color.DARK_GRAY;
        }
    }
	;
	StyledDocument doc = TextPane.getStyledDocument();
	JScrollPane ScrollPane = new JScrollPane(TextPane);
	JScrollPane ScrollPane2 = new JScrollPane(TextArea);
	JLabel Label1_1 = new JLabel("Операции:");
	JLabel Label2 = new JLabel("Массивчик:");
	JButton Button1_1 = new JButton("Применить");
	JButton Button2_1 = new JButton("Применить");
	JButton Button3_1 = new JButton("Применить");
	JButton Button1 = new JButton("Изменить значение в точке");
	JButton Button2 = new JButton("Изменить значения на интервале");
	JButton Button3 = new JButton("Определить сумму значений на интервале");
	GroupLayout grpLayout = new GroupLayout(Panel);
	double[] myArray;
	String Mass = "";
	sqrt tom;
	JComboBox comboBox;
	String[] items;
	boolean flag = true;
    SimpleDateFormat formatForDateNow = new SimpleDateFormat("'['HH:mm:ss'] '");
	 
	 
	
	public secondmod(int Size) 
	{
        
        ActionListener actionListener = new TestActionListener();
        Button1.addActionListener(actionListener);
        Button2.addActionListener(actionListener);
        Button3.addActionListener(actionListener);
        Button1_1.addActionListener(actionListener);
        Button2_1.addActionListener(actionListener);
        Button3_1.addActionListener(actionListener);
    	tom = new sqrt(Size);
    	items = new String[Size];

	   	 for (int i = 0; i < items.length; i++) { items[i] = Integer.toString(i); }
		comboBox = new JComboBox(items);
    	
		TextPane.setEditable(false);
		TextArea.setEditable(false);
		TextArea.setFont(new Font("Dialog", Font.PLAIN, 16));
		TextPane.setFont(new Font("Dialog", Font.PLAIN, 16));
		myArray = new double[Size];
		myArray = tom.ReturnArray(true);
		PrintArray();
		Frame.add(Panel);
		Panel.setLayout(grpLayout);
		Panel.revalidate();
		ScrollPane2.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_NEVER);
		ScrollPane2.setHorizontalScrollBarPolicy(JScrollPane.HORIZONTAL_SCROLLBAR_ALWAYS);
		SetLayout();
		Build();
		
	}
	
	public void PrintArray()
	{
		for (int i = 0; i < myArray.length; i++) 
    	{
			Mass = Mass + "[" + i + "]" + String.valueOf(myArray[i]) + "      ";
    	}
		TextArea.setText(String.valueOf(Mass));
	}
	
	public void StringProve(JTextField TextField)
	{
        ((JTextField) TextField).setDocument(new PlainDocument()
        {
            String chars = "0123456789.-";
            @Override
            public void insertString(int offs, String str, AttributeSet a) throws BadLocationException 
            {
                if((chars.indexOf(str)!=-1) & (offs < 8)){
                    super.insertString( offs, str, a);
                }
            }            
        });
	}
	
	
	public void SetLayout() 
	{
		grpLayout.setHorizontalGroup(grpLayout.createParallelGroup()
		.addGroup(grpLayout.createSequentialGroup()
		.addGap(10)
		.addComponent(Label2)
		.addGap(10))
		.addGroup(grpLayout.createSequentialGroup()
		.addGap(10)
		.addComponent(ScrollPane2)
		.addGap(10))
		.addGroup(grpLayout.createSequentialGroup()	
		.addGap(10)
		.addComponent(Button1)
		.addGap(20)
		.addComponent(Button2)
		.addGap(20)
		.addComponent(Button3)
		.addGap(10))
		.addGroup(grpLayout.createSequentialGroup()
		.addGap(10)
		.addComponent(Label1_1))
		.addGroup(grpLayout.createSequentialGroup()
		.addGap(10)
		.addComponent(ScrollPane)
		.addGap(10)));
		grpLayout.setVerticalGroup(grpLayout.createSequentialGroup()
		.addGap(15)
		.addComponent(Label2)
		.addGap(5)
		.addComponent(ScrollPane2)
		.addGap(20)
		.addGroup(grpLayout.createParallelGroup()
		.addComponent(Button1)
		.addComponent(Button2)
		.addComponent(Button3))
		.addGap(15)
		.addComponent(Label1_1)
		.addGap(5)
		.addGroup(grpLayout.createParallelGroup()
		.addComponent(ScrollPane)
		.addGap(250))
		.addGap(10));
	}
	
	public void Build() 
	{
		setContentPane(Panel);
		pack();
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setLocationRelativeTo(null);
		setTitle("SQRT декомпозиция");
		setVisible(true);
	}
	
	
	
	class TestActionListener implements ActionListener 
	{
		
		JDialog d;
		JTextField TextField1 = new JTextField(15);
		JTextField TextField2_1 = new JTextField(5);
		JTextField TextField2_2 = new JTextField(10);
		JTextField TextField2_3 = new JTextField(5);
		JTextField TextField3 = new JTextField(6);
		JTextField TextField3_1 = new JTextField(6);
		JPanel Panel = new JPanel();
		JLabel Label1_1 = new JLabel("Введите новое значение:");
		JLabel Label1_2 = new JLabel("Выберите элемент:");
		JLabel Label1_3 = new JLabel("Введено некорректное значение");
		JLabel Label2_1 = new JLabel("Введите добавочное значение:");
		JLabel Label2_2 = new JLabel("Введите интервал x1 x2:");
		JLabel Label2_3 = new JLabel("Введены некорректные данные");
		JLabel Label3_1 = new JLabel("Введите интервал x1 x2:");
		JLabel Label3_2 = new JLabel("Введено некорректное значение");
		
		int Position, Posa, Posb;
		double Value, Sum;
		
		public void actionPerformed (ActionEvent e) 
		{
			
			if(e.getSource() == Button1)
			{
				Label1_1.setVisible(true);
				Label1_2.setVisible(true);
				Label1_3.setVisible(false);
				comboBox.setVisible(true);
				TextField1.setVisible(true);
				Button1_1.setVisible(true);
				
				Label2_1.setVisible(false);
				Label2_2.setVisible(false);
				Label2_3.setVisible(false);
				TextField2_1.setVisible(false);
				TextField2_2.setVisible(false);
				TextField2_3.setVisible(false);
				Button2_1.setVisible(false);
				
				Label3_1.setVisible(false);
				Label3_2.setVisible(false);
				TextField3.setVisible(false);
				TextField3_1.setVisible(false);
				Button3_1.setVisible(false);	
				
		        Label1_3.setForeground(Color.red);
				GroupLayout grpLayout = new GroupLayout(Panel);
				d = new JDialog(Frame, "Изменить значения в точке", true);
				d.add(Panel);
				d.setResizable(false);
				
				Panel.setLayout(grpLayout);
				Panel.revalidate();
				
		        StringProve(TextField1);
				
				grpLayout.setHorizontalGroup(grpLayout.createParallelGroup()
						.addGroup(grpLayout.createSequentialGroup()
						.addGap(10)
						.addComponent(Label1_2)
						.addGap(10)
						.addComponent(comboBox)
						.addGap(10))
						.addGroup(grpLayout.createSequentialGroup()
						.addGap(10)
						.addComponent(Label1_1)
						.addGap(10)
						.addComponent(TextField1)
						.addGap(10))
						.addGroup(grpLayout.createSequentialGroup()
						.addGap(10)	
						.addComponent(Button1_1)
						.addGap(30)	
						.addComponent(Label1_3)));
				
				grpLayout.setVerticalGroup(grpLayout.createSequentialGroup()
						.addGap(10)
						.addGroup(grpLayout.createParallelGroup()
						.addComponent(Label1_2)
						.addComponent(comboBox))
						.addGap(10)
						.addGroup(grpLayout.createParallelGroup()
						.addComponent(Label1_1)
						.addComponent(TextField1))
						.addGap(10)
						.addGroup(grpLayout.createParallelGroup()
						.addComponent(Button1_1)
						.addComponent(Label1_3))
						.addGap(10))
						;
				
				d.setContentPane(Panel);
				d.pack();
				d.setLocationRelativeTo(null);
				d.setTitle("Изменить значение в точке");
				d.setVisible(true);
			}
			
			if(e.getSource() == Button2)
			{
				
				Label1_1.setVisible(false);
				Label1_2.setVisible(false);
				Label1_3.setVisible(false);
				comboBox.setVisible(false);
				TextField1.setVisible(false);
				Button1_1.setVisible(false);
				
				Label2_1.setVisible(true);
				Label2_2.setVisible(true);
				Label2_3.setVisible(false);
				TextField2_1.setVisible(true);
				TextField2_2.setVisible(true);
				TextField2_3.setVisible(true);
				Button2_1.setVisible(true);
				
				Label3_1.setVisible(false);
				Label3_2.setVisible(false);
				TextField3.setVisible(false);
				TextField3_1.setVisible(false);
				Button3_1.setVisible(false);	
				
		        Label2_3.setForeground(Color.red);
				GroupLayout grpLayout2 = new GroupLayout(Panel);
				d = new JDialog(Frame, "Изменить значения на интервале", true);
				d.add(Panel);
				d.setResizable(false);
				
				Panel.setLayout(grpLayout2);
				Panel.revalidate();
				
		        StringProve(TextField2_1);
		        StringProve(TextField2_2);
		        StringProve(TextField2_3);
		        
				
		        grpLayout2.setHorizontalGroup(grpLayout2.createParallelGroup()
						.addGroup(grpLayout2.createSequentialGroup()
						.addGap(10)
						.addComponent(Label2_2)
						.addGap(10)
						.addComponent(TextField2_1)
						.addGap(10)
						.addComponent(TextField2_3)
						.addGap(10))
						.addGroup(grpLayout2.createSequentialGroup()
						.addGap(10)
						.addComponent(Label2_1)
						.addGap(10)
						.addComponent(TextField2_2)
						.addGap(10))
						.addGroup(grpLayout2.createSequentialGroup()
						.addGap(10)	
						.addComponent(Button2_1)
						.addGap(20)	
						.addComponent(Label2_3)));
				
		        grpLayout2.setVerticalGroup(grpLayout2.createSequentialGroup()
						.addGap(10)
						.addGroup(grpLayout2.createParallelGroup()
						.addComponent(Label2_2)
						.addComponent(TextField2_1)
						.addComponent(TextField2_3))
						.addGap(10)
						.addGroup(grpLayout2.createParallelGroup()
						.addComponent(Label2_1)
						.addComponent(TextField2_2))
						.addGap(10)
						.addGroup(grpLayout2.createParallelGroup()
						.addComponent(Button2_1)
						.addComponent(Label2_3))
						.addGap(10))
						;
				
				d.setContentPane(Panel);
				d.pack();
				d.setLocationRelativeTo(null);
				d.setTitle("Изменить значения на интервале");
				d.setVisible(true);
			}
			
			if(e.getSource() == Button3)
			{
				Label1_1.setVisible(false);
				Label1_2.setVisible(false);
				Label1_3.setVisible(false);
				comboBox.setVisible(false);
				TextField1.setVisible(false);
				Button1_1.setVisible(false);
				
				Label2_1.setVisible(false);
				Label2_2.setVisible(false);
				Label2_3.setVisible(false);
				TextField2_1.setVisible(false);
				TextField2_2.setVisible(false);
				TextField2_3.setVisible(false);
				Button2_1.setVisible(false);
				
				Label3_1.setVisible(true);
				Label3_2.setVisible(false);
				TextField3.setVisible(true);
				TextField3_1.setVisible(true);
				Button3_1.setVisible(true);	
		        Label3_2.setForeground(Color.red);
				GroupLayout grpLayout = new GroupLayout(Panel);
				d = new JDialog(Frame, "Определить сумму значений на интервале", true);
				d.add(Panel);
				d.setResizable(false);
				
				Panel.setLayout(grpLayout);
				Panel.revalidate();
				
		        StringProve(TextField3);
		        StringProve(TextField3_1);
				
				grpLayout.setHorizontalGroup(grpLayout.createParallelGroup()
						.addGroup(grpLayout.createSequentialGroup()
						.addGap(10)
						.addComponent(Label3_1)
						.addGap(10)
						.addComponent(TextField3)
						.addGap(10)
						.addComponent(TextField3_1)
						.addGap(10))
						.addGroup(grpLayout.createSequentialGroup()
						.addGap(10)	
						.addComponent(Button3_1)
						.addGap(15)	
						.addComponent(Label3_2)));
				
				grpLayout.setVerticalGroup(grpLayout.createSequentialGroup()
						.addGap(10)
						.addGroup(grpLayout.createParallelGroup()
						.addComponent(Label3_1)
						.addComponent(TextField3)
						.addComponent(TextField3_1))
						.addGap(10)
						.addGroup(grpLayout.createParallelGroup()
						.addComponent(Button3_1)
						.addComponent(Label3_2))
						.addGap(10))
						;
				
				d.setContentPane(Panel);
				d.pack();
				d.setLocationRelativeTo(null);
				d.setTitle("Определить сумму значений на интервале");
				d.setVisible(true);
			}
			
			if(e.getSource() == Button1_1)
			{
				try
				{
					Position = Integer.parseInt((String) comboBox.getSelectedItem());
					Value = Double.parseDouble(TextField1.getText());
					tom.EditAtPoint(Position,Value);
					myArray = tom.ReturnArray(true);
					Mass = "";
					PrintArray();
					d.dispose();
				    Date dateNow = new Date();
				    doc.insertString(0, formatForDateNow.format(dateNow) + "Значение в точке " + Position + " изменено на " + Value + "\n", null );

				}
				catch (Exception t1)
				{
					Label1_3.setVisible(true);
				}
			}
			
			if(e.getSource() == Button2_1)
			{
				try
				{
					Posa = Integer.parseInt(TextField2_1.getText());
					Posb = Integer.parseInt(TextField2_3.getText());
					Value = Double.parseDouble(TextField2_2.getText());
					boolean Prove = tom.ChangeOnInterval(Posa, Posb, Value);
					if (Prove)
					{
						myArray = tom.ReturnArray(true);
						Mass = "";
						PrintArray();
						d.dispose();
					    Date dateNow = new Date();
					    doc.insertString(0, formatForDateNow.format(dateNow) + "Добавочное значение на интервале [" + Posa + "," + Posb + "] изменено на " + Value + "\n", null );
					}
					else Label2_3.setVisible(true);
					
				}
				catch (Exception t2)
				{
					Label2_3.setVisible(true);
				}
			}
			
			if(e.getSource() == Button3_1)
			{
				try
				{
					Posa = Integer.parseInt(TextField3.getText());
					Posb = Integer.parseInt(TextField3_1.getText());
					boolean Prove = tom.SummOnInterval(Posa,Posb);
					if (Prove)
					{
						Sum = tom.ReturnSumm();
						myArray = tom.ReturnArray(true);
						Mass = "";
						PrintArray();
						d.dispose();
					    Date dateNow = new Date();
					    doc.insertString(0, formatForDateNow.format(dateNow) + "Сумма на интервале [" + Posa + "," + Posb + "] = " + Sum + "\n", null );
					}
					else Label3_2.setVisible(true);
					
				}
				catch (Exception t3)
				{
					Label3_2.setVisible(true);
				}
				
			}
		}
		
	}
	

>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
}