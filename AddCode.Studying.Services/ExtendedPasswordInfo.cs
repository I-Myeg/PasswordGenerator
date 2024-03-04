using System.Text;

namespace AddCode.Studying.Services;

public class ExtendedPasswordInfo : PasswordInfo
{
    private DateTime GenerationTime { get; }

    public ExtendedPasswordInfo(string cyrillicPhrase, string latinPhrase, string generatedPassword, DateTime generationTime)
        : base(cyrillicPhrase, latinPhrase, generatedPassword)
    {
        GenerationTime = generationTime;
    }

    public override string ToString()
    {
        var stringBuilder = base.ToString();
        var sb = new StringBuilder();
        sb.AppendLine(stringBuilder);
        sb.AppendLine($"Время генерации пароля: {GenerationTime}");
        
        return sb.ToString();
    }
}
