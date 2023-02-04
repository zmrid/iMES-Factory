<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/tools/tools/Tools_ToolsReceive.js此处编写
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
    import extend from "@/extension/tools/tools/Tools_ToolsReceive.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ToolsReceiveId',
                footer: "Foots",
                cnName: '工具领用',
                name: 'tools/Tools_ToolsReceive',
                url: "/Tools_ToolsReceive/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"ToolsReceiveCode":"","ReceiveDate":"","Remark":""});
            const editFormOptions = ref([[{"title":"领用编号","field":"ToolsReceiveCode","type":"text"}],
                              [{"title":"领用日期","required":true,"field":"ReceiveDate","type":"date"}],
                              [{"title":"备注","field":"Remark","type":"textarea"}]]);
            const searchFormFields = ref({"ToolsReceiveCode":"","ReceiveDate":"","Remark":""});
            const searchFormOptions = ref([[{"title":"领用编号","field":"ToolsReceiveCode","type":"like"},{"title":"领用日期","field":"ReceiveDate","type":"date"},{"title":"备注","field":"Remark","type":"like"}]]);
            const columns = ref([{field:'ToolsReceiveId',title:'领用主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ToolsReceiveCode',title:'领用编号',type:'string',link:true,sort:true,width:180,align:'left',sort:true},
                       {field:'ReceiveDate',title:'领用日期',type:'date',width:150,require:true,align:'left'},
                       {field:'Remark',title:'备注',type:'string',width:220,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'}]);
            const detail = ref({
                cnName: "工具领用明细",
                table: "Tools_ToolsReceiveList",
                columns: [{field:'ToolsReceiveListId',title:'刀具领用明细主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ToolsReceiveId',title:'刀具领用主键',type:'int',width:110,hidden:true,require:true,align:'left'},
                       {field:'ToolId',title:'工装夹具',type:'guid',width:110,hidden:true,require:true,align:'left'},
                       {field:'ToolName',title:'工装夹具名称',type:'string',sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'ToolCode',title:'工装夹具编号',type:'string',sort:true,width:120,require:true,align:'left'},
                       {field:'Brand',title:'品牌',type:'string',width:120,align:'left'},
                       {field:'Spec',title:'型号',type:'string',width:120,align:'left'},
                       {field:'Qty',title:'数量',type:'int',width:110,edit:{type:'number'},require:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'}],
                sortName: "CreateDate",
                key: "ToolsReceiveListId"
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
