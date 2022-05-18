users_dnorm <- function(x, u, sigma) {
  e_temp <- exp(1) ** -((x - u) ** 2 / (2 * sigma ** 2))
  return(1 / (sigma * sqrt(2 * pi)) * e_temp)
}
factorial <- function(n) {
  if (n == 1) return(n)
  return(n * factorial(n - 1))
}
fibonacci <- function(n) {
  if (n <= 1) return (1)
  return(fibonacci(n - 1) + fibonacci(n - 2))
}
cat("User's dnorm function result: ", users_dnorm(2, 3, 4))
cat("\nBuild-in dnorm function result: ", dnorm(2, 3, 4))
cat("\nFactorial (6) result:", factorial(6))
cat("\nFibonacci (4) result:", fibonacci(4))