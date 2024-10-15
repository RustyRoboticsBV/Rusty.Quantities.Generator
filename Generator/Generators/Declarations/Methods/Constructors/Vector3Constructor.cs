namespace Generators
{
    public class Vector3Constructor : Constructor
    {
        /* Constructors. */
        public Vector3Constructor(string name, ScalarParameter x, ScalarParameter y, ScalarParameter z) : base(name, new(x, y, z), "") { }
        public Vector3Constructor(string name, VectorParameter vectorParameter) : base(name, vectorParameter, "") { }

        /* Protected methods. */
        protected override string IdContents()
        {
            Implementation = GetImpl();
            return base.IdContents();
        }

        /* Private methods. */
        private string GetImpl()
        {
            string code = "this.x = __X;\nthis.y = __Y;\nthis.z = __Z;";
            if (Parameters.Count == 1 && Parameters[0] is ScalarParameter scalarParam)
            {
                code = code.Replace("__X", scalarParam.CastTo(Numerics.Core));
                code = code.Replace("__Y", scalarParam.CastTo(Numerics.Core));
                code = code.Replace("__Z", scalarParam.CastTo(Numerics.Core));
                code = code.Replace("this.", "");
            }
            else if (Parameters.Count == 3 && Parameters[0] is ScalarParameter x
                 && Parameters[1] is ScalarParameter y && Parameters[2] is ScalarParameter z)
            {
                code = code.Replace("__X", x.CastTo(Numerics.Core));
                code = code.Replace("__Y", y.CastTo(Numerics.Core));
                code = code.Replace("__Z", z.CastTo(Numerics.Core));
            }
            else if (Parameters.Count == 1 && Parameters[0] is VectorParameter vectorParam)
            {
                code = code.Replace("__X", vectorParam.CastXTo(Numerics.Core));
                code = code.Replace("__Y", vectorParam.CastYTo(Numerics.Core));
                if (vectorParam.Type.Size >= 3)
                    code = code.Replace("__Z", vectorParam.CastZTo(Numerics.Core));
                else
                    code = code.Replace("__Z", vectorParam.Type.ScalarType.CastTo("0", Numerics.Core, ""));
                code = code.Replace("this.", "");
            }
            return code;
        }
    }
}