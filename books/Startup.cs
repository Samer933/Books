using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(books.Startup))]
namespace books
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
