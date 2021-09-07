# 3_12 Compute length of a Path
from typing import List
from math import sqrt


def pathlength(x: List[int], y: List[int]):
    length = 0
    for i in range(1, len(x)):
        length += sqrt((x[i] - x[i - 1]) ** 2 + (y[i] - y[i - 1]) ** 2)
    return length


# tests vars
L1 = [[0], [0]]

# Unit test function


def test_pathlength():
    L2_length = 0
    expected_result = True
    print("Expect L1 & L2 to be " + str(expected_result))
    print("Test result is " + str(pathlength(L1[0], L1[1]) == L2_length))
    return


test_pathlength()
