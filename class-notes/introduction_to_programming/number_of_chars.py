st = "google.com"
n = len(st)  # Número de caracteres

last_char = ""
ch_index = []

# [0,1,1,0,4,5,6,7,1,9]

for i in range(n):
    last_char = st[i]
    for j in range(n):
        if(last_char == st[j]):
            ch_index.append(j)
            break


print(ch_index)
# Generar lista [0,1,1,0,4,5,6,7,1,9]
# El método sorted ordena los elementos de menor a mayor
ch_index_sort = sorted(ch_index)
print(ch_index_sort)

# Descarte de los índices repetidos [0,1,4,5,6,7,9]
index = 0
ch_new_index = []
ch_new_index.append(ch_index_sort[0])
for i in range(n):
    hold = ch_index_sort[index]
    comp = index
    # Cuando al for se le pasan dos parámetros, uno es el número de inicio y el otro es el final
    # desde donde cuenta el bucle for
    for j in range(comp, n):
        if (hold != ch_index_sort[j]):
            index = j
            ch_new_index.append(ch_index_sort[j])
            break
print(ch_new_index)

# Es la lista donde se guardan los elementos que se repiten para ver su frecuencia, osea cuantas veces
# se repiten.

freq = []
for i in range(len(ch_new_index)):
    sum_freq = 0
    for j in range(n):
        if (ch_new_index[i] == ch_index[j]):
            sum_freq += 1
    freq.append(sum_freq)
print(freq)


for i in range(len(freq)):
    print("El caracter %s apareció %d veces" % (st[ch_new_index[i]], freq[i]))
