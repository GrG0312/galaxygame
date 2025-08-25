namespace Model
{
    public abstract class NamedObject
    {
        public string Name { get; protected set; }
        protected NamedObject(string name)
        {
            Name = name;
        }
    }
}
