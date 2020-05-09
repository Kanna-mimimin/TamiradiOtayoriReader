using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.IO;
using CsvHelper;
namespace TamiradiOtayoriReader.ViewModels
{
    public class ConfigWindowViewModel : BindableBase
    {
        public Models.Config Config { get; }

        public ReactiveCommand<string> CsvFileColumnLoadCmmand { get; }
        public ReactiveCollection<string> CsvColumnTitles { get; } = new ReactiveCollection<string>();
        public ReactiveCommand<string> CsvFileLoadCmmand { get; }
        public ReactiveCommand SaveCommand { get; } = new ReactiveCommand();

        public ReactiveProperty<Models.Otayori> Otayori { get; }
        public ReactiveProperty<Models.Otayori> OtayoriBackBack { get; } = new ReactiveProperty<Models.Otayori>();
        public ReactiveProperty<Models.Otayori> OtayoriBack { get; } = new ReactiveProperty<Models.Otayori>();
        public ReactiveProperty<Models.Otayori> OtayoriNext { get; } = new ReactiveProperty<Models.Otayori>();
        public ReactiveProperty<Models.Otayori> OtayoriNextNext { get; } = new ReactiveProperty<Models.Otayori>();
        public ReactiveCommand OtayoriBackBackCommand { get; }
        public ReactiveCommand OtayoriBackCommand { get; }
        public ReactiveCommand OtayoriNextCommand { get; }
        public ReactiveCommand OtayoriNextNextCommand { get; }

        public ReactiveProperty<int> OtayoriIndex { get; }
        public ReadOnlyReactiveProperty<int> OtayoriMax { get; }
        public ReadOnlyReactiveProperty<int> OtayoriMin { get; }

        public ReactiveCommand<string> NavigationCommand { get; } = new ReactiveCommand<string>();

        public ConfigWindowViewModel(SubWindowViewModel subWindowViewModel, MainWindowViewModel mainWindowViewModel)
        {
            Config = mainWindowViewModel.Config;
            Config.CsvFilePath.SetValidateNotifyError(path => System.IO.File.Exists(path) ? null : "CSVファイルを指定してください");

            CsvFileColumnLoadCmmand = Config.CsvFilePath.ObserveHasErrors.Inverse().ToReactiveCommand<string>();
            CsvFileColumnLoadCmmand.Subscribe(csvFilePath =>
            {
                CsvColumnTitles.Clear();

                if (!System.IO.File.Exists(csvFilePath))
                {
                    return;
                }

                try
                {
                    using (var reader = new CsvReader(new StreamReader(csvFilePath), System.Globalization.CultureInfo.CurrentCulture))
                    {
                        if (reader.Read())
                        {
                            var dictionary = reader.GetRecord<dynamic>() as IDictionary<string, object>;
                            CsvColumnTitles.AddRangeOnScheduler(dictionary.Keys);
                        }
                    }
                }
                catch
                {
                    //上田が現れた！？スルーしちゃえ♪
                }
            });


            CsvFileLoadCmmand = new[] { Config.NameColumnTitle.Select(str => String.IsNullOrEmpty(str)), Config.ContentColumnTitle.Select(str => String.IsNullOrEmpty(str)) }.CombineLatestValuesAreAllFalse().ToReactiveCommand<string>();
            CsvFileLoadCmmand.Subscribe(csvFilePath =>
            {
                mainWindowViewModel.Otayoris.Clear();
                OtayoriIndex.Value = -1;

                if (!System.IO.File.Exists(csvFilePath))
                {
                    return;
                }

                try
                {
                    using (var reader = new System.IO.StreamReader(csvFilePath))
                    using (var csv = new CsvHelper.CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture))
                    {
                        csv.Read();
                        csv.ReadHeader();
                        while (csv.Read())
                        {
                            var record = new Models.Otayori
                            {
                                Name = csv.GetField(Config.NameColumnTitle.Value),
                                Content = csv.GetField(Config.ContentColumnTitle.Value)
                            };
                            mainWindowViewModel.Otayoris.Add(record);
                        }
                    }

                    if (mainWindowViewModel.Otayoris.Count > 0)
                    {
                        OtayoriIndex.Value = 0;
                    }
                }
                catch
                {
                    //上田が現れた！？スルーしちゃえ♪
                }
            });

            SaveCommand.Subscribe(() =>
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(Config);
                System.IO.File.WriteAllText(mainWindowViewModel.ConfigFilePath, json);
            });

            Otayori = mainWindowViewModel.Otayori;

            OtayoriIndex = mainWindowViewModel.OtayoriIndex;
            OtayoriMin = mainWindowViewModel.Otayoris.ObserveProperty(x => x.Count).Select(num => (num == 0) ? 0 : 1).ToReadOnlyReactiveProperty();
            OtayoriMax = mainWindowViewModel.Otayoris.ObserveProperty(x => x.Count).ToReadOnlyReactiveProperty();

            OtayoriIndex.Subscribe(i =>
            {
                OtayoriBackBack.Value = (i > 1) ? mainWindowViewModel.Otayoris[OtayoriIndex.Value - 2] : null;
                OtayoriBack.Value = (i > 0) ? mainWindowViewModel.Otayoris[OtayoriIndex.Value - 1] : null;
                OtayoriNext.Value = (i + 1 < mainWindowViewModel.Otayoris.Count) ? mainWindowViewModel.Otayoris[OtayoriIndex.Value + 1] : null;
                OtayoriNextNext.Value = (i + 2 < mainWindowViewModel.Otayoris.Count) ? mainWindowViewModel.Otayoris[OtayoriIndex.Value + 2] : null;
            });

            OtayoriBackBackCommand = new[] { mainWindowViewModel.Otayoris.ObserveProperty(item => item.Count).Select(c => c > 0), OtayoriIndex.Select(i => i - 1 > 0) }.CombineLatestValuesAreAllTrue().ToReactiveCommand();
            OtayoriBackCommand = new[] { mainWindowViewModel.Otayoris.ObserveProperty(item => item.Count).Select(c => c > 0), OtayoriIndex.Select(i => i > 0) }.CombineLatestValuesAreAllTrue().ToReactiveCommand();
            OtayoriNextCommand = new[] { mainWindowViewModel.Otayoris.ObserveProperty(item => item.Count).Select(c => c > 0), OtayoriIndex.Select(i => i + 1 < mainWindowViewModel.Otayoris.Count) }.CombineLatestValuesAreAllTrue().ToReactiveCommand();
            OtayoriNextNextCommand = new[] { mainWindowViewModel.Otayoris.ObserveProperty(item => item.Count).Select(c => c > 0), OtayoriIndex.Select(i => i + 2 < mainWindowViewModel.Otayoris.Count) }.CombineLatestValuesAreAllTrue().ToReactiveCommand();

            OtayoriBackBackCommand.Subscribe(() => { OtayoriIndex.Value -= 2; });
            OtayoriBackCommand.Subscribe(() => { OtayoriIndex.Value -= 1; });
            OtayoriNextCommand.Subscribe(() => { OtayoriIndex.Value += 1; });
            OtayoriNextNextCommand.Subscribe(() => { OtayoriIndex.Value += 2; });


            NavigationCommand.Subscribe(window => subWindowViewModel.SubWindowManager.Value.RequestNavigate("SubContentRegion", window) );
        }
    }
}
