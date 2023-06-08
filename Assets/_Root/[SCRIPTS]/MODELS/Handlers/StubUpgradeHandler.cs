using Game.Inventory;
using UnityEngine;

namespace Game.Models
{
    internal class StubUpgradeHandler : IUpgabableHandler
    {
        public void Upgrade(IUpgradable modelForUpgrade)  =>  Debug.Log("Stub handler invoked");
        
    }
}