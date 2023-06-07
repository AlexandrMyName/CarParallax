using Game.Inventory;
using Tools.React;


namespace Game.Models
{
    internal class Profile
    {
        public readonly SubscriptionProperty<GameState> _reactGameState;
        public readonly CarModel Car;
        private readonly IInventory _inventory;

        public Profile(float speedCarSet, GameState stateEntyGame) : this(speedCarSet) => _reactGameState.Value = GameState.Menu;


        public Profile(float speedCarSet)
        {
            _inventory = new InventoryModel();
            _reactGameState = new SubscriptionProperty<GameState>();
             Car = new CarModel(speedCarSet);

        }
    }
}