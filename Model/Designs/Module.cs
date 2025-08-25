namespace Model.Designs
{
    public abstract class Module
    {
        public string Name { get; }
        protected Module(string name)
        {
            Name = name;
        }
    }

    public abstract class WeaponModule : Module
    {
        public WeaponModule(string name) : base(name)
        {

        }
    }

    public class GeneratorModule : Module
    {
        public GeneratorModule(string name) : base(name)
        {

        }
    }
}
