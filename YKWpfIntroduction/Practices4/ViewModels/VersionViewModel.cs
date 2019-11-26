using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practices4.Models;

namespace Practices4.ViewModels
{
    internal class VersionViewModel : NotificationObject
    {
        /// <summary>
        /// アプリケーションの正式名称を取得します
        /// </summary>
        public string ProductName
        {
            get { return ProductInfo.Product; }
        }

        /// <summary>
        /// アプリケーションタイトルを取得します
        /// </summary>
        public string Title
        {
            get { return ProductInfo.Title; }
        }

        /// <summary>
        /// バージョン番号を取得します
        /// </summary>
        public string Version
        {
            get { return "Ver." + ProductInfo.VersionString; }
        }

        public string Copyright
        {
            get { return ProductInfo.Copyright; }
        }
    }
}
