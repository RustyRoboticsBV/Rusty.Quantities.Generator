namespace Generators
{
    /// <summary>
    /// A generator for lists of code sections.
    /// </summary>
    public sealed class SectionList : Generator
    {
        /* Public properties. */
        public Section[] Contents { get; set; }

        /* Constructors. */
        public SectionList(Section[] contents)
        {
            Contents = contents;
        }

        /* Public methods. */
        public static string Generate(Section[] contents)
        {
            return new SectionList(contents).Generate();
        }

        public sealed override string Generate()
        {
            string code = "";
            foreach (Section section in Contents)
            {
                string sectionCode = section.Generate();
                if (sectionCode != "")
                {
                    if (code != "")
                        code += "\n\n";
                    code += section.Generate();
                }
            }
            return code;
        }
    }
}