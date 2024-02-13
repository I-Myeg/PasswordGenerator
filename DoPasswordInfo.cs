using System.Text;

namespace passwordClass;

class DoPasswordInfo
{
    private readonly string _cyrillicPhrase;
    private readonly string _latinPhrase;
    private readonly string _generatedPassword;

    public DoPasswordInfo(string cyrillicPhrase, string latinPhrase, string generatedPassword)
    {
        _cyrillicPhrase = cyrillicPhrase;
        _latinPhrase = latinPhrase;
        _generatedPassword = generatedPassword;
    }
    public override string ToString()
    {   
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append($"Фраза на кириллице: {_cyrillicPhrase}\n");
        stringBuilder.Append($"Фраза на латинице: {_latinPhrase}\n");
        stringBuilder.Append($"Сгенерированный пароль: {_generatedPassword}");
        
        return stringBuilder.ToString();
    }
}