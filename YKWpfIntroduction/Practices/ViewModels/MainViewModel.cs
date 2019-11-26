using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Practices.ViewModels
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
                return this._clearCommand ?? (
                    this._clearCommand = new DelegateCommand(_ =>
                    {
                        this.InputString = "";
                    },
                    _ => !string.IsNullOrWhiteSpace(this.InputString)));

            }
        }
    }

    internal class DelegateCommand : ICommand
    {
        // コマンド実行時の処理内容を保持
        private Action<object> _execute;

        // コマンド実行可能判別の処理内容を保持
        private Func<object, bool> _canExecute;

        // コンストラクタオーバーロード
        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {

        }

        // コンストラクタ
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        #region ICommandの実相
        /// <summary>
        /// コマンドが実行可能かどうかの判定処理を行う
        /// </summary>
        /// <param name="parameter">判定処理に対するパラメータ</param>
        /// <returns>実行可能な場合にtrueを返す</returns>
        public bool CanExecute(object parameter)
        {
            return (this._canExecute != null) ? this._canExecute(parameter) : true;
        }

        /// <summary>
        /// 実行可能判定処理に関する状態が変更されたときに発生
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// CanExecuteChangedイベントを発行
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var h = this.CanExecuteChanged;
            if (h != null) h(this, EventArgs.Empty);
        }

        /// <summary>
        /// コマンドが実行された時の処理
        /// </summary>
        /// <param name="parameter">コマンドに対するパラメータ</param>
        public void Execute(object parameter)
        {
            if (this._execute != null)
                this._execute(parameter);
        }
        #endregion
    }
}
