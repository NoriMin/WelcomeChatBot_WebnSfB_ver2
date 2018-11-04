using Autofac;
using System.Web.Http;
using System.Reflection;
using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Connector;

namespace WelcomeChatBot_WebnSfB_ver2
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Conversation.UpdateContainer(
                builder =>
                {

                    builder.RegisterModule(new AzureModule(Assembly.GetExecutingAssembly()));

                    var store = new InMemoryDataStore();

                    builder.Register(c => store)
                        .Keyed<IBotDataStore<BotData>>(AzureModule.Key_DataStore)
                        .AsSelf()
                        .SingleInstance();

                    builder.RegisterType<Microsoft.Bot.Builder.History.TraceActivityLogger>().AsImplementedInterfaces().InstancePerDependency(); // All Logs Collector (JSON)

                });

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }


    }
}
