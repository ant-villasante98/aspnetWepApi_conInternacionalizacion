var builder = WebApplication.CreateBuilder(args);

// Internalizacion con tipo de lenguaje en la cabecera de la peticion

// Add services to the container.
// 1. Localizacion
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. Suported Cultures
var suportedCultures = new[] { "en-US", "es-ES", "fr-FR" };// USA's englis , Spain's Spanish and France's french
var localizacionOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(suportedCultures[0])
    .AddSupportedCultures(suportedCultures)
    .AddSupportedUICultures(suportedCultures);
// 3. Add Localization to app
app.UseRequestLocalization(localizacionOptions);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
