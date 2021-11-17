# ==== Programa 1 ====
from math import pi


def imprimir_hola():
    print("Hola!")


for i in range(3):
    imprimir_hola()

# ==== Programa 2 ====


def imprimir_argumentos(arg_1, arg_2):
    print(arg_1 + arg_2)


imprimir_argumentos("!Hola, ", "mundo!")
imprimir_argumentos(1 + 1j, 2 + 2j)
imprimir_argumentos([1, 2, 3], [4, 5, 6])

# ==== Programa 3 ====


def regresa_valor_pi():
    return pi


r = 1
area_circulo = (regresa_valor_pi()) * r ** 2
print(area_circulo)

# ==== Programa 4 ====


def multiplica_a_y_b(a, b):
    return a * b


var_1 = multiplica_a_y_b(2, "Hola")
print(var_1)

var_2 = multiplica_a_y_b(2, 3)
print(var_2)

var_3 = multiplica_a_y_b(1+1j, 1-1j)
print(var_3)

# ==== Programa 5 ====

p = {
    0: -1,
    2: 1,
    7: 3
}


def poly_dict(p, x):
    sum = 0
    for grado in p:
        sum += p[grado] * x ** grado
    return sum


print("p(x=2) = ", poly_dict(p, 2))


# ==== Programa 6 ====
def char_frequency(s):
    dict = {}
    for char in s:
        keys = dict.keys()
        if(char in keys):
            dict[char] += 1
        else:
            dict[char] = 1
    return dict


print(char_frequency("goog.com"))
