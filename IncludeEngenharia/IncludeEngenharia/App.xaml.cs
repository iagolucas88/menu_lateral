using Prism;
using Prism.Ioc;
using IncludeEngenharia.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.DryIoc;

using System;
using System.Collections.Generic;
using System.Linq;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace IncludeEngenharia
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */


        public static string DatabaseLocation = string.Empty;

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {

        }

        public App(string databaseLocation, IPlatformInitializer initializer = null) : base(initializer) 
        {
            DatabaseLocation = databaseLocation;
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("MainPage/Navigation/Inicio");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Navigation>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<Inicio>();
            containerRegistry.RegisterForNavigation<Destaques>();
            containerRegistry.RegisterForNavigation<Categorias>();
            containerRegistry.RegisterForNavigation<Favoritos>();
            containerRegistry.RegisterForNavigation<HistoricoDeBuscas>();
            containerRegistry.RegisterForNavigation<MinhasCompras>();
            containerRegistry.RegisterForNavigation<Configuracoes>();
            containerRegistry.RegisterForNavigation<SobreOApp>();
        }
    }
}
