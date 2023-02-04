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
    [Entity(TableCnName = "工资报表",TableName = "View_SalaryReport")]
    public partial class View_SalaryReport:SysEntity
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
       ///报工时间
       /// </summary>
       [Display(Name ="报工时间")]
       [Column(TypeName="varchar")]
       public DateTime? ReportDate { get; set; }

       /// <summary>
       ///生产人员
       /// </summary>
       [Display(Name ="生产人员")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Required(AllowEmptyStrings=false)]
       public string ProductUser { get; set; }

       /// <summary>
       ///账号
       /// </summary>
       [Display(Name ="账号")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string UserName { get; set; }

       /// <summary>
       ///姓名
       /// </summary>
       [Display(Name ="姓名")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string UserTrueName { get; set; }

       /// <summary>
       ///报工总数
       /// </summary>
       [Display(Name ="报工总数")]
       [Column(TypeName="int")]
       public int? ReportAll { get; set; }

       /// <summary>
       ///未审批计件数
       /// </summary>
       [Display(Name ="未审批计件数")]
       [Column(TypeName="int")]
       public int? NoAlreadyAppNumber { get; set; }

       /// <summary>
       ///未审批计时数
       /// </summary>
       [Display(Name ="未审批计时数")]
       [Column(TypeName="int")]
       public int? NoAlreadyAppTime { get; set; }

       /// <summary>
       ///已审批计件数
       /// </summary>
       [Display(Name ="已审批计件数")]
       [Column(TypeName="int")]
       public int? AlreadyAppNumber { get; set; }

       /// <summary>
       ///已审批计时数
       /// </summary>
       [Display(Name ="已审批计时数")]
       [Column(TypeName="int")]
       public int? AlreadyAppTime { get; set; }

       /// <summary>
       ///工资小计
       /// </summary>
       [Display(Name ="工资小计")]
       [DisplayFormat(DataFormatString="38,3")]
       [Column(TypeName="decimal")]
       public decimal? Salary { get; set; }

       
    }
}