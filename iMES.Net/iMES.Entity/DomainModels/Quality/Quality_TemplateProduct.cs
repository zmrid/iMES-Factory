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
    [Entity(TableCnName = "检测模版-产品",TableName = "Quality_TemplateProduct",DBServer = "SysDbContext")]
    public partial class Quality_TemplateProduct:SysEntity
    {
        /// <summary>
       ///检测模版产品主键
       /// </summary>
       [Key]
       [Display(Name ="检测模版产品主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int TemplateProductId { get; set; }

       /// <summary>
       ///模版主键
       /// </summary>
       [Display(Name ="模版主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int TemplateId { get; set; }

       /// <summary>
       ///产品主键
       /// </summary>
       [Display(Name ="产品主键")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int ProductId { get; set; }

       /// <summary>
       ///产品名称
       /// </summary>
       [Display(Name ="产品名称")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string ProductName { get; set; }

       /// <summary>
       ///产品编码
       /// </summary>
       [Display(Name ="产品编码")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string ProductCode { get; set; }

       /// <summary>
       ///产品型号
       /// </summary>
       [Display(Name ="产品型号")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string ProductStandard { get; set; }

       /// <summary>
       ///最低检测数
       /// </summary>
       [Display(Name ="最低检测数")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? CheckMin { get; set; }

       /// <summary>
       ///最大不合格数
       /// </summary>
       [Display(Name ="最大不合格数")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? DisQualityMax { get; set; }

       /// <summary>
       ///致命缺陷率
       /// </summary>
       [Display(Name ="致命缺陷率")]
       [DisplayFormat(DataFormatString="12,2")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? CrRate { get; set; }

       /// <summary>
       ///严重缺陷率
       /// </summary>
       [Display(Name ="严重缺陷率")]
       [DisplayFormat(DataFormatString="12,2")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? MajRate { get; set; }

       /// <summary>
       ///轻微缺陷率
       /// </summary>
       [Display(Name ="轻微缺陷率")]
       [DisplayFormat(DataFormatString="12,2")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? MinRate { get; set; }

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