using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Practices4
{
    internal abstract class NotificationObject : INotifyPropertyChanged
    {

        #region INotifyPropertyChangedの実装
        // プロパティに変更があった場合に発生
        public event PropertyChangedEventHandler PropertyChanged;

        // PropertyChangedイベントを発行
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            var h = this.PropertyChanged;
            if (h != null) h(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// プロパティの値を編集するヘルパ
        /// </summary>
        /// <typeparam name="T">プロパティの型</typeparam>
        /// <param name="target">変更対象のプロパティ</param>
        /// <param name="value">変更後の値</param>
        /// <param name="propertyName">プロパティ名（自動設定）</param>
        /// <returns>プロパティに変更があった場合にtrueを返す</returns>
        protected bool SetProperty<T>(ref T target, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(target, value))
                return false;
            target = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}
