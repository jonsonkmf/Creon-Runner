using UnityEngine;

namespace Infrastructure
{
    public class LoadLevelState : IPayloaderState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader      _sceneLoader;
        private          WayCreator       _wayCreator;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader      = sceneLoader;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            
        }
        
        private void OnLoaded()
        {
            _wayCreator = GameObject.FindWithTag("WayCreator").GetComponent<WayCreator>();
            _wayCreator.Init(SetNextState);
        }

        private void SetNextState()
        {
            _gameStateMachine.Enter<LoadPlayer,Transform[]>( _wayCreator.WayPoints);
        }
    }
}