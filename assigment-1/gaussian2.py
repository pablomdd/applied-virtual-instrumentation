from math import exp, pi, sqrt


def gauss(x, m=0, s=1):
    return 1 / sqrt(2*pi) * exp(-1/2*((x-m)/s)**2)


def printTable(m=-2, s=2):
    print("x \t f(x)")
    for x in range(m - 5*s, m + 5*s + 1):
        print(str(x) + " \t " + str(gauss(x, m, s)))


printTable(0, 1)
