using Microsoft.EntityFrameworkCore;
using MobileExcursionApi.Context;
using MobileExcursionApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PostgresContext>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/getexcursions", async (PostgresContext dbcontext) => 
  await dbcontext.Excursions.OrderBy(e => e.ExcursionId).ToListAsync());

app.MapGet("/getdbversion", async (PostgresContext dbcontext) =>  
  await dbcontext.Dbversions.OrderByDescending(d => d.Version).FirstAsync());

app.MapGet("/getcomments/{excursionID}", async (int excursionID, PostgresContext dbcontex) =>
  await dbcontex.Comments.Where(c => c.ExcursionId == excursionID).OrderByDescending(c => c.CommentDate).ToListAsync());

app.MapPost("/leavecomment", async (Comment comment, PostgresContext dbcontext) =>
{
  comment.CommentDate = DateTime.UtcNow;
  await dbcontext.Comments.AddAsync(comment);
  await dbcontext.SaveChangesAsync();
  return Results.Ok(comment);
});

app.Run();
