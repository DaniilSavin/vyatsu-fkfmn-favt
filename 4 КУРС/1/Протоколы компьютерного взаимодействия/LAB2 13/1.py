<<<<<<< HEAD
from icmplib import ping

print("Input address:")
address = input()
print("\n___________________\n")
if (address != " "):
    print (ping(address, count=10, interval=0.2))
else:
=======
from icmplib import ping

print("Input address:")
address = input()
print("\n___________________\n")
if (address != " "):
    print (ping(address, count=10, interval=0.2))
else:
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
    print ("Вы ничего не ввели.")