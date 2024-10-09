namespace Generators
{
    /// <summary>
    /// Represents a parameter of type Axis.
    /// </summary>
    public class AxisParameter : Variable
    {
        /* Public properties. */
        public new AxisType Type => base.Type as AxisType;

        /* Constructors. */
        public AxisParameter(string name) : base(new AxisType(), name) { }
    }
}
