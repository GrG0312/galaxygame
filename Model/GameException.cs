namespace Model
{
    public class GameException : Exception
    {
        public GameException() { }
        public GameException(string message) : base(message) { }
    }
}
