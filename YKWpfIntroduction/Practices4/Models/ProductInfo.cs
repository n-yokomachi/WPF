﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Practices4.Models
{
    /// <summary>
    /// プロダクト情報を取得するための静的なクラスを表します
    /// </summary>
    public static class ProductInfo
    {
        /// <summary>
        /// 自分のアセンブリを保持します。
        /// </summary>
        private static Assembly assembly = Assembly.GetExecutingAssembly();

        private static string title;
        /// <summary>
        /// アプリケーションの名前を取得します
        /// </summary>
        public static string Title
        {
            get { return title ?? (title = ((AssemblyTitleAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyTitleAttribute))).Title); }
        }

        private static string description;
        /// <summary>
        /// アプリケーションの詳細を取得します
        /// </summary>
        public static string Description
        {
            get { return description ?? (description = ((AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyDescriptionAttribute))).Description); }
        }

        private static string company;
        /// <summary>
        /// アプリケーションの開発元を取得します
        /// </summary>
        public static string Company
        {
            get { return company ?? (company = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyCompanyAttribute))).Company); }
        }

        private static string product;
        /// <summary>
        /// アプリケーションのプロダクト名を取得します
        /// </summary>
        public static string Product
        {
            get { return product ?? (product = ((AssemblyProductAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyProductAttribute))).Product); }
        }

        private static string copyright;
        /// <summary>
        /// アプリケーションのコピーライトを取得します
        /// </summary>
        public static string Copyright
        {
            get { return copyright ?? (copyright = ((AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyCopyrightAttribute))).Copyright); }
        }

        private static string trademark;
        /// <summary>
        /// アプリケーションのトレードマークを取得します
        /// </summary>
        public static string Trademark
        {
            get { return trademark ?? (trademark = ((AssemblyTrademarkAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyTrademarkAttribute))).Trademark); }
        }

        private static Version version;
        /// <summary>
        /// アプリケーションのバージョンを取得します
        /// </summary>
        public static Version Version
        {
            get { return version ?? (version = assembly.GetName().Version); }
        }

        private static string versionString;
        /// <summary>
        /// アプリケーションのバージョン文字列を取得します
        /// </summary>
        public static string VersionString
        {
            get
            {
                return versionString ?? (versionString = 
                    string.Format("{0} {1} {2} {3}",
                                  Version.ToString(3),
                                  IsBetaMode ? "β" : "",
                                  Version.Revision == 0 ? "" : "rev." + Version.Revision,
                                  IsDebugMode ? "Debug Mode" : ""));
            }
        }

        /// <summary>
        /// ビルド時のCLRバージョン文字列を取得します
        /// </summary>
        public static string CLRBuildVerison
        {
            get { return System.Reflection.Assembly.GetExecutingAssembly().ImageRuntimeVersion; }
        }

        public static string CLRExecuteVersion
        {
            get { return System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion(); }
        }

        /// <summary>
        /// デバッグモードかどうか確認します
        /// </summary>
        public static bool IsDebugMode
        {
#if DEBUG
            get { return true; }
#else
            get { return false; }
#endif
        }

        /// <summary>
        /// ベータ版かどうか確認します
        /// </summary>
        public static bool IsBetaMode
        {
#if BETA
            get { return true; }
#else
            get { return false; }
#endif
        }
    }
}
