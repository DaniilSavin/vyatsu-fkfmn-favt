; ���������� ������� ������������ ������
(defun run()
   (cls)  ; ������� ������
   (setq facts (list
                " ����� ���� - ���� "
                " ����� ���� - ���� "
                " ����� ���� - ���������� "
                " ����� "
                " ��� ����� "
                " ���� ����� "
                " ���� ��������� "
                " ��������� ������� "
                " ��������� ��������� "
		" ����������� ������ -10"
		" ����������� ������ +10"
                ))
   (setq gipoteses (list
                " ����� �������"
                " ����������"
                " ��������"
                " �����"
                 ))
  (princ "\n     ")
  (princ " ���������� ������� ��� ������������ ������")
  (terpri)
  (princ "\n       ������ ��� �������������:")
  (terpri)
  (princ " ")
  (dolist (w gipoteses)
          (princ w) (princ ", "))
  (terpri)
  (princ "\n     ")
  (princ " ���������� ������� ��� ������������ ������")
  (terpri)
  (princ "\n       ������ ��� ������������� :")
  (terpri)
  (princ " ")
  (dolist (w gipoteses)
          (princ w) (princ ", "))

  (terpri)
  (setq n 1)
  (princ "\n  ����� ������ �� ��� ��������� ��������")
  (terpri)
  (princ  n) (princ ". ")
  (princ (nth 0 facts))
  (princ "?") 
  (loop (princ " ������� ����������� ����������� (�� 0 �� 1) ") (setq C1 (read))
   (if  (integerp C1) (setq C1 (float C1)))
   (if (and (>= c1 0) (floatp C1)(<= (abs C1) 1)) (return)
      (progn (princ "  ������ �������� �����������!!! ")(terpri))))
 (terpri)
(float c1)
(princ c111)

  (setq n 2)
  (terpri)
  (princ  n) (princ ". ")
  (princ (nth 1 facts))
  (princ "?") (terpri)
   (loop (princ "       ������� ����������� ����������� (�� 0 �� 1) ")(setq C2 (read))
   (if  (integerp C2) (setq C2 (float C2)))
   (if (and (>= C2 0) (floatp C2)(<= (abs C2) 1)) (return)
      (progn (princ "  ������ �������� �����������!!! ")(terpri))))


  (setq n 3)
  (terpri)
  (princ  n) (princ ". ")
  (princ (nth 2 facts))
  (princ "?") (terpri)
   (loop (princ "       ������� ����������� ����������� (�� 0 �� 1) ") (setq C3 (read))
   (if  (integerp C3) (setq C3 (float C3)))
   (if (and (>= c3 0) (floatp C3)(<= (abs C3) 1)) (return)
      (progn (princ "  ������ �������� �����������!!! ")(terpri))))


  (setq n 4)
  (terpri)
  (princ  n) (princ ". ")
  (princ (nth 3 facts))
  (princ "?") (terpri)
   (loop (princ "       ������� ����������� ����������� (�� 0 �� 1) ") (setq C4 (read))
   (if  (integerp C4) (setq C4 (float C4)))
   (if (and (>= c4 0) (floatp C4)(<= (abs C4) 1)) (return)
      (progn (princ "  ������ �������� �����������!!! ")(terpri))))


  (setq n 5)
  (terpri)
  (princ  n) (princ ". ")
  (princ (nth 4 facts))
  (princ "?") (terpri)
   (loop (princ "       ������� ����������� ����������� (�� 0 �� 1) ") (setq C5 (read))
   (if  (integerp C5) (setq C5 (float C5)))
   (if (and (>= c5 0) (floatp C5)(<= (abs C5) 1)) (return)
      (progn (princ "  ������ �������� �����������!!! ")(terpri))))


  (setq n 6)
  (terpri)
  (princ  n) (princ ". ")
  (princ (nth 5 facts))
  (princ "?") (terpri)
   (loop (princ "       ������� ����������� ����������� (�� 0 �� 1) ") (setq C6 (read))
   (if  (integerp C6) (setq C6 (float C6)))
   (if (and (>= c6 0) (floatp C6)(<= (abs C6) 1)) (return)
      (progn (princ "  ������ �������� �����������!!! ")(terpri))))


  (setq n 7)
  (terpri)
  (princ  n) (princ ". ")
  (princ (nth 6 facts))
  (princ "?") (terpri)
   (loop (princ "       ������� ����������� ����������� (�� 0 �� 1) ") (setq C7 (read))
   (if  (integerp C7) (setq C7 (float C7)))
   (if (and (>= c7 0) (floatp C7)(<= (abs C7) 1)) (return)
      (progn (princ "  ������ �������� �����������!!! ")(terpri))))


  (setq n 8)
  (terpri)
  (princ  n) (princ ". ")
  (princ (nth 7 facts))
  (princ "?") (terpri)
   (loop (princ "       ������� ����������� ����������� (�� 0 �� 1) ") (setq C8 (read))
   (if  (integerp C8) (setq C8 (float C8)))
   (if (and (>= c8 0) (floatp C8)(<= (abs C8) 1)) (return)
      (progn (princ "  ������ �������� �����������!!! ")(terpri))))

  (setq n 9)
  (terpri)
  (princ  n) (princ ". ")
  (princ (nth 8 facts))
  (princ "?") (terpri)
   (loop (princ "       ������� ����������� ����������� (�� 0 �� 1) ") (setq C9 (read))
   (if  (integerp C9) (setq C9 (float C9)))
   (if (and (>= c9 0) (floatp C9)(<= (abs C9) 1)) (return)
      (progn (princ "  ������ �������� �����������!!! ")(terpri))))


  (setq n 10)
  (terpri)
  (princ  n) (princ ". ")
  (princ (nth 9 facts))
  (princ "?") (terpri)
   (loop (princ "       ������� ����������� ����������� (�� 0 �� 1) ")
 (setq C10 (read))
   (if  (integerp C10) (setq C10 (float C10)))
   (if (and (>= c10 0) (floatp C10)(<= (abs C10) 1)) (return)
      (progn (princ "  ������ �������� �����������!!! ")(terpri))))

  (setq n 11)
  (terpri)
  (princ  n) (princ ". ")
  (princ (nth 10 facts))
  (princ "?") (terpri)
   (loop (princ "       ������� ����������� ����������� (�� 0 �� 1) ") 
(setq C11 (read))
   (if  (integerp C11) (setq C11 (float C11)))
   (if (and (>= c11 0) (floatp C11)(<= (abs C11) 1)) (return)
      (progn (princ "  ������ �������� �����������!!! ")(terpri))))

(princ c1)
(terpri)
 (setq m ())
(princ c1)
; ������ ����������� �� "�������"
 (setq K1 (min c1 c4 c7 c8 �10))
(princ k1)
 (setq k5(* k1 0.9))
(princ k5)
 (setq l (cons k1 m))
(princ l)
; ������ ����������� �� "����������"
 (setq K2 (* (min c2 c5 c6 c9 �11) 0.9))
 (setq l (cons k2 m))

; ������ ����������� �� "��������"
 (setq K3 (* (min c3 �4 �7 �8 �10 c11) 0.95))
 (setq l (cons k3 m))

; ������ ����������� �� "�����"
 (setq K4 (* (min c2 �5 �6 �9 �11) 0.95))
 (setq l (cons k4 m))
(princ l)

(setq maximum (nth 0 m))
;(setq n 0)
(dolist (w m)
   (if (< maximum w) (setq maximum w))
;(setq max n)
(princ maximum)

(nth 0 l))
 (terpri)
 (princ " � ����������� ")
 (princ " � ������������ ")
 (princ maximum)
 (princ  ", ��� ��� - " )
(setq num 0)
(terpri)
(dolist (w l)
 (if (= max w) (progn(princ (nth (- 3 num) gipoteses))(terpri)))
 (setq num (+ 1 num))
)

(terpri)
(princ "  ����������� ���� �������")
(terpri)
  (setq num 0) 
  (dolist (w l)
     (if (= 0 w ) (progn 
        (princ (nth (- 3 num) gipoteses))
        (princ "\ -  ����������� ")
        (princ (nth num l))
        (terpri))
      )	
     (setq num (1+ num))
  )	

(loop 
  (setq min 1)
  (dolist (w l)
     (if (and (> min w )(/= 0 w)) (setq min w))
   )
  (if (= min 1)(return)) 
  (setq num 0) 
  (dolist (w l)
     (if (= min w ) (progn 
        (princ (nth (- 3 num) gipoteses))
        (princ "\ -  ����������� ")
        (princ (nth num l))
	(terpri))
     )
     (setq num (1+ num))
  )	
(setq l(subst 0 min l))
)  
)
