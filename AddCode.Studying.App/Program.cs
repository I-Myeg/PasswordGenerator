using AddCode.Studying.Services;

namespace AddCode.Studying.App;

internal abstract class Program
{
    private static void Main()
    {
        var passwordInfo = PasswordGenerator.Generate();
        Console.WriteLine(passwordInfo);
    }
}