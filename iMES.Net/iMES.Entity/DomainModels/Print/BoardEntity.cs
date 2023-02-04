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
    public class BoardEntity
    {
        /// <summary>
       /// 名称
       /// </summary>
       public string name { get; set; }

       /// <summary>
       /// 数值
       /// </summary>
     
       public int data { get; set; }
    }
}