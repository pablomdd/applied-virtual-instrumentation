# Raíz de una funcion cuadratica
a = float(input("Ingresa el coeficiente a: \n"))
b = float(input("Ingresa el coeficiente b: \n"))
c = float(input("Ingresa el coeficiente c: \n"))

root1 = (-b + (b**2 - 4 * a * c) ** (1/2)) / (2*a)
root2 = (-b - (b**2 - 4 * a * c) ** (1/2)) / (2*a)

print("R1 = ", root1)
print("R2 = ", root2)
