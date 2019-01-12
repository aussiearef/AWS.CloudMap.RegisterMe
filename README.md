# AWS Cloud Map Register Me

## Allows ASP.Net Core-based microservices to register themselves with an already existing AWS Cloud Map Service.

In Startup.cs:


        public void ConfigureServices(IServiceCollection services)
        {
            services.UseCustomCloudMapClient<CloudMapClient>(); 
            // Add this line only if you use your own implementation of ICloudMapClient
            services.AddMvc();
        }

        
        public async  Task Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            await app.RegisterWithCloudMap(new CloudMapRegistrationOptions
            {
                ServiceId = "<your service Id>"
            });
            app.UseMvc();
        }
