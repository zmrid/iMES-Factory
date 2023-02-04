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
    [Entity(TableCnName = "员工绩效",TableName = "View_EmployeePerformance")]
    public partial class View_EmployeePerformance:SysEntity
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
       ///生产人员
       /// </summary>
       [Display(Name ="生产人员")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Required(AllowEmptyStrings=false)]
       public string ProductUser { get; set; }

       /// <summary>
       ///生产人员
       /// </summary>
       [Display(Name ="生产人员")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string UserTrueName { get; set; }

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
       ///产品编号
       /// </summary>
       [Display(Name ="产品编号")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Required(AllowEmptyStrings=false)]
       public string ProductCode { get; set; }

       /// <summary>
       ///产品名称
       /// </summary>
       [Display(Name ="产品名称")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Required(AllowEmptyStrings=false)]
       public string ProductName { get; set; }

       /// <summary>
       ///产品规格
       /// </summary>
       [Display(Name ="产品规格")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string ProductStandard { get; set; }

       /// <summary>
       ///单位
       /// </summary>
       [Display(Name ="单位")]
       [Column(TypeName="int")]
       public int? Unit_Id { get; set; }

       /// <summary>
       ///单位
       /// </summary>
       [Display(Name ="单位")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string UnitName { get; set; }

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
       ///合格率
       /// </summary>
       [Display(Name ="合格率")]
       [MaxLength(101)]
       [Column(TypeName="varchar(101)")]
       public string PassPercent { get; set; }

       /// <summary>
       ///报工时间
       /// </summary>
       [Display(Name ="报工时间")]
       [Column(TypeName="datetime")]
       public DateTime? CreateDate { get; set; }

       /// <summary>
       ///合计
       /// </summary>
       [Display(Name ="合计")]
       [Column(TypeName="int")]
       public int? AllQty { get; set; }

       
    }
}