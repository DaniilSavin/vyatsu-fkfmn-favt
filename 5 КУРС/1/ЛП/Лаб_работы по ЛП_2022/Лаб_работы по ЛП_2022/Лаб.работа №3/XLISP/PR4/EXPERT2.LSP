;;;******************************************************
;;;   EE 4524 Artificial Intelligence
;;;   Project 4. A knowledge-based system for medical diagnosis
;;;   Programmed by Brian Bond and Oleg Rykov
;;;
;;;   Description : It is an interactive knowledge-based system
;;;   that accepts a list of symptoms, suggests possible disease
;;;   and asks for further symptoms to improve the diadnosis.
;;;
;;;******************************************************

;;;**********************
;;;   Data base for diagnosis
;;;**********************

(setf symptom_list
  '( (1 pertsistent cough)
     (2 fever)
     (3 dilated pupils)
     (4 disoriented/dizziness)
     (5 oozing flesh wound)
     (6 headache)
     (7 diareahha)
     (8 vomiting)
     (9 stomach cramps)
     (10 body aches)
     (11 positive viral throat culture)
     (12 skin rash)
     (13 HIV positive test results)
     (14 lack of energy)
     (15 mucal sputum when coughing)
     (16 open sores)
     (17 weight gain)
     (18 weight loss)
     (19 chest pains)
     (20 unconcious)
     (21 patient flailing uncontrollably)
     (22 skin discoloration)
     (23 erratic pulse)
     (24 no pulse)
     (25 irritability)
     (26 pain in gluteous maximus)
     (27 redness in ears)
     (28 hair loss)
     (29 high blood pressure)
     (30 low blood pressure)
   )
)


(setf disease_list
 '( (1 cold ((1 0.4 0) (2 0.3 0.5) (6 0.3 0)))
    (2 flu ((1 0.3 0) (2 0.3 0.5) (6 0.3 0) (7 0.2 0) (15 0.2 0)))
    (3 strep ((1 0.4 0) (2 0.4 0.2) (6 0.2 0) (10 0.1 0) (11 0.9 0.9)))
    (4 AIDS  ((1 0.1 0) (2 0.1 0) (7 0.1 0) (12 0.1 0) (13 0.9 0.8) (18 0.1 0.2)))
    (5 pneumonia ((1 0.4 0) (2 0.5 0.2) (10 0.1 0)))
    (6 pregnant  ((6 0.1 0) (8 0.5 0) (9 0.4 0) (10 0.2 0.2) (17 0.2 0.7)))
    (7 hypochondriac (()))
    (8 vitamin_deficiency ((4 0.1 0) (9 0.1 0)))
    (9 stroke ((4 0.7 0.8) (20 0.4 0) (21 0.3 0) (29 0.6 0.4)))
    (10 heart_attack ((19 0.9 3) (20 0.2 0) (21 0.3 0) (23 0.7 0.5)))
    (11 epileptic ((21 0.8 0)))
    (12 drunk ((3 0.3 0.4) (4 0.2 0.2) (8 0.1 0) (20 0.3 0) (21 0.1 0)))
    (13 hemorrhiods ((25 0.9 0.9) (26 0.6 0.4)))
    (14 constipated ((26 0.6 0.3)))
    (15 dead ((24 0.9 0.9)))
    (16 concussion ((6 0.6 0.9) (20 0.6 0.0)))
    (17 poison_ivy ((12 0.4 0.9)))
    (18 scurvy ((12 0.5 0.7) (2 0.5 0.4) (22 0.3 0.2) (7 0.2 0.2) (9 0.2 0.1)))
  )
)


