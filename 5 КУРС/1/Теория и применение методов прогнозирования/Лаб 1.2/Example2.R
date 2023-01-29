pr1(-2.2,1.0,-1.2,1.2,300,50,0.25)   #*** вызов функции
#~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
pr1 <- function(x1,x2,y1,y2,n,m,alfa){
A = matrix(0,n,n)
u = c(1:n)
v = c(1:n)
dx = (x2-x1)/n
dy = (y2-y1)/n
a = x1
for(i in 1:n){
          b = y1
   for(j in 1:n){
             at = 0
             bt = 0
             k = 0  
             Q = 0.0    
          while(Q < 100000 & k < m){
             at = at*at - bt*bt + a
             bt = 2.0*at*bt + b
             Q = at*at + bt*bt
             k = k + 1
          }
          A[i,j] =Q^alfa
          v[j] = b
          b = b + dy
          }
   u[i] = a
   a = a + dx
}
win.graph()
image(u, v, A, col=terrain.colors(100))
}