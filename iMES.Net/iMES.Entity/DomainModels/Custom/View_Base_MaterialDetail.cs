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
    [Entity(TableCnName = "物料清单",TableName = "View_Base_MaterialDetail")]
    public partial class View_Base_MaterialDetail:SysEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="MaterialDetail_Id")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int MaterialDetail_Id { get; set; }

       /// <summary>
       ///父项产品
       /// </summary>
       [Display(Name ="父项产品")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int ParentProduct_Id { get; set; }

       /// <summary>
       ///父项产品编号
       /// </summary>
       [Display(Name ="父项产品编号")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string PProductCode { get; set; }

       /// <summary>
       ///父项产品名称
       /// </summary>
       [Display(Name ="父项产品名称")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string PProductName { get; set; }

       /// <summary>
       ///父项产品规格
       /// </summary>
       [Display(Name ="父项产品规格")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string PProductStandard { get; set; }

       /// <summary>
       ///父项单位
       /// </summary>
       [Display(Name ="父项单位")]
       [Column(TypeName="int")]
       public int? PUnit_Id { get; set; }

       /// <summary>
       ///子项产品
       /// </summary>
       [Display(Name ="子项产品")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int ChildProduct_Id { get; set; }

       /// <summary>
       ///子项产品编号
       /// </summary>
       [Display(Name ="子项产品编号")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string CProductCode { get; set; }

       /// <summary>
       ///子项产品名称
       /// </summary>
       [Display(Name ="子项产品名称")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string CProductName { get; set; }

       /// <summary>
       ///子项产品规格
       /// </summary>
       [Display(Name ="子项产品规格")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string CProductStandard { get; set; }

       /// <summary>
       ///子项单位
       /// </summary>
       [Display(Name ="子项单位")]
       [Column(TypeName="int")]
       public int? CUnit_Id { get; set; }

       /// <summary>
       ///单位用量
       /// </summary>
       [Display(Name ="单位用量")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int QuantityPer { get; set; }

       /// <summary>
       ///备注
       /// </summary>
       [Display(Name ="备注")]
       [MaxLength(1000)]
       [Column(TypeName="nvarchar(1000)")]
       [Editable(true)]
       public string Remark { get; set; }

       /// <summary>
       ///创建时间
       /// </summary>
       [Display(Name ="创建时间")]
       [Column(TypeName="datetime")]
       public DateTime? CreateDate { get; set; }

       /// <summary>
       ///
       /// </summary>
       [Display(Name ="CreateID")]
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
       ///
       /// </summary>
       [Display(Name ="ModifyID")]
       [Column(TypeName="int")]
       public int? ModifyID { get; set; }

       
    }
}