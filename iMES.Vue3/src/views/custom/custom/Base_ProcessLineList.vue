<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/custom/Base_ProcessLineList.js此处编写
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
    import extend from "@/extension/custom/custom/Base_ProcessLineList.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ProcessLineList_Id',
                footer: "Foots",
                cnName: '工艺路线-工序列表',
                name: 'custom/Base_ProcessLineList',
                url: "/Base_ProcessLineList/",
                sortName: "Sequence"
            });
            const editFormFields = ref({"ProcessLineType":"","Process_Id":"","ProcessLineDown_Id":"","SubmitWorkMatch":"","Sequence":""});
            const editFormOptions = ref([[{"dataKey":"processLineType","data":[],"title":"类型","required":true,"field":"ProcessLineType","type":"select"}],
                              [{"dataKey":"process","data":[],"title":"工序","field":"Process_Id","type":"select"}],
                              [{"dataKey":"processLineList","data":[],"title":"工艺路线","field":"ProcessLineDown_Id","type":"select"}],
                              [{"title":"报工数配比","field":"SubmitWorkMatch","type":"text"}],
                              [{"title":"顺序","required":true,"field":"Sequence","type":"number"}]]);
            const searchFormFields = ref({"ProcessLineType":""});
            const searchFormOptions = ref([[{"dataKey":"processLineType","data":[],"title":"类型","field":"ProcessLineType","type":"select"}]]);
            const columns = ref([{field:'ProcessLineList_Id',title:'工艺路线工序列表主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ProcessLine_Id',title:'工艺路线',type:'int',bind:{ key:'processLineList',data:[]},width:110,require:true,align:'left',sort:true},
                       {field:'ProcessLineType',title:'类型',type:'string',bind:{ key:'processLineType',data:[]},width:100,require:true,align:'left'},
                       {field:'Process_Id',title:'工序',type:'int',bind:{ key:'process',data:[]},width:150,align:'left'},
                       {field:'ProcessLineDown_Id',title:'工艺路线',type:'int',bind:{ key:'processLineList',data:[]},width:150,align:'left'},
                       {field:'Sequence',title:'顺序',type:'int',width:80,hidden:true,require:true,align:'left'},
                       {field:'SubmitWorkMatch',title:'报工数配比',type:'decimal',width:110,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,align:'left',sort:true},
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
