using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace Practices4.Views.Behaviors
{
    /// <summary>
    /// コモンダイアログに関するビヘイビアを表す
    /// </summary>
    internal class CommonDialogBehavior
    {
        #region Callback 添付プロパティ

        /// <summary>
        /// Action<bool, string>型のCallback添付プロパティを定義する
        /// </summary>
        public static readonly DependencyProperty CallbackProperty =
            DependencyProperty.RegisterAttached("Callback", typeof(Action<bool, string>),
            typeof(CommonDialogBehavior), new PropertyMetadata(null, OnCallbackPropertyChanged));

        /// <summary>
        /// Callback添付プロパティを取得する
        /// </summary>
        /// <param name="target">対象とするDependencyObjectを指定</param>
        /// <returns>取得した値を返却</returns>
        public static Action<bool, string> GetCallback(DependencyObject target)
        {
            return (Action<bool, string>)target.GetValue(CallbackProperty);
        }

        /// <summary>
        /// Callback添付プロパティを設定する
        /// </summary>
        /// <param name="target">対象とするDependencyObjectを指定</param>
        /// <param name="value">設定する値を指定</param>
        public static void SetCallback(DependencyObject target, Action<bool, string> value)
        {
            target.SetValue(CallbackProperty, value);
        }
        #endregion

        #region Title添付プロパティ
        public static readonly DependencyProperty TitleProperty = 
            DependencyProperty.RegisterAttached("Title", typeof(string), typeof(CommonDialogBehavior), new PropertyMetadata("ファイルを開く"));

        public static string GetTitle(DependencyObject target)
        {
            return (string)target.GetValue(TitleProperty);
        }

        public static void SetTitle(DependencyObject target, string value)
        {
            target.SetValue(TitleProperty, value);
        }
        #endregion

        #region Filter添付プロパティ
        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.RegisterAttached("Filter", typeof(string), typeof(CommonDialogBehavior), new PropertyMetadata("すべてのファイル (*.*)|*.*"));

        public static string GetFilter(DependencyObject target)
        {
            return (string)target.GetValue(FilterProperty);
        }

        public static void SetFilter(DependencyObject target, string value)
        {
            target.SetValue(FilterProperty, value);
        }
        #endregion

        public static readonly DependencyProperty MultiselectProperty =
            DependencyProperty.RegisterAttached("Multiselect", typeof(bool), typeof(CommonDialogBehavior), new PropertyMetadata(true));

        public static bool GetMultiselect(DependencyObject target)
        {
            return (bool)target.GetValue(MultiselectProperty);
        }

        public static void SetMultiselect(DependencyObject target, bool value)
        {
            target.SetValue(MultiselectProperty, value);
        }

        /// <summary>
        /// Callback添付プロパティ変更イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnCallbackPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var callback = GetCallback(sender);
            if (callback != null)
            {
                var dlg = new OpenFileDialog()
                {
                    Title = GetTitle(sender),
                    Filter = GetFilter(sender),
                    Multiselect = GetMultiselect(sender)
                };

                var owner = Window.GetWindow(sender);
                var result = dlg.ShowDialog(owner);
                callback(result.Value, dlg.FileName);
            }
        }
    }
}
