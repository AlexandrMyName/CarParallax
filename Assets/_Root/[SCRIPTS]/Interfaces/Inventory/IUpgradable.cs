
namespace Game.Inventory
{
    internal interface IUpgradable  
    {
        float Value { get; }

        void Restore();
    }
}