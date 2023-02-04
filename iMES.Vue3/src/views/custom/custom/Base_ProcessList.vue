<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/custom/Base_ProcessList.js此处编写
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
    import extend from "@/extension/custom/custom/Base_ProcessList.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ProcessList_Id',
                footer: "Foots",
                cnName: '工序采集数据',
                name: 'custom/Base_ProcessList',
                url: "/Base_ProcessList/",
                sortName: "ProcessList_Id"
            });
            const editFormFields = ref({"DataPointType":"","DataPointName":""});
            const editFormOptions = ref([[{"dataKey":"dataPointType","data":[],"title":"类型","required":true,"field":"DataPointType","type":"select"}],
                              [{"title":"名称","required":true,"field":"DataPointName","type":"text"}]]);
            const searchFormFields = ref({"Process_Id":"","DataPointType":"","DataPointName":""});
            const searchFormOptions = ref([[{"dataKey":"process","data":[],"title":"工序","field":"Process_Id","type":"select"},{"dataKey":"dataPointType","data":[],"title":"类型","field":"DataPointType","type":"select"},{"title":"名称","field":"DataPointName","type":"like"}]]);
            const columns = ref([{field:'ProcessList_Id',title:'工序采集数据主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'Process_Id',title:'工序',type:'int',bind:{ key:'process',data:[]},sort:true,width:110,require:true,align:'left',sort:true},
                       {field:'DataPointType',title:'类型',type:'string',bind:{ key:'dataPointType',data:[]},sort:true,width:180,require:true,align:'left'},
                       {field:'DataPointName',title:'名称',type:'string',sort:true,width:180,require:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
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
