namespace AddCode.Studying.Services;

public class StrongGenerator : PasswordGenerator, IPasswordGenerator
{
    public new PasswordInfo Generate()
    {
        Random random = new Random();
        var symbols = new[] { '!', '@', '#', '$', '%'};
        var index = random.Next(symbols.Length);
        var randomSymbol = symbols[index];
        var randomNumber = random.Next(100, 1000);

        var basePassword = base.Generate();
        var strongPassword = $"{randomNumber}{basePassword.GeneratedPassword}{randomSymbol}";

        return new PasswordInfo(basePassword.CyrillicPhrase, basePassword.LatinPhrase, strongPassword);
    }
}