using Rusty.Quantities.Generator;
using Rusty.CSharpGenerator;

// Axis.
Enum axis = new()
{
    Summary = "Represents an axis of a coordinate system.",
    Name = "Axis",
    Inheritance = "byte",
    Members = new string[] { "X", "Y", "Z" }
};
Namespace axisNamespace = new()
{
    Name = "Rusty.Quantities",
    Members = axis
};
File axisFile = new()
{
    Name = "Axis.cs",
    Members = axisNamespace
};
axisFile.WriteToDisk();

// Time.
Quantity time = new Quantity("Time", "A time quantity.");
Namespace timeNamespace = new()
{
    Name = "Rusty.Quantities",
    Members = time
};
File timeFile = new()
{
    Name = "Time.cs",
    Usings = "System",
    Members = timeNamespace
};
timeFile.WriteToDisk();

// Distance.
Quantity distance = new Quantity("Distance", "A distance quantity.");
Namespace distanceNamespace = new()
{
    Name = "Rusty.Quantities",
    Members = distance
};
File distanceFile = new()
{
    Name = "Distance.cs",
    Usings = "System",
    Members = distanceNamespace
};
distanceFile.WriteToDisk();

// Speed.
Quantity speed = new Quantity("Speed", "A speed quantity.");
Namespace speedNamespace = new()
{
    Name = "Rusty.Quantities",
    Members = speed
};
File speedFile = new()
{
    Name = "Speed.cs",
    Usings = "System",
    Members = speedNamespace
};
speedFile.WriteToDisk();


// Acceleration.
Quantity acceleration = new Quantity("Acceleration", "An acceleration quantity.");
Namespace accelerationNamespace = new()
{
    Name = "Rusty.Quantities",
    Members = acceleration
};
File accelerationFile = new()
{
    Name = "Acceleration.cs",
    Usings = "System",
    Members = accelerationNamespace
};
accelerationFile.WriteToDisk();
