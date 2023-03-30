using demo1.chapter10.Interface;
using demo1.chapter10.user.ConfigureJWT_Login;
using demo1.chapter10.user.Identity_Register_Roles;
using demo1.Chapter3.HealthyCheck;
using demo1.entities;
using demo1.Interface;
using demo1.mongodb;
using demo1.repository.data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace demo1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure Cor
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });



            // Config mongodb 
            services.ConfigureMongoDbClient(Configuration);

            // Khai báo 
            services.AddSingleton<Idatarepository, datarepository>();

            // Mapping 
            services.AddAutoMapper(typeof(Mapping));

            // CHO PHÉP CHỨA HẬU TỐ ASYNC 
            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;

            });



            //---------------------------------Thêm healthycheck_ chương 3________________________
            services.AddHealthChecks()
                     .AddCheck("ICMP_01",
                     new ICMPHealthCheck("www.ryadel.com",
                     100))
                     .AddCheck("ICMP_02",
                     new ICMPHealthCheck("www.google.com",
                     100))
                     .AddCheck("ICMP_03",
                     new ICMPHealthCheck("www.does-not-exist.com",
                     100));


            //------------------------------------- Chương 10 ----------------------------------------------

            // Identity
            services.ConfigureIdentity();

            // Configure JWT
            services.ConfigureJWT(Configuration);

            //JWT_Login_Authen
            services.AddScoped<ILogin_JWT, Login_JWT>();

            // _______________________________________DỊCH VỤ TỪ PACKAGES_____________________________________________________________


            // VALIDATION___Model State
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });



            // CHO PHÉP CHỨA HẬU TỐ ASYNC 
            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;

            });


            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "demo1", Version = "v1" });
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "demo1 v1"));
            }
            else
            {
                app.UseHsts();
            }

            if (env.IsDevelopment()) // Cho phép chuyển hướng https nếu đây là chế độ development
            {
                app.UseHttpsRedirection();
            }
            app.UseStaticFiles();


            //CORS
            app.UseCors("CorsPolicy");

            // CHUYỂN TIẾP TIÊU ĐÈ PROXY ĐẾN YÊU CẦU HIỆN TẠI 
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseHttpsRedirection();

            app.UseRouting();


            //Identity_Authentication
            app.UseAuthentication();



            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // healthycheck chương 3_________________
                endpoints.MapHealthChecks("/hc", new CustomHealthCheckOptions());
                endpoints.MapControllers();
            });
        }
    }
}
