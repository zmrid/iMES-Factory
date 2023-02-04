<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/tools/tools/Tools_ToolType.js此处编写
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
    import extend from "@/extension/tools/tools/Tools_ToolType.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ToolTypeId',
                footer: "Foots",
                cnName: '工装夹具类型',
                name: 'tools/Tools_ToolType',
                url: "/Tools_ToolType/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"ToolTypeName":"","ToolTypeCode":"","MaintenType":"","MaintenPeriod":"","Remark":""});
            const editFormOptions = ref([[{"title":"工具类型名称","required":true,"field":"ToolTypeName","type":"text"}],
                              [{"title":"工具类型编码","field":"ToolTypeCode","type":"text"}],
                              [{"dataKey":"MaintenTypeList","data":[],"title":"保养维护方式","field":"MaintenType","type":"radio"}],
                              [{"title":"保养周期","field":"MaintenPeriod","type":"number"}],
                              [{"title":"备注","field":"Remark","type":"textarea"}]]);
            const searchFormFields = ref({"ToolTypeName":"","ToolTypeCode":"","MaintenType":"","MaintenPeriod":[null,null],"Remark":"","CreateDate":""});
            const searchFormOptions = ref([[{"title":"工具类型名称","field":"ToolTypeName","type":"like"},{"title":"工具类型编码","field":"ToolTypeCode","type":"like"},{"dataKey":"MaintenTypeList","data":[],"title":"保养维护方式","field":"MaintenType","type":"radio"}],[{"title":"保养周期","field":"MaintenPeriod","type":"range"},{"title":"备注","field":"Remark","type":"like"},{"title":"创建时间","field":"CreateDate","type":"date"}]]);
            const columns = ref([{field:'ToolTypeId',title:'工具类型主键',type:'guid',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ToolTypeName',title:'工具类型名称',type:'string',link:true,sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'ToolTypeCode',title:'工具类型编码',type:'string',sort:true,width:120,align:'left'},
                       {field:'MaintenType',title:'保养维护方式',type:'string',bind:{ key:'MaintenTypeList',data:[]},width:120,align:'left'},
                       {field:'MaintenPeriod',title:'保养周期',type:'int',sort:true,width:110,align:'left'},
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
