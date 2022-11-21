using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineChat.PersistantMain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//========Connect To Sql=========
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings")));
//========Connect To Sql=========

//========Authorization=========
//builder.Services.AddAuthorization(options =>
//{
//    // load all features from DB
//    var features = rolesProvider.GetAllFeatures(validationContainer);

//    // Add policy foreach feature in DB
//    foreach (var feature in features)
//    {
//        options.AddPolicy(feature.Name, policy => policy.Requirements.Add(new FeatureRequirement(feature.Name)));
//    }
//});
//========Authorization=========

//==========Swagger============
builder.Services.AddSwaggerGen();
//==========Swagger============



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//==========Swagger============
app.UseSwagger();
app.UseSwaggerUI();
//==========Swagger============

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
