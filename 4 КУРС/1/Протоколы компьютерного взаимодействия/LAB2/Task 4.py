<<<<<<< HEAD
import ftplib

if __name__ == "__main__": #windows 7
    ftp = ftplib.FTP()
    HOST = '192.168.0.166'
    PORT = 21
    ftp.connect(HOST, PORT)
    print(ftp.getwelcome()) 
    filename = input("Введите название отправляемого файла: ")
    ftp.login("user3", "12345")
    with open(filename, "rb") as file:
        ftp.storbinary(f"STOR {filename}", file) 

    print("Файлы в корнейвой папке:\n")
    directory = ftp.nlst()
    for i in directory:
        print(i)  
    print("\n") 

    filename = input("Введите название считываемого файла: ")

    with open(filename, "wb") as file:
        ftp.retrbinary(f"RETR {filename}", file.write) 

    file = open(filename, "r")
    print("Данные из файла:\n", file.read())

    file.close()
    ftp.quit()
=======
import ftplib

if __name__ == "__main__": #windows 7
    ftp = ftplib.FTP()
    HOST = '192.168.0.166'
    PORT = 21
    ftp.connect(HOST, PORT)
    print(ftp.getwelcome()) 
    filename = input("Введите название отправляемого файла: ")
    ftp.login("user3", "12345")
    with open(filename, "rb") as file:
        ftp.storbinary(f"STOR {filename}", file) 

    print("Файлы в корнейвой папке:\n")
    directory = ftp.nlst()
    for i in directory:
        print(i)  
    print("\n") 

    filename = input("Введите название считываемого файла: ")

    with open(filename, "wb") as file:
        ftp.retrbinary(f"RETR {filename}", file.write) 

    file = open(filename, "r")
    print("Данные из файла:\n", file.read())

    file.close()
    ftp.quit()
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
