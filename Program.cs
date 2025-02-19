﻿using System;
using Rusty.Quantities.Generator;
using CSharpGenerator;

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
Console.WriteLine(speedFile.Generate());
