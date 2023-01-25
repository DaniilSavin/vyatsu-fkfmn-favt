import socket
from telnetlib import IP

HOST = "127.0.0.1" 
PORT = 65432  

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.connect((HOST, PORT))
    print("Input adress: ")
    ip=input()
    s.sendall(bytes(ip, encoding='utf8'))
    data = s.recv(1024)
    data = data.decode("utf-8")
    print("response: ", data) 

input("Press Enter to continue...")