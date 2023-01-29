a = c(1.99999,-0.85,0.2,-0.15)
b = c(0.0,0.04,-0.26,0.28)
c = c(0.0,-0.04,0.23,0.26)
d = c(0.16,0.85,0.22,0.24)
e = c(0.0,0.0,0.0,0.0)
f = c(0.0,0.15,0.15,0.02)
p = c(0.01,0.85,0.07,0.07)
n = 10000
A = matrix(0,n+1,2)
for(i in 1:n){
    q =  runif(1)
    if(q>=0.93)
    {
      k=4
   }
    else
    {
       if(q>=0.86)
       {
         k=3
       }
          else
          {
             if(q>=0.01)
             {
               k=2
            }
             else
             {
               k=1
            }
          }         
}     
    A[i+1,1] = a[k]*A[i,1]+b[k]*A[i,2]+e[k]
    A[i+1,2] = c[k]*A[i,1]+d[k]*A[i,2]+f[k]
}
win.graph()
plot(A[,1], A[,2], xlab = "x", ylab = "y", main = "Fractal TREE", type = "p", col = "red", pch = 5)