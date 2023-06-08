using Configs.Inventory;
using Game.Models;
using System.Collections.Generic;
using Tools.Generic;

namespace Game.Inventory
{
    internal class UpgradableItemRepository : BaseRepository<string, IUpgabableHandler, UpgradableItemConfig>
    {
        public UpgradableItemRepository(IEnumerable<UpgradableItemConfig> configs) : base(configs) { }

        protected override IUpgabableHandler CreateItem(UpgradableItemConfig config)
         =>  config.Type switch
            {
                UpgradeType.Speed => new SpeedUpgradeHandler(config.Value),
                UpgradeType.None  => new StubUpgradeHandler(),
                _ => new StubUpgradeHandler()
            };

        
        protected override string GetKey(UpgradableItemConfig config) => config.Config.Id;
    }
}