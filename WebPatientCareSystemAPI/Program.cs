using Microsoft.EntityFrameworkCore;
using WebPatientCareSystemAPI;
using WebPatientCareSystemAPI.Data;
using WebPatientCareSystemAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<WebPatientCareSystemAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebPatientCareSystemAPIContext")));

builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/* --- TEST DATA ---
// Adding test data after running the application
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<WebPatientCareSystemAPIContext>();

    DataSeeder.Seed(context);
}

// Clear all data after exiting the application
app.Lifetime.ApplicationStopping.Register(() =>
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<WebPatientCareSystemAPIContext>();
        DataSeeder.Clear(context);
    }
});
*/
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();