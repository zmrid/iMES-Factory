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
    [Entity(TableCnName = "绩效工资配置",TableName = "Base_MeritPay")]
    public partial class Base_MeritPay:SysEntity
    {
        /// <summary>
       ///绩效工资配置主键ID
       /// </summary>
       [Key]
       [Display(Name ="绩效工资配置主键ID")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int MeritPay_Id { get; set; }

       /// <summary>
       ///工序名称
       /// </summary>
       [Display(Name ="工序名称")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? Process_Id { get; set; }

       /// <summary>
       ///报工单位
       /// </summary>
       [Display(Name ="报工单位")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? Unit_Id { get; set; }

       /// <summary>
       ///产品名称
       /// </summary>
       [Display(Name ="产品名称")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? Product_Id { get; set; }

       /// <summary>
       ///工资单价(元)
       /// </summary>
       [Display(Name ="工资单价(元)")]
       [DisplayFormat(DataFormatString="20,3")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public decimal UnitPrice { get; set; }

       /// <summary>
       ///标准效率
       /// </summary>
       [Display(Name ="标准效率")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? StandardNumber { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="StandardHour")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? StandardHour { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="StandardMin")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? StandardMin { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="StandardSec")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? StandardSec { get; set; }

       /// <summary>
       ///创建时间
       /// </summary>
       [Display(Name ="创建时间")]
       [Column(TypeName="datetime")]
       public DateTime? CreateDate { get; set; }

       /// <summary>
       ///创建人编号
       /// </summary>
       [Display(Name ="创建人编号")]
       [Column(TypeName="int")]
       public int? CreateID { get; set; }

       /// <summary>
       ///创建人
       /// </summary>
       [Display(Name ="创建人")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string Creator { get; set; }

       /// <summary>
       ///修改人
       /// </summary>
       [Display(Name ="修改人")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string Modifier { get; set; }

       /// <summary>
       ///修改时间
       /// </summary>
       [Display(Name ="修改时间")]
       [Column(TypeName="datetime")]
       public DateTime? ModifyDate { get; set; }

       /// <summary>
       ///修改人编号
       /// </summary>
       [Display(Name ="修改人编号")]
       [Column(TypeName="int")]
       public int? ModifyID { get; set; }

       
    }
}