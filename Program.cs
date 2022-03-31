// See https://aka.ms/new-console-template for more information

using subcadenmaslarga;

ResultModel result = new ResultModel("", 0);
ResultModel resultAux = new ResultModel("", 1);

#region input

string[] lines = File.ReadAllLines("./assets/input.txt");
if (lines.Length == 0) return;
Service service = new Service(lines);
string[,] array = service.GetArray();

if (array.Length == 0) Console.WriteLine("Invalid array");

#endregion


#region vertical and horizontal process

for (int i = 0; i < lines.Length; i++)
{
    resultAux = new ResultModel("", 1);
    service.FindHorizontalOrVertical(array, i, true, resultAux, result);
}

for (int i = 0; i < lines.Length; i++)
{
    resultAux = new ResultModel("", 1);
    service.FindHorizontalOrVertical(array, i, false, resultAux, result);
}


resultAux = new ResultModel("", 1);
service.FindDiagonal(array, resultAux, result);

#endregion

Console.WriteLine($"Resultado es: {string.Join(",", Enumerable.Repeat(result.character, result.count))}");
Console.ReadLine();




