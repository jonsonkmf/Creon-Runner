using System;
using Player;

namespace Infrastructure
{
    public class GameLoopState : IPayloaderState<PlayerMovement>
    {
        private readonly GameStateMachine _gameStateMachine;

        public GameLoopState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter(PlayerMovement payload)
        {
            payload.StartMove();
        }

        public void Exit()
        {
            
        }

        public void Enter()
        {
            
        }
    }
}