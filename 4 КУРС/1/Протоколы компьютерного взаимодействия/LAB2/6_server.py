<<<<<<< HEAD
import socket
import platform
import subprocess
import requests

HOST = "127.0.0.1" 
PORT = 65432  
resp = ""

def myping(host):
    parameter = '-n' if platform.system().lower() == 'windows' else '-c'
 
    command = ['ping', parameter, '1', host]
    response = subprocess.call(command)
 
    if response == 0:
        return True
    else:
        return False



with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.bind((HOST, PORT))
    s.listen()
    conn, addr = s.accept()
    with conn:
        print(f"Connected by {addr}")
        while True:
            data = conn.recv(1024).decode("utf-8")
            if not data:
                break
            #resp = socket.gethostbyaddr(data)
            #print (resp)
            r = requests.get("https://" + data)
            if r.status_code == requests.codes.ok:
                conn.sendall(bytes("The server responds.", encoding='utf8'))
            else:
                 conn.sendall(bytes("The server not responds", encoding='utf8'))

=======
import socket
import platform
import subprocess
import requests

HOST = "127.0.0.1" 
PORT = 65432  
resp = ""

def myping(host):
    parameter = '-n' if platform.system().lower() == 'windows' else '-c'
 
    command = ['ping', parameter, '1', host]
    response = subprocess.call(command)
 
    if response == 0:
        return True
    else:
        return False



with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.bind((HOST, PORT))
    s.listen()
    conn, addr = s.accept()
    with conn:
        print(f"Connected by {addr}")
        while True:
            data = conn.recv(1024).decode("utf-8")
            if not data:
                break
            #resp = socket.gethostbyaddr(data)
            #print (resp)
            r = requests.get("https://" + data)
            if r.status_code == requests.codes.ok:
                conn.sendall(bytes("The server responds.", encoding='utf8'))
            else:
                 conn.sendall(bytes("The server not responds", encoding='utf8'))

>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
input("Press Enter to continue...")