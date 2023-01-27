(defun m()
  (progn
   (setq ins (open "Test.txt" :direction :input))
     (setq n1 (read ins)) ;son
     (setq n2 (read ins)) ;bol head
     (setq n3 (read ins)) ;nastr
     (setq n4 (read ins)) ;mes osm
     (setq n5 (read ins)) ;vred
     (setq n6 (read ins)) ;voln
     (setq n7 (read ins)) ;ves
     (setq n8 (read ins)) ;bol
    (close ins)
   )

  (princ n1)
  (princ n2)
  (princ n3)
  (setq A1 (+ n1 n2))
  (princ A1)
  (setq A2 (+ n3 n4))
  (setq A3 (+ n5 n6))
  (setq A4 (+ n7 n8))

  (setq A5 (+ A1 A2))
  (setq A6 (+ A3 A4))

  (setq A7 (+ A5 A6))
  
  (setq file2 (open "otchet.txt" :direction :output :if-exists :supersede))
  (cond
   ((= A7 0) (setq res "est kyda rasti"))
   ((= A7 7.5) (setq res "super good"))
   ((= A7 -7.5) (setq res "very bad"))
  )
  (cond
   ((and (< A7 4.5) (> A7 0))
    (setq res "nado nachinat rabotat"))
   ((and (> A7 4.5) (< A7 7.5))
    (setq res "good"))
   ((and (< A7 -4.5) (> A7 -7.5))
    (setq res "nado k doctoru"))
  )
  (princ A7)
  (princ res file2)
  (close file2)

)

