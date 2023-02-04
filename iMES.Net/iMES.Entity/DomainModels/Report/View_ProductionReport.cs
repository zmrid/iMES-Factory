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
    [Entity(TableCnName = "生产报表",TableName = "View_ProductionReport")]
    public partial class View_ProductionReport:SysEntity
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
       ///产品单位
       /// </summary>
       [Display(Name ="产品单位")]
       [Column(TypeName="int")]
       public int? Unit_Id { get; set; }

       /// <summary>
       ///产品单位
       /// </summary>
       [Display(Name ="产品单位")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string UnitName { get; set; }

       /// <summary>
       ///工单编号
       /// </summary>
       [Display(Name ="工单编号")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string WorkOrderCode { get; set; }

       /// <summary>
       ///工单计划数
       /// </summary>
       [Display(Name ="工单计划数")]
       [Column(TypeName="int")]
       public int? PlanQty { get; set; }

       /// <summary>
       ///工单实际数
       /// </summary>
       [Display(Name ="工单实际数")]
       [Column(TypeName="int")]
       public int? RealQty { get; set; }

       /// <summary>
       ///工单状态
       /// </summary>
       [Display(Name ="工单状态")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string Status { get; set; }

       /// <summary>
       ///工单计划开始时间
       /// </summary>
       [Display(Name ="工单计划开始时间")]
       [Column(TypeName="datetime")]
       public DateTime? PlanStartDate { get; set; }

       /// <summary>
       ///工单计划结束时间
       /// </summary>
       [Display(Name ="工单计划结束时间")]
       [Column(TypeName="datetime")]
       public DateTime? PlanEndDate { get; set; }

       /// <summary>
       ///工单实际开始时间
       /// </summary>
       [Display(Name ="工单实际开始时间")]
       [Column(TypeName="datetime")]
       public DateTime? ActualStartDate { get; set; }

       /// <summary>
       ///工单实际结束时间
       /// </summary>
       [Display(Name ="工单实际结束时间")]
       [Column(TypeName="datetime")]
       public DateTime? ActualEndDate { get; set; }

       /// <summary>
       ///工单备注
       /// </summary>
       [Display(Name ="工单备注")]
       [MaxLength(1000)]
       [Column(TypeName="nvarchar(1000)")]
       public string Remark { get; set; }

       /// <summary>
       ///工序编号
       /// </summary>
       [Display(Name ="工序编号")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Required(AllowEmptyStrings=false)]
       public string ProcessCode { get; set; }

       /// <summary>
       ///工序名称
       /// </summary>
       [Display(Name ="工序名称")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Required(AllowEmptyStrings=false)]
       public string ProcessName { get; set; }

       /// <summary>
       ///报工数配比
       /// </summary>
       [Display(Name ="报工数配比")]
       [DisplayFormat(DataFormatString="20,3")]
       [Column(TypeName="decimal")]
       [Required(AllowEmptyStrings=false)]
       public decimal SubmitWorkMatch { get; set; }

       /// <summary>
       ///任务计划开始时间
       /// </summary>
       [Display(Name ="任务计划开始时间")]
       [Column(TypeName="datetime")]
       [Required(AllowEmptyStrings=false)]
       public DateTime TaskPlanStartDate { get; set; }

       /// <summary>
       ///任务计划结束时间
       /// </summary>
       [Display(Name ="任务计划结束时间")]
       [Column(TypeName="datetime")]
       [Required(AllowEmptyStrings=false)]
       public DateTime TaskPlanEndDate { get; set; }

       /// <summary>
       ///任务实际开始时间
       /// </summary>
       [Display(Name ="任务实际开始时间")]
       [Column(TypeName="datetime")]
       public DateTime? TaskActualStartDate { get; set; }

       /// <summary>
       ///任务实际结束时间
       /// </summary>
       [Display(Name ="任务实际结束时间")]
       [Column(TypeName="datetime")]
       public DateTime? TaskActualEndDate { get; set; }

       /// <summary>
       ///任务计划数
       /// </summary>
       [Display(Name ="任务计划数")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int TaskPlanQty { get; set; }

       /// <summary>
       ///任务实际数
       /// </summary>
       [Display(Name ="任务实际数")]
       [Column(TypeName="int")]
       public int? TaskRealQty { get; set; }

       
    }
}