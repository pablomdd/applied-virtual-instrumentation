s = "numero de caracteres"

dict = {}
for c in s:
    if c in dict:
        dict[c] += 1
    else:
        dict[c] = 1

for key, val in dict.items():
    print(f"El caracter {key} aparecio {val} veces")
