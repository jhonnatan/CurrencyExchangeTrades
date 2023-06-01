namespace Application.Boundaries
{
    public interface IOutputPort<T>
    {
        void Standard(T output);
        void Error(string message);
        void NotFound(string message);
    }
}
