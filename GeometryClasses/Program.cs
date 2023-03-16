using GeometryClasses;
using System.Runtime.ExceptionServices;

Point2D[] createPointArray(int numberOfPoints)
{
    Point2D[] p = new Point2D[numberOfPoints];
    for (int j = 0; j < numberOfPoints; j++)
    {
        double[] xy = new double[2];
        Console.WriteLine((j + 1).ToString() + " point. Coordinate X:");
        xy[0] = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine((j + 1).ToString() + " point. Coordinate Y:");
        xy[1] = Convert.ToDouble(Console.ReadLine());
        p[j] = new Point2D(xy);   
    }
    return p;
}

IShape newShape(string type) {
    IShape shape;
    if (type == "polyline")
    {
        Console.WriteLine("Number of points: ");
        int numberOfPoints = Convert.ToInt32(Console.ReadLine());
        shape = new Polyline(createPointArray(numberOfPoints));
    }
    else if (type == "ngon")
    {
        Console.WriteLine("Number of points: ");
        int numberOfPoints = Convert.ToInt32(Console.ReadLine());
        shape = new NGon(createPointArray(numberOfPoints));
    }
    else if (type == "qgon")
    {
        shape = new QGon(createPointArray(4));
    }
    else if (type == "tgon")
    {
        shape = new TGon(createPointArray(3));
    }
    else if (type == "trapeze")
    {
        shape = new Trapeze(createPointArray(4));
    }
    else if (type == "rectangle")
    {
        shape = new Rectangle(createPointArray(4));
    }
    else if (type == "segment")
    {
        double[] start = new double[2];
        Console.WriteLine("Start X coordinate: ");
        start[0] = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Start Y coordinate: ");
        start[1] = Convert.ToDouble(Console.ReadLine());
        double[] finish = new double[2];
        Console.WriteLine("Finish X coordinate: ");
        finish[0] = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Finish Y coordinate: ");
        finish[1] = Convert.ToDouble(Console.ReadLine());
        shape = new Segment(new Point2D(start), new Point2D(finish));
    }
    else if (type == "circle")
    {
        double[] center = new double[2];
        Console.WriteLine("Center X coordinate: ");
        center[0] = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Center Y coordinate: ");
        center[1] = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Radius: ");
        double radius = Convert.ToDouble(Console.ReadLine());
        shape = new Circle(new Point2D(center), radius);
    }
    else throw new Exception("Inexistent shape type");
    return shape;
}




List<IShape> figures = new List<IShape>();

Console.WriteLine("Number of Shapes: ");
int numberOfShapes = Convert.ToInt32(Console.ReadLine());

for (int i = 0; i < numberOfShapes; i++)
{
    Console.WriteLine((i+1).ToString() + " Shape type: ");
    string type = Console.ReadLine().ToLower();
    figures.Add(newShape(type));
}
figures.ForEach(f => { Console.WriteLine(f.toString()); });

double totalSquare = 0, totalLength = 0;
figures.ForEach(f => { totalLength += f.length(); totalSquare += f.square(); });
Console.WriteLine("Total square of shapes: " + totalSquare);
Console.WriteLine("Total length of shapes: " + totalLength);
Console.WriteLine("Average square of a shape: " + totalSquare/numberOfShapes);


