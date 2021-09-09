from math import exp, cos, log, pi, sin


def diff(f, x, h=1E-5):
    return (f(x + h) - f(x - h)) / (2*h)


def test_diff():
    def test_f(x): return x**2
    print("======Test======")
    print("Expect that function comparison is True. \nTest result is: ")
    # d/dt x**2 = 2x
    expected_res = 2
    print(diff(test_f, 1) - expected_res < 1E-11)


test_diff()

func_dict = {
    'e^x': (exp, 0, exp(0)),
    'e^(-2x^2)': (lambda x: exp(-2 * x**2), 0, 0),
    'cos(x)': (cos, 2*pi, sin(2*pi)),
    'ln(x)': (log, 1, 0)
}


def application():
    print("===Application===")
    print("f(x) \t\tx   \t\tf'(x)  \t\tdiff(x) \t\tError")
    for func in func_dict:
        f, x, res = func_dict[func]
        d = diff(f, x, 0.1)
        error = d - res
        print(func + "\t\t" +
              "{:.4f}".format(x) + "\t\t" + "{:.4f}".format(res) + "\t\t" + "{:.4f}".format(d) + "\t\t" + "{:.4f}".format(error))


application()
