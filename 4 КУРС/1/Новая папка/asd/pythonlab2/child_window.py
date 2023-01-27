<<<<<<< HEAD
from tkinter import *
from tkinter.scrolledtext import ScrolledText
from tkinter import filedialog
from tkinter import messagebox
import module
import os

class ChildWindow():
    def __init__(self, parent, width, height, title="Статистика файла", resizable=(False,False), icon=None):
        self.par = parent
        self.kek = "txt"
        self.par.withdraw()
        self.root = Toplevel(parent)
        self.root.title(title)
        self.root.geometry(f"{width}x{height}+500+300")
        self.root.resizable(resizable[0],resizable[1])

        self.label1 = Label(self.root, text="Введите подстроку:").pack(side=LEFT, padx=5, pady=0)

        self.message = StringVar()
        self.message_entry = Entry(self.root, textvariable=self.message).pack(side=LEFT, padx=5, pady=0)

        self.Button = Button(self.root, text="Применить", command=self.apply).pack(side=LEFT, pady=0, padx=5)

        self.message.trace_variable("w", self.entry_set_call)

        if icon:
            self.root.iconbitmap(icon)


    def entry_set_call(self, name, index, mode):
        text = self.message.get()
        if len(text) > 10:
            self.message.set(text[:-1])


    def apply(self):
        self.par.deiconify()
        s = module.CountOfCcurrences('TimeFile.txt', self.message.get())
        messagebox.showinfo('Статистика файла', 'Количество подстрок: '+ str(s))
        os.remove('TimeFile.txt')
        self.root.destroy()


    def on_closing(self):
        self.par.deiconify()
        self.root.destroy()


    def run(self):
        self.root.protocol("WM_DELETE_WINDOW", self.on_closing)


        


=======
from tkinter import *
from tkinter.scrolledtext import ScrolledText
from tkinter import filedialog
from tkinter import messagebox
import module
import os

class ChildWindow():
    def __init__(self, parent, width, height, title="Статистика файла", resizable=(False,False), icon=None):
        self.par = parent
        self.kek = "txt"
        self.par.withdraw()
        self.root = Toplevel(parent)
        self.root.title(title)
        self.root.geometry(f"{width}x{height}+500+300")
        self.root.resizable(resizable[0],resizable[1])

        self.label1 = Label(self.root, text="Введите подстроку:").pack(side=LEFT, padx=5, pady=0)

        self.message = StringVar()
        self.message_entry = Entry(self.root, textvariable=self.message).pack(side=LEFT, padx=5, pady=0)

        self.Button = Button(self.root, text="Применить", command=self.apply).pack(side=LEFT, pady=0, padx=5)

        self.message.trace_variable("w", self.entry_set_call)

        if icon:
            self.root.iconbitmap(icon)


    def entry_set_call(self, name, index, mode):
        text = self.message.get()
        if len(text) > 10:
            self.message.set(text[:-1])


    def apply(self):
        self.par.deiconify()
        s = module.CountOfCcurrences('TimeFile.txt', self.message.get())
        messagebox.showinfo('Статистика файла', 'Количество подстрок: '+ str(s))
        os.remove('TimeFile.txt')
        self.root.destroy()


    def on_closing(self):
        self.par.deiconify()
        self.root.destroy()


    def run(self):
        self.root.protocol("WM_DELETE_WINDOW", self.on_closing)


        


>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
