namespace AddCode.Studying.Services;

public static class PasswordGenerator
{
    private static readonly Random _random = new();

    public static PasswordInfo Generate()
    {
        var verbsFilePath = Routes.FilePath.VerbsFilePath;
        var nounsFilePath = Routes.FilePath.NounsFilePath;

        var verbs = File.ReadAllLines(verbsFilePath);
        var nouns = File.ReadAllLines(nounsFilePath);

        if (nouns.Length < 2 || verbs.Length < 1)
            throw new Exception("В файле должно быть как минимум 2 существительных и 1 глагол.");

        var verb = GetRandomElement(verbs);
        var noun = GetRandomElement(nouns);
        var noun2 = GetRandomElement(nouns);

        var cyrillicPassword = $"{noun} {verb} {noun2}";
        var latinPassword = ConvertToEnglishLayout(cyrillicPassword);
        var latinArray = latinPassword.Split(' ');
        var generatedPassword = Generate(latinArray);

        return new PasswordInfo(cyrillicPassword, latinPassword, generatedPassword);
    }
    
    private static string GetRandomElement(string[] array)
    {
        return array[_random.Next(array.Length)];
    }

    private static string ConvertToEnglishLayout(string cyrillicPassword)
    {
        var layoutMapping = new Dictionary<char, char>
        {
            { 'а', 'f' }, { 'б', ',' }, { 'в', 'd' }, { 'г', 'u' }, { 'д', 'l' },
            { 'е', 't' }, { 'ё', '`' }, { 'ж', ';' }, { 'з', 'p' }, { 'и', 'b' },
            { 'й', 'q' }, { 'к', 'r' }, { 'л', 'k' }, { 'м', 'v' }, { 'н', 'y' },
            { 'о', 'j' }, { 'п', 'g' }, { 'р', 'h' }, { 'с', 'c' }, { 'т', 'n' },
            { 'у', 'e' }, { 'ф', 'a' }, { 'х', '[' }, { 'ц', 'w' }, { 'ч', 'x' },
            { 'ш', 'i' }, { 'щ', 'o' }, { 'ъ', 'm' }, { 'ы', 's' }, { 'ь', '\'' },
            { 'э', ']' }, { 'ю', '.' }, { 'я', 'z' }, { ' ', ' ' }
        };
        var latinPassword = new string(cyrillicPassword
            .ToLower()
            .ToCharArray()
            .Select(c => layoutMapping.ContainsKey(c) ? layoutMapping[c] : c)
            .ToArray());

        return latinPassword;
    }

    private static string Generate(string[] latinArray)
    {
        var selectedWords = latinArray
            .OrderBy(_ => _random.Next())
            .Take(_random.Next(3, 5))
            .ToArray();
        var generatedPassword = string
            .Join("", selectedWords
                .Select(w => w.Substring(0, Math.Min(3, w.Length))));
        
        return generatedPassword;
    }
}