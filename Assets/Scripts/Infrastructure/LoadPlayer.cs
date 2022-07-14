using CodeBase.CameraLogic;
using Player;
using UnityEngine;

namespace Infrastructure
{
    public class LoadPlayer : IPayloaderState<Transform[]>
    {
        private readonly GameStateMachine _gameStateMachine;

        public LoadPlayer(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter(Transform[] payload)
        {
            
            GameObject cube   = Instantiate("Cube");
            var        player = cube.GetComponent<PlayerMovement>();
          
            player.Init(payload);
            CameraFollow(cube);
            
            _gameStateMachine.Enter<GameLoopState,PlayerMovement>(player);
        }

        public void Exit()
        {
        }

        public void Enter()
        {
        }
        
        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        private static void CameraFollow(GameObject hero)
        {
            Camera.main.GetComponent<CameraFollow>().Follow(hero);
        }
    }
}