using PracticeDDD.Application;
using PracticeDDD.Infracstructure;
using PracticeDDD.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// techaid
builder.Services.ConfigureInfrastructureService(builder.Configuration);
builder.Services.ConfigurePersistenceService(builder.Configuration);
builder.Services.ConfigureApplicationService();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "PracticeDDD", Version = "v1" });
});

builder.Services.AddCors(a => a.AddPolicy("CorsPolicy", b =>
{
    b.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
