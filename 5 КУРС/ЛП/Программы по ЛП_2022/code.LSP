(defconstant N_DAY 3) ; отсчет с 0

(loop for K from 0 to N_DAY 
    do (loop for M from 0 to N_DAY 
        do (loop for A from 0 to N_DAY 
            do (loop for L from 0 to N_DAY 
                if (and 
                        (/= K M A L)
                        (or (= L 0) (= K 0))
                        (or (= K 0) (= K 1) (= A 0))
                        (or (= M 3) (= K 2))
                        (or (/= L 1) (/= K 0))
                        (or (/= A 0) (/= M 1))
                    )
                    do
                    (format t "K = ~d~%" K)
                    (format t "M = ~d~%" M)
                    (format t "A = ~d~%" A)
                    (format t "L = ~d~%~%" L)
                
            )
        )
    )
)
