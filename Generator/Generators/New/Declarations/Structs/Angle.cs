namespace Generators
{
    /// <summary>
    /// A angle quantity struct generator.
    /// </summary>
    public sealed class Angle : ScalarQuantityStruct
    {
        /* Constructors. */
        public Angle() : base(Quantities.Angle, "Represents an angle quantity.")
        {
            AddMethodPair(new ToDegreesMethod(Quantities.Angle));
            AddMethodPair(new ToRadiansMethod(Quantities.Angle));

            // Rotation methods.
            InstanceMethods.Add(new Method("public", "readonly", Numerics.Quaternion, "GetRotation", new AxisParameter("axis"),
                  "float euler = (float)value;"
                + "\nswitch (axis)"
                + "\n{"
                + Indent("\ncase Axis.X:")
                + Indent("\nreturn Quaternion.FromEuler(new Vector3(0f, euler, 0f));", 2)
                + Indent("\ncase Axis.Y:")
                + Indent("\nreturn Quaternion.FromEuler(new Vector3(euler, 0f, 0f));", 2)
                + Indent("\ncase Axis.Z:")
                + Indent("\nreturn Quaternion.FromEuler(new Vector3(0f, 0f, euler));", 2)
                + Indent("\ndefault:")
                + Indent("\nreturn Quaternion.Identity;", 2)
                + "\n}",
                new("Interpret this angle as a value in radians, and return a quaternion representing the rotation by "
                + "this amount around the specified axis.")
            ));
            InstanceMethods.Add(new Method("public", "readonly", Numerics.Quaternion, "GetRotationDegrees", new AxisParameter("axis"),
                "return ToRadians().GetRotation(axis);",
                new("Interpret this angle as a value in degrees, and return a quaternion representing the rotation by "
                + "this amount around the specified axis.")
            ));

            StaticMethods.Add(new Method("public", "static", Numerics.Quaternion, "GetRotation", new(new ScalarQuantityParameter(Quantities.Angle, "value"), new AxisParameter("axis")),
                "return value.GetRotation(axis);",
                new("Interpret an angle as a value in radians, and return a quaternion representing the rotation by "
                + "this amount around the specified axis.")
            ));
            StaticMethods.Add(new Method("public", "static", Numerics.Quaternion, "GetRotationDegrees", new(new ScalarQuantityParameter(Quantities.Angle, "value"), new AxisParameter("axis")),
                "return value.GetRotationDegrees(axis);",
                new("Interpret an angle as a value in degrees, and return a quaternion representing the rotation by "
                + "this amount around the specified axis.")
            ));
        }
    }
}