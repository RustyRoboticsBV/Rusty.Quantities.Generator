namespace Rusty.Quantities.Generator
{
    public static class Formulas
    {
        public static Formula TSV = new Formula("V=s/t", "t=s/V", "s=V*t");
        public static Formula TSUV = new Formula("s=1/2*(v+u)*t", "v=2*s/t-u", "u=2*s/t-v", "t=2*s/(v+u)");
        public static Formula TUVA = new Formula("v=u+a*t", "u=v-a*t", "a=(v-u)/t", "t=(v-u)/a");
        public static Formula SUVA = new Formula("v=SQRT(POW2(u)+2*a*s)", "u=SQRT(POW2(v)-2*a*s)", "a=(POW2(v)-POW2(u))/(2*s)", "s=(POW2(v)-POW2(u))/(2*a)");
        public static Formula TSUA = new Formula("s=u*t+1/2*a*POW2(t)", "u=s/t-1/2*a*t", "a=2*s/POW2(t)-2*u/t", "t=(SQRT(2*a*s+POW2(u))-u)/a");
        public static Formula TSVA = new Formula("s=v*t-1/2*a*POW2(t)", "v=s/t+1/2*a*t", "a=UMIN2*(s-v*t)/POW2(t)", "t=(v-SQRT(POW2(v)-2*a*s))/a");

        public static Formula[] All = { TSV, TSUV, TUVA, SUVA, TSUA, TSVA };
    }
}