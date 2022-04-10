using M01.ExtendMethods;
using M01.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;
using M01.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.Configure<RazorViewEngineOptions>(option => {
    //thay đổi đường dẫn nếu không tìm thấy trong cấu trúc mặc định
    //  /Views/Controller/action   thành  /MyView/Controller/action

    //{0} ->Action
    //{1} ->Controller
    //{2} ->tên area
    //RazorViewEngine.ViewExtension là đuôi dạng file
    option.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
});

// builder.Services.AddSingleton<ProductService>();
// builder.Services.AddSingleton<ProductService, ProductService>();
// builder.Services.AddSingleton(typeof(ProductService));
builder.Services.AddSingleton(typeof(ProductService), typeof(ProductService));
builder.Services.AddSingleton(typeof(PlanetService), typeof(PlanetService));

// Đăng kí DbContext
builder.Services.AddDbContext<AppDbContext>(options => 
       options.UseSqlServer(builder.Configuration.GetConnectionString("AppMvcConnectionString")));

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

app.AddStatusCodePages(); // tùy biến trag khi có lỗi 400 lên
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.UseEndpoints(e => {
    e.MapGet("/hi", async context => {
        await context.Response.WriteAsync("conturt      " + DateTime.Now);
    });
    
});
 
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//các MapController :
// app.MapControllers()
// app.MapControllerRoute()
// app.MapDefaultControllerRoute()
// app.MapAreaControllerRoute();

app.MapControllerRoute(
    name: "firstroute", //tên route
    // pattern: "start-here/{id}",  //start-here or /start-here/1
    // defaults: new {
    //     controller = "First" ,
    //     action = "ViewProduct",
    //     id = 3
    // }
    
    pattern: "start-here/{controller=Home}/{action=Index}/{id?}"

    );

app.MapControllerRoute(
    name: "first",
    pattern: "{url}/{id}",
    defaults: new {
        controller = "First",
        action = "ViewProduct"
    },
    constraints: new {          //ràng buộc cho các giá trị
        // url = new StringRouteConstraint("xémanpham") or trực tiếp
        url = "xemsp",
        id = new RangeRouteConstraint(2,4)  
    } 
);

app.MapAreaControllerRoute(
    name: "product",
    pattern: "{controller=Home}/{action=Index}/{id?}",
    areaName: "ProductManage"
);

app.Run();
