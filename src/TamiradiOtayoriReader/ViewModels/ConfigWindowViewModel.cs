﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
namespace TamiradiOtayoriReader.ViewModels
{
    public class ConfigWindowViewModel : BindableBase, IDialogAware
    {
        public Models.Config Config { get; }
        public ReactiveCommand<string> CsvFileLoadCmmand { get; }
        public ReactiveCommand SaveCommand { get; } = new ReactiveCommand();

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
        public ReactiveProperty<int> Otayori { get; }


        public ConfigWindowViewModel(MainWindowViewModel mainWindowViewModel)
        {
            Config = mainWindowViewModel.Config;

            CsvFileLoadCmmand = new ReactiveCommand<string>();

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

            OtayoriIndex = mainWindowViewModel.OtayoriIndex;
            OtayoriMin = mainWindowViewModel.Otayoris.ObserveProperty(x => x.Count).Select(num => (num == 0) ? 0 : 1).ToReadOnlyReactiveProperty();
            OtayoriMax = mainWindowViewModel.Otayoris.ObserveProperty(x => x.Count).ToReadOnlyReactiveProperty();

            OtayoriIndex.Subscribe(i =>
            {
                OtayoriBackBack.Value  = (i > 1) ? mainWindowViewModel.Otayoris[OtayoriIndex.Value - 2] : null;
                OtayoriBack.Value = (i > 0) ? mainWindowViewModel.Otayoris[OtayoriIndex.Value - 1] : null;
                OtayoriNext.Value = (i +1 < mainWindowViewModel.Otayoris.Count) ? mainWindowViewModel.Otayoris[OtayoriIndex.Value + 1] : null;
                OtayoriNextNext.Value = (i +2 < mainWindowViewModel.Otayoris.Count) ? mainWindowViewModel.Otayoris[OtayoriIndex.Value + 2] : null;
            });

            OtayoriBackBackCommand = new[] { mainWindowViewModel.Otayoris.ObserveProperty(item => item.Count).Select(c => c > 0), OtayoriIndex.Select(i => i -1 > 0) }.CombineLatestValuesAreAllTrue().ToReactiveCommand();
            OtayoriBackCommand = new[] { mainWindowViewModel.Otayoris.ObserveProperty(item => item.Count).Select(c => c > 0), OtayoriIndex.Select(i => i > 0) }.CombineLatestValuesAreAllTrue().ToReactiveCommand();
            OtayoriNextCommand = new[] { mainWindowViewModel.Otayoris.ObserveProperty(item => item.Count).Select(c => c > 0), OtayoriIndex.Select(i => i + 1 < mainWindowViewModel.Otayoris.Count) }.CombineLatestValuesAreAllTrue().ToReactiveCommand();
            OtayoriNextNextCommand = new[] { mainWindowViewModel.Otayoris.ObserveProperty(item => item.Count).Select(c => c > 0), OtayoriIndex.Select(i => i + 2 < mainWindowViewModel.Otayoris.Count) }.CombineLatestValuesAreAllTrue().ToReactiveCommand();

            OtayoriBackBackCommand.Subscribe(() => { OtayoriIndex.Value -= 2; });
            OtayoriBackCommand.Subscribe(() =>{ OtayoriIndex.Value -= 1; });
            OtayoriNextCommand.Subscribe(() =>{ OtayoriIndex.Value += 1; });
            OtayoriNextNextCommand.Subscribe(() => { OtayoriIndex.Value += 2; });
        }

        public string Title => "コントロールパネル";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}