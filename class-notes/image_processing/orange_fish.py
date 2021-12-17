# -*- coding: utf-8 -*-
"""
Created on Fri Dec 17 17:14:59 2021

@author: petir
"""
import cv2
import numpy as np
import matplotlib.pyplot as plt

background = cv2.imread("fish_bg.png")
img = cv2.imread("fish.png")

img_org = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
hsv = cv2.cvtColor(img, cv2.COLOR_BGR2HSV)
mask = cv2.inRange(hsv, (5, 75, 25), (25, 255, 255))

plt.figure(figsize = (20,20))
plt.subplot(111)
plt.imshow(img_org)
plt.axis("off")
plt.title("Original image")

imask = mask > 0
orange = np.zeros_like(img, np.uint8)
orange[imask] = img[imask]
orange_rgb = cv2.cvtColor(orange, cv2.COLOR_BGR2RGB)

plt.figure(figsize = (20,20))
plt.subplot(111)
plt.imshow(orange_rgb)
plt.axis("off")
plt.title("Fish")

yellow = img.copy()
hsv[...,0] = hsv[...,0] + 20
yellow[imask] = cv2.cvtColor(hsv, cv2.COLOR_HSV2BGR)[imask]
yellow = np.clip(yellow, 0, 255)

yellow_rgb = cv2.cvtColor(yellow,cv2.COLOR_BGR2RGB)

plt.figure(figsize=(20,20))
plt.subplot(111)
plt.imshow(yellow_rgb)
plt.axis('off')
plt.title('Yellow fish')

bckfish = cv2.bitwise_and(background, background, mask = imask.astype(np.uint8))
nofish = img.copy()
nofish = cv2.bitwise_and(nofish, nofish,
                         mask = (np.bitwise_not(imask)).astype(np.uint8))
nofish = nofish + bckfish
nofish_rgb = cv2.cvtColor(nofish,cv2.COLOR_BGR2RGB)

plt.figure(figsize=(20,20))
plt.subplot(111)
plt.imshow(nofish_rgb)
plt.axis('off')
plt.title('Transparent fish image')

