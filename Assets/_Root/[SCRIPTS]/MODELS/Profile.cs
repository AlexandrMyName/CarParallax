using Tools.React;


namespace Game.Models
{
    internal class Profile
    {
        public readonly SubscriptionProperty<GameState> _reactGameState;
        public readonly CarModel Car;

        public Profile(float speedCarSet, GameState stateEntyGame) : this(speedCarSet) => _reactGameState.Value = GameState.Menu;


        public Profile(float speedCarSet)
        {
            _reactGameState = new SubscriptionProperty<GameState>();
            Car = new CarModel(speedCarSet);

        }
    }
}