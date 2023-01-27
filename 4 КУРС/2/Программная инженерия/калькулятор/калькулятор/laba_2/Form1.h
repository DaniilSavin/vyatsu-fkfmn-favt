#pragma once

namespace laba_2 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Form1
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//	
			nn=0; 
			fg=0;
			b=0;
			c=0;
			flag =-1;
			del = false;
		}



	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button^  button1;
	protected: 
	private: System::Windows::Forms::Button^  button2;
	private: System::Windows::Forms::Button^  button3;
	private: System::Windows::Forms::Button^  button4;
	private: System::Windows::Forms::Button^  button5;
	private: System::Windows::Forms::Button^  button6;
	private: System::Windows::Forms::Button^  button7;
	private: System::Windows::Forms::Button^  button8;
	private: System::Windows::Forms::Button^  button9;
	private: System::Windows::Forms::Button^  button10;
	private: System::Windows::Forms::Button^  button11;
	private: System::Windows::Forms::Button^  button12;
	private: System::Windows::Forms::Button^  button13;
	private: System::Windows::Forms::Button^  button14;
	private: System::Windows::Forms::TextBox^  textBox1;
	private: System::Windows::Forms::Button^  button15;
	private: System::Windows::Forms::Button^  button16;
	private: System::Windows::Forms::Button^  button17;


	private:
		/// <summary>
		/// Required designer variable.
		//static 
			int nn,fg;//нужен ли static?
		int flag;
		double b,c;
		bool del;
	private: System::Windows::Forms::Button^  button18;
			 System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->button3 = (gcnew System::Windows::Forms::Button());
			this->button4 = (gcnew System::Windows::Forms::Button());
			this->button5 = (gcnew System::Windows::Forms::Button());
			this->button6 = (gcnew System::Windows::Forms::Button());
			this->button7 = (gcnew System::Windows::Forms::Button());
			this->button8 = (gcnew System::Windows::Forms::Button());
			this->button9 = (gcnew System::Windows::Forms::Button());
			this->button10 = (gcnew System::Windows::Forms::Button());
			this->button11 = (gcnew System::Windows::Forms::Button());
			this->button12 = (gcnew System::Windows::Forms::Button());
			this->button13 = (gcnew System::Windows::Forms::Button());
			this->button14 = (gcnew System::Windows::Forms::Button());
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->button15 = (gcnew System::Windows::Forms::Button());
			this->button16 = (gcnew System::Windows::Forms::Button());
			this->button17 = (gcnew System::Windows::Forms::Button());
			this->button18 = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->button1->Location = System::Drawing::Point(24, 86);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(40, 40);
			this->button1->TabIndex = 0;
			this->button1->Text = L"1";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// button2
			// 
			this->button2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->button2->Location = System::Drawing::Point(70, 86);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(40, 40);
			this->button2->TabIndex = 1;
			this->button2->Text = L"2";
			this->button2->UseVisualStyleBackColor = true;
			this->button2->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// button3
			// 
			this->button3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->button3->Location = System::Drawing::Point(116, 86);
			this->button3->Name = L"button3";
			this->button3->Size = System::Drawing::Size(40, 40);
			this->button3->TabIndex = 2;
			this->button3->Text = L"3";
			this->button3->UseVisualStyleBackColor = true;
			this->button3->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// button4
			// 
			this->button4->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->button4->Location = System::Drawing::Point(24, 132);
			this->button4->Name = L"button4";
			this->button4->Size = System::Drawing::Size(40, 40);
			this->button4->TabIndex = 3;
			this->button4->Text = L"4";
			this->button4->UseVisualStyleBackColor = true;
			this->button4->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// button5
			// 
			this->button5->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->button5->Location = System::Drawing::Point(70, 132);
			this->button5->Name = L"button5";
			this->button5->Size = System::Drawing::Size(40, 40);
			this->button5->TabIndex = 4;
			this->button5->Text = L"5";
			this->button5->UseVisualStyleBackColor = true;
			this->button5->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// button6
			// 
			this->button6->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->button6->Location = System::Drawing::Point(116, 132);
			this->button6->Name = L"button6";
			this->button6->Size = System::Drawing::Size(40, 40);
			this->button6->TabIndex = 5;
			this->button6->Text = L"6";
			this->button6->UseVisualStyleBackColor = true;
			this->button6->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// button7
			// 
			this->button7->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->button7->Location = System::Drawing::Point(24, 178);
			this->button7->Name = L"button7";
			this->button7->Size = System::Drawing::Size(40, 40);
			this->button7->TabIndex = 6;
			this->button7->Text = L"7";
			this->button7->UseVisualStyleBackColor = true;
			this->button7->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// button8
			// 
			this->button8->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->button8->Location = System::Drawing::Point(70, 178);
			this->button8->Name = L"button8";
			this->button8->Size = System::Drawing::Size(40, 40);
			this->button8->TabIndex = 7;
			this->button8->Text = L"8";
			this->button8->UseVisualStyleBackColor = true;
			this->button8->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// button9
			// 
			this->button9->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->button9->Location = System::Drawing::Point(116, 178);
			this->button9->Name = L"button9";
			this->button9->Size = System::Drawing::Size(40, 40);
			this->button9->TabIndex = 8;
			this->button9->Text = L"9";
			this->button9->UseVisualStyleBackColor = true;
			this->button9->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// button10
			// 
			this->button10->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->button10->Location = System::Drawing::Point(181, 86);
			this->button10->Name = L"button10";
			this->button10->Size = System::Drawing::Size(40, 86);
			this->button10->TabIndex = 9;
			this->button10->Tag = L"1";
			this->button10->Text = L"+";
			this->button10->UseVisualStyleBackColor = true;
			this->button10->Click += gcnew System::EventHandler(this, &Form1::button10_Click);
			// 
			// button11
			// 
			this->button11->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->button11->Location = System::Drawing::Point(227, 86);
			this->button11->Name = L"button11";
			this->button11->Size = System::Drawing::Size(40, 40);
			this->button11->TabIndex = 10;
			this->button11->Tag = L"2";
			this->button11->Text = L"-";
			this->button11->UseVisualStyleBackColor = true;
			this->button11->Click += gcnew System::EventHandler(this, &Form1::button10_Click);
			// 
			// button12
			// 
			this->button12->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->button12->Location = System::Drawing::Point(181, 178);
			this->button12->Name = L"button12";
			this->button12->Size = System::Drawing::Size(40, 40);
			this->button12->TabIndex = 11;
			this->button12->Text = L"=";
			this->button12->UseVisualStyleBackColor = true;
			this->button12->Click += gcnew System::EventHandler(this, &Form1::button12_Click);
			// 
			// button13
			// 
			this->button13->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->button13->Location = System::Drawing::Point(227, 178);
			this->button13->Name = L"button13";
			this->button13->Size = System::Drawing::Size(40, 40);
			this->button13->TabIndex = 12;
			this->button13->Tag = L"4";
			this->button13->Text = L"/";
			this->button13->UseVisualStyleBackColor = true;
			this->button13->Click += gcnew System::EventHandler(this, &Form1::button10_Click);
			// 
			// button14
			// 
			this->button14->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->button14->Location = System::Drawing::Point(227, 132);
			this->button14->Name = L"button14";
			this->button14->Size = System::Drawing::Size(40, 40);
			this->button14->TabIndex = 13;
			this->button14->Tag = L"3";
			this->button14->Text = L"*";
			this->button14->UseVisualStyleBackColor = true;
			this->button14->Click += gcnew System::EventHandler(this, &Form1::button10_Click);
			// 
			// textBox1
			// 
			this->textBox1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->textBox1->Location = System::Drawing::Point(24, 29);
			this->textBox1->MaxLength = 20;
			this->textBox1->Multiline = true;
			this->textBox1->Name = L"textBox1";
			this->textBox1->Size = System::Drawing::Size(241, 31);
			this->textBox1->TabIndex = 0;
			this->textBox1->Text = L"0";
			this->textBox1->TextAlign = System::Windows::Forms::HorizontalAlignment::Right;
			this->textBox1->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &Form1::textBox1_KeyPress);
			// 
			// button15
			// 
			this->button15->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->button15->Location = System::Drawing::Point(24, 225);
			this->button15->Name = L"button15";
			this->button15->Size = System::Drawing::Size(40, 40);
			this->button15->TabIndex = 15;
			this->button15->Text = L"0";
			this->button15->UseVisualStyleBackColor = true;
			this->button15->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// button16
			// 
			this->button16->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->button16->Location = System::Drawing::Point(116, 226);
			this->button16->Name = L"button16";
			this->button16->Size = System::Drawing::Size(40, 40);
			this->button16->TabIndex = 16;
			this->button16->Text = L",";
			this->button16->UseVisualStyleBackColor = true;
			this->button16->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// button17
			// 
			this->button17->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->button17->Location = System::Drawing::Point(181, 226);
			this->button17->Name = L"button17";
			this->button17->Size = System::Drawing::Size(84, 39);
			this->button17->TabIndex = 17;
			this->button17->Text = L"C";
			this->button17->UseVisualStyleBackColor = true;
			this->button17->Click += gcnew System::EventHandler(this, &Form1::button17_Click);
			// 
			// button18
			// 
			this->button18->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 16, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->button18->Location = System::Drawing::Point(70, 225);
			this->button18->Name = L"button18";
			this->button18->Size = System::Drawing::Size(40, 40);
			this->button18->TabIndex = 18;
			this->button18->Text = L"+/-";
			this->button18->UseVisualStyleBackColor = true;
			this->button18->Click += gcnew System::EventHandler(this, &Form1::button18_Click);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(292, 278);
			this->Controls->Add(this->button18);
			this->Controls->Add(this->button17);
			this->Controls->Add(this->button16);
			this->Controls->Add(this->button15);
			this->Controls->Add(this->textBox1);
			this->Controls->Add(this->button14);
			this->Controls->Add(this->button13);
			this->Controls->Add(this->button12);
			this->Controls->Add(this->button11);
			this->Controls->Add(this->button10);
			this->Controls->Add(this->button9);
			this->Controls->Add(this->button8);
			this->Controls->Add(this->button7);
			this->Controls->Add(this->button6);
			this->Controls->Add(this->button5);
			this->Controls->Add(this->button4);
			this->Controls->Add(this->button3);
			this->Controls->Add(this->button2);
			this->Controls->Add(this->button1);
			this->MaximizeBox = false;
			this->Name = L"Form1";
			this->Text = L"Калькулятор";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
				 if (del== true) 
				return;
				 if(nn==1)textBox1->Clear();
				 Button^ a= dynamic_cast <Button^> (sender);
					if (a)
					{
						if ((a->Text==",")&&(fg==1))
							fg=1;		 
						else if ((a->Text==",")&&(fg==0))
							{textBox1->Text+=a->Text;
							fg=1;}
						else if(textBox1->Text=="0")textBox1->Text=a->Text;
						else
							textBox1->Text+=a->Text;
					}
						 
						// if((textBox1->Text=="0")&&(fg==1))textBox1->Text="0,";//?нигде не присваивается fg=1;
						 

}
private: System::Void button10_Click(System::Object^  sender, System::EventArgs^  e) {
			if (del== true) 
				return;
			 if (textBox1->Text=="") 
				b=0;
			else 
				b=Convert::ToDouble(textBox1->Text);//нет проверки значения текст
			textBox1->Text="";
			Button^ a= dynamic_cast <Button^> (sender);
			flag=Convert::ToInt32(a->Tag);
			fg=0;
			nn=0;
			//textBox1->TabIndex=0;
		 }
