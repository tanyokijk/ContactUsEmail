global using ContactUs.Services.EmailService;
global using ContactUs.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IEmailService, EmailService>();
var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapFallbackToPage("/ContactUs");
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
//app.UseAuthorization();

//app.MapControllers();

app.Run();
