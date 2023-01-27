from math import factorial as fact
from functools import reduce


tt = [6e-9, 5e-9, 6e-9, 7e-9, 7e-9, 5e-9, 8e-9]
L = 64 # 32
ti = 14e-9
ts = 47e-9
tc = 8e-9 #max(tt)
n = 15


def P(L, n, tc, ti):
	return L / (tc * (L + n - 1) + ti)

def d(f, r):
	return f * r + (1 - r)

def tstart(ti, tc, n):
	return ti + n * tc

def E(L, tscalar, tstart, tc):
	return L * tscalar / (tstart + (L - 1) * tc)

# print(f'P = {P(L, n, tc, ti)}')

# print(f'd = 1')

# print(f'tstart = {tstart(ti, tc, n)}')

# print(f'E = {E(L, ts, tstart(ti, tc, n), tc)}')

# p = P(64, 5, 9e-9, 16e-9) + P(32, 5, 9e-9, 11e-9) + P(32, 5, 9e-9, 16e-9)
# print(f'P = {p / 3}')

# e = E(64, 49e-9, tstart(16e-9, 9e-9, 5), 9e-9) +\
#     E(32, 43e-9, tstart(11e-9, 9e-9, 5), 9e-9) +\
#     E(32, 49e-9, tstart(16e-9, 9e-9, 5), 9e-9)
# print(f'E = {e / 3}')

print(P(128, 7, 8e-9, ti))
print(P(128, 8, 7e-9, ti))
print(P(128, 9, 6e-9, ti))
print(P(128, 10, 5e-9, ti))
print(P(128, 12, 5e-9, ti))
print(P(128, 15, 5e-9, ti))
print("------------------------------------")
print(E(128, 47e-9, tstart(16e-9, 8e-9, 7), 8e-9))
print(E(128, 47e-9, tstart(16e-9, 7e-9, 8), 7e-9))
print(E(128, 47e-9, tstart(16e-9, 6e-9, 9), 6e-9))
print(E(128, 47e-9, tstart(16e-9, 5e-9, 10), 5e-9))
print(E(128, 47e-9, tstart(16e-9, 5e-9, 12), 5e-9))
print(E(128, 47e-9, tstart(16e-9, 5e-9, 15), 5e-9))
input()