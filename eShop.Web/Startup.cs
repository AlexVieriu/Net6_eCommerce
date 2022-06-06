namespace eShop.Web;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddRazorPages();
        services.AddServerSideBlazor();

        services.AddAuthentication("eShop.CookieAuth")
                .AddCookie("eShop.CookieAuth", config =>
                {
                    config.Cookie.Name = "eShop.CookieAuth";
                    config.LoginPath = "/login";
                });

        services.AddSingleton<IProductRepository, ProductRepository>();
        services.AddSingleton<IOrderRepository, OrderRepository>();

        services.AddScoped<IShoppingCart, ShopingCartBase>();
        services.AddScoped<IShoppingCartStateStore, StateStoreShoppingCart>();

        services.AddTransient<IOrderService, OrderService>();

        services.AddTransient<ISearchProductsUseCase, SearchProductsUseCase>();
        services.AddTransient<IViewProductUseCase, ViewProductUseCase>();

        services.AddTransient<IAddProductToCartUseCase, AddProductToCartUseCase>();

        services.AddTransient<IViewShoppingCartUseCase, ViewShoppingCartUseCase>();
        services.AddTransient<IUpdateQuantityUseCase, UpdateQuantityUseCase>();
        services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();

        services.AddTransient<IPlaceOrderUseCase, PlaceOrderUseCase>();
        services.AddTransient<IViewOrderConfirmationUseCase, ViewOrderConfirmationUseCase>();

        services.AddTransient<IViewOutstandingOrdersUseCase, ViewOutstandingOrdersUseCase>();
        services.AddTransient<IViewProcessedOrdersUseCase, ViewProcessedOrdersUseCase>();
        services.AddTransient<IViewOrderDetailUseCase, ViewOrderDetailUseCase>();
        services.AddTransient<IProcessOrderUseCase, ProcessOrderUseCase>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
    }
}
