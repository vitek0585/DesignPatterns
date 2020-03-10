using System;

namespace Servant.After
{
    class Program
    {
        static void Main(string[] args)
        {
            var servant = new MoveServant();

            var triangle = new Triangle();
            servant.MoveBy(triangle, 12,30);

            var ellipse = new Ellipse();
            servant.MoveTo(ellipse, new Position(23,33));
        }
    }
}
