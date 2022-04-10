using System.Net;
using Microsoft.AspNetCore.Builder;

namespace M01.ExtendMethods
{
    public static class AppExtends
    {
        public static void AddStatusCodePages(this IApplicationBuilder app)
        {
            app.UseStatusCodePages(appEr =>
            {
                appEr.Run(async context =>
                {
                    var response = context.Response;
                    var code = response.StatusCode;

                    var content = @$"<html>
                        <head>
                            <meta charset='UTF-8' />
                            <title>{code}</title>
                        </head>
                        <body>
                            <p style='color: red; font-size: 30px;' >
                                có lỗi : {code} - {(HttpStatusCode)code}
                            </p>
                        </body>
                    </html>";
                    await response.WriteAsync(content);
                });
            });
        }
    }
}