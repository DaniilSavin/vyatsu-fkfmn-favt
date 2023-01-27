<<<<<<< HEAD
package pack;
import java.awt.*;
import java.awt.event.*;

import javax.swing.*;
import javax.swing.JFrame;
import javax.swing.JTextField;
import javax.swing.text.*;


public class mod extends JFrame 
{
    private Component label = new JLabel("Введите количество элементов");
    private Component label2 = new JLabel("Пустое поле!");
    private Component field = new JTextField(15);
    private Component button = new JButton("Ввести");
    private int Size = 0;
    
    public mod () 
	{
		
		super("Массивчик");
		this.setBounds(700, 300, 250, 120);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setResizable(false);
		Container container = this.getContentPane();
		
		 SpringLayout layout = new SpringLayout();
		 container.setLayout(layout);
	        ActionListener actionListener = new TestActionListener();
	        ((JButton) button).addActionListener(actionListener);

	        container.add(label);
	        container.add(field);
	        container.add(label2);
	        container.add(button);
	        
	        
	        label2.setVisible(false);
	        label2.setFont(new Font("Dialog", Font.BOLD, 10));
	        label2.setForeground(Color.red);
	        field.setPreferredSize(new Dimension(30, 27));
	        field.setFont(new Font("Dialog", Font.PLAIN, 16));

	        ((JTextField) field).setDocument(new PlainDocument()
	        {            
	            String chars = "0123456789";
	            @Override
	            public void insertString(int offs, String str, AttributeSet a) throws BadLocationException 
	            {
	                if((chars.indexOf(str)!=-1) & (offs < 3)){
	                    super.insertString( offs, str, a);
	                }
	            }            
	        });
	        
	        layout.putConstraint(SpringLayout.WEST , label, 10, 
			                    SpringLayout.WEST , container);
			layout.putConstraint(SpringLayout.NORTH, label, 10, 
			                    SpringLayout.NORTH, container);
			
			layout.putConstraint(SpringLayout.NORTH, field, 35, 
			                    SpringLayout.NORTH, container);
			layout.putConstraint(SpringLayout.WEST, field, 10, 
                    			SpringLayout.WEST, container);
			layout.putConstraint(SpringLayout.EAST, field, -15, 
        						SpringLayout.WEST, button);
			
			layout.putConstraint(SpringLayout.NORTH , button, 35, 
                    			SpringLayout.NORTH , container);
			layout.putConstraint(SpringLayout.WEST , button, 150, 
        						SpringLayout.WEST , container);
			
			layout.putConstraint(SpringLayout.SOUTH , label2, 15, 
								SpringLayout.SOUTH , field);
	        layout.putConstraint(SpringLayout.WEST , label2, 10, 
                    			SpringLayout.WEST , container);
			
	}
	
	class TestActionListener implements ActionListener 
	{
		public void actionPerformed (ActionEvent e) {
			 try 
			 { 	
				 Size = Integer.parseInt(((JTextField) field).getText());
				 if (Size > 100)
				 {
					 label2.setVisible(true);
					 ((JLabel) label2).setText("Введите не более 100!");
					 return;
				 }
				 if (Size == 0)
				 {
					 label2.setVisible(true);
					 ((JLabel) label2).setText("Введите больше чем 0!");
					 return;
				 }
				 			 		 
				 secondmod app = new secondmod(Size);
				 
				 setVisible(false);
				 
			 } 
			 catch (Exception t)
			 {
				 label2.setVisible(true);
				 ((JLabel) label2).setText("Пустое поле!");
			 }
		}
	}
	
}
=======
package pack;
import java.awt.*;
import java.awt.event.*;

import javax.swing.*;
import javax.swing.JFrame;
import javax.swing.JTextField;
import javax.swing.text.*;


public class mod extends JFrame 
{
    private Component label = new JLabel("Введите количество элементов");
    private Component label2 = new JLabel("Пустое поле!");
    private Component field = new JTextField(15);
    private Component button = new JButton("Ввести");
    private int Size = 0;
    
    public mod () 
	{
		
		super("Массивчик");
		this.setBounds(700, 300, 250, 120);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setResizable(false);
		Container container = this.getContentPane();
		
		 SpringLayout layout = new SpringLayout();
		 container.setLayout(layout);
	        ActionListener actionListener = new TestActionListener();
	        ((JButton) button).addActionListener(actionListener);

	        container.add(label);
	        container.add(field);
	        container.add(label2);
	        container.add(button);
	        
	        
	        label2.setVisible(false);
	        label2.setFont(new Font("Dialog", Font.BOLD, 10));
	        label2.setForeground(Color.red);
	        field.setPreferredSize(new Dimension(30, 27));
	        field.setFont(new Font("Dialog", Font.PLAIN, 16));

	        ((JTextField) field).setDocument(new PlainDocument()
	        {            
	            String chars = "0123456789";
	            @Override
	            public void insertString(int offs, String str, AttributeSet a) throws BadLocationException 
	            {
	                if((chars.indexOf(str)!=-1) & (offs < 3)){
	                    super.insertString( offs, str, a);
	                }
	            }            
	        });
	        
	        layout.putConstraint(SpringLayout.WEST , label, 10, 
			                    SpringLayout.WEST , container);
			layout.putConstraint(SpringLayout.NORTH, label, 10, 
			                    SpringLayout.NORTH, container);
			
			layout.putConstraint(SpringLayout.NORTH, field, 35, 
			                    SpringLayout.NORTH, container);
			layout.putConstraint(SpringLayout.WEST, field, 10, 
                    			SpringLayout.WEST, container);
			layout.putConstraint(SpringLayout.EAST, field, -15, 
        						SpringLayout.WEST, button);
			
			layout.putConstraint(SpringLayout.NORTH , button, 35, 
                    			SpringLayout.NORTH , container);
			layout.putConstraint(SpringLayout.WEST , button, 150, 
        						SpringLayout.WEST , container);
			
			layout.putConstraint(SpringLayout.SOUTH , label2, 15, 
								SpringLayout.SOUTH , field);
	        layout.putConstraint(SpringLayout.WEST , label2, 10, 
                    			SpringLayout.WEST , container);
			
	}
	
	class TestActionListener implements ActionListener 
	{
		public void actionPerformed (ActionEvent e) {
			 try 
			 { 	
				 Size = Integer.parseInt(((JTextField) field).getText());
				 if (Size > 100)
				 {
					 label2.setVisible(true);
					 ((JLabel) label2).setText("Введите не более 100!");
					 return;
				 }
				 if (Size == 0)
				 {
					 label2.setVisible(true);
					 ((JLabel) label2).setText("Введите больше чем 0!");
					 return;
				 }
				 			 		 
				 secondmod app = new secondmod(Size);
				 
				 setVisible(false);
				 
			 } 
			 catch (Exception t)
			 {
				 label2.setVisible(true);
				 ((JLabel) label2).setText("Пустое поле!");
			 }
		}
	}
	
}
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
