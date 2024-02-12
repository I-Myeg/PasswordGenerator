namespace passwordClass;

class Program
{
    static void Main()
    {
        GeneratePassword generatePassword = new GeneratePassword();
        DoPasswordInfo doPasswordInfo = generatePassword.PasswordInfo();
        Console.WriteLine(doPasswordInfo);
    }
}