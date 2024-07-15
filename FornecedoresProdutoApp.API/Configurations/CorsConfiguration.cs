namespace UsuariosApp.API.Configurations
{ 
    public class CorsConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:5075")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }


        public static void Use(IApplicationBuilder app)
        {
            //Política de CORS
            app.UseCors("DefaultPolicy");
        }
    }
}
