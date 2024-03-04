using AddCode.Studying.Services;

namespace AddCode.Studying.App;

internal abstract class Program
{
    private static void Main()
    {
        IPasswordGenerator generator;
        
        var parameter = File.ReadAllText(@".\Resources\params.txt"); 
        
        if (parameter == "simple")
        {
            generator = new PasswordGenerator();
        }
        else if (parameter == "strong")
        {
            generator = new StrongGenerator();
        }
        else
        {
            throw new AggregateException("Invalid parameter");
        }
        PrintPassword(generator);
    }

    private static void PrintPassword(IPasswordGenerator generator)
    {
        var password = generator.Generate();
        Console.WriteLine(password);
    }
}