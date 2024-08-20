using Carter;
using Microsoft.AspNetCore.Builder;

namespace UserManagementPresentation
{
    public static class MapPresentationLayerExtension
    {
        public static IApplicationBuilder MapPresentationLayer(this IApplicationBuilder app)
        {
            app.UseRouting();

            // Carter'ı veya diğer endpoint yapılandırmalarını buraya ekleyin
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapCarter(); // Carter endpoint'lerini haritalandırın
            });

            return app;
        }
    }
}