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
    public class NoticeOutput
    {
        /// <summary>
       /// 标题
       /// </summary>
       public string title { get; set; }

       /// <summary>
       /// 内容
       /// </summary>
     
       public string message { get; set; }

       /// <summary>
       /// 日期
       /// </summary>
       public string date { get; set; }
    }
}