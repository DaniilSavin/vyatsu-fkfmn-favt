<<<<<<< HEAD
import smtplib
from email.mime.text import MIMEText
from email.mime.multipart import MIMEMultipart

line = [] #считывание логинов и паролей пользователей на сервере
with open("date.txt", "r") as file:
    for i in file:
        line.append(i.replace("\n",""))
    
email1 = line[0]
email2 = line[2]
password1 = line[1]
password2 = line[3]

if __name__ == "__main__":
    msg = MIMEMultipart()
    
    ip = input('Введите ip-адрес сервера: ') #192.168.0.166
    message = input("Введите сообщение: ")
    
    msg.attach(MIMEText(message, 'plain'))
    server = smtplib.SMTP(ip, port = 25)
    print("Подключение установлено")
    server.login(email1, password1)
    server.sendmail(email1,email2, msg.as_string())
    print("Сообщение отправлено!")
    server.quit()
    server.close()
=======
import smtplib
from email.mime.text import MIMEText
from email.mime.multipart import MIMEMultipart

line = [] #считывание логинов и паролей пользователей на сервере
with open("date.txt", "r") as file:
    for i in file:
        line.append(i.replace("\n",""))
    
email1 = line[0]
email2 = line[2]
password1 = line[1]
password2 = line[3]

if __name__ == "__main__":
    msg = MIMEMultipart()
    
    ip = input('Введите ip-адрес сервера: ') #192.168.0.166
    message = input("Введите сообщение: ")
    
    msg.attach(MIMEText(message, 'plain'))
    server = smtplib.SMTP(ip, port = 25)
    print("Подключение установлено")
    server.login(email1, password1)
    server.sendmail(email1,email2, msg.as_string())
    print("Сообщение отправлено!")
    server.quit()
    server.close()
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
