namespace Model.CodeComponents.PlanetComponents
{
    public class TraversabilityComponent
    {
        private Dictionary<Nation, bool> accessibility;
        public IReadOnlyDictionary<Nation, bool> AccessabilityTable => accessibility;

        public TraversabilityComponent(Dictionary<Nation, bool>? access = null)
        {
            accessibility = new Dictionary<Nation, bool>(access!);
            if (accessibility.Count == 0)
            {
                accessibility = new Dictionary<Nation, bool>();
                // TODO
                List<Nation> tempList = new List<Nation>();
                foreach (Nation nation in tempList) /* !!! */
                {
                    accessibility[nation] = true;
                }
            }
        }
    }
}
