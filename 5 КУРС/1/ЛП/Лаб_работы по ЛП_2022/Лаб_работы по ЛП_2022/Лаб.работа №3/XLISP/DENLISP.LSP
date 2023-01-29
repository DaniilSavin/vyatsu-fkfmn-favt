;Ñïèñîê êîıôôèöèåíòîâ
;E1 - Ó æèâîòíîãî åñòü íîãè ?
;E2 - Ó æèâîòíîãî åñòü ïëàâíèêè ?
;E3 - Ó æèâîòíîãî åñòü ğîãà ?
;E4 - Ó æèâîòíîãî åñòü êğûëüÿ ?
;E5 - ßâëÿåòñÿ ëè æèâîòíîå õèùíèêîì ?
;E6 - Æèâîòíîå òåïëîêğîâíîå ?
;E7 - Ñğåäà îáèòàíèÿ çåìëÿ ?
;E8 - Ñğåäà îáèòàíèÿ âîäà ?
;                   ÌÀÒĞÈÖÀ      ÇÍÀ×ÅÍÈÉ
;		E1   E2   E3   E4   E5   E6   E7   E8
;ËÎÑÜ		1    0    1    0    0    1    1    0 
;ÃÅÏÀĞÄ		1    0    0    0    1    1    1    0
;ÎĞÅË		1    0    0    1    1    1    0    0
;ÂÎĞÎÁÅÉ	1    0    0    1    0    1    0    0
;ÙÓÊÀ		0    1    0    0    1    0    0    1
;ÊÀĞÀÑÜ		0    1    0    0    0    0    0    1
;ÇÌÅß		0    0    0    0    1    0    1    1
;ÊĞÎÊÎÄÈË	1    0    0    0    1    0    1    1







(defun main ()
  (cls)
  (koef)
  (calc)
  (princ "\n")
  (out_result)
)

(defun koef ()
  (princ "Ââîä êîıôôèöèåíòîâ: \n")
  (princ "E1: Ó æèâîòíîãî åñòü íîãè ?  ")
  (setq E1 (read))
  (princ "E2: Ó æèâîòíîãî åñòü ïëàâíèêè ?  ")
  (setq E2 (read))
  (princ "E3: Ó æèâîòíîãî åñòü ğîãà ?  ")
  (setq E3 (read))
  (princ "E4: Ó æèâîòíîãî åñòü êğûëüÿ ?  ")
   (setq E4 (read))
  (princ "E5: ßâëÿåòñÿ ëè æèâîòíîå õèùíèêîì ?  ")
  (setq E5 (read))
  (princ "E6: Æèâîòíîå òåïëîêğîâíîå ?  ")
  (setq E6 (read))
  (princ "E7: Ñğåäà îáèòàíèÿ çåìëÿ ?  ")
  (setq E7 (read))
  (princ "E8: Ñğåäà îáèòàíèÿ âîäà ?  ")
  (setq E8 (read))
)


(defun calc ()
  (setq ne8 (- 0 E8))
  (setq C1 (ct E6 ne8))
  (setq C2 (ct E7 E8)) 
  (setq C3 (ct E1 E5))
  (setq ne5 (- 0 E5))
  (setq C4 (ct E4 ne5))
  (setq C5 (ct E1 E4)) 
  (setq ne2 (- 0 E2))
  (setq C6 (ct E3 ne2))
  (setq C7 (ct E7 E1)) 
  (setq ne1 (- 0 E1))
  (setq ne6 (- 0 E6))
  (setq C8 (ct C2 ne1))
  (setq C9 (ct E2 ne5))
  (setq ne3 (- 0 E3))
  (setq ne8 (- 0 E8))
  
  (setq a1 (* (min E7 E8) 0.9))
  (setq na1 (- 0 a1))
  (setq nc1 (- 0 C1))
  (setq nc4 (- 0 C4))
  (setq nc5 (- 0 C5))
  (setq nc6 (- 0 C6))
  (setq nc7 (- 0 C7))
  (setq nc8 (- 0 C8))
  (setq nc9 (- 0 C9))
  (setq a2 (* (min E7 ne8) 0.9))
  (setq CTotal1 (imp7 nc1 C2 C3 nc4 nc9 E1 ne6))
  (setq CTotal2 (imp2 C1 C6 C7 E3))
  (setq CTotal3 (imp1 nc1 nc4 nc5 nc6 nc7))
  (setq CTotal4 (imp3 C1 C4 E4 C5 nc8))
  (setq CTotal5 (imp8 nc1 C2 nc4 C8 nc9 ne1))
  (setq CTotal6 (imp6 a2 C1 C3 nc4 C7 nc9 ne3 E6))
  (setq CTotal7 (imp4 na1 C1 C3 C5 nc8 nc9 ne3 E4))
  (setq CTotal8 (imp5 nc1 C9 nc5 nc7 nc6 ne5))
)

