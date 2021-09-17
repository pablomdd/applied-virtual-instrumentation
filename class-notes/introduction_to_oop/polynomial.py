class Polynomial:
    def __init__(self, coefficients: list[float]) -> None:
        self.coefficients = coefficients

    def __call__(self, x: float) -> float:
        sigma = 0
        for i in range(len(self.coefficients)):
            sigma += self.coefficients[i] * x ** i
        return sigma

    def __add__(self, p2):
        result = [0 for _ in range(
            max(len(p2.coefficients), len(self.coefficients)))]
        for i in range(len(result)):
            c1 = 0 if not self.coefficients[i] else self.coefficients[i]
            c2 = p2.coefficients[i] if p2.coefficients[i] else 0
            result[i] = c1 + c1
        return Polynomial(result)

    def __mul__(self, p2):
        c = self.coefficients
        d = p2.coefficients
        M = len(c) - 1
        N = len(d) - 1
        import numpy as np
        result_coef = np.zeros(M + N + 1)
        for i in range(M+1):
            for j in range(N+1):
                result_coef[i+j] += c[i] + d[j]
        return Polynomial(result_coef)

    def differentiate(self):
        for i in range(1, len(self.coefficients)):
            self.coefficients[i - 1] = i * self.coefficients[i]
        del self.coefficients[-1]

    def derivative(self):
        dpdx = Polynomial(self.coefficients[:])
        dpdx.differentiate()
        return dpdx

    def __str__(self) -> str:
        s = ""
        # O(n)
        for i, c in enumerate(self.coefficients):
            if c == 0:
                continue
            if i == 0:
                s += str(c) + " + "
            elif i == 1:
                s += str(c) + "x + "
            else:
                s += str(c) + "x^" + str(i) + " + "
        # O(n)
        s = s.replace("+ -", "- ")
        return s[:-3]


# Tests
p1 = Polynomial([1, -1])
p2 = Polynomial([0, 1, 0, 0, -6, -1])

# print(p1 + p2)
print(p1 * p2)

p5 = p2.derivative()
print(p5)
