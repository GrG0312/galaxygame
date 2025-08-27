using System.Text;

namespace Model.Designs
{
    /// <summary>
    /// <see cref="Blueprint"/>s are researched throughout the game. These will be the basis for creating new designs.
    /// </summary>
    public class Blueprint : NamedObject
    {
        private ModuleSlot[] _moduleSlots;
        public IReadOnlyCollection<ModuleSlot> ModuleSlots => _moduleSlots;
        public Blueprint(string name, ModuleSlot[] moduleSlots) : base(name)
        {
            _moduleSlots = moduleSlots;
        }

        public Design OnSave(string name, Nation nation)
        {
            if (!CanSave(out string error))
            {
                throw new GameException($"Cannot create design from blueprint. {error}");
            }
            List<DesignPart> components = new List<DesignPart>();
            return new Design(name, this, components.ToArray());
        }

        public bool CanSave(out string error)
        {
            error = string.Empty;
            return false;
        }
    }
}
