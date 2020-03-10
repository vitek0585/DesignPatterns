namespace Servant.After
{
	// Servant class, offering its functionality to classes implementing
    // IMovable Interface
    public class MoveServant
    {
        // Method, which will move IMovable implementing class to position where
        public void MoveTo(IMovable serviced, Position where)
        {
            // Do some other stuff to ensure it moves smoothly and nicely, this is
            // the place to offer the functionality
            serviced.SetPosition(where);
        }

        // Method, which will move IMovable implementing class by dx and dy
        public void MoveBy(IMovable serviced, int dx, int dy)
        {
            // this is the place to offer the functionality
            dx += serviced.GetPosition().XPosition;
            dy += serviced.GetPosition().YPosition;
            serviced.SetPosition(new Position(dx, dy));
        }
    }
}