namespace AddCode.Studying.Services.Models;

public static class LanguageConvertor
{
    public static string ConvertToEnglishLayout(string cyrillicPassword)
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
}