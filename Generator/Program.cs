using Generator;


Parameter time = new Parameter('t', "Time", "time");
Parameter distance = new Parameter('s', "Distance", "distance");
Parameter startSpeed = new Parameter('u', "Speed", "startSpeed");
Parameter endSpeed = new Parameter('v', "Speed", "endSpeed");
Parameter acceleration = new Parameter('a', "Acceleration", "acceleration");

FormulaSet tsuv = new FormulaSet("v=u+s/t", new Parameter[] { time, distance, startSpeed, endSpeed },
    new string[] { "t=u+s/v", "s=u+v*t", "u=v-s/t" });
FormulaSet tuva = new FormulaSet("a=(v-u)/t", new Parameter[] { time, startSpeed, endSpeed, acceleration },
    new string[] { "v=u+a*t", "u=v-a*t", "t=(v-u)/a" });
FormulaSet suva = new FormulaSet("v=SQRT(POW2(u)+2*a*s)", new Parameter[] { distance, startSpeed, endSpeed, acceleration },
    new string[] { "u=SQRT(POW2(v)-2*a*s)", "a=(POW2(v)-POW2(u))/(2*s)", "s=(POW2(v)-POW2(u))/(2*a)" });

TimeGenerator.Generate(tsuv);
DistanceGenerator.Generate(tsuv, suva);
SpeedGenerator.Generate(tsuv, suva);
AccelerationGenerator.Generate(tuva, suva);
