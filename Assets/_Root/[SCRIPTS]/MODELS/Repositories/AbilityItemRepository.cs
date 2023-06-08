using Configs.Inventory;
using Game.Models;
using System.Collections.Generic;
using Tools.Generic;

namespace Game.Inventory
{
    internal class AbilityItemRepository : BaseRepository<string, IAbility, AbilityItemConfig>
    {
        public AbilityItemRepository(IEnumerable<AbilityItemConfig> configs) : base(configs) { }

        protected override IAbility CreateItem(AbilityItemConfig config)
         =>
            config.Type switch
            {
                AbilityType.BombGun => new BombGunAbility(config),
                AbilityType.Jump => new JumpAbility(config),
                _ => new StubAbility()
            };
         

        protected override string GetKey(AbilityItemConfig config) => config.Id;
    }
}