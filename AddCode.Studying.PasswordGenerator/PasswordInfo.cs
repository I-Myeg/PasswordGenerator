using System.Text;

namespace AddCode.Studying.PasswordGenerator;

public class PasswordInfo(string cyrillicPhrase, string latinPhrase, string generatedPassword)
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