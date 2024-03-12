using System.Text;

namespace AddCode.Studying.Services.Information;

public class ExtendedPasswordInfo(
    string cyrillicPhrase,
    string latinPhrase,
    string generatedPassword,
    DateTime generationTime)
    : PasswordInfo(cyrillicPhrase, latinPhrase, generatedPassword)
{
    private DateTime GenerationTime { get; } = generationTime;

    public override string ToString()
    {
        var stringBuilder = base.ToString();
        var sb = new StringBuilder();
        sb.AppendLine(stringBuilder);
        sb.AppendLine($"Время генерации пароля: {GenerationTime}");
        
        return sb.ToString();
    }
}
