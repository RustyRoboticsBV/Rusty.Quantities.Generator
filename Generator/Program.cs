using Generators;

// Define parameters.
FormulaParameter time = new FormulaParameter('t', "Time", "time");
FormulaParameter distance = new FormulaParameter('s', "Distance", "distance");
FormulaParameter constantSpeed = new FormulaParameter('V', "Speed", "constantSpeed");
FormulaParameter startSpeed = new FormulaParameter('u', "Speed", "startSpeed");
FormulaParameter endSpeed = new FormulaParameter('v', "Speed", "endSpeed");
FormulaParameter acceleration = new FormulaParameter('a', "Acceleration", "acceleration");

// Define formula sets.
FormulaSet tsv = new FormulaSet("V=s/t", "t=s/V", "s=V*t", constantSpeed, distance, time);
FormulaSet tsuw = new FormulaSet("s=1/2*(v-u)*t", "t=2*s/(v-u)", "v=u+2*s/t", "u=v-2*s/t", startSpeed, endSpeed, distance, time);
FormulaSet tuwa = new FormulaSet("v=u*t+1/2*a*POW2(t)", "u=v/t-1/2*a*t", "a=2*(v-t*u)/POW2(t)", "t=(SQRT(2*a*v+POW2(u))-u)/a", startSpeed, endSpeed, acceleration, time);
FormulaSet suwa = new FormulaSet("v=SQRT(POW2(u)+2*a*s)", "u=SQRT(POW2(v)-2*a*s)", "a=(POW2(v)-POW2(u))/(2*s)", "s=(POW2(v)-POW2(u))/(2*a)", startSpeed, endSpeed, acceleration, distance);
FormulaSet tsua = new FormulaSet("s=u*t+1/2*a*POW2(t)", "a=2*(s+u*t)/POW2(t)", "u=s/t-1/2*a*t", "t=(SQRT(2*a*s+POW2(u))-u)/a", startSpeed, acceleration, distance, time);
FormulaSet tswa = new FormulaSet("s=v*t-1/2*a*POW2(t)", "a=UMIN2*(s-v*t)/POW2(t)", "v=s/t+1/2*a*t", "t=(SQRT(UMIN2*a*s+POW2(v))+v)/a", endSpeed, acceleration, distance, time);
FormulaSet[] formulas = new FormulaSet[] { tsv, tsuw, tuwa, suwa, tsua, tswa };

// Generate quantity types.
CSFile.Generate(new Time(formulas));
CSFile.Generate(new Distance(formulas));
CSFile.Generate(new Speed(formulas));
CSFile.Generate(new Acceleration(formulas));
//AngleGenerator.Generate();
//MotionGenerator.Generate(tsv, tsuv, suva, tsua, tsva);
//VelocityGenerator.Generate(tsv, tsuv, tuva, suva, tsua, tsva);