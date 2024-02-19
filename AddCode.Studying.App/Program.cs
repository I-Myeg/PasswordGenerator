namespace AddCode.Studying.App;

internal abstract class Program
{
    private static void Main()
    {
        var passwordInfo = PasswordGenerator.PasswordGenerator.PasswordInfo();
        Console.WriteLine(passwordInfo);
    }
}