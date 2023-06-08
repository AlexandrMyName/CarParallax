
namespace Game.Inventory
{
    internal interface IUpgradable  
    {
        float Value { get; set; }

        void Restore();
    }
}