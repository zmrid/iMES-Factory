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
    [Entity(TableCnName = "不良品项汇总",TableName = "View_DefectItemSummary")]
    public partial class View_DefectItemSummary:SysEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="ID")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid ID { get; set; }

       /// <summary>
       ///工单编号
       /// </summary>
       [Display(Name ="工单编号")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string WorkOrderCode { get; set; }

       /// <summary>
       ///产品编号
       /// </summary>
       [Display(Name ="产品编号")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string ProductCode { get; set; }

       /// <summary>
       ///产品名称
       /// </summary>
       [Display(Name ="产品名称")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string ProductName { get; set; }

       /// <summary>
       ///产品规格
       /// </summary>
       [Display(Name ="产品规格")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string ProductStandard { get; set; }

       /// <summary>
       ///工序编号
       /// </summary>
       [Display(Name ="工序编号")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string ProcessCode { get; set; }

       /// <summary>
       ///工序名称
       /// </summary>
       [Display(Name ="工序名称")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string ProcessName { get; set; }

       /// <summary>
       ///生产人员
       /// </summary>
       [Display(Name ="生产人员")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string UserTrueName { get; set; }

       /// <summary>
       ///生产开始时间
       /// </summary>
       [Display(Name ="生产开始时间")]
       [Column(TypeName="datetime")]
       public DateTime? StartDate { get; set; }

       /// <summary>
       ///生产结束时间
       /// </summary>
       [Display(Name ="生产结束时间")]
       [Column(TypeName="datetime")]
       public DateTime? EndDate { get; set; }

       /// <summary>
       ///不良品项
       /// </summary>
       [Display(Name ="不良品项")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Required(AllowEmptyStrings=false)]
       public string DefectItem { get; set; }

       /// <summary>
       ///不良品项
       /// </summary>
       [Display(Name ="不良品项")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string DefectItemName { get; set; }

       /// <summary>
       ///工序计划数
       /// </summary>
       [Display(Name ="工序计划数")]
       [Column(TypeName="int")]
       public int? PlanQty { get; set; }

       /// <summary>
       ///报工数
       /// </summary>
       [Display(Name ="报工数")]
       [Column(TypeName="int")]
       public int? ReportQty { get; set; }

       /// <summary>
       ///良品数
       /// </summary>
       [Display(Name ="良品数")]
       [Column(TypeName="int")]
       public int? GoodQty { get; set; }

       /// <summary>
       ///不良品数
       /// </summary>
       [Display(Name ="不良品数")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int NoGoodQty { get; set; }

       /// <summary>
       ///不良品率
       /// </summary>
       [Display(Name ="不良品率")]
       [MaxLength(101)]
       [Column(TypeName="varchar(101)")]
       public string NoPassPercent { get; set; }

       
    }
}