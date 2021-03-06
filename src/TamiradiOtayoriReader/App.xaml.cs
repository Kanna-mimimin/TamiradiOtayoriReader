﻿using Prism.Ioc;
using TamiradiOtayoriReader.Views;
using System.Windows;

namespace TamiradiOtayoriReader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ViewModels.MainWindowViewModel>();
            containerRegistry.RegisterSingleton<ViewModels.ConfigWindowViewModel>();
            containerRegistry.RegisterSingleton<ViewModels.SubWindowViewModel>();
            containerRegistry.RegisterDialog<SubWindow>(typeof(SubWindow).FullName);

            containerRegistry.RegisterForNavigation<ConfigWindow>();
            containerRegistry.RegisterForNavigation<MiniControlPanelWindow, ViewModels.ConfigWindowViewModel>();
        }
    }
}
