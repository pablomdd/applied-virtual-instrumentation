from math import sin, pi


def S(t, n, T):
    sum = 0
    for i in range(1, n + 1):
        sum += 1 / (2 * i - 1) * sin(2 * (2 * i - 1) * pi * t / T)
    sum *= 4 / pi
    return sum


def f(t, T):
    if 0 < t < T / 2:
        return 1
    # when t == T /2 or pi / 2
    elif abs(t - T / 2) < 1E-14:
        return 0
    elif T / 2 < t < T:
        return -1


def printErrorTable():
    n_list = [1, 3, 5, 10, 30, 100]
    alpha_list = [0.01, 0.25, 0.49]
    T = 2 * pi
    t_list = [2 * alpha * T for alpha in alpha_list]
    for n in n_list:
        print("n=" + str(n) + "\t\tS(t, n, T)\t\tf(t, T)\t\t\tError")
        for t in t_list:
            fourier = S(t, n, T)
            sin_approx = f(t, T)
            error = sin_approx - fourier
            print("\t\t" + "{:.8f}".format(fourier) +
                  "\t\t" + "{:.8f}".format(sin_approx) +
                  "\t\t" + "{:.8f}".format(error))
        print("\n")


printErrorTable()
