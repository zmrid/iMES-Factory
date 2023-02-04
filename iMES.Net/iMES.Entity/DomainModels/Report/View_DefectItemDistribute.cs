/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果数据库字段发生变化，请在代码生器重新生成此Model
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iMES.Entity.SystemModels;

namespace iMES.Entity.DomainModels
{
    [Entity(TableCnName = "不良品项分布",TableName = "View_DefectItemDistribute")]
    public partial class View_DefectItemDistribute:SysEntity
    {
        /// <summary>
       ///主键ID
       /// </summary>
       [Key]
       [Display(Name ="主键ID")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid ID { get; set; }

       /// <summary>
       ///时间
       /// </summary>
       [Display(Name ="时间")]
       [Column(TypeName="varchar")]
       public DateTime? CreateDate { get; set; }

       /// <summary>
       ///不良品项编号
       /// </summary>
       [Display(Name ="不良品项编号")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string DefectItemCode { get; set; }

       /// <summary>
       ///不良品项名称
       /// </summary>
       [Display(Name ="不良品项名称")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string DefectItemName { get; set; }

       /// <summary>
       ///数量
       /// </summary>
       [Display(Name ="数量")]
       [Column(TypeName="int")]
       public int? Qty { get; set; }

       /// <summary>
       ///总数量
       /// </summary>
       [Display(Name ="总数量")]
       [Column(TypeName="int")]
       public int? AllQty { get; set; }

       /// <summary>
       ///占比
       /// </summary>
       [Display(Name ="占比")]
       [MaxLength(101)]
       [Column(TypeName="varchar(101)")]
       public string PassPercent { get; set; }

       
    }
}