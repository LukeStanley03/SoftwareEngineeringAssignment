using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineeringAssignment
{
    public static class commandFactory
    {
        public static ICanvasCommand CreateCommand(string commandType, params string[] parameters)
        {
            switch (commandType.ToLower())
            {
                case "moveto":
                    // Ensure parameters length and parse to integers
                    if (parameters.Length != 2)
                        throw new GPLexception("moveto expects 2 parameters");
                    int x = int.Parse(parameters[0]);
                    int y = int.Parse(parameters[1]);
                    return new moveto(x, y);

                case "drawto":
                    if (parameters.Length != 2)
                        throw new GPLexception("drawto expects 2 parameters");
                    int toX = int.Parse(parameters[0]);
                    int toY = int.Parse(parameters[1]);
                    return new drawto(toX, toY);

                case "circle":
                    if (parameters.Length != 1)
                        throw new GPLexception("moveto expects 1 parameter");
                    int radius = int.Parse(parameters[0]);
                    return new circle(radius);

                case "square":
                    if (parameters.Length != 1)
                        throw new GPLexception("square expects 1 parameter");
                    int squareWidth = int.Parse(parameters[0]);
                    return new square(squareWidth);

                case "rectangle":
                    if (parameters.Length != 2)
                        throw new GPLexception("rectangle expects 2 parameters");
                    int rectangleWidth = int.Parse(parameters[0]);
                    int rectangleHeight = int.Parse(parameters[1]);
                    return new rectangle(rectangleWidth, rectangleHeight);

                case "triangle":
                    if (parameters.Length != 2)
                        throw new GPLexception("triangle expects 2 parameters");
                    int triangleWidth = int.Parse(parameters[0]);
                    int triangleHeight = int.Parse(parameters[1]);
                    return new triangle(triangleWidth, triangleHeight);

                case "colour":
                    if (parameters.Length != 3)
                        throw new GPLexception("setcolour expects 3 parameters");

                    if (!int.TryParse(parameters[0], out int red) ||
                        !int.TryParse(parameters[1], out int green) ||
                        !int.TryParse(parameters[2], out int blue))
                    {
                        throw new GPLexception("Invalid parameters for SetColour command.");
                    }

                    return new setcolour(red, green, blue);

                case "fill":
                    if (parameters.Length != 1)
                        throw new GPLexception("SetFill command expects 1 parameter.");
                    return new setfill(parameters[0]);

                case "updatecursor":
                    return new updatecursor();

                case "red":
                    return new red();

                case "green":
                    return new green();

                case "blue":
                    return new blue();

                case "black":
                    return new black();

                case "reset":
                    return new reset();

                case "clear":
                    return new clear();

                
                case "complex":
                    return new complexshape();

                case "shapes":
                    if (parameters.Length != 1)
                        throw new GPLexception("shapes command expects 1 parameter (numberOfShapes)");

                    int numberOfShapes = int.Parse(parameters[0]);
                    return new MultipleComplexShapesCommand(numberOfShapes);

                case "randomlines":
                    if (parameters.Length != 1)
                        throw new GPLexception("drawrandomlines expects 1 parameter");
                    int numberOfLines = int.Parse(parameters[0]);
                    return new randlines(numberOfLines);

                case "star":
                    if (parameters.Length != 3)
                        throw new GPLexception("Star command expects 3 parameters: outerRadius, innerRadius, numPoints");

                    int outerRadius = int.Parse(parameters[0]);
                    int innerRadius = int.Parse(parameters[1]);
                    int numPoints = int.Parse(parameters[2]);

                    return new star(outerRadius, innerRadius, numPoints);

                case "pattern":
                    return new pattern();


                default:
                    throw new GPLexception($"Unknown command type: {commandType}");
            }
        }
    }

}