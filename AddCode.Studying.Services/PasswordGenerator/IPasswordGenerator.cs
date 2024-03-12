using AddCode.Studying.Services.Information;

namespace AddCode.Studying.Services.PasswordGenerator;

public interface IPasswordGenerator
{
    PasswordInfo Generate();
}