<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/quality/quality/Quality_InComingCheck.js此处编写
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
    import extend from "@/extension/quality/quality/Quality_InComingCheck.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'InComingCheckId',
                footer: "Foots",
                cnName: '来料检验单',
                name: 'quality/Quality_InComingCheck',
                url: "/Quality_InComingCheck/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"InComingCheckName":"","InComingCheckCode":"","Product_Id":"","ProductName":"","ProductCode":"","ProductStandard":"","ReciveNumber":"","CheckNumber":"","DisStandNumber":"","InComingDate":"","CheckDate":"","Result":"","Remark":""});
            const editFormOptions = ref([[{"title":"检验单名称","required":true,"field":"InComingCheckName","colSize":6,"type":"text"},
                               {"title":"检验单编码","field":"InComingCheckCode","colSize":6,"type":"text"},
                               {"title":"产品","required":true,"field":"Product_Id","disabled":true,"type":"number"}],
                              [{"title":"产品名称","required":true,"field":"ProductName","disabled":true},
                               {"title":"产品编码","required":true,"field":"ProductCode","disabled":true},
                               {"title":"规格型号","field":"ProductStandard","disabled":true}],
                              [{"title":"本次接收数量","required":true,"field":"ReciveNumber","type":"number"},
                               {"title":"本次检验数量","required":true,"field":"CheckNumber","type":"number"},
                               {"title":"不合格数量","field":"DisStandNumber","type":"number"}],
                              [{"title":"来料日期","required":true,"field":"InComingDate","type":"date"},
                               {"title":"检测日期","required":true,"field":"CheckDate","type":"date"},
                               {"dataKey":"QcResult","data":[],"title":"检测结果","required":true,"field":"Result","type":"select"}],
                              [{"title":"备注","field":"Remark","colSize":12,"type":"textarea"}]]);
            const searchFormFields = ref({"InComingCheckName":"","InComingCheckCode":"","ProductName":"","ProductCode":"","ProductStandard":"","ReciveNumber":[null,null],"CheckNumber":[null,null],"DisStandNumber":[null,null],"InComingDate":"","CheckDate":"","Result":"","Remark":""});
            const searchFormOptions = ref([[{"title":"检验单名称","field":"InComingCheckName","type":"like"},{"title":"检验单编码","field":"InComingCheckCode","type":"like"},{"title":"产品名称","field":"ProductName","type":"like"}],[{"title":"产品编码","field":"ProductCode","type":"like"},{"title":"规格型号","field":"ProductStandard","type":"like"},{"title":"本次接收数量","field":"ReciveNumber","type":"range"}],[{"title":"本次检验数量","field":"CheckNumber","type":"range"},{"title":"不合格数量","field":"DisStandNumber","type":"range"},{"title":"来料日期","field":"InComingDate","type":"date"}],[{"title":"检测日期","field":"CheckDate","type":"date"},{"dataKey":"QcResult","data":[],"title":"检测结果","field":"Result","type":"select"},{"title":"备注","field":"Remark","type":"like"}]]);
            const columns = ref([{field:'InComingCheckId',title:'来料检验单主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'InComingCheckName',title:'检验单名称',type:'string',link:true,width:120,require:true,align:'left',sort:true},
                       {field:'InComingCheckCode',title:'检验单编码',type:'string',width:120,align:'left'},
                       {field:'Product_Id',title:'产品',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ProductName',title:'产品名称',type:'string',width:120,readonly:true,require:true,align:'left'},
                       {field:'ProductCode',title:'产品编码',type:'string',width:120,readonly:true,require:true,align:'left'},
                       {field:'ProductStandard',title:'规格型号',type:'string',width:180,readonly:true,align:'left'},
                       {field:'ReciveNumber',title:'本次接收数量',type:'int',width:110,require:true,align:'left'},
                       {field:'CheckNumber',title:'本次检验数量',type:'int',width:110,require:true,align:'left'},
                       {field:'DisStandNumber',title:'不合格数量',type:'int',width:110,align:'left'},
                       {field:'InComingDate',title:'来料日期',type:'date',width:110,require:true,align:'left'},
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
                cnName: "来料检验单-检验项",
                table: "Quality_InComingCheckTestItem",
                columns: [{field:'InComingCheckTestItemId',title:'来料检验单检测项主键',type:'int',width:110,hidden:true,require:true,align:'left'},
                       {field:'InComingCheckId',title:'来料检验单主键',type:'int',width:110,hidden:true,require:true,align:'left'},
                       {field:'TemplateTestItemId',title:'检验模版检验项主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
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
                sortName: "InComingCheckTestItemId",
                key: "InComingCheckTestItemId"
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
