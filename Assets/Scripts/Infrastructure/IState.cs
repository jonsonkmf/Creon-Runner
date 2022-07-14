namespace Infrastructure
{
    public interface IState: IExitableState
    {
        void Enter();
    }

    public interface IExitableState
    {
        void Exit();
    }
    
    public interface IPayloaderState<TPayload>: IExitableState
    {
        void Enter(TPayload payload);
    }
    
}