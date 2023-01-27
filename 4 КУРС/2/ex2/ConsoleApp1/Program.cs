// See https://aka.ms/new-console-template for more information
using ExpressionNamespace;



Expression expression = new Expression(0, 4, 0.01, 0.01,5,1);

var result = expression.CalcInterval().ToList().ConvertAll(x => (int)Math.Floor(x)).ToArray();
foreach (var item in result)
{
    Console.WriteLine(item);
}
