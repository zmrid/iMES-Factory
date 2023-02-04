/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Equip_DeviceController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Equip.IServices;
namespace iMES.Equip.Controllers
{
    [Route("api/Equip_Device")]
    [PermissionTable(Name = "Equip_Device")]
    public partial class Equip_DeviceController : ApiBaseController<IEquip_DeviceService>
    {
        public Equip_DeviceController(IEquip_DeviceService service)
        : base(service)
        {
        }
    }
}

