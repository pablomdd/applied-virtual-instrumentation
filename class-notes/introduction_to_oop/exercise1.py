class Y:
    def __init__(self, y0, v0) -> None:
        self.y0 = y0
        self.v0 = v0
        self.g = 9.81

    def value(self, t):
        return self.y0 + self.v0 * t + 0.5 * self.g * t ** 2

    # Evaluar fórmula directamente
    def __call__(self, t):
        return self.y0 + self.v0 * t + 0.5 * self.g * t ** 2

    def formular(self):
        print("y = %g + %g*t + 0.5%g*t^2" % (self.y0, self.v0, self.g))


Ye = Y(10, 5)
print(Ye(15))
Ye.y0 = 20
print(Ye(15))
Ye.formular()
