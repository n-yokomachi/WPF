using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Practices4.ViewModels
{
    internal class MainViewModel : NotificationObject
    {
        private DelegateCommand _openFileCommand;
        /// <summary>
        /// ファイルを開くコマンドを取得する
        /// </summary>
        public DelegateCommand OpenFileCommand
        {
            get
            {
                return this._openFileCommand ?? (this._openFileCommand = new DelegateCommand(
                    _ =>
                    {
                        this.DialogCallback = OnDialogCallback;
                    }));
            }
        }


        public Func<bool> ClosingCallback
        {
            get { return OnExit; }
        }

        /// <summary>
        /// アプリケーション終了コマンドを取得する
        /// </summary>
        private DelegateCommand _exitCommand;
        public DelegateCommand ExitCommand
        {
            get
            {
                return this._exitCommand ?? (this._exitCommand = new DelegateCommand(
                    _ =>
                    {
                        OnExit();
                    }));
            }
        }

        private bool OnExit()
        {
            App.Current.Shutdown();
            return true;
        }

        private Action<bool, string> _dialogCallback;
        /// <summary>
        /// ダイアログに対するコールバックを取得する
        /// </summary>
        public Action<bool, string> DialogCallback
        {
            get { return this._dialogCallback; }
            private set { SetProperty(ref this._dialogCallback, value); }
        }

        /// <summary>
        /// ダイアログに対するコールバック処理を実行する
        /// </summary>
        /// <param name="isOk">ダイアログの結果を指定する</param>
        /// <param name="filePath">ファイルのフルパスを指定する</param>
        private void OnDialogCallback(bool isOk, string filePath)
        {
            this.DialogCallback = null;
            System.Diagnostics.Debug.WriteLine("isOk : {0}, filePath : {1}",
                isOk, filePath);
        }



        private VersionViewModel _versionViewModel = new VersionViewModel();
        /// <summary>
        /// VersionViewウインドウに対するデータコンテキストを取得する
        /// </summary>
        public VersionViewModel VersionViewModel
        {
            get { return this._versionViewModel; }
        }

        private DelegateCommand _versionDialogCommand;

        public DelegateCommand VersionDialogCommand
        {
            get
            {
                return this._versionDialogCommand = new DelegateCommand(
                    _ =>
                    {
                        this.VersionDialogCallback = OnVersionDialog;
                    });
            }
        }


        private Action<bool> _versionDialogCallback;
        /// <summary>
        /// バージョン情報表示コールバックを取得する
        /// </summary>
        public Action<bool> VersionDialogCallback
        {
            get { return this._versionDialogCallback; }
            private set { SetProperty(ref this._versionDialogCallback, value); }
        }

        /// <summary>
        /// バージョン情報表示コールバック処理を行う
        /// </summary>
        /// <param name="result"></param>
        private void OnVersionDialog(bool result)
        {
            this.VersionDialogCallback = null;
            System.Diagnostics.Debug.WriteLine(result);
        }


        private Timer _timer;
        private DateTime _currentTime;

        public DateTime CurrentTime
        {
            get
            {
                if (this._timer == null)
                {
                    this._currentTime = DateTime.Now;

                    this._timer = new Timer(1000);
                    this._timer.Elapsed += (_, __) =>
                    {
                        this.CurrentTime = DateTime.Now;
                    };
                    this._timer.Start();
                }
                return this._currentTime;
            }
            private set { SetProperty(ref this._currentTime, value); }
        }
    }
}
