// See https://aka.ms/new-console-template for more information
using ClassLibrary2;

void BorderBTest()
{
    Expression expression = new Expression(1, 0, 3);
    var йцуйцу = Math.Floor(expression.Calc());
    return;
    double bMin = -2, a = 1, x = 3;
    double step = 1;
    double[] expected = new double[] { -2, 0, double.NaN, 4, 5 };
    //Arange
    List<double> result = new List<double>(); ;

    //Act
    while (result.Count < expected.Length)
    {
        result.Add((int)(new Expression(a, bMin, x)).Calc());
        bMin += step;
    }
    var actual = result.ToArray();

    for (int i = 0; i < actual.Length; i++)
    {
        Console.WriteLine(actual[i] + " " + expected[i]);
    }
    //Assert
}

List<int> result = new List<int>(); ;
BorderBTest();
////Act
//double bMin = 0.01;
//while (result.Count < 5)
//{
//    result.Add((int)(new Expression(1, bMin, 1)).Calc());
//    bMin += 1;
//}
//var actual = result.ToArray();
//foreach (var item in actual)
//{
//    Console.WriteLine(item);
//}

Console.ReadKey();