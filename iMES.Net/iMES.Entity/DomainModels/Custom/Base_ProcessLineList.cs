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
    [Entity(TableCnName = "工艺路线-工序列表",TableName = "Base_ProcessLineList")]
    public partial class Base_ProcessLineList:SysEntity
    {
        /// <summary>
       ///工艺路线工序列表主键ID
       /// </summary>
       [Key]
       [Display(Name ="工艺路线工序列表主键ID")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int ProcessLineList_Id { get; set; }

       /// <summary>
       ///工艺路线
       /// </summary>
       [Display(Name ="工艺路线")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int ProcessLine_Id { get; set; }

       /// <summary>
       ///类型
       /// </summary>
       [Display(Name ="类型")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string ProcessLineType { get; set; }

       /// <summary>
       ///工序
       /// </summary>
       [Display(Name ="工序")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? Process_Id { get; set; }

       /// <summary>
       ///工艺路线
       /// </summary>
       [Display(Name ="工艺路线")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? ProcessLineDown_Id { get; set; }

       /// <summary>
       ///顺序
       /// </summary>
       [Display(Name ="顺序")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int Sequence { get; set; }

       /// <summary>
       ///报工数配比
       /// </summary>
       [Display(Name ="报工数配比")]
       [DisplayFormat(DataFormatString="20,3")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? SubmitWorkMatch { get; set; }

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