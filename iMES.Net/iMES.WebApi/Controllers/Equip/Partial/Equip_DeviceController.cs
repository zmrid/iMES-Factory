/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Equip_Device",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Entity.DomainModels;
using iMES.Equip.IServices;
using iMES.Equip.Services;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using QuestPDF.Fluent;
using iMES.Core.DBManager;
using iMES.Core.Infrastructure;
using iMES.Core.Configuration;

namespace iMES.Equip.Controllers
{
    public partial class Equip_DeviceController
    {
        private readonly IEquip_DeviceService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Equip_DeviceController(
            IEquip_DeviceService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost, Route("getSelectorDevice")]
        public IActionResult getSelectorDevice([FromBody] PageDataOptions options)
        {
            //1.可以直接调用框架的GetPageData查询
            PageGridData<Equip_Device> data = Equip_DeviceService.Instance.GetPageData(options);
            return JsonNormal(data);
        }
        /// <summary>
        /// 导出PDF
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("ExportPDF")]
        public string ExportPDF()
        {
            var titleStyle = TextStyle.Default.FontSize(36).SemiBold().FontColor(Colors.Blue.Medium);
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
            string path_file = AppSetting.GetSettingString("ExportPDFPath") + @"\Device\" + fileName;
            //整合对象
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    //字体默认大小20号字体
                    page.DefaultTextStyle(x => x.FontSize(20));

                    //页眉部分
                    page.Header()
                          .Row(row =>
                          {
                              row.RelativeItem().Column(column =>
                              {
                                  column.Item().AlignCenter().Text("设备台账").FontFamily("simhei").Style(TextStyle.Default.FontSize(22).FontColor(Colors.Blue.Medium));
                                  column.Item().AlignLeft().AlignBottom().Height(50).Width(50).Image(@"C:\iMES\ReourceWeb\logo.png");
                                  column.Item().AlignRight().AlignTop().Text("编号:______________").FontFamily("simhei").Style(TextStyle.Default.FontSize(12));
                              });
                          });
                    //内容部分
                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            //表格
                            x.Item().Table(table =>
                            {
                                //设置表头的列参数占比
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                // 表头
                                table.Header(header =>
                                {
                                    header.Cell().AlignCenter().Text("设备名称").FontFamily("simhei").Style(TextStyle.Default.FontSize(12));
                                    header.Cell().AlignCenter().Text("设备编码").FontFamily("simhei").Style(TextStyle.Default.FontSize(12));
                                    header.Cell().AlignCenter().Text("品牌").FontFamily("simhei").Style(TextStyle.Default.FontSize(12));
                                    header.Cell().AlignCenter().Text("规格型号").FontFamily("simhei").Style(TextStyle.Default.FontSize(12));
                                    header.Cell().AlignCenter().Text("设备分类").FontFamily("simhei").Style(TextStyle.Default.FontSize(12));
                                    header.Cell().ColumnSpan(5).PaddingVertical(4).BorderBottom(1).BorderColor(Colors.Black);
                                });
                                string sql = " select * from Equip_Device ";
                                List<Equip_Device> list = DBServerProvider.SqlDapper.QueryList<Equip_Device>(sql, new { });
                                for (int i = 0; i < list.Count; i++)
                                {
                                    table.Cell().Element(CellStyle).AlignCenter().Text(list[i].DeviceName).FontFamily("simsun").Style(TextStyle.Default.FontSize(10));
                                    table.Cell().Element(CellStyle).AlignCenter().Text(list[i].DeviceCode).FontFamily("simsun").Style(TextStyle.Default.FontSize(10));
                                    table.Cell().Element(CellStyle).AlignCenter().Text(list[i].DeviceBrand).FontFamily("simsun").Style(TextStyle.Default.FontSize(10));
                                    table.Cell().Element(CellStyle).AlignCenter().Text(list[i].ModelType).FontFamily("simsun").Style(TextStyle.Default.FontSize(10));
                                    table.Cell().Element(CellStyle).AlignCenter().Text(DictionaryManager.GetDictionaryList("DeviceCatalogDic", list[i].ParentId.ToString())).FontFamily("simsun").Style(TextStyle.Default.FontSize(10));
                                 
                                 }
                                static IContainer CellStyle(IContainer container)
                                {
                                    return container.BorderBottom(1).PaddingVertical(4);
                                }

                            });
                        });

                    //页脚部分
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("第").FontFamily("simsun").FontSize(12);
                            x.CurrentPageNumber().FontSize(12);
                            x.Span("页").FontFamily("simsun").FontSize(12);
                        });
                });
            }).GeneratePdf(path_file);
            //返回对应文件
            return fileName;
        }
    }
}
