namespace Model.CodeComponents.PlanetComponents
{
    public class VisibilityComponent
    {
        private HashSet<Nation> hiddenFor;

        public VisibilityComponent(HashSet<Nation>? reference)
        {
            if (reference is null)
            {
                hiddenFor = new();
            } else
            {
                hiddenFor = new(reference);
            }
        }

        public bool IsVisibleTo(Nation nation)
        {
            return hiddenFor.Contains(nation);
        }

        public void SetVisibility(Nation f, bool v)
        {
            if (v)
            {
                hiddenFor.Remove(f);
            }
            else
            {
                hiddenFor.Add(f);
            }
        }
    }
}
