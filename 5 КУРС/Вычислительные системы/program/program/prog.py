from PyQt5.QtWidgets import QApplication, QMainWindow, QLabel, QTextEdit, QPushButton, QLineEdit, QSpinBox, QDoubleSpinBox
from PyQt5 import uic, QtGui
from math import comb
import sys


class Window(QMainWindow):
    def __init__(self):
       super(Window, self).__init__()
       uic.loadUi("untitled.ui", self)

       self.setWindowTitle("Ленивый вычислитель")
       self.memoryCount = self.findChild(QSpinBox, "memoryCount")
       self.inoutCount = self.findChild(QSpinBox, "inoutCount")

       self.procP = self.findChild(QDoubleSpinBox, "procP")
       self.memoryP = self.findChild(QDoubleSpinBox, "memoryP")
       self.inoutP = self.findChild(QDoubleSpinBox, "inoutP")

       self.g_1 = self.findChild(QDoubleSpinBox, "g_1")
       self.k_pr_1 = self.findChild(QDoubleSpinBox, "k_pr_1")
       self.k_mem_1 = self.findChild(QDoubleSpinBox, "k_mem_1")
       self.k_inout_1 = self.findChild(QDoubleSpinBox, "k_inout_1")
       self.k_vc_1 = self.findChild(QDoubleSpinBox, "k_vc_1")       

       self.g_2 = self.findChild(QDoubleSpinBox, "g_2")
       self.k_pr_2 = self.findChild(QDoubleSpinBox, "k_pr_2")
       self.k_mem_2 = self.findChild(QDoubleSpinBox, "k_mem_2")
       self.k_inout_2 = self.findChild(QDoubleSpinBox, "k_inout_2")
       self.k_vc_2 = self.findChild(QDoubleSpinBox, "k_vc_2")  

       self.g_3 = self.findChild(QDoubleSpinBox, "g_3")
       self.k_pr_3 = self.findChild(QDoubleSpinBox, "k_pr_3")
       self.k_mem_3 = self.findChild(QDoubleSpinBox, "k_mem_3")
       self.k_inout_3 = self.findChild(QDoubleSpinBox, "k_inout_3")
       self.k_vc_3 = self.findChild(QDoubleSpinBox, "k_vc_3")  

       self.g_4 = self.findChild(QDoubleSpinBox, "g_4")
       self.k_pr_4 = self.findChild(QDoubleSpinBox, "k_pr_4")
       self.k_mem_4 = self.findChild(QDoubleSpinBox, "k_mem_4")
       self.k_inout_4 = self.findChild(QDoubleSpinBox, "k_inout_4")
       self.k_vc_4 = self.findChild(QDoubleSpinBox, "k_vc_4")  

       self.plusP = self.findChild(QSpinBox, "plusP")
       self.plusMemory = self.findChild(QSpinBox, "plusMemory")
       self.plusInout = self.findChild(QSpinBox, "plusInout")

       self.firstButton = self.findChild(QPushButton, "firstButton")
       self.secondButton = self.findChild(QPushButton, "secondButton")
       self.thirdButton = self.findChild(QPushButton, "thirdButton")
       self.plusButton = self.findChild(QPushButton, "plusButton")

       self.firstButton.clicked.connect(self.firstClicker)
       self.secondButton.clicked.connect(self.secondClicker)
       self.thirdButton.clicked.connect(self.thirdClicker)
       self.plusButton.clicked.connect(self.plusClicker)
       
       self.show()

    def firstClicker(self):
       self.g_1.setValue(self.procP.value()**1*self.memoryP.value()**self.memoryCount.value()*self.inoutP.value()**self.inoutCount.value())
       self.k_pr_1.setValue(self.procP.value()/1)
       self.k_mem_1.setValue(self.memoryP.value()**self.memoryCount.value()/self.memoryCount.value())
       self.k_inout_1.setValue(self.inoutP.value()**self.inoutCount.value()/self.inoutCount.value())
       self.k_vc_1.setValue(self.k_pr_1.value()*self.k_mem_1.value()*self.k_inout_1.value())

    def secondClicker(self):
       pr = (1-(1-self.procP.value())**2)
       mem = (1-(1-self.memoryP.value()**self.memoryCount.value())**2)
       iu = (1-(1-self.inoutP.value()**self.inoutCount.value())**2)
       self.g_2.setValue(pr * mem * iu)
       
       self.k_pr_2.setValue(pr/2)
       self.k_mem_2.setValue(mem/(2*self.memoryCount.value()))
       self.k_inout_2.setValue(iu/(2*self.inoutCount.value()))
       self.k_vc_2.setValue(self.k_pr_2.value()*self.k_mem_2.value()*self.k_inout_2.value())

    def thirdClicker(self):
       pr = (1-(1-self.procP.value())**3)
       mem = (1-(1-self.memoryP.value()**self.memoryCount.value())**3)
       iu = (1-(1-self.inoutP.value()**self.inoutCount.value())**3)
       self.g_3.setValue(pr * mem * iu)

       self.k_pr_3.setValue(pr/3)
       self.k_mem_3.setValue(mem/(3*self.memoryCount.value()))
       self.k_inout_3.setValue(iu/(3*self.inoutCount.value()))
       self.k_vc_3.setValue(self.k_pr_3.value()*self.k_mem_3.value()*self.k_inout_3.value())

    def plusClicker(self):
       pr = self.procP.value()**(self.plusP.value()+1)
       mem = 0
       iu = 0
       sizeMem = self.plusMemory.value() + self.memoryCount.value()
       iter = self.plusMemory.value() + 1
       for i in range(iter):
          mem = mem + comb(sizeMem,sizeMem-i) * self.memoryP.value()**(sizeMem-i) * (1-self.memoryP.value())**(sizeMem-(sizeMem-i))

       sizeInout = self.plusInout.value() + self.inoutCount.value()
       iter = self.plusInout.value() + 1
       for i in range(iter):
          iu = iu + comb(sizeInout,sizeInout-i) * self.inoutP.value()**(sizeInout-i) * (1-self.inoutP.value())**(sizeInout-(sizeInout-i))

       self.g_4.setValue(pr * mem * iu)
       print(pr, mem, iu)
       self.k_pr_4.setValue(pr/(1+self.plusP.value()))
       self.k_mem_4.setValue(mem/sizeMem)
       self.k_inout_4.setValue(iu/sizeInout)
       self.k_vc_4.setValue(self.k_pr_4.value()*self.k_mem_4.value()*self.k_inout_4.value())



    
app = QApplication(sys.argv)
UIWindow = Window()
app.exec_()