(defun out_result ()
 (setq aaa 8) 
 (loop 
  (setq out (mini CTotal1 CTotal2 CTotal3 CTotal4 CTotal5 CTotal6 CTotal7 CTotal8))
  (if (= out CTotal1) (princ "Êğîêîäèë: "))
  (if (= out CTotal1) (princ CTotal1))
  (if (= out CTotal1) (princ "\n"))
  (if (= out CTotal1) (setq CTotal1 2))

  (if (= out CTotal2) (princ "Ëîñü:     "))
  (if (= out CTotal2) (princ CTotal2))
  (if (= out CTotal2) (princ "\n"))
  (if (= out CTotal2) (setq CTotal2 2))

  (if (= out CTotal3) (princ "Ùóêà:     "))
  (if (= out CTotal3) (princ CTotal3))
  (if (= out CTotal3) (princ "\n"))
  (if (= out CTotal3) (setq CTotal3 2))
  
  (if (= out CTotal4) (princ "Âîğîáåé:  "))
  (if (= out CTotal4) (princ CTotal4))
  (if (= out CTotal4) (princ "\n"))
  (if (= out CTotal4) (setq CTotal4 2))

  (if (= out CTotal5) (princ "Çìåÿ:     "))
  (if (= out CTotal5) (princ CTotal5))
  (if (= out CTotal5) (princ "\n"))
  (if (= out CTotal5) (setq CTotal5 2))

  (if (= out CTotal6) (princ "Ãåïàğä:   "))
  (if (= out CTotal6) (princ CTotal6))
  (if (= out CTotal6) (princ "\n"))
  (if (= out CTotal6) (setq CTotal6 2))

  (if (= out CTotal7) (princ "Îğåë:     "))
  (if (= out CTotal7) (princ CTotal7))
  (if (= out CTotal7) (princ "\n"))
  (if (= out CTotal7) (setq CTotal7 2))
  
  (if (= out CTotal8) (princ "Êàğàñü:   "))
  (if (= out CTotal8) (princ CTotal8))
  (if (= out CTotal8) (princ "\n"))
  (if (= out CTotal8) (setq CTotal8 2))

 (setq aaa (- aaa 1))
 (if (= aaa 0) (return))
 )
)

(defun mini (x1 x2 x3 x4 x5 x6 x7 x8)
 (min x1 x2 x3 x4 x5 x6 x7 x8) 
)


(defun imp2 (x1 x2 x3 x4)
 (* (min x1 x2 x3 x4) 0.9) 
)

(defun imp1 (x1 x2 x3 x4 x5)
 (* (min x1 x2 x3 x4 x5) 0.95) 
)

(defun imp3 (x1 x2 x3 x4 x5)
 (* (min x1 x2 x3 x4 x5) 0.92) 
)

(defun imp4 (x1 x2 x3 x4 x5 x6 x7 x8)
 (* (min x1 x2 x3 x4 x5 x6 x7 x8) 0.84) 
)

(defun imp5 (x1 x2 x3 x4 x5 x6)
 (* (min x1 x2 x3 x4 x5 x6) 0.75) 
)

(defun imp6 (x1 x2 x3 x4 x5 x6 x7 x8)
 (* (min x1 x2 x3 x4 x5 x6 x7 x8) 0.8) 
)

(defun imp7 (x1 x2 x3 x4 x5 x6 x7)
 (* (min x1 x2 x3 x4 x5 x6 x7) 0.94) 
)

(defun imp8 (x1 x2 x3 x4 x5 x6)
 (* (min x1 x2 x3 x4 x5 x6) 0.86) 
)

(defun ct (ct1 ct2)
   (if (and (> ct1 0) (> ct2 0))
     (- (+ ct1 ct2) (* ct1 ct2))
    (if (and (< ct1 0) (< ct2 0)) (+ (+ ct1 ct2) (* ct1 ct2))
     (/ (+ ct1 ct2) (- 1 (min (abs ct1) (abs ct2)))))
)
)




