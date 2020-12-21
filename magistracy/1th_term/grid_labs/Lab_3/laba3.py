import math

L1 = 2.5E-4
L2 = 2.5E-4
C1 = 2.5E-11
C2 = 5.0E-11
Ccv = 2.0E-11


FILE1 = open('res1', 'w')
FILE2 = open('res2', 'w')

while Ccv <= 2.0E-10:
    wp1 = math.sqrt(1.0 / (L1 + C1))
    wm1 = math.sqrt(1.0 / L1 * (1.0 / C1 + 2.0 / Ccv))
    wd1 = wm1 - wp1
    w0 = (wd1 * Ccv) / C1

    p1_1 = 1 / wd1
    p1_2 = 1 / w0

    FILE1.write("%0.20f %0.20f %0.20f\n" % (Ccv, p1_1, p1_2))

    wp2 = math.sqrt(1.0 / (L2 + C2))
    wm2 = math.sqrt(1.0 / L2 * (1.0 / C2 + 2.0 / Ccv))
    wd2 = wm2 - wp2
    w0_2 = (wd2 * Ccv) / C2

    p2_1 = 1 / wd2
    p2_2 = 1 / w0_2

    FILE2.write("%0.20f %0.20f %0.20f\n" % (Ccv, p2_1, p2_2))
    Ccv += 1.0E-11