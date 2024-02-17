namespace passwordClass;

internal abstract class Program
{
    private static void Main()
    {
        var passwordGenerator = new PasswordGenerator();
        var passwordInfo = passwordGenerator.PasswordInfo();
        Console.WriteLine(passwordInfo);
    }
}