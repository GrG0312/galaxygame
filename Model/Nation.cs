namespace Model
{
    public class Nation : NamedObject
    {
        public string Adjective { get; protected set; }

        public Nation(string name, string adjective) : base(name)
        {
            Adjective = adjective;
        }
    }
}