Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting

Module Program
    Sub Main(args As String())
        Dim builder = WebApplication.CreateBuilder(args)

        ' builder.WebHost.UseStaticWebAssets()

        ' Enable Razor Pages AND Runtime Compilation
        builder.Services.AddRazorPages() _
                        .AddRazorRuntimeCompilation()
        Dim app = builder.Build()

        if Not app.Environment.IsDevelopment() then
            app.UseExceptionHandler("/Error")
            app.UseHsts()
        end if

        ' app.UseHttpsRedirection()
        ' Serve CSS, JS, and images from wwwroot
        app.UseStaticFiles()
        app.UseRouting()

        'app.UseAuthorization()

        app.MapStaticAssets()
        ' app.MapGet("/", Function() "Hello World from VB.NET Web App!")
        app.MapRazorPages() _
            .WithStaticAssets()
        app.Run()
    End Sub
End Module