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
    [Entity(TableCnName = "出库单",TableName = "Ware_OutWareHouseBill",DetailTable =  new Type[] { typeof(Ware_OutWareHouseBillList)},DetailTableCnName = "出库明细",DBServer = "SysDbContext")]
    public partial class Ware_OutWareHouseBill:SysEntity
    {
        /// <summary>
       ///出库单主键ID
       /// </summary>
       [Key]
       [Display(Name ="出库单主键ID")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int OutWareHouseBill_Id { get; set; }

       /// <summary>
       ///出库单号
       /// </summary>
       [Display(Name ="出库单号")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string OutWareHouseBillCode { get; set; }

       /// <summary>
       ///出库类型
       /// </summary>
       [Display(Name ="出库类型")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string OutWareHouseBillType { get; set; }

       /// <summary>
       ///出库时间
       /// </summary>
       [Display(Name ="出库时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public DateTime OutWareHouseDate { get; set; }

       /// <summary>
       ///审批状态
       /// </summary>
       [Display(Name ="审批状态")]
       [Column(TypeName="int")]
       public int? AuditStatus { get; set; }

       /// <summary>
       ///缩略图
       /// </summary>
       [Display(Name ="缩略图")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string ImageUrl { get; set; }

       /// <summary>
       ///附件
       /// </summary>
       [Display(Name ="附件")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string Attachement { get; set; }

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

       [Display(Name ="出库明细")]
       [ForeignKey("OutWareHouseBill_Id")]
       public List<Ware_OutWareHouseBillList> Ware_OutWareHouseBillList { get; set; }

    }
}