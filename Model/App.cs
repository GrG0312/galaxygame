using Model.Sessions;

namespace Model
{
    public static class App
    {
        public static Session? Current { get; private set; }
    }
}
