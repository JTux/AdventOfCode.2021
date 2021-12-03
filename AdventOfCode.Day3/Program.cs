//-- Task 1
string[] input = new StreamReader("Input.txt").ReadToEnd().Split("\r\n");

// Calculate Gamma
string gammaBase2 = string.Empty;
for (int i = 0; i < input[0].Length; i++)
{
    var slotAverage = input.Select(v => int.Parse(v.ElementAt(i).ToString())).Average();
    gammaBase2 += slotAverage > .5 ? 1 : 0;
}

int gammaBase10 = Convert.ToInt32(gammaBase2, 2);

// Calculate Epsilon
string epsilonBase2 = string.Empty;
for (int i = 0; i < input[0].Length; i++)
{
    var slotAverage = input.Select(v => int.Parse(v.ElementAt(i).ToString())).Average();
    epsilonBase2 += slotAverage > .5 ? 0 : 1;
}

int epsilonBase10 = Convert.ToInt32(epsilonBase2, 2);

// Power Consumption
Console.WriteLine(gammaBase10 * epsilonBase10);