using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TamiradiOtayoriReader.ViewModels
{
    public class SubWindowViewModel : BindableBase, IDialogAware
    {
        public Reactive.Bindings.ReactiveProperty<IRegionManager> SubWindowManager { get; } = new Reactive.Bindings.ReactiveProperty<IRegionManager>();

        public SubWindowViewModel(RegionManager regionManager)
        {
            SubWindowManager.Value = regionManager.CreateRegionManager();
            SubWindowManager.Value.RegisterViewWithRegion("SubContentRegion", typeof(Views.ConfigWindow));
        }

        public string Title => "コントロールパネル";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return false;
        }

        public void OnDialogClosed()
        {
            SubWindowManager.Value.Regions.Remove("SubContentRegion");
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }
    }
}
