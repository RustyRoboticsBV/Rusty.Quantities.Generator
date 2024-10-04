namespace Generators
{
    /// <summary>
    /// An area of generators, where the resulting code places the result of each generator on a new line.
    /// </summary>
    public class Area<T> : Generator
        where T : Generator
    {
        /* Public properties. */
        public string StructName { get; set; }
        public List<T> Members { get; set; } = new();
        public List<bool> Spaces { get; set; } = new();

        /* Constructors. */
        public Area(string structName)
        {
            StructName = structName;
        }

        /* Public methods. */
        public void Add(T member)
        {
            Members.Add(member);
            Spaces.Add(false);
        }

        public void Remove(T member)
        {
            int index = Members.IndexOf(member);
            Members.RemoveAt(index);
            Spaces.RemoveAt(index);
        }

        public void Space()
        {
            Spaces[^1] = true;
        }

        public sealed override string Generate()
        {
            string code = "";
            for (int i = 0; i < Members.Count; i++)
            {
                T member = Members[i];
                bool space = Spaces[i];

                if (code != "")
                    code += "\n";

                code += Generate(member);

                if (space)
                    code += "\n";
            }

            return code;
        }

        /* Protected methods. */
        protected virtual string Generate(T member)
        {
            return member.Generate();
        }
    }
}