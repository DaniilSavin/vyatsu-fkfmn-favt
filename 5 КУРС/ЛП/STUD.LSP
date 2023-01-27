; Экспертная система идентификации студентов

(defun students()
 (cls)  ; очиска экрана
 (setq q (list
          " Рост низкий    : "
          " Рост средний   : "
          " Рост высокий   : "
          " Волосы светлые : "
          " Волосы темные  : "
          " Волосы рыжие   : "
          " Мужчина        : "
          " Носит очки     : "
          "  : "
          "  : "))

 (setq r(list
          " Ситников     : "
          " Слобожанинов : "
          " Харитонов    : "
          " Перегородин  : "
          " Горшкова     : "
          " Нечаева      : "))

  (princ "\nЭкспертная система идентификации студентов:")
  (princ "\n   Горшкова,\n   Перегородин,\n   Нечаева,\n   Ситинков,\n   Слобожанинов,\n   Харитонов\n")
  (princ "\nВведите коэффициенты [-1;1]: \n")
; Ввод коэффициентов
  (loop (princ(nth 0 q)) (setq C1 (read))
   (if (integerp C1) (setq C1 (float C1)))
   (if (and (floatp C1)(<= (abs C1) 1)) (return)))

  (loop (princ(nth 1 q)) (setq C2 (read))
   (if (integerp C2) (setq C2 (float C2)))
   (if (and (floatp C2)(<= (abs C2) 1)) (return)))

  (loop (princ(nth 2 q)) (setq C3 (read))
   (if (integerp C3) (setq C3 (float C3)))
   (if (and (floatp C3)(<= (abs C3) 1)) (return)))

  (loop (princ(nth 3 q)) (setq C4 (read))
   (if (integerp C4) (setq C4 (float C4)))
   (if (and (floatp C4)(<= (abs C4) 1)) (return)))

  (loop (princ(nth 4 q)) (setq C5 (read))
   (if (integerp C5) (setq C5 (float C5)))
   (if (and (floatp C5)(<= (abs C5) 1)) (return)))

  (loop (princ(nth 5 q)) (setq C6 (read))
   (if (integerp C6) (setq C6 (float C6)))
   (if (and (floatp C6)(<= (abs C6) 1)) (return)))

  (loop (princ(nth 6 q)) (setq C7 (read))
   (if (integerp C7) (setq C7 (float C7)))
   (if (and (floatp C7)(<= (abs C7) 1)) (return)))

  (loop (princ(nth 7 q)) (setq C8 (read))
   (if (integerp C8) (setq C8 (float C8)))
   (if (and (floatp C8)(<= (abs C8) 1)) (return)))

  (loop (princ(nth 8 q)) (setq C9 (read))
   (if (integerp C9) (setq C9 (float C9)))
   (if (and (floatp C9)(<= (abs C9) 1)) (return)))

  (loop (princ(nth 9 q)) (setq C10 (read))
   (if (integerp C10) (setq C10 (float C10)))
   (if (and (floatp C10)(<= (abs C10) 1)) (return)))

; вычисляем D1...D5
    ;A1
  (setq A1 (* (max C1 C2 C3 C4 C6 C7 C8) 0.9))
    ;A2
  (setq A2 (* (max C1 C2 C3 C4 C6 (- 0 C7) (- 0 C8) ) 0.9))
    ;A3
  (setq A3 (* (max C1 C2 C3 C4 C7 (- 0 C5) (- 0 C8) (- 0 C10)) 0.9))
    ;A4
  (setq A4 (* (max C1 C2 C3 C4 (- 0 C5) (- 0 C10) (- 0 C7) (- 0 C8)) 0.9))
    ;A5
  (setq A5 (* (max C8  (- 0 C4) (- 0 C5) (- 0 C7) (- 0 C1) (- 0 C6)) 0.9))
    ;A6
  (setq A6 (* (min (- 0 C2) (- 0 C9) (- 0 C10)) 0.9))


; вычисляем Y1...Y6
  ; Y1 -
  (setq Y1 (int (int (* A1 0.9) (* (- 0 C9) 0.9)) (* C10 0.9)))
  ; Y2 -
  (setq Y2 (int (int (* C9 0.9) (* C5 0.9)) (int (* C10 0.9) (* A2 0.9))))
  ; Y3 -
  (setq Y3 (int (int (* (- 0 C9) 0.9) (* (- 0 C6) 0.9)) (* A3 0.9)))
  ; Y4 -
  (setq Y4 (int (int (* C9 0.9) (* (- 0 C6) 0.9)) (* A4 0.9)))
  ; Y5 -
  (setq Y5 (int (int (* (- 0 C2) 0.9) (* (- 0 C10) 0.9)) (int (* C9 0.9) (* A5 0.99))))
  ; Y6 -
  (setq Y6 (int (* A6 0.9) (* A5 0.9)))
  ;
  (setq l1 (list (nth 0 r) Y1))
  (setq l2 (list (nth 1 r) Y2))
  (setq l3 (list (nth 2 r) Y3))
  (setq l4 (list (nth 3 r) Y4))
  (setq l5 (list (nth 4 r) Y5))
  (setq l6 (list (nth 5 r) Y6))
  (princ "\nРезультаты: \n\n")
  (setq li (list l1 l2 l3 l4 l5 l6))

  ; сортировка и вывод результатов

  (setq c 0)
  (dotimes (c 6)
  (setq z (car li))
  (dolist (tst li)
    (if (< (cadr z) (cadr tst)) (setq z tst))
   )
  (princ (car z))
  (print (cadr z))
  (setq li (delete z li))
  )

  (terpri)
)

; функция реализует импликацию 2х посылок

(defun int(i1 i2)
  (cond
    ((and (> i1 0) (> i2 0)) (setq int (+ i1 i2 (* -1 i1 i2))))
    ((and (< i1 0) (< i2 0)) (setq int (+ i1 i2 (* i1 i2))))
    (T (setq int (/ (+ i1 i2) (- 1 (min (abs i1) (abs i2))))))
  )
)