private: System::Void button17_Click(System::Object^  sender, System::EventArgs^  e) {
			 textBox1->Text="0";
			 fg=0; 
			 nn=0; 
			 b=0; 
			 c=0;
			 flag=-1;
			del= false;
			 //textBox1->TabIndex=0;
		 }
private: System::Void button12_Click(System::Object^  sender, System::EventArgs^  e) {
			 //
			if (del== true) 
				return;
			 double rez;
			if(nn==0) c=Convert::ToDouble(textBox1->Text);//Условие нужно для обработки многократного равенства
			if(flag==1)rez=b+c;
			 else if(flag==2)rez=b-c;
			 else if(flag==3)rez=b*c;
			 else if(flag==4) 
			 {
				 if (c!=0)
					rez=b/c;
				 else 
					del=true;
			 }
			 if (del)
			 textBox1->Text= "Деление на ноль невозможно";
			 else
			 {
		     textBox1->Text=Convert::ToString(rez);
			 b=rez;
			 nn=1;
			 fg=0;
			 }
			
		 }
private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) {
	
		 }

private: System::Void button13_Click(System::Object^  sender, System::EventArgs^  e) {
 }
private: System::Void button14_Click(System::Object^  sender, System::EventArgs^  e) {
 }
private: System::Void button18_Click(System::Object^  sender, System::EventArgs^  e) {
			 if (del== true) 
				return;
			 double per;
			 per=Convert::ToDouble(textBox1->Text);//!ошибка преобразования исправлена.
			 textBox1->Text=Convert::ToString(-per);
			 b=Convert::ToDouble(textBox1->Text);//?
		 }
