using Model.CodeComponents.DelegateComponents;

namespace Model.Designs
{
    /// <summary>
    /// A slot that can hold an object of type <typeparamref name="THeld"/>. Conditions can be set to restrict what kind of objects can be assigned to this slot.
    /// </summary>
    /// <typeparam name="THeld">InstanceStats of the held object</typeparam>
    public class Slot<THeld> : NamedObject
    {
        /// <summary>
        /// Holds all slotConditions that must be fulfilled in order to assign an object to this slot.
        /// </summary>
        private readonly ConditionComponent<THeld> _conditions;

        /// <summary>
        /// Fires when an object is assigned to this slot.
        /// </summary>
        public event EventHandler? ObjectAssigned;

        /// <summary>
        /// The object assigned to this slot. Null if it is empty.
        /// </summary>
        public THeld? AssignedObject { get; private set; }

        public Slot(Condition<THeld>[] conditions) : this(string.Empty, conditions) { }

        public Slot(string name, Condition<THeld>[] conditions) : base(name)
        {
            this._conditions = new ConditionComponent<THeld>(conditions);
        }

        /// <summary>
        /// Assign a <typeparamref name="THeld"/> object to this slot. Should not be used without checking with <see cref="CanAssign(THeld, out string)"/>,
        /// but with <paramref name="shouldCheck"/> the checks here can be bypassed.
        /// </summary>
        /// <param name="obj">Object to be assigned</param>
        /// <param name="shouldCheck">Should check the slotConditions or not. Useful if the <see cref="CanAssign(THeld, out string)"/> is called beforehand.</param>
        /// <exception cref="GameException"></exception>
        public void Assign(THeld obj, bool shouldCheck = true)
        {
            if (shouldCheck && !_conditions.FulfillsAll(obj, out string whyNot))
            {
                throw new GameException($"Cannot assign obj to slot because it doesn't fullfil the given condition: {whyNot}");
            }
            AssignedObject = obj;
        }

        /// <summary>
        /// Checks if the given <typeparamref name="THeld"/> object fulfills all slotConditions.
        /// </summary>
        /// <param name="whynot">The name of the first condition that's not fulfilled.</param>
        public bool CanAssign(THeld obj, out string whynot)
        {
            return _conditions.FulfillsAll(obj, out whynot);
        }
    }
}
