using System.Drawing; 

namespace Programming_Assignment
{
    interface ShapesInterface 
    { 
        void set(Color colour, int x, int y, float penWidth, params int[] list);

        void draw(Graphics graphicsContext);

        void isFilled(bool fill);
    }
}
