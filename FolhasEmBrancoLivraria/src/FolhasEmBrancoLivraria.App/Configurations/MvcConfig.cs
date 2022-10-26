using Microsoft.Extensions.DependencyInjection;

namespace FolhasEmBrancoLivraria.App.Configurations
{
    public static class MvcConfig
    {
        public static IServiceCollection AddMvcConfiguration(this IServiceCollection services)
        {
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
            return services;
        }
    }
}
