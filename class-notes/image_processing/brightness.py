# -*- coding: utf-8 -*-
"""
Created on Wed Dec 15 15:15:30 2021

@author: pablomdd
"""

import numpy as np
from skimage.io import imread
from skimage.color import rgb2lab, lab2rgb
import matplotlib.pyplot as plt

im = imread('flowers.png')
im1 = rgb2lab(im)

# Add brightness
# im1[..., 0] = im1[..., 0] + 50
# Normalization
im1[..., 0] = np.max(im1[..., 0]) - np.min(im1[..., 0]) 
im1 = lab2rgb(im1)

im2 = rgb2lab(im)
im2[..., 0] = im2[..., 0] - 50
im2 = lab2rgb(im2)

plt.figure(figsize=(20,10))
plt.subplot(131)
plt.imshow(im)
plt.axis("off")
plt.title("Original image", size=20)

plt.subplot(132)
plt.imshow(im1)
plt.axis("off")
plt.title("Brighter image", size=20)

plt.subplot(133)
plt.imshow(im2)
plt.axis("off")
plt.title("Darker image", size=20)

plt.show()