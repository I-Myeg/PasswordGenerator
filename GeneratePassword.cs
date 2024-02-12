namespace passwordClass;

class GeneratePassword
{
    private Random _random;
    
    public DoPasswordInfo PasswordInfo()
    {
        string verbsFilePath = @".\Resources\Verbs.txt";
        string nounsFilePath = @".\Resources\Nouns.txt";

        string[] verbs = File.ReadAllLines(verbsFilePath);
        string[] nouns = File.ReadAllLines(nounsFilePath);

        if (nouns.Length < 2 || verbs.Length < 1)
        {
            throw new Exception("В файле должно быть как минимум 2 существительных и 1 глагол.");   
        }

        string verb = GetRandomElement(verbs);
        string noun = GetRandomElement(nouns);
        string noun2 = GetRandomElement(nouns);

        string cyrillicPassword = $"{noun} {verb} {noun2}";
        string latinPassword = ConvertToEnglishLayout(cyrillicPassword);
        string generatedPassword = Generation(new string[] { latinPassword });
        
        return new DoPasswordInfo(cyrillicPassword, latinPassword, generatedPassword);
    }

    private string GetRandomElement(string[] array)
    {
        _random = new Random();
        
        return array[_random.Next(array.Length)];
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
        string[] selectedWords = latinPassword.OrderBy(w => _random.Next()).Take(_random.Next(3, 5)).ToArray();
        string generatedPassword = string.Join("", selectedWords.Select(w => w.Substring(0, Math.Min(3, w.Length))));
        
        return generatedPassword;
    }
}