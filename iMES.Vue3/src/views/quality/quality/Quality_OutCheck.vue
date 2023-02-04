<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/quality/quality/Quality_OutCheck.js此处编写
 -->
<template>
    <view-grid ref="grid"
               :columns="columns"
               :detail="detail"
               :editFormFields="editFormFields"
               :editFormOptions="editFormOptions"
               :searchFormFields="searchFormFields"
               :searchFormOptions="searchFormOptions"
               :table="table"
               :extend="extend">
    </view-grid>
</template>
<script>
    import extend from "@/extension/quality/quality/Quality_OutCheck.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'OutCheckId',
                footer: "Foots",
                cnName: '出货检验单',
                name: 'quality/Quality_OutCheck',
                url: "/Quality_OutCheck/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"OutCheckName":"","OutCheckCode":"","Product_Id":"","ProductName":"","ProductCode":"","ProductStandard":"","OutNumber":"","CheckNumber":"","DisStandNumber":"","OutDate":"","CheckDate":"","Result":"","Remark":""});
            const editFormOptions = ref([[{"title":"检验单名称","required":true,"field":"OutCheckName","colSize":6,"type":"text"},
                               {"title":"检验单编码","field":"OutCheckCode","colSize":6,"type":"text"},
                               {"title":"产品","required":true,"field":"Product_Id","disabled":true,"type":"number"}],
                              [{"title":"产品名称","required":true,"field":"ProductName","disabled":true},
                               {"title":"产品编码","required":true,"field":"ProductCode","disabled":true},
                               {"title":"规格型号","field":"ProductStandard","disabled":true}],
                              [{"title":"发货数量","required":true,"field":"OutNumber","type":"number"},
                               {"title":"检测数量","required":true,"field":"CheckNumber","type":"number"},
                               {"title":"不合格数量","field":"DisStandNumber","type":"number"}],
                              [{"title":"出货日期","required":true,"field":"OutDate","type":"date"},
                               {"title":"检测日期","required":true,"field":"CheckDate","type":"date"},
                               {"dataKey":"QcResult","data":[],"title":"检测结果","required":true,"field":"Result","type":"select"}],
                              [{"title":"备注","field":"Remark","colSize":12,"type":"textarea"}]]);
            const searchFormFields = ref({"OutCheckName":"","OutCheckCode":"","ProductName":"","ProductCode":"","ProductStandard":"","OutNumber":[null,null],"CheckNumber":[null,null],"DisStandNumber":[null,null],"OutDate":"","CheckDate":"","Result":"","Remark":""});
            const searchFormOptions = ref([[{"title":"检验单名称","field":"OutCheckName","type":"like"},{"title":"检验单编码","field":"OutCheckCode","type":"like"},{"title":"产品名称","field":"ProductName","type":"like"}],[{"title":"产品编码","field":"ProductCode","type":"like"},{"title":"规格型号","field":"ProductStandard","type":"like"},{"title":"发货数量","field":"OutNumber","type":"range"}],[{"title":"检测数量","field":"CheckNumber","type":"range"},{"title":"不合格数量","field":"DisStandNumber","type":"range"},{"title":"出货日期","field":"OutDate","type":"date"}],[{"title":"检测日期","field":"CheckDate","type":"date"},{"dataKey":"QcResult","data":[],"title":"检测结果","field":"Result","type":"select"},{"title":"备注","field":"Remark","type":"like"}]]);
            const columns = ref([{field:'OutCheckId',title:'出库检验单主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'OutCheckName',title:'检验单名称',type:'string',link:true,sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'OutCheckCode',title:'检验单编码',type:'string',sort:true,width:120,align:'left'},
                       {field:'Product_Id',title:'产品',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ProductName',title:'产品名称',type:'string',width:120,readonly:true,require:true,align:'left'},
                       {field:'ProductCode',title:'产品编码',type:'string',width:120,readonly:true,require:true,align:'left'},
                       {field:'ProductStandard',title:'规格型号',type:'string',width:180,readonly:true,align:'left'},
                       {field:'OutNumber',title:'发货数量',type:'int',width:110,require:true,align:'left'},
                       {field:'CheckNumber',title:'检测数量',type:'int',width:110,require:true,align:'left'},
                       {field:'DisStandNumber',title:'不合格数量',type:'int',width:110,align:'left'},
                       {field:'OutDate',title:'出货日期',type:'datetime',sort:true,width:110,require:true,align:'left',sort:true},
                       {field:'CheckDate',title:'检测日期',type:'datetime',sort:true,width:110,require:true,align:'left',sort:true},
                       {field:'Result',title:'检测结果',type:'string',bind:{ key:'QcResult',data:[]},width:120,require:true,align:'left'},
                       {field:'Remark',title:'备注',type:'string',width:220,align:'left'},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',sort:true,width:110,align:'left',sort:true}]);
            const detail = ref({
                cnName: "出货检验单-检验项",
                table: "Quality_OutCheckTestItem",
                columns: [{field:'OutCheckTestItemId',title:'出货检验单检测项主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'OutCheckId',title:'出货检验单主键',type:'int',width:110,hidden:true,require:true,align:'left'},
                       {field:'TemplateTestItemId',title:'检验模版检验项主键',type:'int',width:110,hidden:true,require:true,align:'left'},
                       {field:'TemplateId',title:'模版主键',type:'int',width:110,hidden:true,require:true,align:'left'},
                       {field:'TestItemId',title:'检测项主键',type:'int',width:110,hidden:true,require:true,align:'left'},
                       {field:'TestItemName',title:'检测项名称',type:'string',width:120,align:'left',sort:true},
                       {field:'TestItemCode',title:'检测项编码',type:'string',width:120,align:'left'},
                       {field:'TestItemType',title:'检测项类型',type:'string',bind:{ key:'QCDefectType',data:[]},width:180,align:'left'},
                       {field:'QCTool',title:'检测工具',type:'string',width:180,align:'left'},
                       {field:'CheckMethod',title:'检测要求',type:'string',width:180,align:'left'},
                       {field:'StanderValue',title:'标准值',type:'decimal',width:110,align:'left'},
                       {field:'ThresholdMax',title:'误差上限',type:'decimal',width:110,align:'left'},
                       {field:'ThresholdMin',title:'误差下限',type:'decimal',width:110,align:'left'},
                       {field:'CrQuantity',title:'致命缺陷数量',type:'int',width:110,edit:{type:'number'},align:'left'},
                       {field:'MajQuantity',title:'严重缺陷数量',type:'int',width:110,edit:{type:'number'},align:'left'},
                       {field:'MinQuantity',title:'轻微缺陷数量',type:'int',width:110,edit:{type:'number'},align:'left'},
                       {field:'Remark',title:'备注',type:'string',width:220,edit:{type:'text'},align:'left'},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,hidden:true,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,hidden:true,align:'left',sort:true}],
                sortName: "OutCheckTestItemId",
                key: "OutCheckTestItemId"
            });
            return {
                table,
                extend,
                editFormFields,
                editFormOptions,
                searchFormFields,
                searchFormOptions,
                columns,
                detail,
            };
        },
    });
</script>
