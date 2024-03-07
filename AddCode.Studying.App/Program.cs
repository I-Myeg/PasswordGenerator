using AddCode.Studying.Services.PasswordGenerator;

namespace AddCode.Studying.App;

internal abstract class Program
{
    private static void Main()
    {
        IPasswordGenerator generator;
        
        var parameter = File.ReadAllText(@".\Resources\params.txt");

        generator = parameter switch
        {
            "simple" => new PasswordGenerator(),
            "strong" => new StrongPassword(),
            _ => throw new AggregateException("Invalid parameter")
        };
        PrintPassword(generator);
    }

    private static void PrintPassword(IPasswordGenerator generator)
    {
        var password = generator.Generate();
        Console.WriteLine(password);
    }
}