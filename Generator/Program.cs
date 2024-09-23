using Generator;


Parameter time = new Parameter('t', "Time", "time");
Parameter distance = new Parameter('s', "Distance", "distance");
Parameter startSpeed = new Parameter('u', "Speed", "startSpeed");
Parameter endSpeed = new Parameter('v', "Speed", "endSpeed");
Parameter acceleration = new Parameter('a', "Acceleration", "acceleration");

FormulaSet vust = new FormulaSet("v=u+s/t", new Parameter[] { time, distance, startSpeed, endSpeed },
    new string[] { "t=u+s/v", "s=u+v*t", "u=v-s/t" });
FormulaSet avut = new FormulaSet("a=(v-u)/t", new Parameter[] { time, startSpeed, endSpeed, acceleration },
    new string[] { "v=u+a*t", "u=v-a*t", "t=(v-u)/a"});

TimeGenerator.Generate(vust);
DistanceGenerator.Generate(vust);
SpeedGenerator.Generate(vust);
AccelerationGenerator.Generate(avut);
