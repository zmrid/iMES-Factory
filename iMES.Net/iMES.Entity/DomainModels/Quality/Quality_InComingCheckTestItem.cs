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
    [Entity(TableCnName = "来料检验单-检验项",TableName = "Quality_InComingCheckTestItem",DBServer = "SysDbContext")]
    public partial class Quality_InComingCheckTestItem:SysEntity
    {
        /// <summary>
       ///来料检验单检测项主键
       /// </summary>
       [Key]
       [Display(Name ="来料检验单检测项主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int InComingCheckTestItemId { get; set; }

       /// <summary>
       ///来料检验单主键
       /// </summary>
       [Display(Name ="来料检验单主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int InComingCheckId { get; set; }

       /// <summary>
       ///检验模版检验项主键
       /// </summary>
       [Display(Name ="检验模版检验项主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int TemplateTestItemId { get; set; }

       /// <summary>
       ///模版主键
       /// </summary>
       [Display(Name ="模版主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int TemplateId { get; set; }

       /// <summary>
       ///检测项主键
       /// </summary>
       [Display(Name ="检测项主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int TestItemId { get; set; }

       /// <summary>
       ///检测项名称
       /// </summary>
       [Display(Name ="检测项名称")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string TestItemName { get; set; }

       /// <summary>
       ///检测项编码
       /// </summary>
       [Display(Name ="检测项编码")]
       [MaxLength(100)]
       [Column(TypeName="varchar(100)")]
       [Editable(true)]
       public string TestItemCode { get; set; }

       /// <summary>
       ///检测项类型
       /// </summary>
       [Display(Name ="检测项类型")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string TestItemType { get; set; }

       /// <summary>
       ///检测工具
       /// </summary>
       [Display(Name ="检测工具")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string QCTool { get; set; }

       /// <summary>
       ///检测要求
       /// </summary>
       [Display(Name ="检测要求")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string CheckMethod { get; set; }

       /// <summary>
       ///标准值
       /// </summary>
       [Display(Name ="标准值")]
       [DisplayFormat(DataFormatString="12,2")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? StanderValue { get; set; }

       /// <summary>
       ///误差上限
       /// </summary>
       [Display(Name ="误差上限")]
       [DisplayFormat(DataFormatString="12,2")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? ThresholdMax { get; set; }

       /// <summary>
       ///误差下限
       /// </summary>
       [Display(Name ="误差下限")]
       [DisplayFormat(DataFormatString="12,2")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? ThresholdMin { get; set; }

       /// <summary>
       ///致命缺陷数量
       /// </summary>
       [Display(Name ="致命缺陷数量")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? CrQuantity { get; set; }

       /// <summary>
       ///严重缺陷数量
       /// </summary>
       [Display(Name ="严重缺陷数量")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? MajQuantity { get; set; }

       /// <summary>
       ///轻微缺陷数量
       /// </summary>
       [Display(Name ="轻微缺陷数量")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? MinQuantity { get; set; }

       /// <summary>
       ///备注
       /// </summary>
       [Display(Name ="备注")]
       [MaxLength(1000)]
       [Column(TypeName="nvarchar(1000)")]
       [Editable(true)]
       public string Remark { get; set; }

       /// <summary>
       ///创建人编号
       /// </summary>
       [Display(Name ="创建人编号")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? CreateID { get; set; }

       /// <summary>
       ///创建人
       /// </summary>
       [Display(Name ="创建人")]
       [MaxLength(30)]
       [Column(TypeName="nvarchar(30)")]
       [Editable(true)]
       public string Creator { get; set; }

       /// <summary>
       ///创建时间
       /// </summary>
       [Display(Name ="创建时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? CreateDate { get; set; }

       /// <summary>
       ///修改人编号
       /// </summary>
       [Display(Name ="修改人编号")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? ModifyID { get; set; }

       /// <summary>
       ///修改人
       /// </summary>
       [Display(Name ="修改人")]
       [MaxLength(30)]
       [Column(TypeName="nvarchar(30)")]
       [Editable(true)]
       public string Modifier { get; set; }

       /// <summary>
       ///修改时间
       /// </summary>
       [Display(Name ="修改时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? ModifyDate { get; set; }

       
    }
}