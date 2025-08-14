using Misoso.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDependencies(builder.Configuration);
builder.Services.ConfigureAuthentication(builder.Configuration);

//Configuring cors
builder.Services.AddCors(option =>
{
    option.AddPolicy("allowAny", x =>
    {
        x.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.ConfigureSwaggerAuthFunctionality(builder.Configuration);
var app = builder.Build();

//Setting cors policy
app.UseCors("allowAny");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
