using aspnetserver.Data;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
    options.AddPolicy("CORSPolicy",
        builder => {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000", "https://appname.azurestaticapps.net");
        });
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(swaggerGenOptions => 
{
    swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP.NET React", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
//Ovo radimokako bimogli da izbrisemo
//"launchUrl": "swagger", izProperties/launchSettings
app.UseSwaggerUI(swaggerUIOptions => 
{
    swaggerUIOptions.DocumentTitle = "ASP.NET React";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json","Web Api serving a very simple Korisnicki model");
    swaggerUIOptions.RoutePrefix = string.Empty;
});


app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

app.MapGet("/get-all-korisnici", async () => await KorisnikRepository.GetPostAsync())
    .WithTags("Korisnici Endpoint");


app.MapGet("/get-all-korisnici-by-id{postId}", async (int postId) =>
{
    Korisnik korisnik = await KorisnikRepository.GetKorisnikAsyncById(postId);
    //Vraca one status kodove sto smo ucili
    if (korisnik != null)
    {
        return Results.Ok(korisnik);

    }
    else
    {
        return Results.BadRequest();
    }
}) .WithTags("Korisnici Endpoint");

app.MapPost("/create-korisnik", async (Korisnik korisnikToCreate) =>
{
    bool createdSuccessful = await KorisnikRepository.CreateKorisnikAsync(korisnikToCreate);

    if (createdSuccessful)
    {
        return Results.Ok("Create Succesfully");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Korisnici Endpoint");



app.MapPut("/update-korisnik", async (Korisnik korisnikToUpdate) =>
{
    bool updateSuccessful = await KorisnikRepository.UpdateKorisnikAsync(korisnikToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Updated Succesfully");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Korisnici Endpoint");

app.MapDelete("/delete-korisnik-by-id", async (int korisnikId) =>
{
    bool deleteSuccessful = await KorisnikRepository.DeleteKorisnikAsync(korisnikId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete Succesfully");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Korisnici Endpoint");

app.Run();