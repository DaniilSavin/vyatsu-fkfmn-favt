from tkinter import *
from tkinter.scrolledtext import ScrolledText
from icmplib import traceroute

#adress = ping('google.com', count=10, interval=0.2)


def Testproc():
    #txt.insert(INSERT, 'WAIT..')
    tmpStr = message.get()
    
    if (tmpStr != " " or tmpStr != ""):
        txt.insert(INSERT, 'WAIT..')
        hops = traceroute(tmpStr)
        txt.delete(1.0, END)
        txt.insert(INSERT, 'Distance/TTL    Address    Average round-trip time')
        last_distance = 0
        for hop in hops:
            if last_distance + 1 != hop.distance:
                txt.insert(INSERT,'\nSome gateways are not responding')
            txt.insert(INSERT, "\n")
            txt.insert(INSERT, f'{hop.distance}    {hop.address}    {hop.avg_rtt} ms')
            last_distance = hop.distance



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