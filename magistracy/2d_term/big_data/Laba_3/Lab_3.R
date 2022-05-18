x1<-sample(0:1000, 100, replace=FALSE, prob=NULL)
x2<-sample(0:1000, 100, replace=FALSE, prob=NULL)
x_matr<-matrix(c(rep(1, 100), x1, x2), ncol = 3)
b0<-3
b1<-5
b2<-7

eseq<-seq(0, 1, by = .01)
e<-dnorm(eseq, mean=2.5, sd=0.5)
y<-seq(1, 100, by = 1)

for(i in 1:100)
  y[i]<-b0+b1*x1[i]+b2*x2[i]+e[i]


m1<-lm(y~x1+x2)
c1<-solve(t(x_matr) %*% x_matr) %*% t(x_matr) %*% y

print("Built-in function lm():")
print(m1)
print("Estimator: ")
print(c1)

