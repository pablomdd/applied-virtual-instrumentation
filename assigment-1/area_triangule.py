# 3_11: Compute the area of an arbitrary triangule

def areaTriangule(vertices=[[0, 0], [0, 0], [0, 0]]):
    v1, v2, v3 = vertices
    return (1 / 2) * abs(
        v2[0] * v3[1] - v3[0] * v2[1] - v3[0] * v2[1] - v1[0] * v3[1] + v3[0] * v1[1] + v1[0] * v2[1] - v2[0] * v1[1])


t1 = [[0, 0], [1, 0], [0, 2]]
print(areaTriangule(t1))
