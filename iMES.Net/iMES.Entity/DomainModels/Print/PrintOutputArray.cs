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
    public class PrintOutputArray
    {
        /// <summary>
       ///数据
       /// </summary>
       public JArray data { get; set; }

       /// <summary>
       ///消息
       /// </summary>
     
       public string message { get; set; }

       /// <summary>
       ///状态
       /// </summary>
       public int status { get; set; }
       
       public bool success { get; set; }
    }
}