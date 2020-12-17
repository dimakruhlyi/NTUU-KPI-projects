Start = 0.0
End = 3.0E-04
N = 1000000 
size = N + 1
h = (End - Start) / N
f = open('results', 'w')

vt = [0] * (size)
vq1 = [0] * (size)
vq2 = [0] * (size)
vi1 = [0] * (size)
vi2 = [0] * (size)
vur2 = [0] * (size)

L1 = 2.5E-04 
L2 = 2.5E-04 
C1 = 2.5E-11 
C2 = 5.0E-11 
Ccb = 1.0E-9 
R2 = 250.0 

Q10 = 2.5E-10
Q20 = 0.0
I10 = 0.0
I20 = 0.0

vt[0] = t = Start
vq1[0] = q1 = Q10
vq2[0] = q2 = Q20
vi1[0] = i1 = I10
vi2[0] = i2 = I20
vur2[0] = i2 * R2
f.write("%0.10f %0.20f %0.20f %0.20f %0.20f %0.20f\n" % (vt[0], vq1[0], vq2[0], vi1[0], vi2[0], vur2[0]))

W1 = 1 / (L1 * C1) + 1 / (L1 * Ccb)
W12 = 1 / (L1 * Ccb)
W21 = 1 / (L2 * Ccb)
W22 = 1 / (L2 * C2) + 1 / (L2 * C2)
W23 = R2 / L2

def f1(i):
    return i

def f2(q, q2):
    return -W1 * q + W12 * q2

def f3(q1, q2, i2):
    return W21 * q1 - W22 * q2 - W23 * i2

for i in range(1, size):

       k1 = h * f1(i1)
       l1 = h * f2(q1, q2)
       m1 = h * f1(i2)
       n1 = h * f3(q1, q2, i2)

       k2 = h * f1(i1 + l1/2)
       l2 = h * f2(q1 + k1/2, q2 + m1/2)
       m2 = h * f1(i2 + n1/2)
       n2 = h * f3(q1 + k1/2, q2 + m1/2, i2 + n1/2)

       k3 = h * f1(i1 + l2/2)
       l3 = h * f2(q1 + k2/2, q2 + m2/2)
       m3 = h * f1(i2 + n2/2)
       n3 = h * f3(q1 + k2/2, q2 + m2/2, i2 + n2/2)

       k4 = h * f1(i1 + l3)
       l4 = h * f2(q1 + k3, q2 + m3)
       m4 = h * f1(i2 + n3)
       n4 = h * f3(q1 + k3, q2 + m3, i2 + n3)

       vq1[i] = q1 = q1 + (k1 + 2 * k2 + 2 * k3 + k4) / 6
       vq2[i] = q2 = q2 + (m1 + 2 * m2 + 2 * m3 + m4) / 6
       vi1[i] = i1 = i1 + (l1 + 2 * l2 + 2 * l3 + l4) / 6
       vi2[i] = i2 = i2 + (n1 + 2 * n2 + 2 * n3 + n4) / 6
       vur2[i] = i2 * R2
       vt[i] = t = t + h

       f.write("%0.10f %0.20f %0.20f %0.20f %0.20f %0.20f\n" % (vt[i], vq1[i], vq2[i], vi1[i], vi2[i], vur2[i]))
