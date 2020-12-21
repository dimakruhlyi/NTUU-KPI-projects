from math import cos

Start = 0.0
End = 1.0E-04
N = 1000
size = N + 1
h = (End - Start) / N



L1 = 2.5E-04 
L2 = 2.5E-04 
C1 = 2.5E-11 
C2 = 5.0E-11 
Ccb = 1.0E-9 
R2 = 250.0 
Eds = 10

Q10 = 2.5E-10
Q20 = 0.0
I10 = 0.0
I20 = 0.0

W1 = 1 / (L1 * C1) + 1 / (L1 * Ccb)
W12 = 1 / (L1 * Ccb)
W13 = Eds / L1
W21 = 1 / (L2 * Ccb)
W22 = 1 / (L2 * C2) + 1 / (L2 * C2)
W23 = R2 / L2

deltaW = 4.1237E+04
W0 = deltaW * Ccb / C2
W = 0



vt = [0] * (size)
vq1 = [0] * (size)
vq2 = [0] * (size)
vi1 = [0] * (size)
vi2 = [0] * (size)
vur2 = [0] * (size)

vt[0] = t = Start
vq1[0] = q1 = Q10
vq2[0] = q2 = Q20
vi1[0] = i1 = I10
vi2[0] = i2 = I20
vur2[0] = i2 * R2


def f1(i1):
    return i1


def f2(q1, q2, t):
    return -W1 * q1 + W12 * q2 - W13 * cos(W * t)


def f4(q1, q2, i2):
    return W21 * q1 - W22 * q2 - W23 * i2


def lab4():
    vt[0] = t = Start
    vq1[0] = q1 = Q10
    vq2[0] = q2 = Q20
    vi1[0] = i1 = I10
    vi2[0] = i2 = I20
    for i in range(1, size):
        k1 = h * f1(i1)
        l1 = h * f2(q1, q2, t)
        m1 = h * f1(i2)
        n1 = h * f4(q1, q2, i2)

        k2 = h * f1(i1 + l1/2)
        l2 = h * f2(q1 + k1/2, q2 + m1/2, t + h/2)
        m2 = h * f1(i2 + n1/2)
        n2 = h * f4(q1 + k1/2, q2 + m1/2, i2 + n1/2)

        k3 = h * f1(i1 + l2/2)
        l3 = h * f2(q1 + k2/2, q2 + m2/2, t + h/2)
        m3 = h * f1(i2 + n2/2)
        n3 = h * f4(q1 + k2/2, q2 + m2/2, i2 + n2/2)

        k4 = h * f1(i1 + l3)
        l4 = h * f2(q1 + k3, q2 + m3, t + h)
        m4 = h * f1(i2 + n3)
        n4 = h * f4(q1 + k3, q2 + m3, i2 + n3)

        vq1[i] = q1 = q1 + (k1 + 2 * k2 + 2 * k3 + k4) / 6
        vq2[i] = q2 = q2 + (m1 + 2 * m2 + 2 * m3 + m4) / 6
        vi1[i] = i1 = i1 + (l1 + 2 * l2 + 2 * l3 + l4) / 6
        vi2[i] = i2 = i2 + (n1 + 2 * n2 + 2 * n3 + n4) / 6

        vur2[i] = i2 * R2

        vt[i] = t = t + h
    return vur2


points = 200
Wstep = 2 * W0 / points
with open("results", 'w') as f:
    for i in range(points + 1):
        vur2 = lab4()
        amp = max(vur2)
        step = 2 * (float(i) / points)
        f.write("%0.20f %0.20f\n" % (step, amp))
        W = Wstep * i

