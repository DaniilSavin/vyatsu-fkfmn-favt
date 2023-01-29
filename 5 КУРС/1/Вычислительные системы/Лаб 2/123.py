from math import factorial as fact
from functools import reduce


def p_0(R, N):
    num = R ** N
    den = fact(N - 1) * (N - R)
    s = sum((R ** n) / fact(n) for n in range(N))
    return 1 / (num / den + s)


def p_n(R, n, N):
    if n <= N:
        return p_0(R, N) * (R ** n) / fact(n)
    else:
        return p_0(R, N) * (R ** n) / (fact(N) * N ** (n - N))


def p_0_1(N, p):
    num = N ** (N - 1) * p ** N
    den = fact(N - 1) * (1 - p)
    s = sum((N ** i) * (p ** i) / fact(i) for i in range(N))
    return 1 / (num / den + s)


def l(N, p):
    num = N ** (N - 1) * p ** (N + 1) * p_0_1(N, p)
    den = fact(N - 1) * (1 - p) ** 2
    return num / den


#t1 = p_n(0.7, 12, 2)
#print(round(t1, 20))

#t2 = p_n(1.1, 12, 2)
#print(round(t2, 6))

#t3 = p_n(1.5, 12, 2)
#print(round(t3, 6))

#t4 = p_n(1.9, 12, 2)
#print(round(t4, 6))

t3 = l(1, 0.20833)
print('l=', round(t3, 5))

t3 = l(3, 0.20833)
print('l=', round(t3, 5))

input()