using SpaceInvaders.Utils;
using UnityEngine;
using Zenject;

namespace SpaceInvaders.Components
{
    public class GameStarter : MonoBehaviour
    {
        private GameplayTracker _gameplayTracker;

        [Inject]
        private void Construct(GameplayTracker gameplayTracker) => 
            _gameplayTracker = gameplayTracker;

        private void Start()
        {
            _gameplayTracker.StartGame();
        }
    }
}