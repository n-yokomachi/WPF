using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Practices2.ViewModels
{

    /// <summary>
    /// MainViewウインドウに対するデータコンテキスト
    /// </summary>
    internal class MainViewModel : NotificationObject
    {
        private string _upperString;
        /// <summary>
        /// すべて大文字に変換した文字列を取得
        /// </summary>
        public string UpperString
        {
            get { return this._upperString; }
            private set { SetProperty(ref this._upperString, value); }

        }


        private string _inputString;
        /// <summary>
        /// 入力文字列を受けつける
        /// </summary>
        public string InputString
        {
            get { return this._inputString; }
            set
            {
                if (SetProperty(ref this._inputString, value))
                {
                    this.UpperString = this.InputString.ToUpper();
                    this.ClearCommand.RaiseCanExecuteChanged();

                    System.Diagnostics.Debug.WriteLine("UpperString=" + this.UpperString);
                }
            }
        }

        private DelegateCommand _clearCommand;

        public DelegateCommand ClearCommand
        {
            get
            {
                if (this._clearCommand == null)
                {
                    this._clearCommand = new DelegateCommand(_ =>
                    {
                        this.InputString = "";
                    },
                    _ => !string.IsNullOrWhiteSpace(this.InputString));
                }
                return this._clearCommand;
            }
        }
    }


}
