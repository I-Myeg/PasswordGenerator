using System.Text;

namespace AddCode.Studying.Services;

public class PasswordInfo(string cyrillicPhrase, string latinPhrase, string generatedPassword)
{
    private string CyrillicPhrase { get; } = cyrillicPhrase;
    private string LatinPhrase { get; } = latinPhrase;
    private string GeneratedPassword { get; } = generatedPassword;

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"Фраза на кириллице: {CyrillicPhrase}");
        stringBuilder.AppendLine($"Фраза на латинице: {LatinPhrase}");
        stringBuilder.AppendLine($"Сгенерированный пароль: {GeneratedPassword}");

        return stringBuilder.ToString();
    }
}