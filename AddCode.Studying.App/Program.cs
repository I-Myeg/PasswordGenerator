using AddCode.Studying.Services;

namespace AddCode.Studying.App;

internal abstract class Program
{
    private static void Main()
    {
        var generationTime = DateTime.Now;
        var passwordInfo = PasswordGenerator.Generate();
        var extendedPasswordInfo = new ExtendedPasswordInfo(passwordInfo.CyrillicPhrase, passwordInfo.LatinPhrase, passwordInfo.GeneratedPassword, generationTime);
        Console.WriteLine(extendedPasswordInfo);
    }
}