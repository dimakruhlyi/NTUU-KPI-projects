library(MASS)
lambda = 100
x <- rexp(1000, lambda)
hist(x)
(fit <- fitdistr(x, densfun="exponential"))
Fn <- ecdf(x)
seqX = seq(0,0.1,0.1/1000.0);
ecdfData <- Fn(seqX)
plot(seqX, ecdfData, type='l', col='#ff0000')
curve(pexp(x, fit$estimate[1]), from = 0, to = 0.2, add=T, col='#00ff00')
ks.test(x, "pexp", lambda)