using Microsoft.EntityFrameworkCore;
using ObjectBussiness;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    // Add Supportgropup
/*    app.MapDelete("supportgroup/{id}", async (string id, PetroleumBusinessDBContext db) =>
    {
        if (await db.News.FromSqlRaw($"select * from groups where supportgroup='{id}'").ToListAsync() is List<News> supportgroup)
        {
            await db.Database.ExecuteSqlRawAsync($"delete from groups where supportgroup='{id}'");
            return Results.Ok(supportgroup);
        }
        else
        {
            return Results.NotFound();
        }
    });*/
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
      name: "areas",
      pattern: "{area=Admin}/{controller=News}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
