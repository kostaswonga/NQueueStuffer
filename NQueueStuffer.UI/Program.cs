using System;
using System.Configuration;
using System.Windows.Forms;
using NQueueStuffer.Core;
using NQueueStuffer.UI.Controller;
using NQueueStuffer.UI.View;
using Autofac;

namespace NQueueStuffer.UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var container = SetupContainer();
            Application.Run(new MdiForm(container));
        }

        private static IContainer SetupContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AssemblyFetcher>().As<IAssemblyFetcher>();
            builder.RegisterType<QueueStufferView>().As<IQueueStufferView>();
            builder.RegisterType<QueueStufferController>().As<IQueueStufferController>();

            return builder.Build();
        }
    }
}
