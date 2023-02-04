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
    public class HomeProcessNumberOutput
    {
        /// <summary>
       /// 工序名称
       /// </summary>
       public string ProcessName { get; set; }

       /// <summary>
       /// 计划数
       /// </summary>
     
       public string PlanQty { get; set; }

       /// <summary>
       /// 良品数
       /// </summary>
       public string GoodQty { get; set; }

        /// <summary>
        /// 不良品数
        /// </summary>
        public string NoGoodQty { get; set; }
    }
}