;;*****************************************
;;;  CONFIDENCE - for an input list of symptoms defines
;;;  confidence of disease. If disease has a symptom from
;;;  input symptom's list it returns list of :
;;;  first element confidence, name of disease and left
;;;  unchecked symptoms.
;;;  PARAMETERS :
;;;      disease - current disease
;;;      input_symptoms - list of observed symptoms
;;;*****************************************
(defun confidence (disease input_symptoms)
   (let
    ((conf 0.0)
     (MB 0.0)
     (MD 0.0)
     (flag Nil)
     (new_elem Nil)
    )
    (dolist (elem_disease (caddr disease) conf)
       (setf flag Nil)
       (dolist (elem_symptom input_symptoms)
         (cond
          ;; measure of disbelief
          ((and (equal (car elem_disease) (car elem_symptom))
                (Null (cadr elem_symptom)))
            (setf MD (+ MD (* (caddr elem_disease) (- 1 MD))))
            (setf flag 'Ill)
          )
          ;; measure of belief
          ((and (equal (car elem_disease) (car elem_symptom))
                (Not (Null (cadr elem_symptom))))
            (setf MB (+ MB (* (cadr elem_disease) (- 1 MB))))
            (setf flag 'Ill)
          )
         )
       )
       (if (Null flag)
          (setf new_elem (append new_elem (list elem_disease)))
       )
       (setf conf (- MB MD))
    )
    ;; exclude all disease with negative confidence
    (if (< conf 0)
       nil
       (setf new_elem (append
                       (list conf)
                       (list (car disease))
                       (list (cadr disease))
                       (list new_elem)
                    )
       )
    )
   )
)


;;;*****************************************
;;;  CREATE_NEW_LIST - for all diseases in the disease's list
;;;  calculates confidence and deletes from list all diseases with
;;;  negative confidence
;;;  PARAMETERS :
;;;      disease_list - list of diseases
;;;      input_symptoms - list of observed symptoms
;;;  returns a list of lists : first item in each element is a confidence
;;;  and last part - diseases with nonnegative confidence
;;;*****************************************
(defun create_new_list (disease_list input_symptoms)
  (let
    ((new_one nil)
     (prom nil)
     (conf_list nil)
    )
    (dolist  (elem disease_list new_one)
       (setf prom (confidence elem input_symptoms))
       (if (Not (Null prom))
           (setf new_one (append new_one (List prom)))
       )
    )
  )
)

;;;*****************************************
;;;  POSSIBLE - finds two diseases with maximum confidence from
;;;  the list of diseases.
;;;  PARAMETERS :
;;;      disease_list - list of diseases
;;;      input_symptoms - list of observed symptoms
;;;  returns information about two possible diseases in th such form :
;;;  ((confidence disease_info) (confidence disease_info))
;;;*****************************************
(defun possible (disease_list input_symptoms)
   (let
      ( (operation_list (create_new_list disease_list input_symptoms))
        (result nil)
      )
      (setf result (car operation_list))
      (dolist (elem operation_list)
        (if (> (car elem) (car result))
            (setf result elem)
        )
      )
      (if (equal result (car operation_list))
          (setf result (list result  (cadr operation_list)))
          (setf result (list result  (car operation_list)))
      )
      (dolist (elem operation_list)
        (if (and (> (car elem) (caadr result)) (Not (equal elem (car result))))
            (setf result (list (car result) elem))
        )
      )
      result
   )
)

;;;*****************************************
;;;  BEST_SYMPTOM - in the list of symptoms
;;;  ((a1 b1 c1) (a2 b2 c2)...(an bn cn)) finds more valuable
;;;  symptom - list with maximum value bi+ci and returns it
;;;  PARAMETERS :
;;;     symptoms - list of symptoms
;;;  returns : symptom's number
;;;*****************************************
(defun best_symptom (symptoms)
  (let
    ((maxim (+ (cadar symptoms) (caddar symptoms)))
     (result (caar symptoms))
    )
    (dolist  (elem symptoms)
        (cond
            ((< maxim (+ (cadr elem) (caddr elem)))
             (setf maxim (+ (cadr elem) (caddr elem)))
             (setf result (car elem))
            )
        )
    )
    result
  )
)

;;*****************************************
;; Main function EXPERT
;;*****************************************
(defun expert  ()
  (let
    ( (two_possible nil)
      (first nil)
      (second nil)
    )
    (prin1 'Symptoms_)
    (do
       (   ; bindings
        (input_symptoms (read) (append input_symptoms (read)))
       )
          ; test expression for terminate work
       ((equal (last input_symptoms) '(exit) ) )
       ; body of loop
       (setf two_possible (possible disease_list input_symptoms))
       (setf first (car two_possible))
       (setf second (cadr two_possible))
       (prin1 'first_alternative)  (goto-xy 19 (cadr (goto-xy)))
       (prin1 'disease)   (goto-xy 28 (cadr (goto-xy)))
       (prin1 (cadr first)) (goto-xy 32 (cadr (goto-xy)))
       (prin1 (caddr first)) (goto-xy 52 (cadr (goto-xy)))
       (prin1 'confidence) (goto-xy 63 (cadr (goto-xy)))
       (print (car first))
       (prin1 'second_alternative)  (goto-xy 19 (cadr (goto-xy)))
       (prin1 'disease)   (goto-xy 28 (cadr (goto-xy)))
       (prin1 (cadr second)) (goto-xy 32 (cadr (goto-xy)))
       (prin1 (caddr second)) (goto-xy 52 (cadr (goto-xy)))
       (prin1 'confidence) (goto-xy 63 (cadr (goto-xy)))
       (print (car second))
       (cond
          ((or (Not (Null (cadddr first))) (Not (Null (cadddr second))))
           (prin1 'check)  (goto-xy 6 (cadr (goto-xy)))
           (prin1 'for)   (goto-xy 10 (cadr (goto-xy)))
           (prin1 'symptom)  (goto-xy 18 (cadr (goto-xy)))
           (print (nth (1- (best_symptom (append
                                           (cadddr first)
                                           (cadddr second)
                                          )
                           )
                       )
                       symptom_list)
           )
          )
          (t
            (prin1 'Possinble) (goto-xy 11 (cadr (goto-xy)))
            (prin1 'disease) (goto-xy 20 (cadr (goto-xy)))
            (prin1 (caddr first)) (goto-xy 40 (cadr (goto-xy)))
            (prin1 'confidence) (goto-xy 51 (cadr (goto-xy)))
            (print (car first))
            (print 'Next_patient)
            (setf input_symptoms nil)
          )
       )
       (prin1 'Symptoms_)
    )
  )
)
                                                                                                                                                                                                     
