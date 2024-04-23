using System;
using SpaceInvaders.Components;
using SpaceInvaders.Components.Units;
using SpaceInvaders.Configs;

namespace SpaceInvaders.Utils
{
    public class GameplayTracker : IDisposable
    {
        private int _currentStage;
        private int _stagesAmount;
        private Defender _player;
        private AlienGrid _aliens;
        private ProjectileSpawner _spawner;

        public GameplayTracker(Defender player, AlienGrid aliens, ProjectileSpawner spawner, AliensPattern pattern)
        {
            _player = player;
            _aliens = aliens;
            _spawner = spawner;
            _stagesAmount = pattern.Stages.Count;
            _aliens.StageComplete += SetNewStage;
            _player.Died += StartGame;
        }

        public void StartGame()
        {
            _currentStage = -1;
            SetNewStage();
        }

        private void SetNewStage()
        {
            _currentStage++;
            
            if (_currentStage == _stagesAmount)
            {
                StartGame();
                return;
            }

            _spawner.RemoveAllProjectiles();
            _aliens.InitializeStage(_currentStage);
        }

        public void Dispose()
        {
            _aliens.StageComplete -= SetNewStage;
            _player.Died -= StartGame;
        }
    }
}