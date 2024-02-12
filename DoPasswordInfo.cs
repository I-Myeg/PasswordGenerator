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
        return $"Фраза на кириллице: {_cyrillicPhrase}\nФраза на латинице: {_latinPhrase}\nСгенерированный пароль: {_generatedPassword}";
    }
}