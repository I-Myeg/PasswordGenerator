using AddCode.Studying.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("PasswordInformation", () =>
    {
        var passwordGenerator = new PasswordGenerator();
        var passwordInfo = passwordGenerator.Generate();
        return passwordInfo.ToString();
    })
    .WithName("GetPasswordInformation")
    .WithOpenApi();

app.Run();
