//-- Task 1
// Get input from Input.txt (added to .csproj)
string input = new StreamReader("Input.txt").ReadToEnd();

var commands = input.Split('\n')
    .Select(c => c.Split(' '))
    .Select(c => new { Direction = c[0], Value = int.Parse(c[1]) })
    .ToList();

int horizontal = 0, vertical = 0;
foreach (var command in commands)
{
    switch (command.Direction)
    {
        case "forward":
            horizontal += command.Value;
            break;
        case "down":
            vertical += command.Value;
            break;
        case "up":
            vertical -= command.Value;
            break;
    }
}

Console.WriteLine(horizontal + " + " + vertical + " = " + horizontal * vertical);

//-- Task 2 - Might refactor later to be not so tall
int aim = 0;

horizontal = 0;
vertical = 0;
foreach(var command in commands)
{
    switch (command.Direction)
    {
        case "forward":
            horizontal += command.Value;
            vertical += aim * command.Value;
            break;
        case "down":
            aim += command.Value;
            break;
        case "up":
            aim -= command.Value;
            break;
    }
}

Console.WriteLine(horizontal + " + " + vertical + " = " + horizontal * vertical);