class Polynomial:
    def __init__(self, coefficients: list[float]) -> None:
        self.coefficients = coefficients

    def __call__(self, x: float) -> float:
        sigma = 0
        for i in range(len(self.coefficients)):
            sigma += self.coefficients[i] * x ** i
        return sigma

    def __str__(self) -> str:
        s = ""
        for i, c in enumerate(self.coefficients):
            s += str(c) + "x^" + str(i) + " + "
        return s[:-3]


p1 = Polynomial([1, -1])
p2 = Polynomial([0, 1, 0, 0, -6, -1])

print(p1(1))
print(p1)
