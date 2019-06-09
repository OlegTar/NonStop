using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Application.Context;
using Application.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace Application
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddDbContext<NonStopContext>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddOpenApiDocument();

            //services.AddScoped<Database>((provider) =>
            //{
            //    return new DatabaseWithMVCMiniProfiler("MainConnectionString");
            //});

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "VK";
            })
        .AddCookie()
        .AddOAuth("VK", options =>
        {
            options.CallbackPath = new PathString("/callback");

            options.ClientId = "7014754";
            options.ClientSecret = "ZkitGPqJoCoU1I3KCvg1";
            
            options.Scope.Add("openid");
            options.Scope.Add("photo_50");

            options.AuthorizationEndpoint = "https://oauth.vk.com/authorize";
            options.TokenEndpoint = "https://oauth.vk.com/access_token";
            options.UserInformationEndpoint = "https://api.vk.com/method/users.get?v=5.95";

            options.Events = new OAuthEvents
            {
                OnCreatingTicket = async context =>
                {
                    var items = context.Properties.Items;

                    var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint + "&access_token=" + HttpUtility.UrlEncode(context.AccessToken) 
                        + "&fields=photo_50,bdate");
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

                    var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
                    response.EnsureSuccessStatusCode();

                    var str = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<VkViewModel>(str);
                    var idInOAuthProvider = "VK_" + user.Response[0].Id;
                    
                    using (var dbContext = new NonStopContext())
                    {

                        var person = dbContext.Persons.FirstOrDefault(p => p.IdInOAuthProvider == idInOAuthProvider);
                        if (person == null)
                        {
                            var birthDateParts = user.Response[0].Birthdate.Split('.').Select(p => int.Parse(p)).ToList();

                            dbContext.Persons.Add(new Models.Person()
                            {
                                Name = user.Response[0].FirstName,
                                Surname = user.Response[0].LastName,
                                Avatar = user.Response[0].Avatar,
                                BirthDate = new DateTime(birthDateParts[2], birthDateParts[1], birthDateParts[0]),
                                IdInOAuthProvider = idInOAuthProvider,
                                SessionId = items["sessionId"]
                            });
                        }
                        else
                        {
                            person.SessionId = items["sessionId"];
                            dbContext.Entry(person).State = EntityState.Modified;
                        }
                        await dbContext.SaveChangesAsync();
                    }
                }
            };
        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSwagger();
            app.UseSwaggerUi3();

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:4200", "https://localhost:44314")
                    .AllowAnyHeader()
                    .AllowAnyMethod());

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
