namespace Servant.After
{
	// Interface specifying what serviced classes needs to implement, to be
    // serviced by servant.
    public interface IMovable
    {
        void SetPosition(Position p);

        Position GetPosition();
    }
}