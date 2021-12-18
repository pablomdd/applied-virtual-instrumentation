# -*- coding: utf-8 -*-
"""
Created on Fri Dec 17 20:03:22 2021

"""

import numpy as np
import csv

class MathOps():
    def __init__(self, t, y):
        # self.t = t if bool(t) else np.array([])
        # self.y = y if bool(y) else np.array([])
        pass
    
    def primera_derivada(self, t, y):
        N = len(x)
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
    
    def integral_numerica(self, t, y):
        N = len(x)
        if (N == 0 or not N):
            return 0
        h = (t[N-1] - t[0]) / (N - 1)
        sigma = 0
        for i in range(N - 1):
            sigma += (h / 2) * (y[i] + y[i + 1])
        return sigma
    
    def media_aritmetica(self, x):
        return np.mean(x)
    
    def desviacion_std(self, x):
        return np.std(x)
    
    def mean(self, x):
        N = len(x)
        if not N:
            return 0
        sigma = 0
        for i in range(N):
            sigma += x[i]
        return sigma / N
    
    def standard_deviation(self, x):
        N = len(x)
        if not N:
            return 0
        mean = self.mean(x)
        sigma = 0
        for i in range(N):
            sigma += (x[i] - mean)**2
        return np.sqrt(sigma / N)
        
if __name__ == "__main__":
    x = np.array([])
    y = np.array([])
    with open('sample_data.csv', mode='r') as csv_file:
        csv_reader = csv.reader(csv_file, delimiter=",")
        line_count = 0
        for row in csv_reader:
            if line_count == 0:
                print(f'Column names are {", ".join(row)}')
                line_count += 1
                continue
            x = np.append(x, float(row[0]))
            y = np.append(y, float(row[1]))

            # print(f'\t{row[0]} , {row[1]}')
            line_count += 1
        print(f'Processed {line_count} lines.')
        
    ops = MathOps(x, y)
    # print(ops.primera_derivada(x, y))
    # print(ops.integral_numerica(x, y))
    # print(ops.media_aritmetica(y))
    print(ops.standard_deviation(y))