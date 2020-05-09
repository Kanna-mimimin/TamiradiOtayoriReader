using System;
using System.Linq;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Linq;
using TamiradiOtayoriReader.Models;
using Prism.Ioc;

namespace TamiradiOtayoriReader.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ReactiveCollection<Models.Otayori> Otayoris { get; } = new ReactiveCollection<Models.Otayori>();
        public ReactiveProperty<Otayori> Otayori { get; } = new ReactiveProperty<Otayori>();
        public ReactiveProperty<int> OtayoriIndex { get; } = new ReactiveProperty<int>(-1);
        public ReactiveCommand BackCommand { get; }
        public ReactiveCommand NextCommand { get; }
        public ReactiveCommand OpenConfigCommand { get; } = new ReactiveCommand();
        bool IsConfigWindowOpend = false;
        public Config Config { get; }
        public string ConfigFilePath { get; }
        public ReactiveCommand<string> CsvFileLoadCmmand { get; } = new ReactiveCommand<string>();
        public ReactiveProperty<string> OtayoriImage { get; }


        public MainWindowViewModel(IDialogService dialogService)
        {
            System.Reflection.AssemblyTitleAttribute asmttl = (System.Reflection.AssemblyTitleAttribute)Attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(System.Reflection.AssemblyTitleAttribute));
            ConfigFilePath = $"{asmttl.Title}.json";

            if (System.IO.File.Exists(ConfigFilePath))
            {
                try
                {
                    var json = System.IO.File.ReadAllText(ConfigFilePath);
                    Config = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(json);
                }
                catch
                {
                    //上田が現れた！？スルーしちゃえ♪
                }
            }

            if(Config == null)
            {
                Config = new Config();
            }

            OtayoriImage = Config.BackgroundImagePath.Select(path =>
            {
                if (System.IO.File.Exists(path))
                {
                    return path;
                }

                return "/Resources/DefaultImg.png";
            }).ToReactiveProperty();

            OtayoriIndex.Subscribe(_ =>
            {
                if (OtayoriIndex.Value < 0)
                {
                    Otayori.Value = new Otayori() { Name = "みみみんねーむ", Content = "Googleフォームから集計CSVファイルをDLして読み込んでください" };
                }
                else
                {
                    Otayori.Value = Otayoris[OtayoriIndex.Value];
                }
            });

            OpenConfigCommand.Subscribe(() =>
            {
                if (!IsConfigWindowOpend)
                {
                    IsConfigWindowOpend = true;
                    IDialogResult result = null;
                    dialogService.Show(typeof(Views.SubWindow).FullName, null, ret => { result = ret; IsConfigWindowOpend = false; });
                }
            });


            CsvFileLoadCmmand.Execute("");
        }
    }
}
