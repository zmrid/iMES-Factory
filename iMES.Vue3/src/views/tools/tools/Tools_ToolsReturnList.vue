<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/tools/tools/Tools_ToolsReturnList.js此处编写
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
    import extend from "@/extension/tools/tools/Tools_ToolsReturnList.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ToolsReturnListId',
                footer: "Foots",
                cnName: '工具归还明细',
                name: 'tools/Tools_ToolsReturnList',
                url: "/Tools_ToolsReturnList/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"Qty":""});
            const editFormOptions = ref([[{"title":"数量","required":true,"field":"Qty","type":"number"}]]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'ToolsReturnListId',title:'刀具归还明细主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ToolsReturnId',title:'刀具归还主键',type:'int',width:110,hidden:true,require:true,align:'left'},
                       {field:'ToolId',title:'工装夹具',type:'guid',width:110,hidden:true,require:true,align:'left'},
                       {field:'ToolName',title:'工装夹具名称',type:'string',sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'ToolCode',title:'工装夹具编号',type:'string',sort:true,width:120,require:true,align:'left'},
                       {field:'Brand',title:'品牌',type:'string',width:120,align:'left'},
                       {field:'Spec',title:'型号',type:'string',width:120,align:'left'},
                       {field:'Qty',title:'数量',type:'int',width:110,require:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'}]);
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
