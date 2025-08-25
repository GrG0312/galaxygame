namespace Model
{
    public class Nation
    {
        public string Name { get; protected set; }
        public string Adjective { get; protected set; }

        public Nation(string name, string adjective)
        {
            Name = name;
            Adjective = adjective;
        }
    }
}