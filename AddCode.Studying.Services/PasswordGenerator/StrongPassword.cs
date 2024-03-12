using AddCode.Studying.Services.Information;
using AddCode.Studying.Services.Models;

namespace AddCode.Studying.Services.PasswordGenerator;

public class StrongPassword<T> : IPasswordGenerator where T : ExtendedPasswordInfo
{
    private static readonly Random _random = new();
    
    public PasswordInfo Generate()
    {
        var verbsFilePath = Routes.VerbsFilePath;
        var nounsFilePath = Routes.NounsFilePath;

        var verbs = File.ReadAllLines(verbsFilePath);
        var nouns = File.ReadAllLines(nounsFilePath);

        if (nouns.Length < 2 || verbs.Length < 1)
            throw new Exception("В файле должно быть как минимум 2 существительных и 1 глагол.");

        var verb = GetRandomElement(verbs);
        var noun = GetRandomElement(nouns);
        var noun2 = GetRandomElement(nouns);

        var cyrillicPassword = $"{noun} {verb} {noun2}";
        var latinPassword = LanguageConvertor.ConvertToEnglishLayout(cyrillicPassword);
        var latinArray = latinPassword.Split(' ');
        var generatedPassword = Generate(latinArray);
        var strongPassword = GenerateStrongPassword(generatedPassword);

        return (T)Activator.CreateInstance(typeof(T),cyrillicPassword, latinPassword, strongPassword, DateTime.Now);
    }
    
    private static string GenerateStrongPassword(string generatedPassword)
    {
        var symbols = new[] { '!', '@', '#', '$', '%'};
        var index = _random.Next(symbols.Length);
        var randomSymbol = symbols[index];
        var randomNumber = _random.Next(100, 1000);

         return $"{randomNumber}{generatedPassword}{randomSymbol}";
    }
    
    private static string GetRandomElement(string[] array)
    {
        return array[_random.Next(array.Length)];
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