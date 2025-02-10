using Backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
 
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<KriptovaluteContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("KriptovaluteContext"));
});


var app = builder.Build();


app.MapOpenApi();


app.UseHttpsRedirection();

app.UseAuthorization();


app.UseSwagger();
app.UseSwaggerUI(o => {
    o.EnableTryItOutByDefault();
    o.ConfigObject.AdditionalItems.Add("requestSnippetsEnabled", true);
});

app.MapControllers();

app.Run();