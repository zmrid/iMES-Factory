<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/quality/quality/Quality_TemplateTestItem.js此处编写
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
    import extend from "@/extension/quality/quality/Quality_TemplateTestItem.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'TemplateTestItemId',
                footer: "Foots",
                cnName: '检测模版-检测项',
                name: 'quality/Quality_TemplateTestItem',
                url: "/Quality_TemplateTestItem/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"TestItemType":"","TestItemCode":"","TestItemName":"","ThresholdMax":"","ThresholdMin":""});
            const editFormOptions = ref([[{"dataKey":"QCDefectType","data":[],"title":"检测项类型","field":"TestItemType","type":"select"},
                               {"title":"检测项编码","field":"TestItemCode","type":"text"},
                               {"title":"检测项名称","field":"TestItemName","type":"text"},
                               {"title":"误差上限","field":"ThresholdMax","type":"number"},
                               {"title":"误差下限","field":"ThresholdMin","type":"number"}]]);
            const searchFormFields = ref({"TestItemType":"","QCTool":"","TestItemCode":"","TestItemName":"","CheckMethod":"","StanderValue":"","ThresholdMax":[null,null],"ThresholdMin":[null,null],"Remark":""});
            const searchFormOptions = ref([[{"dataKey":"QCDefectType","data":[],"title":"检测项类型","field":"TestItemType","type":"select"},{"title":"检测项编码","field":"TestItemCode","type":"like"},{"title":"检测项名称","field":"TestItemName","type":"like"}],[{"title":"检测工具","field":"QCTool","type":"like"},{"title":"检测要求","field":"CheckMethod","type":"like"},{"title":"标准值","field":"StanderValue","type":"like"}],[{"title":"误差上限","field":"ThresholdMax","type":"range"},{"title":"误差下限","field":"ThresholdMin","type":"range"},{"title":"备注","field":"Remark","type":"like"}]]);
            const columns = ref([{field:'TemplateTestItemId',title:'检测模版检测项主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'TemplateId',title:'模版主键',type:'int',width:110,require:true,align:'left',sort:true},
                       {field:'TestItemId',title:'检测项主键',type:'int',width:110,require:true,align:'left'},
                       {field:'TestItemType',title:'检测项类型',type:'string',bind:{ key:'QCDefectType',data:[]},width:180,align:'left'},
                       {field:'QCTool',title:'检测工具',type:'string',width:180,align:'left'},
                       {field:'TestItemCode',title:'检测项编码',type:'string',width:120,align:'left'},
                       {field:'TestItemName',title:'检测项名称',type:'string',width:110,align:'left'},
                       {field:'CheckMethod',title:'检测要求',type:'string',width:180,align:'left'},
                       {field:'StanderValue',title:'标准值',type:'decimal',sort:true,width:110,align:'left'},
                       {field:'ThresholdMax',title:'误差上限',type:'decimal',sort:true,width:110,align:'left'},
                       {field:'ThresholdMin',title:'误差下限',type:'decimal',sort:true,width:110,align:'left'},
                       {field:'Remark',title:'备注',type:'string',width:220,align:'left'},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',sort:true,width:110,align:'left',sort:true}]);
            const detail = ref({
                cnName: "#detailCnName",
                table: "#detailTable",
                columns: [],
                sortName: "",
                key: ""
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
