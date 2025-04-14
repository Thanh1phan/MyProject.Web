using MyProject.Web.Services.IServices;
using MyProject.Web.Services;

namespace MyProject.Web.Config
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDI(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingConfig));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpClient<IAuthService, AuthService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddHttpClient<IProductService, ProductService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddSingleton<IApiMessageRequestBuilder, ApiMessageRequestBuilder>();
            services.AddScoped<IBaseService, BaseService>();
            services.AddScoped<ITokenProvider, TokenProvider>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}
