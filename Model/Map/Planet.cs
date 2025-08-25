using Model.CodeComponents;
using Model.Graph;

namespace Model.Map
{
    public class Planet : IVertex<Planet>
    {
        public string Name { get; protected set; }
        public VisibilityComponent Visibility { get; private set; }

        public SpaceComponent SpaceComponent { get; }
        public GroundComponent? GroundComponent { get; }

        #region Constructors
        public Planet(
            string name, 
            SpaceComponent spaceComponent, 
            GroundComponent? groundComponent, 
            HashSet<Nation>? reference)
        {
            Name = name;
            SpaceComponent = spaceComponent;
            GroundComponent = groundComponent;
            Visibility = new VisibilityComponent(reference);
        }
        #endregion

        #region IVertex
        public bool Equals(Planet? other)
        {
            return Name.Equals(other?.Name);
        }
        #endregion
    }
}
