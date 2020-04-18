﻿using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamiradiOtayoriReader.Models
{
    public class Config
    {
        public ReactiveProperty<string> CsvFilePath { get; } = new ReactiveProperty<string>(@"C:\おたより集計.csv");
        public ReactiveProperty<string> BackgroundImagePath { get; } = new ReactiveProperty<string>(@"C:\otayori.png");
        public ReactiveProperty<string> NameColumnTitle { get; } = new ReactiveProperty<string>("お名前");
        public ReactiveProperty<string> ContentColumnTitle { get; } = new ReactiveProperty<string>("お題");
        public ReactiveProperty<bool> IsVisibleOtayori { get; } = new ReactiveProperty<bool>(true);

        //お名前表示調整
        public ReactiveProperty<string> Keisyou { get; } = new ReactiveProperty<string>("　さん");
        public ReactiveProperty<int> NameFontSize { get; } = new ReactiveProperty<int>(28);
        public ReactiveProperty<int> KeisyouFontSize { get; } = new ReactiveProperty<int>(24);
        public ReactiveProperty<bool> IsNameFill { get; } = new ReactiveProperty<bool>(true);
        public ReactiveProperty<bool> IsVisibleNameGridSpliter { get; } = new ReactiveProperty<bool>(false);
        public ReactiveProperty<double> NameGridSplitterLeft { get; } = new ReactiveProperty<double>(70);
        public ReactiveProperty<double> NameGridSplitterRight { get; } = new ReactiveProperty<double>(150);
        public ReactiveProperty<double> NameGridSplitterTop { get; } = new ReactiveProperty<double>(40);
        public ReactiveProperty<double> NameGridSplitterBottom { get; } = new ReactiveProperty<double>(710);

        //本文表示調整
        public ReactiveProperty<int> ContentFontSize { get; } = new ReactiveProperty<int>(20);
        public ReactiveProperty<bool> IsContentFill { get; } = new ReactiveProperty<bool>(false);
        public ReactiveProperty<bool> IsContentWrap { get; } = new ReactiveProperty<bool>(true);
        public ReactiveProperty<bool> IsVisibleContentGridSpliter { get; } = new ReactiveProperty<bool>(false);
        public ReactiveProperty<double> ContentGridSplitterLeft { get; } = new ReactiveProperty<double>(50);
        public ReactiveProperty<double> ContentGridSplitterRight { get; } = new ReactiveProperty<double>(40);
        public ReactiveProperty<double> ContentGridSplitterTop { get; } = new ReactiveProperty<double>(110);
        public ReactiveProperty<double> ContentGridSplitterBottom { get; } = new ReactiveProperty<double>(30);

        //おたより数表示表調整
        public ReactiveProperty<bool> IsVisibleCounter { get; } = new ReactiveProperty<bool>(true);
        public ReactiveProperty<int> CounterFontSize { get; } = new ReactiveProperty<int>(22);
        public ReactiveProperty<bool> IsVisibleCounterGridSpliter { get; } = new ReactiveProperty<bool>(false);
        public ReactiveProperty<double> CounterGridSplitterLeft { get; } = new ReactiveProperty<double>(210);
        public ReactiveProperty<double> CounterGridSplitterTop { get; } = new ReactiveProperty<double>(35);

    }
}
