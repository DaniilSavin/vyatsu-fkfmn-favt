domains
imya=symbol

predicates
nondeterm roditel(imya,imya).
nondeterm ded(imya,imya).

clauses
roditel(maria,fedor).
roditel(ivan,fedor).
roditel(ivan,stepan).
roditel(fedor,olga).
roditel(fedor,tatiana).
ded(ivan,olga).
ded(ivan,tatiana).

goal
roditel(X,tatiana).