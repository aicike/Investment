using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemindTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("The first app in Beginning C# Programming!");  
      

        }

        #region 流程定期提醒 
        /// <summary>
        /// 提前一天提醒出纳放款（自有资金）
        /// </summary>
        public void RemindCNFK()
        {
            System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(() =>
            {
               
            });
        }

        /// <summary>
        /// 放款后收利息提醒 （自有资金） 提前5天通知项目经理，如未收利息提前3天通知财务总监
        /// </summary>
        public void RemindLX()
        {
            System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(() =>
            {

            });
        }
        #endregion
        
    }
}
