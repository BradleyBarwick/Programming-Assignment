using System;

namespace Programming_Assignment
{
    class ShapeFactory
    {
        public Shape getShape(String shape)
        {
            shape = shape.ToLower().Trim();
            switch (shape)
            {
                case "rectangle":
                    return new Rectangle();
                case "circle":
                    return new Circle();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
