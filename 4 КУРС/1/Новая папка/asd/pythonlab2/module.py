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
        return reduce(lambda x, counter: x + counter, map(f.read().count,list("1234567890")))