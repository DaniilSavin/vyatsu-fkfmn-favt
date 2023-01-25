from ctypes import *
from ctypes import wintypes as w
import struct
import sys
from PyQt5 import QtCore
from PyQt5.QtWidgets import (QPlainTextEdit, QWidget, QToolTip, QLineEdit, QPushButton, QApplication)
from PyQt5.QtGui import QFont
from PyQt5 import QtWidgets

MAXLEN_PHYSADDR = 8
TYPE = {1:'other',2:'invalid',3:'dynamic',4:'static'}

class MIB_IPNETROW(Structure):
    _fields_ = (('dwIndex',w.DWORD),
                ('dwPhysAddrLen',w.DWORD),
                ('bPhysAddr',w.BYTE * MAXLEN_PHYSADDR),
                ('dwAddr',w.DWORD),
                ('dwType',w.DWORD))
    def __repr__(self):
        ip = struct.pack('<L',self.dwAddr)
        ip = f'{ip[0]}.{ip[1]}.{ip[2]}.{ip[3]}'
        mac = bytes(self.bPhysAddr)[:self.dwPhysAddrLen]
        mac = '-'.join(f'{b:02x}' for b in mac)
        return f"#| {mac}\t|  {ip}\t|\t{TYPE[self.dwType]}"

def TABLE(n):
    class _MIB_IPNETTABLE(Structure):
        _fields_ = (('dwNumEntries',w.DWORD),
                    ('table',MIB_IPNETROW * n))
    return _MIB_IPNETTABLE

def Testproc():
    MIB_IPNETTABLE = TABLE(0)

    dll = WinDLL('iphlpapi')
    dll.GetIpNetTable.argtypes = POINTER(MIB_IPNETTABLE),w.PULONG,w.BOOL
    dll.GetIpNetTable.restype = w.ULONG


    size = w.DWORD(0)
    dll.GetIpNetTable(None,byref(size),True)


    buf = cast(create_string_buffer(b'',size=size.value),POINTER(MIB_IPNETTABLE))


    dll.GetIpNetTable(buf,byref(size),True)
    buf = cast(buf,POINTER(TABLE(buf.contents.dwNumEntries)))

    tmpStr =result
    for t in buf.contents.table:
        if t.dwType != 2 and t.dwPhysAddrLen:
            tmpStr+=str(t)
            tmpStr+='\n'
            
    return tmpStr
            

result = "#|\tMAC\t|\tIP\t|\tType\n"



class Example(QWidget):


    def __init__(self):
        super().__init__()
        self.initUI()


    def initUI(self):
        self.setWindowTitle("ARP -a")
        desktop = QtWidgets.QApplication.desktop()

        QToolTip.setFont(QFont('SansSerif', 10))
        self.textbox = QPlainTextEdit(self)
        self.textbox.move(10, 50)
        self.textbox.resize(450,200)
        
        self.textbox.setReadOnly(True)
        
      

        self.btn = QPushButton('Поиск', self)
        self.btn.resize(self.btn.sizeHint())
        self.btn.move(10, 10)
        self.btn.clicked.connect(self.click)


        self.setGeometry((int)(desktop.width()/2) - (int)(self.width()/2), (int)(desktop.height()/2) - (int)(self.height()/2), 470, 260)
        self.show()

    def click(self):
        result = Testproc()
        self.textbox.clear()
        self.textbox.insertPlainText(result)


if __name__ == '__main__':
    input()
    app = QApplication(sys.argv)
    ex = Example()
    sys.exit(app.exec_())
