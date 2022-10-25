using FolhasEmBrancoLivraria.App.Data;
using FolhasEmBrancoLivraria.App.Extensions;
using FolhasEmBrancoLivraria.Business.Interfaces;
using FolhasEmBrancoLivraria.Data.Context;
using FolhasEmBrancoLivraria.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Globalization;
using static FolhasEmBrancoLivraria.App.Extensions.MoedaAttribute;

namespace FolhasEmBrancoLivraria.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<DataDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAutoMapper(typeof(Startup));

            services.AddControllersWithViews(o =>
            {
                string mensagemValorInvalido = "O valor preenchido é inválido para este campo.";
                string mensagemValorNumerico = "O campo deve ser numérico.";
                string mensagemValorObrigatorio = "Este campo precisa ser preenchido.";
                string mensagemBodyObrigatorio = "É necessário que o body não esteja vazio.";


                o.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y)
                    => mensagemValorInvalido);
                o.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(x
                    => mensagemValorObrigatorio);
                o.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(()
                    => mensagemValorObrigatorio);
                o.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(()
                    => mensagemBodyObrigatorio);
                o.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor((x)
                    => mensagemValorInvalido);
                o.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(()
                    => mensagemValorInvalido);
                o.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(()
                    => mensagemValorNumerico);
                o.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor((x)
                    => mensagemValorInvalido);
                o.ModelBindingMessageProvider.SetValueIsInvalidAccessor((x)
                    => mensagemValorInvalido);
                o.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(x
                    => mensagemValorNumerico);
                o.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x
                    => mensagemValorObrigatorio);

            });
            services.AddRazorPages();
            services.AddScoped<DataDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            var defaultCulture = new CultureInfo("pt-BR");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };
            app.UseRequestLocalization(localizationOptions);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
