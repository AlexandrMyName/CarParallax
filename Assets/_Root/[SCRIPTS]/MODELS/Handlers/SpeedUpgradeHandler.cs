using Game.Inventory;

namespace Game.Models
{
    internal class SpeedUpgradeHandler : IUpgabableHandler
    {

        public SpeedUpgradeHandler(float speed) => _speed = speed;

        private float _speed;

        public void Upgrade(IUpgradable modelForUpgrade) => modelForUpgrade.Value += _speed;
         
    }
}