Console.WriteLine("Input ugly twins for preceding shapes. ");
for (int i = 0; i < numberOfShapes; i++)
{ 
    Type t = figures[i].GetType();
    Console.WriteLine((i + 1).ToString() + " Shape type: " + t);
    IShape shape = null;    
    if (t == typeof(Segment)) shape = newShape("segment");
    else if (t == typeof(Polyline)) shape = newShape("polyline");
    else if (t == typeof(Circle)) shape = newShape("circle");
    else if (t == typeof(NGon)) shape = newShape("ngon");
    else if (t == typeof(QGon)) shape = newShape("qgon");
    else if (t == typeof(TGon)) shape = newShape("tgon");
    else if (t == typeof(Trapeze)) shape = newShape("trapeze");
    else if (t == typeof(Rectangle)) shape = newShape("rectangle");
    Console.WriteLine("Does the shape cross figure with the same index?");
    if (shape.cross(figures[i])) Console.WriteLine("YES");
    else Console.WriteLine("NO");
    Console.WriteLine("Now its time to skrew these shapes. ");
    Console.WriteLine("Movement type: ");
    string movementType = Console.ReadLine().ToLower();
    if (movementType == "shift")
    {
        double[] movementVector = new double[2];
        Console.WriteLine("Shift vector X coordinate: ");
        movementVector[0] = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Shift vector Y coordinate: ");
        movementVector[1] = Convert.ToDouble(Console.ReadLine());
        shape.shift(new Point2D(movementVector));
    }
    else if (movementType == "rot")
    {
        Console.WriteLine("Rotation angle (counterclockwise): ");
        double angle = Convert.ToDouble(Console.ReadLine());
        shape.rot(angle);
    }
    else if (movementType == "symaxis")
    {
        Console.WriteLine("Axis index: ");
        int axisOfSymmetryIndex = Convert.ToInt32(Console.ReadLine());
        shape.symAxis(axisOfSymmetryIndex);
    }
    else throw new Exception("Such movement is not applicable");
    Console.WriteLine("Movement parameters: ");
    Console.WriteLine("Does the shifted shape cross figure with the same index?");
    if (shape.cross(figures[i])) Console.WriteLine("YES");
    else Console.WriteLine("NO");
}



/*
double[] d1 = new double[] {-4,1};
double[] d2 = new double[] { -3, 4 };
double[] d3, d4, d5, d6;
Point2D[] sg = new Point2D[] { new Point2D(d1), new Point2D(d2)};
d1 = new double[] { -7, 2 };
d2 = new double[] { -5, 2 };
d3 = new double[] { -5, 4 };
d4 = new double[] { -3, 6 };
d5 = new double[] { -2, 5 };
Point2D[] pl = new Point2D[] { new Point2D(d1), new Point2D(d2), new Point2D(d3), new Point2D(d4), new Point2D(d5) };
d1 = new double[] { 3, 0 };
d2 = new double[] { 4, 2 };
d3 = new double[] { 6, 2 };
d4 = new double[] { 7, 0 };
d5 = new double[] { 6, -2 };
d6 = new double[] { 4, -2 };
Point2D[] ng = new Point2D[] { new Point2D(d1), new Point2D(d2), new Point2D(d3), new Point2D(d4), new Point2D(d5), new Point2D(d6) };
d1 = new double[] { 0, -3 };
d2 = new double[] { 3, -1 };
d3 = new double[] { 3, -4 };
Point2D[] tg = new Point2D[] { new Point2D(d1), new Point2D(d2), new Point2D(d3) };
d1 = new double[] { -3, 1 };
d2 = new double[] { -1, 3 };
d3 = new double[] { 2, 0 };
d4 = new double[] { 0, -2 };
Point2D[] rc = new Point2D[] { new Point2D(d1), new Point2D(d2), new Point2D(d3), new Point2D(d4) };
d1 = new double[] { -4, 0 };
d2 = new double[] { -1, -2 };
d3 = new double[] { -4, -3 };
d4 = new double[] { -5, -1 };
Point2D[] qg = new Point2D[] { new Point2D(d1), new Point2D(d2), new Point2D(d3), new Point2D(d4) };
d1 = new double[] { -2, 1 };
d2 = new double[] { -2, 4 };
d3 = new double[] { 0, 5 };
d4 = new double[] { 2, 3 };
Point2D[] tr = new Point2D[] { new Point2D(d1), new Point2D(d2), new Point2D(d3), new Point2D(d4) };
figures.Add(new Segment(sg[0], sg[1]));
figures.Add(new NGon(pl));
figures.Add(new NGon(ng));
d1 = new double[] { 4.5, 4.5 };
figures.Add(new Circle(new Point2D(d1), 1.5));
figures.Add(new TGon(tg));
figures.Add(new Rectangle(rc));
figures.Add(new QGon(qg));0
figures.Add(new Trapeze(tr));
*/
/*

figures.ForEach(f => {
    Console.WriteLine("Figure: " + f.GetType().ToString());
    Console.WriteLine("Square: " + f.square());
    Console.WriteLine("Length: " + f.length());
});
*/