namespace Servant.After
{
    // One of geometric classes
    public class Triangle : IMovable
    {
        // Position of the geometric object on some canvas
        private Position _p;

        // Method, which sets position of geometric object
        public void SetPosition(Position p)
        {
            this._p = p;
        }

        // Method, which returns position of geometric object
        public Position GetPosition()
        {
            return this._p;
        }
    }

    // One of geometric classes
    public class Ellipse : IMovable
    {
        // Position of the geometric object on some canvas
        private Position _p;

        // Method, which sets position of geometric object
        public void SetPosition(Position p)
        {
            this._p = p;
        }

        // Method, which returns position of geometric object
        public Position GetPosition()
        {
            return this._p;
        }
    }

    // One of geometric classes
    public class Rectangle : IMovable
    {
        // Position of the geometric object on some canvas
        private Position _p;

        // Method, which sets position of geometric object
        public void SetPosition(Position p)
        {
            this._p = p;
        }

        // Method, which returns position of geometric object
        public Position GetPosition()
        {
            return this._p;
        }
    }

    // Just a very simple container class for position.
    public class Position
    {
        public int XPosition;
        public int YPosition;

        public Position(int dx, int dy)
        {
            XPosition = dx;
            YPosition = dy;
        }
    }
}