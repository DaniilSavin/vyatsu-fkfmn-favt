domains
imya=symbol

predicates
nondeterm roditel(imya,imya).
nondeterm praroditel(imya,imya).
nondeterm ded(imya,imya).

clauses
roditel(maria,fedor).
roditel(ivan,fedor).
roditel(ivan,stepan).
roditel(fedor,olga).
roditel(fedor,tatiana).
praroditel(maria,olga).
praroditel(maria,tatiana).
ded(ivan,olga).
ded(ivan,tatiana).

goal
praroditel(X,olga).