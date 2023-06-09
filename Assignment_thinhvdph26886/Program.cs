using Assignment_thinhvdph26886.IServices;
using Assignment_thinhvdph26886.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProductServices, ProductServices>();
builder.Services.AddTransient<IRoleServices, RoleServices>();
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<ICartDetailServices, CartDetailServices>();
builder.Services.AddTransient<ICartServices, CartServices>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(60);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseStatusCodePagesWithReExecute("/Home/Index");
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
