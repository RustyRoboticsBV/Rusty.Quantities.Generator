/*using Rusty.Quantities;

Time time = 2;
Speed constSpeed = 4;
Distance distance = 8;
Acceleration acceleration = 3;
Speed startSpeed = 1;
Speed endSpeed = 7;

Console.WriteLine("REFERENCE VALUES:");
Console.WriteLine("Time \t\tt:\t" + time);
Console.WriteLine("Constant speed\tv:\t" + constSpeed);
Console.WriteLine("Distance\ts:\t" + distance);
Console.WriteLine("Acceleration\ta:\t" + acceleration);
Console.WriteLine("Start speed\tu:\t" + startSpeed);
Console.WriteLine("End speed\tv:\t" + endSpeed);
Console.WriteLine("");

Console.WriteLine("TIME:");
Console.WriteLine("t (vs): " + Time.CalcTimeFromVS(constSpeed, distance));
Console.WriteLine("t (uvs): " + Time.CalcTimeFromUVS(startSpeed, endSpeed, distance));
Console.WriteLine("t (uva): " + Time.CalcTimeFromUVA(startSpeed, endSpeed, acceleration));
Console.WriteLine("t (uas): " + Time.CalcTimeFromUAS(startSpeed, acceleration, distance));
Console.WriteLine("t (vas): " + Time.CalcTimeFromVAS(endSpeed, acceleration, distance));
Console.WriteLine("");

Console.WriteLine("DISTANCE:");
Console.WriteLine("s (vt): " + Distance.CalcDistanceFromVT(constSpeed, time));
Console.WriteLine("s (uvt): " + Distance.CalcDistanceFromUVT(startSpeed, endSpeed, time));
Console.WriteLine("s (uva): " + Distance.CalcDistanceFromUVA(startSpeed, endSpeed, acceleration));
Console.WriteLine("s (uat): " + Distance.CalcDistanceFromUAT(startSpeed, acceleration, time));
Console.WriteLine("s (vat): " + Distance.CalcDistanceFromVAT(endSpeed, acceleration, time));
Console.WriteLine("");

Console.WriteLine("CONSTANT SPEED:");
Console.WriteLine("v (st): " + Speed.CalcConstantSpeedFromST(distance, time));
Console.WriteLine("");

Console.WriteLine("ACCELERATION:");
Console.WriteLine("a (ust): " + Acceleration.CalcAccelerationFromUST(startSpeed, distance, time));
Console.WriteLine("a (vst): " + Acceleration.CalcAccelerationFromVST(endSpeed, distance, time));
Console.WriteLine("a (uvt): " + Acceleration.CalcAccelerationFromUVT(startSpeed, endSpeed, time));
Console.WriteLine("a (uvs): " + Acceleration.CalcAccelerationFromUVS(startSpeed, endSpeed, distance));
Console.WriteLine("");

Console.WriteLine("START SPEED:");
Console.WriteLine("u (vst): " + Speed.CalcStartSpeedFromVST(endSpeed, distance, time));
Console.WriteLine("u (vat): " + Speed.CalcStartSpeedFromVAT(endSpeed, acceleration, time));
Console.WriteLine("u (vas): " + Speed.CalcStartSpeedFromVAS(endSpeed, acceleration, distance));
Console.WriteLine("u (ast): " + Speed.CalcStartSpeedFromAST(acceleration, distance, time));
Console.WriteLine("");

Console.WriteLine("END SPEED:");
Console.WriteLine("v (ust): " + Speed.CalcEndSpeedFromUST(startSpeed, distance, time));
Console.WriteLine("v (uat): " + Speed.CalcEndSpeedFromUAT(startSpeed, acceleration, time));
Console.WriteLine("v (uas): " + Speed.CalcEndSpeedFromUAS(startSpeed, acceleration, distance));
Console.WriteLine("v (ast): " + Speed.CalcEndSpeedFromAST(acceleration, distance, time));
Console.WriteLine("");*/