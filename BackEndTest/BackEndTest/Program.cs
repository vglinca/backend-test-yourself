using System.Text.Json;
using BackEndTest.Extensions;

var list = new List<int>(){1,2,3,4,5,6,7,8,9};
var vectors = new List<Vector2d>() {new(0, 3), new(-6, 9), new(4, 20), new(12, 28)};

var listStr = list.Map(x => x.ToString());
var listSq = list.Map(x => x * x);
var vectorsLengths =
    vectors.Map(x => $"|({x.X}, {x.Y})| = {Math.Round(Math.Sqrt(Math.Pow(x.X, 2) + Math.Pow(x.Y, 2)), 2)}");

Console.WriteLine(JsonSerializer.Serialize(listStr));
Console.WriteLine(JsonSerializer.Serialize(listSq));
Console.WriteLine(JsonSerializer.Serialize(vectorsLengths));

var sum = list.Fold(0, (a, b) => a + b);
var str = list.Fold(string.Empty, (a, b) => $"{a}{b}");
var str1 = list.Fold("The numbers are: ", (a, b) => $"{a}{b}");

Console.WriteLine(JsonSerializer.Serialize(sum));
Console.WriteLine(JsonSerializer.Serialize(str));
Console.WriteLine(JsonSerializer.Serialize(str1));

var listSqrt = list.Map2(x => $"Sqrt({x}) = {Math.Round(Math.Sqrt(x), 5)}");
var vectorsLengths1 =
    vectors.Map2(x => $"|({x.X}, {x.Y})| = {Math.Round(Math.Sqrt(Math.Pow(x.X, 2) + Math.Pow(x.Y, 2)), 2)}");
Console.WriteLine(JsonSerializer.Serialize(listSqrt));
Console.WriteLine(JsonSerializer.Serialize(vectorsLengths1));

public record Vector2d(double X, double Y);