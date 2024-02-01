class InformationAboutPassword
{
    public string CyrillicPhrase;
    public string LatinPhrase;
    public string GeneratedPassword;
    
    public InformationAboutPassword(string cyrillicPhrase, string latinPhrase, string generatedPassword)
    {
        CyrillicPhrase = cyrillicPhrase;
        LatinPhrase = latinPhrase;
        GeneratedPassword = generatedPassword;
    }

    public override string ToString()
    {
        return $"Фраза на кириллице: {{CyrillicPhrase}}\\nФраза на латинице: {{LatinPhrase}}\\nСгенерированный пароль: {{GeneratedPassword}}";
    }
}

class GeneratePassword
{
    public InformationAboutPassword InformationAboutPassword()
    {
        string verbsFilePath = @"C:\Users\litpu\RiderProjects\Ex2\Verbs.txt";
        string nounsFilePath = @"C:\Users\litpu\RiderProjects\Ex2\Nouns.txt";

        string[] verbs = File.ReadAllLines(verbsFilePath);
        string[] nouns = File.ReadAllLines(nounsFilePath);

        if (nouns.Length < 2 || verbs.Length < 1)
        {
            Console.WriteLine("В файле должно быть как минимум 2 существительных и 1 глагол.");
            return null;
        }

        string verb = GetRandomElement(verbs);
        string noun = GetRandomElement(nouns);

        string cyrillicPassword = $"{nouns} {verbs} {nouns}";
        return new InformationAboutPassword(cyrillicPassword, );
    }

    private string GetRandomElement(string[] array)
    {
        Random random = new Random();
        return array[random.Next(array.Length)];
    }
}

class Program
{
    static void Main()
    {
        GeneratePassword generatePassword = new GeneratePassword();
        InformationAboutPassword informationAboutPassword = generatePassword.InformationAboutPassword();
    }
}