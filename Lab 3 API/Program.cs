
using Azure;
using Lab_3_API.Data;
using Lab_3_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab_3_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddAuthorization();

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

            app.UseAuthorization();

            //Return all people
            app.MapGet("/peoples", async (ApplicationDbContext context) =>
            {
                var peoples = await context.Peoples.Include(c => c.Hobbys).ThenInclude(x => x.Webpages).ToListAsync();
                if (peoples == null || !peoples.Any())
                {
                    return Results.NotFound("Did not find any people");
                }
                return Results.Ok(peoples);
            });

            //Search for a name that contains a part of a string
            app.MapGet("/peoples/search", async (string search ,ApplicationDbContext context) =>
            {
                var peoples = await context.Peoples.Where(x => x.Name.Contains(search)).Include(c => c.Hobbys).ThenInclude(x => x.Webpages).ToListAsync();
                if (peoples == null || !peoples.Any())
                {
                    return Results.NotFound("Did not find any people");
                }
                return Results.Ok(peoples);
            });

            //Return people with pagination
            app.MapGet("/peoples/pages", async (int page, int pageSize, ApplicationDbContext context) =>
            {
                var totalcount = await context.Peoples.CountAsync();
                var totalPages = (int)Math.Ceiling((decimal)totalcount / pageSize);
                var peoples = await context.Peoples
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Include(c => c.Hobbys)
                    .ThenInclude(x => x.Webpages)
                    .ToListAsync();

                if (peoples == null || !peoples.Any())
                {
                    return Results.NotFound("Did not find any people");
                }
                return Results.Ok(peoples);
            });

            // Create a person
            app.MapPost("/peoples", async (Peoples peoples, ApplicationDbContext context) =>
            {
                context.Peoples.Add(peoples);
                await context.SaveChangesAsync();
                return Results.Created($"/peoples/{peoples.PeopleId}", peoples);
            });

            //Get info about a person by id
            app.MapGet("/peoples/{id:int}", async (int id, ApplicationDbContext context) =>
            {
                var people = await context.Peoples.FindAsync(id);
                if (people == null)
                {
                    return Results.NotFound("Did not find a person with that Id.");
                }
                else 
                {
                    var respones = await context.Peoples.Where(x => x.PeopleId == people.PeopleId).Include(x => x.Hobbys).ThenInclude(x => x.Webpages).ToListAsync();
                    return Results.Ok(respones);
                }

            });

            //Edit a person with their hobbys and webpages
            app.MapPut("/peoples/{id:int}", async (int id, Peoples updatedPeople, ApplicationDbContext context) =>
            {
                var people = await context.Peoples.FindAsync(id);

                if (people == null)
                {
                    return Results.NotFound("Did not find a person with that Id.");
                }
                else
                {
                    people.Name = updatedPeople.Name;
                    people.PhoneNumber = updatedPeople.PhoneNumber;
                    people.Hobbys = updatedPeople.Hobbys;
                    await context.SaveChangesAsync();
                    return Results.Ok(people);
                }
            });
            //Delete a person with all their hobbys and webpages
            app.MapDelete("/peoples/{id:int}", async (int id, ApplicationDbContext context) =>
            {
                var people = await context.Peoples.FindAsync(id);
                var response = await context.Peoples.Where(x => x.PeopleId == people.PeopleId).Include(x => x.Hobbys).ThenInclude(x => x.Webpages).FirstAsync();

                if (people == null)
                {
                    return Results.NotFound("Did not find a person with that Id.");
                }
                else
                {
                    context.Peoples.Remove(response);
                    await context.SaveChangesAsync();
                    return Results.Ok($"Person with ID: {id} deleted");
                }
            });

            app.Run();
        }
    }
}
