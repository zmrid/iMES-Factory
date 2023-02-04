<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/custom/Base_Process.js此处编写
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
    import extend from "@/extension/custom/custom/Base_Process.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'Process_Id',
                footer: "Foots",
                cnName: '工序',
                name: 'custom/Base_Process',
                url: "/Base_Process/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"ProcessCode":"","ProcessName":"","SubmitWorkLimit":[],"SubmitWorkMatch":"","DefectItem":[]});
            const editFormOptions = ref([[{"title":"工序编号","field":"ProcessCode","type":"text"},
                               {"title":"工序名称","required":true,"field":"ProcessName","type":"text"}],
                              [{"dataKey":"usersWithAll","data":[],"title":"报工权限","required":true,"field":"SubmitWorkLimit","type":"selectList"},
                               {"title":"报工数配比","required":true,"field":"SubmitWorkMatch","type":"decimal"}],
                              [{"dataKey":"DefectItem","data":[],"title":"不良品项列表","required":true,"field":"DefectItem","colSize":12,"type":"selectList"}]]);
            const searchFormFields = ref({"ProcessCode":"","ProcessName":"","SubmitWorkLimit":[],"SubmitWorkMatch":[null,null],"DefectItem":[],"CreateDate":""});
            const searchFormOptions = ref([[{"title":"工序编号","field":"ProcessCode","type":"like"},{"title":"工序名称","field":"ProcessName","type":"like"},{"dataKey":"usersWithAll","data":[],"title":"报工权限","field":"SubmitWorkLimit","type":"selectList"}],[{"title":"报工数配比","field":"SubmitWorkMatch","type":"range"},{"dataKey":"DefectItem","data":[],"title":"不良品项列表","field":"DefectItem","type":"selectList"},{"title":"创建时间","field":"CreateDate","type":"date"}]]);
            const columns = ref([{field:'Process_Id',title:'工序主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ProcessCode',title:'工序编号',type:'string',sort:true,width:180,align:'left',sort:true},
                       {field:'ProcessName',title:'工序名称',type:'string',link:true,sort:true,width:180,require:true,align:'left'},
                       {field:'SubmitWorkLimit',title:'报工权限',type:'string',bind:{ key:'usersWithAll',data:[]},width:220,require:true,align:'left'},
                       {field:'SubmitWorkMatch',title:'报工数配比',type:'decimal',width:110,require:true,align:'left'},
                       {field:'DefectItem',title:'不良品项列表',type:'string',bind:{ key:'DefectItem',data:[]},width:220,require:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'}]);
            const detail = ref({
                cnName: "工序采集数据",
                table: "Base_ProcessList",
                columns: [{field:'ProcessList_Id',title:'工序采集数据主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'Process_Id',title:'工序',type:'int',bind:{ key:'process',data:[]},sort:true,width:110,require:true,align:'left',sort:true},
                       {field:'DataPointType',title:'类型',type:'string',bind:{ key:'dataPointType',data:[]},sort:true,width:180,edit:{type:'select'},require:true,align:'left'},
                       {field:'DataPointName',title:'名称',type:'string',sort:true,width:180,edit:{type:'text'},require:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'}],
                sortName: "ProcessList_Id",
                key: "ProcessList_Id"
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
