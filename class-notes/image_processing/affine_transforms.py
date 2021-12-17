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

# rotated image
theta = np.pi / 6
mat_rotate = (np.array([[1,0,w/2],
                        [0,1,h/2],
                        [0,0,1]]) @
              np.array([[np.cos(theta), np.sin(theta),0],
                        [-np.sin(theta), np.cos(theta), 0],
                        [0,0,1]]) @
              np.array([[1,0,-w/2], 
                        [0,1,-h/2],
                        [0,0,1]]))
img_rotate = ndi.affine_transform(img, mat_rotate)

# Sheared image
lamda1 = 0.5
mat_shear = np.array([[1, lamda1, 0],
                       [lamda1, 1, 0],
                       [0, 0, 1]])
img_shear = ndi.affine_transform(img, mat_shear)

# All transformations 
mat_all = mat_identity @ mat_reflect @ mat_scale @ mat_rotate @ mat_shear
img_all = ndi.affine_transform(img, mat_all)

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

plt.subplot(234)
plt.imshow(img_rotate, cmap="gray")
plt.axis("off")
plt.title("Rotated image", size=20)

plt.subplot(235)
plt.imshow(img_shear, cmap="gray")
plt.axis("off")
plt.title("Sheare image", size=20)

plt.subplot(236)
plt.imshow(img_all, cmap="gray")
plt.axis("off")
plt.title("All transforms image", size=20)
