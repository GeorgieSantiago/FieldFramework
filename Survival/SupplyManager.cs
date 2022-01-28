namespace Field.Survival
{
    using GameCreator.Variables;
    using GameCreator.Core;

    public enum SupplyType
    {
        Iron,
        Carbon,
        Fuel,
        Food,
        Lumber,
        Medicine
    }

    public class SupplyManager : Singleton<SupplyManager>
    {
        public NumberProperty m_Iron;
        public NumberProperty m_Carbon;
        public NumberProperty m_Fuel;
        public NumberProperty m_Food;
        public NumberProperty m_Lumber;
        public NumberProperty m_Medicine;

        public void Effect(SupplyType type, int amount)
        {
            switch (type)
            {
                case SupplyType.Iron:
                    this.ApplyEffect(this.m_Iron, amount);
                break;
                case SupplyType.Carbon:
                    this.ApplyEffect(this.m_Carbon, amount);
                break;
                case SupplyType.Fuel:
                    this.ApplyEffect(this.m_Fuel, amount);
                break;
                case SupplyType.Food:
                     this.ApplyEffect(this.m_Food, amount);
                break;
                case SupplyType.Lumber:
                    this.ApplyEffect(this.m_Lumber, amount);
                break;
                case SupplyType.Medicine:
                    this.ApplyEffect(this.m_Medicine, amount);
                break;
            }
        }

        private void ApplyEffect(NumberProperty target, int amount)
        {
            target.value += amount;
        }
    }
}