namespace Infrastructure
{
    public class Game
    {
        public static    IInputServices   InputServices;
        public GameStateMachine _stateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            _stateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
        }
    }
}