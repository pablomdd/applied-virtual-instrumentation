import numpy as np

class Toolbox():
    """
    This library includes operations:
        - First Derivative
        - Numerical Integration
        - Aritmetic Mean
        - Stantard Deviation
    """
    def __init__(self):
        pass
    
    def first_derivative(self, t, y):
        """
            Return the first derivative of the array pair (t, y) with the
            central finite diferentation method.
            Note that len(t) = len(y), and length must be >= 5.
        """
        N = len(t)
        if (N < 5):
            return ([],[])
        h = t[3] - t[1]
        y_d = np.array([])
        t_aux = np.array([])
        for i in range(2, N - 2):
            y_di = (y[i+2] - y[i-2]) / (2 * h)
            t_i = t[i]
            y_d = np.append(y_d, y_di)
            t_aux = np.append(t_aux, t_i)
        return y_d, t_aux
    
    def numerical_integral(self, t, y):
        """
            Return the numerical integral of the array pair (t, y).
            Note that len(t) = len(y), and length must be >= 2.
        """
        N = len(t)
        if not N:
            return 0
        h = (t[N-1] - t[0]) / (N - 1)
        sigma = 0
        for i in range(N - 1):
            sigma += (h / 2) * (y[i] + y[i + 1])
        return sigma
    
    def mean(self, x):
        """
            Return the aritmetic mean of an array.
        """
        N = len(x)
        if not N:
            return 0
        sigma = 0
        for i in range(N):
            sigma += x[i]
        return sigma / N
    
    def std(self, x):
        """
            Return the stantard deviation of an array.
        """
        N = len(x)
        if not N:
            return 0
        mean = self.mean(x)
        sigma = 0
        for i in range(N):
            sigma += (x[i] - mean)**2
        return np.sqrt(sigma / N)
    
    
if (__name__ == "__main__"):
     x = [2, 3, 5,2, 3, 5,6,2,9,2]
     toolbox = Toolbox()
     print(toolbox.mean(x))
     