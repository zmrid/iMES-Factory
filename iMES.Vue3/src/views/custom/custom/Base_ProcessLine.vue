<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/custom/Base_ProcessLine.js此处编写
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
    import extend from "@/extension/custom/custom/Base_ProcessLine.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ProcessLine_Id',
                footer: "Foots",
                cnName: '工艺路线',
                name: 'custom/Base_ProcessLine',
                url: "/Base_ProcessLine/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"ProcessLineCode":"","ProcessLineName":""});
            const editFormOptions = ref([[{"title":"工艺路线编号","field":"ProcessLineCode","type":"text"}],
                              [{"title":"工艺路线名称","required":true,"field":"ProcessLineName","type":"text"}]]);
            const searchFormFields = ref({"ProcessLineCode":"","ProcessLineName":""});
            const searchFormOptions = ref([[{"title":"工艺路线编号","field":"ProcessLineCode","type":"like"},{"title":"工艺路线名称","field":"ProcessLineName","type":"like"}]]);
            const columns = ref([{field:'ProcessLine_Id',title:'工艺路线表主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ProcessLineCode',title:'工艺路线编号',type:'string',sort:true,width:180,align:'left',sort:true},
                       {field:'ProcessLineName',title:'工艺路线名称',type:'string',link:true,sort:true,width:180,require:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'}]);
            const detail = ref({
                cnName: "工艺路线-工序列表",
                table: "Base_ProcessLineList",
                columns: [{field:'ProcessLineList_Id',title:'工艺路线工序列表主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ProcessLine_Id',title:'工艺路线',type:'int',bind:{ key:'processLineList',data:[]},width:110,require:true,align:'left',sort:true},
                       {field:'ProcessLineType',title:'类型',type:'string',bind:{ key:'processLineType',data:[]},width:100,edit:{type:'select'},require:true,align:'left'},
                       {field:'Process_Id',title:'工序',type:'int',bind:{ key:'process',data:[]},width:150,edit:{type:'select'},align:'left'},
                       {field:'ProcessLineDown_Id',title:'工艺路线',type:'int',bind:{ key:'processLineList',data:[]},width:150,edit:{type:'select'},align:'left'},
                       {field:'Sequence',title:'顺序',type:'int',width:80,hidden:true,edit:{type:'number'},require:true,align:'left'},
                       {field:'SubmitWorkMatch',title:'报工数配比',type:'decimal',width:110,edit:{type:'text'},align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'}],
                sortName: "Sequence",
                key: "ProcessLineList_Id"
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
