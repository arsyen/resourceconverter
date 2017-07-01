using Ninject;
using ResourceConverter.Core;
using ResourceConverter.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ResourceConverter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel container;

        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigureContainer();

            MainWindow mainWindow = container.Get<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        private void ConfigureContainer()
        {
            this.container = new StandardKernel();
            container.Bind<MainWindow>().ToSelf();
            container.Bind<IResourceConverter>().To<DefaultResourceConverter>();
            container.Bind<IResourceProvider>().To<DefaultResourceProvider>();
        }
    }
}
