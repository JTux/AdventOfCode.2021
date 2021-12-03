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


//-- Task 2
// Life support rating = oxygen generator rating * co2 scrubber rating

// Calculate O2
List<string> validOptions = new(input);
for (int i = 0; i < input[0].Length; i++)
{
    if (validOptions.Count < 2)
        break;

    var digits = validOptions.Select(v => int.Parse(v.ElementAt(i).ToString()));
    var zeroes = digits.Where(d => d == 0);
    var ones = digits.Where(d => d == 1);

    validOptions.RemoveAll(o => o.ElementAt(i) == (zeroes.Count() > ones.Count() ? '1' : '0'));
}

int o2Rating = Convert.ToInt32(validOptions.FirstOrDefault(), 2);


// Calculate CO2
validOptions = new(input);
for (int i = 0; i < input[0].Length; i++)
{
    if (validOptions.Count < 2)
        break;

    var digits = validOptions.Select(v => int.Parse(v.ElementAt(i).ToString()));
    var zeroes = digits.Where(d => d == 0).Count();
    var ones = digits.Where(d => d == 1).Count();

    char digitToRemove = zeroes > ones ? '0' : '1';
    validOptions.RemoveAll(o => o.ElementAt(i) == digitToRemove);
}

int co2Rating = Convert.ToInt32(validOptions.FirstOrDefault(), 2);

Console.WriteLine(o2Rating * co2Rating);