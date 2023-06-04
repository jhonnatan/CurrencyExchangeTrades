namespace UnitTests
{
    public static class Util
    {
        public static string GetRootTestPath() =>
            Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
    }
}
