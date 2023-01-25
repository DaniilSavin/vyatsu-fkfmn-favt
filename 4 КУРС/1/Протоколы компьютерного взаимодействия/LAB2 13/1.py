from icmplib import ping

print("Input address:")
address = input()
print("\n___________________\n")
if (address != " "):
    print (ping(address, count=10, interval=0.2))
else:
    print ("Вы ничего не ввели.")