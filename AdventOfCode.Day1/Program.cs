
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

Console.WriteLine(depthIncreaseCount);