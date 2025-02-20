namespace Rusty.Quantities.Generator
{
    /// <summary>
    /// A set of equations representing a all variants of a physics formula.
    /// </summary>
    public class Formula
    {
        /* Public properties. */
        public Equation[] Variants { get; set; }

        /* Constructors. */
        public Formula(params Equation[] equations)
        {
            Variants = equations;
        }

        public Formula(params string[] equations)
        {
            Variants = new Equation[equations.Length];
            for (int i = 0; i < equations.Length; i++)
            {
                Variants[i] = new(equations[i]);
            }
        }

        /* Indexers. */
        public Equation this[char result]
        {
            get
            {
                foreach (Equation variant in Variants)
                {
                    if (variant.Result.Symbol == result)
                        return variant;
                }
                return null;
            }
        }
    }
}