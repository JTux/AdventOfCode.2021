//-- Task 1
// Get input from Input.txt (added to .csproj)
string input = new StreamReader("Input.txt").ReadToEnd();

// Split the input string into seperate values and parse them to integers
List<int> depths = input
    .Split('\n')
    .Select(depth => int.Parse(depth))
    .ToList();

// Set the first depth as the first value of the list
int previous = depths[0];

// As the first number hasn't increased, start at 0 iterations
int depthIncreaseCount = 0;

// Skip the first value but check the rest
for (int i = 1; i < depths.Count; i++)
{
    // Get the new depth
    int depth = depths[i];

    // Compare the two depths, if it increases increase the count
    if (depth > previous)
        depthIncreaseCount++;

    // Save current depth as previous for next iteration
    previous = depth;
}

Console.WriteLine(depthIncreaseCount); // 1475


//-- Task 2
Console.WriteLine($"Number of measurements: {depths.Count}"); // 2000
int threeMeasurementCount = depths.Count / 3; // 666

// Set the first set value like before, but by grabbing the first three
int previousSet = depths[0] + depths[1] + depths[2]; // Good enough
int depthSetIncreaseCount = 0;

// Check all sets as long as there are 3 adjacent elements left to check
for (int i = 1; i + 2 < depths.Count; i++)
{
    // Check the current and next two values as a set
    int depthSet = depths[i] + depths[i + 1] + depths[i + 2];

    // Check against previous set
    if (depthSet > previousSet)
        depthSetIncreaseCount++;

    // Save current set as next previous set
    previousSet = depthSet;
}

Console.WriteLine(depthSetIncreaseCount); // 1516