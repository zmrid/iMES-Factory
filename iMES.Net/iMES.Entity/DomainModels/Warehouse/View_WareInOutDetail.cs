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
    [Entity(TableCnName = "库存收发明细",TableName = "View_WareInOutDetail")]
    public partial class View_WareInOutDetail:SysEntity
    {
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
       ///库存单位
       /// </summary>
       [Display(Name ="库存单位")]
       [Column(TypeName="int")]
       public int? Unit_Id { get; set; }

       /// <summary>
       ///单据数量
       /// </summary>
       [Display(Name ="单据数量")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int FormQty { get; set; }

       /// <summary>
       ///库存变更数量
       /// </summary>
       [Display(Name ="库存变更数量")]
       [Column(TypeName="int")]
       public int? ChangeQty { get; set; }

       /// <summary>
       ///库存收发时间
       /// </summary>
       [Display(Name ="库存收发时间")]
       [Column(TypeName="datetime")]
       public DateTime? WareHouseDate { get; set; }

       /// <summary>
       ///来源单据类型
       /// </summary>
       [Display(Name ="来源单据类型")]
       [MaxLength(3)]
       [Column(TypeName="nvarchar(3)")]
       [Required(AllowEmptyStrings=false)]
       public string FromType { get; set; }

       /// <summary>
       ///来源单据编号
       /// </summary>
       [Display(Name ="来源单据编号")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string WareHouseBillCode { get; set; }

       /// <summary>
       ///库存类型
       /// </summary>
       [Display(Name ="库存类型")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string WareHouseBillType { get; set; }

       /// <summary>
       ///备注
       /// </summary>
       [Display(Name ="备注")]
       [MaxLength(1000)]
       [Column(TypeName="nvarchar(1000)")]
       public string Remark { get; set; }

       /// <summary>
       ///创建时间
       /// </summary>
       [Display(Name ="创建时间")]
       [Column(TypeName="datetime")]
       public DateTime? CreateDate { get; set; }

       /// <summary>
       ///创建人
       /// </summary>
       [Display(Name ="创建人")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       public string Creator { get; set; }

       /// <summary>
       ///最后更新时间
       /// </summary>
       [Display(Name ="最后更新时间")]
       [Column(TypeName="datetime")]
       public DateTime? ModifyDate { get; set; }

       /// <summary>
       ///最小库存
       /// </summary>
       [Display(Name ="最小库存")]
       [Column(TypeName="int")]
       public int? MinInventory { get; set; }

       /// <summary>
       ///最大库存
       /// </summary>
       [Display(Name ="最大库存")]
       [Column(TypeName="int")]
       public int? MaxInventory { get; set; }

       /// <summary>
       ///安全库存
       /// </summary>
       [Display(Name ="安全库存")]
       [Column(TypeName="int")]
       public int? SafeInventory { get; set; }

       /// <summary>
       ///当前库存数量
       /// </summary>
       [Display(Name ="当前库存数量")]
       [Column(TypeName="int")]
       public int? InventoryQty { get; set; }

       /// <summary>
       ///主键ID
       /// </summary>
       [Key]
       [Display(Name ="主键ID")]
       [Column(TypeName="uniqueidentifier")]
       [Required(AllowEmptyStrings=false)]
       public Guid ID { get; set; }

       
    }
}