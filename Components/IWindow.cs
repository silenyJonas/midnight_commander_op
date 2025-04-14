namespace MidnightCommander.Components
{
    public interface IWindow
    {
        void Draw();
        void HandleKey(ConsoleKeyInfo key);
    }
}