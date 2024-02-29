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
        var baseInfo = base.ToString();
        var extendedInfo = $"Время генерации пароля: {GenerationTime}";
        
        return $"{baseInfo}\n{extendedInfo}";
    }
}
