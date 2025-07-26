using System.Globalization;

namespace MyRecipeBook.APi.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;
        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);
            
            var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            var culturInfo = new CultureInfo("en");

            if (string.IsNullOrEmpty(requestedCulture) == false && 
                supportedLanguages.Any(c =>  c.Name.Equals(requestedCulture)))
            {
                culturInfo = new CultureInfo(requestedCulture);
            }

            CultureInfo.CurrentCulture = culturInfo;

            CultureInfo.CurrentUICulture = culturInfo;

            await _next(context);
        }
    }
}
