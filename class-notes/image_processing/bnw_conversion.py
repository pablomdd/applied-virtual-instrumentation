# -*- coding: utf-8 -*-
"""
Created on Wed Dec 15 15:05:06 2021

@author: petir
"""

import numpy as np
from skimage.io import imread
from skimage.color import rgb2lab, lab2rgb
import matplotlib.pyplot as plt

im = imread('flowers.png')

im1 = rgb2lab(im)
im1[...,1] = im1[..., 2] = 0
im1 = lab2rgb(im1)

plt.figure(figsize=(20,10))
plt.subplot(121)
plt.imshow(im)
plt.axis("off")
plt.title("Original image", size=20)

plt.subplot(122)
plt.imshow(im1)
plt.axis("off")
plt.title("Grayscale image", size=20)

plt.show()