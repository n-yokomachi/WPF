using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practices3.Models
{
    internal class Calculator
    {
        /// <summary>
        /// 被演算項を設定/取得する
        /// </summary>
        public double Lhs { get; set; }

        /// <summary>
        /// 演算項を設定/取得する
        /// </summary>
        public double Rhs { get; set; }

        /// <summary>
        /// 計算結果を取得する
        /// </summary>
        public double Result { get; private set; }

        /// <summary>
        /// 割り算を行う
        /// </summary>
        public void ExecuteDiv()
        {
            this.Result = this.Lhs / this.Rhs;
        }
    }
}
