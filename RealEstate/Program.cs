using MediatR;
using RealEstate.CQRS;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Use_PostgreSQL_Context(builder.Configuration);
//builder.Services.Add_MicrosoftSQL_Context(builder.Configuration);

builder.Services.AddIdentityContext();
builder.Services.AddAuthentication();
//builder.Services.AddModelBinders();
builder.Services.AddApplicationServices();
builder.Services.AddMediatR(typeof(MediatREntryPoint).Assembly); //Reference to the CQRS Assembly

var app = builder.Build();

app.UseHttpsRedirection().UseStaticFiles();
app.UseRouting();
app.UseAuthentication().UseAuthorization();

app.MapControllerRoute(name: "Area", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

var developmentFlag = app.Environment.IsDevelopment() ? app.UseMigrationsEndPoint() : app.UseExceptionHandler("/Home/Error");

app.Run();