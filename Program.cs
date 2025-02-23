using Rusty.Quantities.Generator;
using Rusty.CSharpGenerator;

//Character character = new();
//System.Console.WriteLine((string)character.CalcJumpStartSpeed(5, -9.81));
//System.Console.WriteLine((double)character.CalcAccelerationDistance(0, 10, 5));

// Interface.
Interface scalar = new()
{
    Summary = "A scalar quantity type, based on the double type.",
    Name = "IScalarQuantity",
    Members = new IInterfaceMember[]
    {
        new Property()
        {
            Summary = $"The internal value of this quantity.",
            Type = "double",
            Name = "Value",
            Setter = null
        }
    }
};
Namespace scalarNamespace = new()
{
    Name = "Rusty.Quantities",
    Members = scalar
};
File scalarFile = new()
{
    Name = "IScalarQuantity.cs",
    Members = scalarNamespace
};
scalarFile.WriteToDisk();

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
Quantity time = new Time();
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
Quantity distance = new Distance();
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
Speed speed = new();
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
Quantity acceleration = new Acceleration();
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
