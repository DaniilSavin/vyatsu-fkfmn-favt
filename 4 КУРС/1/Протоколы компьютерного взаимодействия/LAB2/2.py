<<<<<<< HEAD
from tkinter import *
from tkinter.scrolledtext import ScrolledText
from icmplib import traceroute
import ctypes, sys
#adress = ping('google.com', count=10, interval=0.2)

def is_admin():
    try:
        return ctypes.windll.shell32.IsUserAnAdmin()
    except:
        return False
def Testproc():
    #txt.insert(INSERT, 'WAIT..')
    if is_admin():
        tmpStr = message.get()
        
        if (tmpStr != " " and tmpStr != ""):
            txt.insert(INSERT, 'WAIT..')
            #target = ["172.217.17.46"]
            #result, unans = traceroute(target, l4=UDP(sport=RandShort())/DNS(qd=DNSQR(qname="www.google.com")))
            #hops = traceroute(tmpStr,2, 0.05, 2, 1, 30, False, None, '178.141.174.175')
            hops = traceroute(tmpStr)
            txt.delete(1.0, END)
            txt.insert(INSERT, 'Distance/TTL    Address    Average round-trip time')
            #webb.traceroute(tmpStr, 'file-name.txt')
            
            #for snd, rcv in result:
                #print(snd.ttl, rcv.src, snd.sent_time, rcv.time)
                #txt.insert(INSERT, f'{snd.ttl} {rcv.src} {snd.sent_time} {rcv.time}')
            last_distance = 0
            for hop in hops:
                if last_distance + 1 != hop.distance:
                    txt.insert(INSERT,'\nSome gateways are not responding')
                txt.insert(INSERT, "\n")
                txt.insert(INSERT, f'{hop.distance}    {hop.address}    {hop.avg_rtt} ms')
                last_distance = hop.distance
    else:
        ctypes.windll.shell32.ShellExecuteW(None, "runas", sys.executable, __file__, None, 1)



if is_admin():
    window = Tk()  
    window.title("")  
    lbl = Label(window, text="Введите IP-адрес:") 
    lbl.place(relx=.15, rely=.15, anchor="c")

    message = StringVar()
    message_entry = Entry(textvariable=message)
    message_entry.place(relx=.5, rely=.15, anchor="c")

    Button_1 = Button(window, text="Ввести", command=Testproc)
    Button_1.place(relx=.85, rely=.15, anchor="c")

    txt = ScrolledText(window, width=60, height=10)
    txt.place(relx=.5, rely=.6, anchor="c")

    window.geometry(f"{500}x{250}+500+300")
    window.mainloop()
else:
=======
from tkinter import *
from tkinter.scrolledtext import ScrolledText
from icmplib import traceroute
import ctypes, sys
#adress = ping('google.com', count=10, interval=0.2)

def is_admin():
    try:
        return ctypes.windll.shell32.IsUserAnAdmin()
    except:
        return False
def Testproc():
    #txt.insert(INSERT, 'WAIT..')
    if is_admin():
        tmpStr = message.get()
        
        if (tmpStr != " " and tmpStr != ""):
            txt.insert(INSERT, 'WAIT..')
            #target = ["172.217.17.46"]
            #result, unans = traceroute(target, l4=UDP(sport=RandShort())/DNS(qd=DNSQR(qname="www.google.com")))
            #hops = traceroute(tmpStr,2, 0.05, 2, 1, 30, False, None, '178.141.174.175')
            hops = traceroute(tmpStr)
            txt.delete(1.0, END)
            txt.insert(INSERT, 'Distance/TTL    Address    Average round-trip time')
            #webb.traceroute(tmpStr, 'file-name.txt')
            
            #for snd, rcv in result:
                #print(snd.ttl, rcv.src, snd.sent_time, rcv.time)
                #txt.insert(INSERT, f'{snd.ttl} {rcv.src} {snd.sent_time} {rcv.time}')
            last_distance = 0
            for hop in hops:
                if last_distance + 1 != hop.distance:
                    txt.insert(INSERT,'\nSome gateways are not responding')
                txt.insert(INSERT, "\n")
                txt.insert(INSERT, f'{hop.distance}    {hop.address}    {hop.avg_rtt} ms')
                last_distance = hop.distance
    else:
        ctypes.windll.shell32.ShellExecuteW(None, "runas", sys.executable, __file__, None, 1)



if is_admin():
    window = Tk()  
    window.title("")  
    lbl = Label(window, text="Введите IP-адрес:") 
    lbl.place(relx=.15, rely=.15, anchor="c")

    message = StringVar()
    message_entry = Entry(textvariable=message)
    message_entry.place(relx=.5, rely=.15, anchor="c")

    Button_1 = Button(window, text="Ввести", command=Testproc)
    Button_1.place(relx=.85, rely=.15, anchor="c")

    txt = ScrolledText(window, width=60, height=10)
    txt.place(relx=.5, rely=.6, anchor="c")

    window.geometry(f"{500}x{250}+500+300")
    window.mainloop()
else:
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
    ctypes.windll.shell32.ShellExecuteW(None, "runas", sys.executable, __file__, None, 1)