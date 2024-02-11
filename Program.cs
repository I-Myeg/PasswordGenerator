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
        return $"Фраза на кириллице: {CyrillicPhrase}\nФраза на латинице: {LatinPhrase}\nСгенерированный пароль: {GeneratedPassword}";
    }
}

class GeneratePassword
{
    private Random random;
    
    public InformationAboutPassword InformationAboutPassword()
    {
        string verbsFilePath = @"C:\Users\litpu\RiderProjects\passwordClass\Verbs.txt";
        string nounsFilePath = @"C:\Users\litpu\RiderProjects\passwordClass\Nouns.txt";

        string[] verbs = File.ReadAllLines(verbsFilePath);
        string[] nouns = File.ReadAllLines(nounsFilePath);

        if (nouns.Length < 2 || verbs.Length < 1)
        {
            Console.WriteLine("В файле должно быть как минимум 2 существительных и 1 глагол.");
            return null;
        }

        string verb = GetRandomElement(verbs);
        string noun = GetRandomElement(nouns);
        string noun_2 = GetRandomElement(nouns);

        string cyrillicPassword = $"{noun} {verb} {noun_2}";
        string latinPassword = ConvertToEnglishLayout(cyrillicPassword);
        string generatedPassword = Generation(new string[] { latinPassword });
        return new InformationAboutPassword(cyrillicPassword, latinPassword, generatedPassword);
    }

    private string GetRandomElement(string[] array)
    {
        random = new Random();
        return array[random.Next(array.Length)];
    }

    private string ConvertToEnglishLayout(string cyrillicPassword)
    {
        Dictionary<char, char> layoutMapping = new Dictionary<char, char>
        {
            { 'а', 'f' }, { 'б', ',' }, { 'в', 'd' }, { 'г', 'u' }, { 'д', 'l' },
            { 'е', 't' }, { 'ё', '`' }, { 'ж', ';' }, { 'з', 'p' }, { 'и', 'b' },
            { 'й', 'q' }, { 'к', 'r' }, { 'л', 'k' }, { 'м', 'v' }, { 'н', 'y' },
            { 'о', 'j' }, { 'п', 'g' }, { 'р', 'h' }, { 'с', 'c' }, { 'т', 'n' },
            { 'у', 'e' }, { 'ф', 'a' }, { 'х', '[' }, { 'ц', 'w' }, { 'ч', 'x' },
            { 'ш', 'i' }, { 'щ', 'o' }, { 'ъ', 'm' }, { 'ы', 's' }, { 'ь', '\'' },
            { 'э', ']' }, { 'ю', '.' }, { 'я', 'z' }, { ' ', ' ' }
        };

        return new string(cyrillicPassword.ToLower().ToCharArray().Select(c =>
            layoutMapping.ContainsKey(c) ? layoutMapping[c] : c).ToArray());
    }

    private string Generation(string[] latinPassword)
    {
        string[] selectedWords = latinPassword.OrderBy(w => random.Next()).Take(random.Next(3, 5)).ToArray();
        string generatedPassword = string.Join("", selectedWords.Select(w => w.Substring(0, Math.Min(3, w.Length))));
        return generatedPassword;
    }
}

class Program
{
    static void Main()
    {
        GeneratePassword generatePassword = new GeneratePassword();
        InformationAboutPassword informationAboutPassword = generatePassword.InformationAboutPassword();
        Console.WriteLine(informationAboutPassword);
        
    }
}
