using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iMES.Entity;

namespace iMES.Entity.DomainModels
{
    public class PrintFieldOutput
    {
        /// <summary>
       ///数据
       /// </summary>
       public List<filed> data { get; set; }
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
    public class filed
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<filedDetail> fields { get; set; }

        public string tag { get; set; }
    }
    public class filedDetail
    {
        public string key { get; set; }
        public string name { get; set; }
    }
}