namespace Application.Boundaries
{
    public interface IOutputPort<T>
    {
        void Standard(T output);
        void Error(string message, string stackTrace);
        void NotFound(string message);
    }
}
