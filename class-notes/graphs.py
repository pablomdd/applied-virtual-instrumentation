# -*- coding: utf-8 -*-
import matplotlib.pyplot as plt
import numpy as np

filename = "D:/petir/Documents/GitHub/applied-virtual-instrumentation/class-notes/Datos2.csv"
# filename = "./Datos2.csv"
new_file = open(filename, 'r')
data_str = []

for line in new_file:
    line = line.replace("\n", "")
    data_str.append(line.split(','))
new_file.close()

data = np.asarray(data_str, dtype=float)
data = data.T

fig = plt.figure()
ax = plt.axes()
for i in range(1, len(data)):
    ax.plot(data[0], data[i], 'o--')
ax.set_xlabel(r'$t$ (s)')
ax.set_ylabel(r'$A$ (u.a.))')
