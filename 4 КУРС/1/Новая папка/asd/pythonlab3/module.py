<<<<<<< HEAD
from functools import reduce

def CountWords(name):
    with open(name, encoding='UTF-8') as f:
        return len(f.read().split())

def CountCharacters(name):
    with open(name, encoding='UTF-8') as f:
        return len(f.read())

def CountOfCcurrences(name, Cur):
    with open(name, encoding='UTF-8') as f:
        return f.read().count(Cur)

def CountLines(name):
    with open(name, encoding='UTF-8') as f:
        return sum(1 for line in f)

def CountNumbers(name):
    with open(name, encoding='UTF-8') as f:
=======
from functools import reduce

def CountWords(name):
    with open(name, encoding='UTF-8') as f:
        return len(f.read().split())

def CountCharacters(name):
    with open(name, encoding='UTF-8') as f:
        return len(f.read())

def CountOfCcurrences(name, Cur):
    with open(name, encoding='UTF-8') as f:
        return f.read().count(Cur)

def CountLines(name):
    with open(name, encoding='UTF-8') as f:
        return sum(1 for line in f)

def CountNumbers(name):
    with open(name, encoding='UTF-8') as f:
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
        return reduce(lambda x, counter: x + counter, map(f.read().count,list("1234567890")))