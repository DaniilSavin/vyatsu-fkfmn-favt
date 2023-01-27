(defun s()
(setq base (vector "Я" "Г" "О" "Д" "А"
				   "Я" "М" "А" "Л" " " 
                   "А" "В" "Т" "О" "Р"
                   "А" "Т" "А" "С" " "
                   "В" "О" "Р" " " " "
                   "В" "О" "Т" " " " " ))
(dotimes (i1 6)    
 (dotimes (i2 6)   
  (dotimes (i3 6)  
   (setq im1 (* i1 6))
   (setq im2 (* i2 6))
   (setq im3 (* i3 6))
   (if (and (string= (elt base im2) "Я")


       )
    (print) 
) 
  )
 )
)

)


(defun print() 
 (setq cr (vector " " " " " " "Я" (elt base (+ im2 1)) (elt base (+ im2 2)) (elt base (+ im2 3))
                  " " " " " " "Г" " " " " " "
				  " " " " " " "О" " " " " " "
				  " " " " " " "Д" " " " " " "
				  " " " " " " "А" " " " " " "))
(dotimes (q1 35) 
 (if(= (rem q1 7) 0) (terpri))
 (princ (elt cr q1))
)
(printnext)
)

(defun printnext()
 (terpri)
 (princ "Нажмите любой символ ,а потом Enter: ")
 (read)
 (terpri)
 (terpri)
)
