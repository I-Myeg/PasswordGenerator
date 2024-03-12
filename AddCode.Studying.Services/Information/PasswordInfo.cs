using System.Text;

namespace AddCode.Studying.Services.Information;

public class PasswordInfo(string cyrillicPhrase, string latinPhrase, string generatedPassword)
{
    public string CyrillicPhrase { get; } = cyrillicPhrase;
    public string LatinPhrase { get; } = latinPhrase;
    public string GeneratedPassword { get; } = generatedPassword;

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"Фраза на кириллице: {CyrillicPhrase}");
        stringBuilder.AppendLine($"Фраза на латинице: {LatinPhrase}");
        stringBuilder.AppendLine($"Сгенерированный пароль: {GeneratedPassword}");

        return stringBuilder.ToString();
    }
}