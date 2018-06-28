using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Mvc.Context.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json.Serialization;
using AspNetCore.Mvc.Context.IDb;
using AspNetCore.Mvc.Context;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;
using System.Runtime.Loader;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AspNetCore.Mvc.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
         .SetBasePath(env.ContentRootPath)
         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = configuration;
            ConfigurationInfo = builder.Build();
            Configuration = configuration;
        }
        public IConfigurationRoot ConfigurationInfo { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc();
            services.AddOptions();
            //注入连接字符串
            services.AddSingleton<IConfigurationRoot>(ConfigurationInfo);

            //注入使用HttpContext
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddWebApiConventions();
            services.AddMvc().AddJsonOptions(option =>
            {
                //忽略循环引用
                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                //不使用驼峰样式的key
                option.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //设置时间格式
                option.SerializerSettings.DateFormatString = "yyyy-MM-dd";
            });

            //全局注册
            foreach (var itemClass in GetClassInterfacePairs("AspNetCore.Mvc.Context"))
            {
                foreach (var itemInterface in itemClass.Value)
                {
                    services.AddTransient(itemInterface, itemClass.Key);
                }
            }

            services.AddScoped(typeof(ISqlSugarBaseRepository<>), typeof(SqlSugarBaseRepository<>));

            //注册上下文对象
            services.AddTransient<SqlSugarFactoryContext>();

            //注册Session
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        #region  注册上下文，全局注入
        private Dictionary<Type, List<Type>> GetClassInterfacePairs(string assemblyName)
        {
            //存储 实现类 以及 对应接口 
            Dictionary<Type, List<Type>> dic = new Dictionary<Type, List<Type>>();
            Assembly assembly = GetAssembly(assemblyName);
            Type[] types = assembly.GetTypes();
            foreach (var item in types.AsEnumerable().Where(x => !x.IsAbstract && !x.IsInterface && !x.IsGenericType))
            {
                dic.Add(item, item.GetInterfaces().Where(x => !x.IsGenericType).ToList());
            }
            return dic;
        }


        private List<Assembly> GetAllAssemblies()
        {
            var list = new List<Assembly>();
            var deps = DependencyContext.Default;
            var libs = deps.CompileLibraries.Where(lib => !lib.Serviceable && lib.Type != "package");//排除所有的系统程序集、Nuget下载包
            foreach (var lib in libs)
            {
                try
                {
                    var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name));
                    list.Add(assembly);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            return list;
        }

        private Assembly GetAssembly(string assemblyName)
        {
            return GetAllAssemblies().FirstOrDefault(assembly => assembly.FullName.Contains(assemblyName));
        }
        #endregion



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            app.UseExceptionHandler("/error");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            //启用Cookie会话
            app.UseAuthentication();
            //注册session
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
