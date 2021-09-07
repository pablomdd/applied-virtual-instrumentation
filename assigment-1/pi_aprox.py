from math import sin, cos, pi, sqrt
from path_length import pathlength


def piaprox(n):
    x = [1 / 2 * cos(2 * pi * i / n) for i in range(n + 1)]
    y = [1 / 2 * sin(2 * pi * i / n) for i in range(n + 1)]
    return x, y


def test_piaprox():
    for k in range(2, 11):
        n = 2**k
        x, y = piaprox(n)
        dim = pathlength(x, y)
        error = pi - dim
        print("With " + str(n) + " points the error is " + str(error))


test_piaprox()
