# -*- coding: utf-8 -*-
"""
Created on Wed Dec 15 15:33:06 2021

@author: petir
"""

import numpy as np
from skimage.io import imread
from skimage.color import rgb2gray
import matplotlib.pyplot as plt
from scipy import ndimage as ndi

img = rgb2gray(imread('humming.png'))
w, h = img.shape

mat_identity = np.array([[1,0,0], [0,1,0], [0,0,1]])
img_identity = ndi.affine_transform(img, mat_identity)

# Reflected image
mat_reflect = (np.array([[1,0,0], [0,-1,0],[0,0,1]]) @ 
    np.array([[1,0,0],[0,1,-h],[0,0,1]]))
img_reflect = ndi.affine_transform(img, mat_reflect)

# scaled image
s_x = 0.75
s_y = 1.25
mat_scale = np.array([[s_x,0,0],[0,s_y,0],[0,0,1]])
img_scale = ndi.affine_transform(img, mat_scale)

plt.figure(figsize=(20,10))
plt.subplot(231)
plt.imshow(img_identity, cmap="gray")
plt.axis("off")
plt.title("Original image", size=20)

plt.subplot(232)
plt.imshow(img_reflect, cmap="gray")
plt.axis("off")
plt.title("Reflected image", size=20)

plt.subplot(233)
plt.imshow(img_scale, cmap="gray")
plt.axis("off")
plt.title("Scaled image", size=20)

