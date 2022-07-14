using Application = UnityEngine.Device.Application;

namespace Infrastructure
{
    public class BootstrapState: IState
    {
        private const    string           Initial = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader      _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader  = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(Initial,onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState,string>("Main");
        }

        private void RegisterServices()
        {
            Game.InputServices = RegisterInputService();
        }

        public void Exit()
        {
            
        }
        
        private static IInputServices RegisterInputService()
        {
            return new InputServices();
        }
    }
}