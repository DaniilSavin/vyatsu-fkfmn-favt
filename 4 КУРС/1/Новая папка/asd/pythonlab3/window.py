from tkinter import *
from tkinter.scrolledtext import ScrolledText
from tkinter import filedialog
from tkinter import messagebox
import module
from child_window import ChildWindow
import os
from xmlrpc.client import ServerProxy

proxy = ServerProxy("http://localhost:8000/")



class Window:

    def __init__(self, width, height, title, resizable=(False, False), icon=None):
        self.root = Tk()
        self.root.title(title)
        self.root.geometry(f"{width}x{height}+500+300")
        self.root.resizable(resizable[0],resizable[1])
        if icon:
            self.root.iconbitmap(icon)

        self.file_name = ""

        self.frame_1 = Frame(self.root, relief=RAISED, borderwidth=0)
        self.frame_1.pack(fill=X, expand=False)
        self.frame_2 = Frame(self.root, relief=RAISED, borderwidth=0)
        self.frame_2.pack(fill=X, expand=False)

        self.label1 = Label(self.frame_1, text="Содержимое файла:").pack(side=LEFT, padx=5, pady=2)

        self.txt = ScrolledText(self.frame_2, width=150, height=15)
        self.txt.pack(side=LEFT, padx=5)
        self.bol = False

        self.txt.bind('<Key>', self.Boolean())

        self.Button_1 = Button(self.root, text="Количество слов", command=self.CountWords).pack(side=LEFT, pady=0, padx=5)
        self.Button_2 = Button(self.root, text="Количество символов", command=self.CountCharacters).pack(side=LEFT, pady=0, padx=15)
        self.Button_3 = Button(self.root, text="Количество вхождений подстроки", command=self.CreateChild).pack(side=LEFT, pady=0, padx=5)
        self.Button_4 = Button(self.root, text="Количество строк", command=self.CountLines).pack(side=LEFT, pady=0, padx=15)
        self.Button_5 = Button(self.root, text="Количество цифр", command=self.CountNumbers).pack(side=LEFT, pady=0, padx=5)

        self.menu = Menu(self.root)
        self.new_item = Menu(self.menu, tearoff=0)
        self.new_item.add_command(label='Новый', command=self.New_File)  
        self.new_item.add_command(label="Открыть", command=self.Open_File)
        self.new_item.add_command(label="Сохранить", command=self.Save_File)
        self.new_item.add_command(label="Сохранить как", command=self.Save_AsFile)
        self.menu.add_cascade(label='Файл', menu=self.new_item)
        self.root.config(menu=self.menu)

    def Seek(self):
        self.root.withdraw()

    def Boolean(self):
        self.bol = False

    def run(self):
        self.root.protocol("WM_DELETE_WINDOW", self.on_closing)
        self.root.mainloop()


    def on_closing(self):
        if (self.bol == False):
            if messagebox.askokcancel("Выход", "Вы точно хотите выйти без сохранения?"):
                self.root.destroy()
        else:
            self.root.destroy()



    def TimeFileUse(self):
        TimeFile = open("TimeFile.txt", "w+", encoding='UTF-8')
        TimeFile.write(self.txt.get('1.0', END))
        TimeFile.close()


    def New_File(self):
        if (self.bol == True):
            self.file_name = ""
            self.txt.delete("1.0", END)
            self.bol = False
        else:
            if messagebox.askokcancel("Оповещение", "Вы точно не хотите сохранить предыдущий файл?"):
                self.file_name = ""
                self.txt.delete("1.0", END)

    def Open_File(self):

        wanted_files = (
            ("TEXT files", "*.txt;*.log"),
            ("PY files", "*.py")
        )
        if (self.bol == True):
            self.file_name = filedialog.askopenfilename(filetypes=wanted_files)
            if self.file_name:
                with open(self.file_name, encoding='UTF-8') as f:
                    self.txt.delete("1.0", END)
                    self.txt.insert("1.0", f.read())
        else:
            if messagebox.askokcancel("Оповещение", "Вы точно не хотите сохранить предыдущий файл?"):
                self.file_name = filedialog.askopenfilename(filetypes=wanted_files)
                if self.file_name:
                    with open(self.file_name, encoding='UTF-8') as f:
                        self.txt.delete("1.0", END)
                        self.txt.insert("1.0", f.read())


    def Save_File(self):
        if self.file_name:
            with open(self.file_name, "w+", encoding='UTF-8') as f:
                f.write(self.txt.get('1.0', END))
                f.close()
                self.bol = True
        else:
            self.Save_AsFile()


    def Save_AsFile(self):
        self.file_name = filedialog.asksaveasfilename(filetypes=(("TEXT files", "*.txt"), ("PY files","*.py")))
        if self.file_name:
            with open(self.file_name, "w+", encoding='UTF-8') as f:
                f.write(self.txt.get('1.0', END))
                f.close()
                self.bol = True


    def CountWords(self):
        self.TimeFileUse()
        s = proxy.CountWords('TimeFile.txt')
        messagebox.showinfo('Статистика файла', 'Количество слов: ' + str(s))
        os.remove('TimeFile.txt')


    def CountCharacters(self):
        self.TimeFileUse()
        s = proxy.CountCharacters('TimeFile.txt')
        messagebox.showinfo('Статистика файла', 'Количество символов: ' + str(s))
        os.remove('TimeFile.txt')


    def CountLines(self):
        self.TimeFileUse()
        s = proxy.CountLines('TimeFile.txt')
        messagebox.showinfo('Статистика файла', 'Количество строк: ' + str(s))



    def CountNumbers(self):
        self.TimeFileUse()
        s = proxy.CountNumbers('TimeFile.txt')
        messagebox.showinfo('Статистика файла', 'Количество чисел: ' + str(s))
        os.remove('TimeFile.txt')


    def CreateChild(self):
        self.TimeFileUse()
        self.rt = ChildWindow(self.root, 350, 100)
        self.rt.run()





if __name__ == "__main__":
    MainWindow = Window(750, 330, "Статистика файла")
    MainWindow.run()