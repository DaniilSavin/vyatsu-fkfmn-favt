(defun s()
(setq base (vector "Я" "М" "А" "Л" " "
                   "Я" "Г" "О" "Д" "А"  
                   "А" "В" "Т" "О" "Р"
                   "А" "Т" "А" "С" " "
                   "В" "О" "Р" " " " "
                   "В" "О" "Т" " " " "))
(dotimes (i1 6)    
 (dotimes (i2 6)   
  (dotimes (i3 6)  
   (setq im1 (* i1 6))
   (setq im2 (* i2 6))
   (setq im3 (* i3 6))
      (princ im1)
   (princ im2)
   (if (and (string= (elt base im1) "Я")
            (string= (elt base im2) "А")
       )

    (print) 
) 
  )
 )
)
)

(defun print() 
 (setq cr (vector "_" "_" "_" "Я" (elt base (+ im1 1)) (elt base (+ im1 2)) (elt base (+ im1 3))
                  "_" "_" "_" "Г" "_" "_" "_"
                  "_" "_" "_" "О" "_" "_" "_"
                  "_" "_" "_" "Д" "_" "_" "_"
                  "_" "_" "_" "А" (elt base (+ im2 1)) (elt base (+ im2 2)) (elt base (+ im2 3)))
                  )
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
