(defun cross()
(setq base (vector "Т" "А" "Й" "Ф" "У" "Н" 
                   "О" "С" "А" " " " " " "
                   "О" "Б" "А" " " " " " "
                   "У" "Ш" "У" " " " " " "
                   "Ф" "О" "Н" " " " " " "
                   "Ф" "Е" "Я" " " " " " " ))
(dotimes (i1 6)    
 (dotimes (i2 6)   
  (dotimes (i3 6)  
   (setq im1 (* i1 6))
   (setq im2 (* i2 6))
   (setq im3 (* i3 6))
   (if (and (string= (elt base (+ im1 2)) "А")
            (string= (elt base im2) "Ф")
            (string= (elt base (+ im3 2)) "У")
       )
    (print) 
) 
  )
 )
)
 
)
 
 
(defun print() 
 (setq cr (vector " " (elt base im1) " " " " (elt base im3) " " 
                 " " (elt base (+ im1 1)) " " " " (elt base (+ im3 1)) " " 
      	 "Т" "А" "Й" "Ф" "У" "Н" 
                 " " " " " " (elt base (+ im2 1)) " " " " 
                 " " " " " " (elt base (+ im2 2)) " " " " ))
(dotimes (q1 30) 
 (if(= (rem q1 6) 0) (terpri))
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
