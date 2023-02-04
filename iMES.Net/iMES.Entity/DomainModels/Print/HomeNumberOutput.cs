using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iMES.Entity;
using Newtonsoft.Json.Linq;

namespace iMES.Entity.DomainModels
{
    public class HomeNumberOutput
    {
        /// <summary>
       /// 名称
       /// </summary>
       public string ItemName { get; set; }

       /// <summary>
       /// 背景颜色
       /// </summary>
     
       public string Background { get; set; }

       /// <summary>
       /// 编码
       /// </summary>
       public string ItemCode { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public string Qty { get; set; }
    }
}