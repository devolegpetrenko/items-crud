using FluentValidation;
using ItemsCrud.Persistence;
using ItemsCrud.Services;
using ItemsCrud.Validators;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCorsPolicy", builder =>
    {
        builder
            .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddValidatorsFromAssemblyContaining<ItemViewModelValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddDbContext<ItemsContext>();
builder.Services.AddTransient<IItemsService, ItemsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("DevCorsPolicy");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();