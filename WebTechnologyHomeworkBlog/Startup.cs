using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebTechnologyHomeworkBlog.Startup))]
namespace WebTechnologyHomeworkBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
