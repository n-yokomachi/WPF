using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Practices3.Models;

namespace Practices3.ViewModels
{

    /// <summary>
    /// MainViewウインドウに対するデータコンテキスト
    /// </summary>
    internal class MainViewModel : NotificationObject
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainViewModel()
        {
            // 計算インスタンスを生成
            this._calc = new Calculator();
        }

        private string _lhs;
        /// <summary>
        /// 割られる数に指定される文字列を取得/設定する
        /// </summary>
        public string Lhs
        {
            get { return this._lhs; }
            set
            {
                if (SetProperty(ref this._lhs, value))
                {
                    this.DivCommand.RaiseCanExecuteChanged();
                }
            }
        }


        private string _rhs;
        /// <summary>
        /// 割る数に指定される文字列を取得/設定する
        /// </summary>
        public string Rhs
        {
            get { return this._rhs; }
            set
            {
                if (SetProperty(ref this._rhs, value))
                {
                    this.DivCommand.RaiseCanExecuteChanged();
                }
            }
        }


        private string _result;
        /// <summary>
        /// 計算結果を文字列として取得する
        /// </summary>
        public string Result
        {
            get { return this._result; }
            private set { SetProperty(ref this._result, value); }
        }


        private DelegateCommand _divCommand;
        /// <summary>
        /// 割り算コマンドの取得
        /// </summary>
        public DelegateCommand DivCommand
        {
            get
            {
                return this._divCommand ?? (this._divCommand = new DelegateCommand(
                    _ =>
                    {
                        OnDivision();
                    },
                    _ =>
                    {
                        var dummy = 0.0;
                        if (!double.TryParse(this.Lhs, out dummy))
                        {
                            return false;   // 変換不可,または未入力の場合はfalse(実行不可)
                        }
                        if (!double.TryParse(this.Rhs, out dummy))
                        {
                            return false;   // 変換不可,または未入力の場合はfalse(実行不可)
                        }
                        return true;
                    }));
            }
        }

        private Calculator _calc;
        /// <summary>
        /// 割り算処理
        /// </summary>
        public void OnDivision()
        {
            this._calc.Lhs = double.Parse(this.Lhs);
            this._calc.Rhs = double.Parse(this.Rhs);
            this._calc.ExecuteDiv();
            this.Result = this._calc.Result.ToString();
        }

    }


}