private: System::Void textBox1_KeyPress(System::Object^  sender, System::Windows::Forms::KeyPressEventArgs^  e) {
			 if (del== true) 
				return;
			 switch(e->KeyChar){
			 case 13:button12_Click(sender,e);e->KeyChar=0;break;
			 case '=':button12_Click(sender,e);e->KeyChar=0;break;
			 case '+':button10_Click(button10,e);e->KeyChar=0;break;
			 case '-':button10_Click(button11,e);e->KeyChar=0;break;
			 case '*':button10_Click(button14,e);e->KeyChar=0;break;
			 case '/':button10_Click(button13,e);e->KeyChar=0;break;
			 }
			 if(((e->KeyChar==46)||(e->KeyChar==44))&&(fg==1))e->KeyChar=0;
			 if((e->KeyChar==46)||(e->KeyChar==44)){e->KeyChar=44;fg=1;}
			 if((e->KeyChar>=48)&&(e->KeyChar<=57))button1_Click(sender,e);//некорректно прописано нажатие цифр
			 if ((e->KeyChar>=65)&&(e->KeyChar<=127)) e->KeyChar=0;//отсекаются только английские буквы
		 }
private: System::Void button16_Click(System::Object^  sender, System::EventArgs^  e) {
			 //if(fg==0){textBox1->Text=textBox1->Text+',';fg=1;}
		 }
};
}
