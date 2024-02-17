using System.Text;

namespace passwordClass;

internal class PasswordInfo(string cyrillicPhrase, string latinPhrase, string generatedPassword)
{
    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"Фраза на кириллице: {cyrillicPhrase}");
        stringBuilder.AppendLine($"Фраза на латинице: {latinPhrase}");
        stringBuilder.AppendLine($"Сгенерированный пароль: {generatedPassword}");

        return stringBuilder.ToString();
    }
}