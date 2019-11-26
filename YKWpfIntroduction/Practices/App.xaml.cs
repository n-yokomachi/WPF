using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Practices.ViewModels;
using Practices.Views;

namespace Practices
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // ウインドウをインスタンス化
            var w = new MainView();
            // ウインドウに対するViewModelをインスタンス化
            var vm = new MainViewModel();
            // ウインドウに対するviewModelをデータコンテキストに指定
            w.DataContext = vm;
            // ウインドウを表示
            w.Show();
        }
    }
}
