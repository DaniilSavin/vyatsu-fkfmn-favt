(defun main()
 (setq way ( ));путь (пока пустой)
 (gogo 1 1)
 ;(setq way (reverse way))
 (printway)
)

(defun add(y x);добавление в начало
 (setq way (cons (+ (* y 10) x) way))
)

(defun del();удаление из начала
 (setq way (cdr way))
)

(defun chek(y x) ;1 - есть в пути 0 - нет в пути
 (setq tmplist (member (+ (* y 10) x) way))
 (setq tmp 1)
 (cond ((= (list-length tmplist) 0) (setq tmp 0)) )
 (setq chek tmp)
)

(defun gogo(y x)
 (add y x)
 (cond ((and (= (list-length way) 12)
             (or (and (= y 2) (= x 1)) (and (= x 2) (= y 1)) )
        ) 
        (return-from gogo 1)
       )
 );удачное завершение
 (setq tmp 0)
 (cond ( (and (> y 1) (= (chek (- y 1) x) 0)) (cond ((= (gogo (- y 1) x) 1) (return-from gogo 1))) ) )

 (cond ( (and (< y 3) (= (chek (+ y 1) x) 0)) (cond ((= (gogo (+ y 1) x) 1) (return-from gogo 1))) ) )

 (cond ( (and (> x 1) (= (chek y (- x 1)) 0)) (cond ((= (gogo y (- x 1)) 1) (return-from gogo 1))) ) )

 (cond ( (and (< x 4) (= (chek y (+ x 1)) 0)) (cond ((= (gogo y (+ x 1)) 1) (return-from gogo 1))) ) )

 (del)
 (setq gogo 0)
)

(defun printway()
 (setq way (reverse way))
 (print "Путь:")
 (dolist (elem way)
  (case elem
   (11 (princ "a-1 "))
   (12 (princ "b-1 "))
   (13 (princ "c-1 "))
   (14 (princ "d-1 "))
   (21 (princ "a-2 "))
   (22 (princ "b-2 "))
   (23 (princ "c-2 "))
   (24 (princ "d-2 "))
   (31 (princ "a-3 "))
   (32 (princ "b-3 "))
   (33 (princ "c-3 "))
   (34 (princ "d-3 "))
   (t (print "error " elem))
  );case
 );dolist
)