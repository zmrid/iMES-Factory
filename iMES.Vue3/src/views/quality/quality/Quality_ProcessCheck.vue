<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/quality/quality/Quality_ProcessCheck.js此处编写
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
    import extend from "@/extension/quality/quality/Quality_ProcessCheck.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ProcessCheckId',
                footer: "Foots",
                cnName: '过程检验',
                name: 'quality/Quality_ProcessCheck',
                url: "/Quality_ProcessCheck/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"ProcessCheckName":"","ProcessCheckCode":"","CheckType":"","WorkOrder_Id":"","Product_Id":"","Process_Id":"","WorkOrderCode":"","ProductName":"","ProductCode":"","ProductStandard":"","ProcessCode":"","ProcessName":"","StandNumber":"","DisStandNumber":"","CheckDate":"","CrQuantity":"","MajQuantity":"","MinQuantity":"","Result":"","Remark":""});
            const editFormOptions = ref([[{"title":"检验单名称","required":true,"field":"ProcessCheckName","type":"text"},
                               {"title":"检验单编码","field":"ProcessCheckCode","type":"text"},
                               {"dataKey":"QcProcessCheckType","data":[],"title":"检验类型","required":true,"field":"CheckType","type":"select"}],
                              [{"title":"工序","field":"Process_Id","disabled":true,"type":"number"},
                               {"title":"工单","required":true,"field":"WorkOrder_Id","type":"number"},
                               {"title":"产品","required":true,"field":"Product_Id","type":"number"}],
                              [{"title":"工单编号","required":true,"field":"WorkOrderCode","disabled":true,"type":"text"},
                               {"title":"产品编码","required":true,"field":"ProductCode","disabled":true,"type":"text"},
                               {"title":"产品名称","required":true,"field":"ProductName","disabled":true}],
                              [{"title":"规格型号","field":"ProductStandard","disabled":true},
                               {"title":"工序编码","field":"ProcessCode","disabled":true},
                               {"title":"工序名称","field":"ProcessName","disabled":true}],
                              [{"title":"合格品数量","field":"StandNumber","type":"number"},
                               {"title":"不合格数","field":"DisStandNumber","type":"number"},
                               {"title":"检测日期","required":true,"field":"CheckDate","type":"date"}],
                              [{"title":"致命缺陷数量","field":"CrQuantity","type":"number"},
                               {"title":"严重缺陷数量","field":"MajQuantity","type":"number"},
                               {"title":"轻微缺陷数量","field":"MinQuantity","type":"number"}],
                              [{"dataKey":"QcResult","data":[],"title":"检测结果","required":true,"field":"Result","colSize":4,"type":"select"},
                               {"title":"备注","field":"Remark","colSize":8,"type":"textarea"}]]);
            const searchFormFields = ref({"ProcessCheckName":"","ProcessCheckCode":"","CheckType":"","WorkOrderCode":"","ProductName":"","ProductCode":"","ProductStandard":"","ProcessCode":"","ProcessName":"","StandNumber":[null,null],"DisStandNumber":[null,null],"CrQuantity":[null,null],"MajQuantity":[null,null],"MinQuantity":[null,null],"CheckDate":"","Result":"","Remark":"","CreateDate":""});
            const searchFormOptions = ref([[{"title":"检验单名称","field":"ProcessCheckName","type":"like"},{"title":"检验单编码","field":"ProcessCheckCode","type":"like"},{"dataKey":"QcProcessCheckType","data":[],"title":"检验类型","field":"CheckType","type":"select"}],[{"title":"工单编号","field":"WorkOrderCode","type":"like"},{"title":"产品名称","field":"ProductName","type":"like"},{"title":"产品编码","field":"ProductCode","type":"like"}],[{"title":"规格型号","field":"ProductStandard","type":"like"},{"title":"工序编码","field":"ProcessCode","type":"like"},{"title":"工序名称","field":"ProcessName","type":"like"}],[{"title":"合格品数量","field":"StandNumber","type":"range"},{"title":"不合格数","field":"DisStandNumber","type":"range"},{"title":"致命缺陷数量","field":"CrQuantity","type":"range"}],[{"title":"严重缺陷数量","field":"MajQuantity","type":"range"},{"title":"轻微缺陷数量","field":"MinQuantity","type":"range"},{"title":"检测日期","field":"CheckDate","type":"date"}],[{"dataKey":"QcResult","data":[],"title":"检测结果","field":"Result","type":"select"},{"title":"备注","field":"Remark","type":"like"},{"title":"创建时间","field":"CreateDate","type":"date"}]]);
            const columns = ref([{field:'ProcessCheckId',title:'过程检验单主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ProcessCheckName',title:'检验单名称',type:'string',link:true,width:120,require:true,align:'left',sort:true},
                       {field:'ProcessCheckCode',title:'检验单编码',type:'string',width:120,align:'left'},
                       {field:'CheckType',title:'检验类型',type:'string',bind:{ key:'QcProcessCheckType',data:[]},width:120,require:true,align:'left'},
                       {field:'WorkOrder_Id',title:'工单',type:'int',width:110,require:true,align:'left'},
                       {field:'WorkOrderCode',title:'工单编号',type:'string',width:120,readonly:true,require:true,align:'left'},
                       {field:'Product_Id',title:'产品',type:'int',width:110,require:true,align:'left'},
                       {field:'ProductName',title:'产品名称',type:'string',width:120,readonly:true,require:true,align:'left'},
                       {field:'ProductCode',title:'产品编码',type:'string',width:120,readonly:true,require:true,align:'left'},
                       {field:'ProductStandard',title:'规格型号',type:'string',width:180,readonly:true,align:'left'},
                       {field:'Process_Id',title:'工序',type:'int',width:110,readonly:true,align:'left'},
                       {field:'ProcessCode',title:'工序编码',type:'string',width:120,readonly:true,align:'left'},
                       {field:'ProcessName',title:'工序名称',type:'string',width:120,readonly:true,align:'left'},
                       {field:'StandNumber',title:'合格品数量',type:'int',width:110,align:'left'},
                       {field:'DisStandNumber',title:'不合格数',type:'int',width:110,align:'left'},
                       {field:'CrQuantity',title:'致命缺陷数量',type:'int',width:110,align:'left'},
                       {field:'MajQuantity',title:'严重缺陷数量',type:'int',width:110,align:'left'},
                       {field:'MinQuantity',title:'轻微缺陷数量',type:'int',width:110,align:'left'},
                       {field:'CheckDate',title:'检测日期',type:'date',width:110,require:true,align:'left'},
                       {field:'Result',title:'检测结果',type:'string',bind:{ key:'QcResult',data:[]},width:120,require:true,align:'left'},
                       {field:'Remark',title:'备注',type:'string',width:220,align:'left'},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,align:'left',sort:true}]);
            const detail = ref({
                cnName: "过程检验单-检验项",
                table: "Quality_ProcessCheckTestItem",
                columns: [{field:'ProcessCheckTestItemId',title:'过程检验单检测项主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ProcessCheckId',title:'过程检验单主键',type:'int',width:110,hidden:true,require:true,align:'left'},
                       {field:'TemplateTestItemId',title:'检验模版检验项主键',type:'int',width:110,hidden:true,require:true,align:'left'},
                       {field:'TemplateId',title:'模版主键',type:'int',width:110,hidden:true,require:true,align:'left'},
                       {field:'TestItemId',title:'检测项主键',type:'int',width:110,hidden:true,require:true,align:'left'},
                       {field:'TestItemName',title:'检测项名称',type:'string',width:120,align:'left',sort:true},
                       {field:'TestItemCode',title:'检测项编码',type:'string',width:120,align:'left'},
                       {field:'TestItemType',title:'检测项类型',type:'string',bind:{ key:'QCDefectType',data:[]},width:180,edit:{type:'select'},align:'left'},
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
                sortName: "ProcessCheckTestItemId",
                key: "ProcessCheckTestItemId"
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
