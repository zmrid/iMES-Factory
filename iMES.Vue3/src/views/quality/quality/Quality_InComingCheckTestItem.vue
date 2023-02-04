<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/quality/quality/Quality_InComingCheckTestItem.js此处编写
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
    import extend from "@/extension/quality/quality/Quality_InComingCheckTestItem.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'InComingCheckTestItemId',
                footer: "Foots",
                cnName: '来料检验单-检验项',
                name: 'quality/Quality_InComingCheckTestItem',
                url: "/Quality_InComingCheckTestItem/",
                sortName: "InComingCheckTestItemId"
            });
            const editFormFields = ref({"CrQuantity":"","MajQuantity":"","MinQuantity":"","Remark":""});
            const editFormOptions = ref([[{"title":"致命缺陷数量","field":"CrQuantity","type":"number"},
                               {"title":"严重缺陷数量","field":"MajQuantity","type":"number"},
                               {"title":"轻微缺陷数量","field":"MinQuantity","type":"number"},
                               {"title":"备注","field":"Remark","type":"text"}]]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'InComingCheckTestItemId',title:'来料检验单检测项主键',type:'int',width:110,hidden:true,require:true,align:'left'},
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
                       {field:'CrQuantity',title:'致命缺陷数量',type:'int',width:110,align:'left'},
                       {field:'MajQuantity',title:'严重缺陷数量',type:'int',width:110,align:'left'},
                       {field:'MinQuantity',title:'轻微缺陷数量',type:'int',width:110,align:'left'},
                       {field:'Remark',title:'备注',type:'string',width:220,align:'left'},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,hidden:true,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,hidden:true,align:'left',sort:true}]);
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
