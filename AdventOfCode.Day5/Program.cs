// Get input
List<string> input = new StreamReader("Input.txt").ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToList();


//-- Task 1
// Split the line with " -> " => [xy, xy]
var coords = input.Select(line => line.Split(" -> "));

// Splits the coords and filters and lines that are not horizontal/vertical
// set => 2 pair => 2 coords string[][][]
// At this point I'm just having fun
var sets = coords.Select(pair =>
        pair.Select(coord =>
            coord.Split(",")
        ).ToArray()
    ).ToArray()
    .Where(set =>
        set[0][0] == set[1][0] ||
        set[0][1] == set[1][1]
    ).ToArray();

var coordPairOverlaps = new Dictionary<string, int>();

foreach (var set in sets)
{
    // Check for x coord equality
    bool isVertical = set[0][0] == set[1][0];

    // If the x coords are equal, then it's a vertical line
    int index = isVertical ? 1 : 0;

    // Get Min/Max coordinate values
    var coord0 = int.Parse(set[0][index]);
    var coord1 = int.Parse(set[1][index]);

    // Get direction between coordinates
    bool flows0to1 = coord0 < coord1;

    for (int i = flows0to1 ? coord0 : coord1; i <= (flows0to1 ? coord1 : coord0); i++)
    {
       string key = isVertical ? $"{set[0][0]},{i}" : $"{i},{set[0][1]}";
        if (coordPairOverlaps.ContainsKey(key))
        {
            coordPairOverlaps[key]++;
        }
        else
        {
            coordPairOverlaps.Add(key, 1);
        }
    }
}

int totalStraightOverlaps = coordPairOverlaps.Count(kvp => kvp.Value > 1);
Console.WriteLine($"Task 1: {totalStraightOverlaps}");