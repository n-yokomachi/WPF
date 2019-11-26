using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Practices4.Views.Behaviors
{
    internal class OpenDialogBehavior
    {
        /// <summary>
        /// object型のDataContext添付プロパティ
        /// </summary>
        public static readonly DependencyProperty DataContextProperty =
            DependencyProperty.RegisterAttached("DataContext", typeof(object),
            typeof(OpenDialogBehavior), new PropertyMetadata(null));

        /// <summary>
        /// DataContext添付プロパティを取得する
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static object GetDataContext(DependencyObject target)
        {
            return target.GetValue(DataContextProperty);
        }

        /// <summary>
        /// DataContext添付プロパティを設定する
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public static void SetDataContext(DependencyObject target, object value)
        {
            target.SetValue(DataContextProperty, value);
        }


        /// <summary>
        /// Type型のWindowType添付プロパティを定義
        /// </summary>
        public static readonly DependencyProperty WindowTypeProperty =
            DependencyProperty.RegisterAttached("WindowType", typeof(Type),
            typeof(OpenDialogBehavior), new PropertyMetadata(null));

        /// <summary>
        /// WindowType添付プロパティを取得する
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Type GetWindowType(DependencyObject target)
        {
            return (Type)target.GetValue(WindowTypeProperty);
        }

        /// <summary>
        /// WindowType添付プロパティを設定する
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public static void SetWindowType(DependencyObject target, Type value)
        {
            target.SetValue(WindowTypeProperty, value);
        }


        /// <summary>
        /// Callback添付プロパティ
        /// </summary>
        public static readonly DependencyProperty CallbackProperty =
            DependencyProperty.RegisterAttached("Callback", typeof(Action<bool>),
            typeof(OpenDialogBehavior), new PropertyMetadata(null, OnCallbackPropertyChanged));

        /// <summary>
        /// Callback添付プロパティを取得する
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Action<bool> GetCallback(DependencyObject target)
        {
            return (Action<bool>)target.GetValue(CallbackProperty);
        }

        /// <summary>
        /// Callback添付プロパティを設定する
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public static void SetCallback(DependencyObject target, Action<bool> value)
        {
            target.SetValue(CallbackProperty, value);
        }

        /// <summary>
        /// Callback添付プロパティ変更イベントハンドラ
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnCallbackPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var callback = GetCallback(sender);
            if (callback != null)
            {
                var type = GetWindowType(sender);
                var obj = type.InvokeMember(null, System.Reflection.BindingFlags.CreateInstance,
                                            null, null, null);
                var child = obj as Window;
                if (child != null)
                {
                    child.DataContext = GetDataContext(sender);
                    var result = child.ShowDialog();
                    callback(result.Value);
                }
            }
        }
    }
}
