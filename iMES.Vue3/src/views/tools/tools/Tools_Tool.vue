<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/tools/tools/Tools_Tool.js此处编写
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
    import extend from "@/extension/tools/tools/Tools_Tool.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ToolId',
                footer: "Foots",
                cnName: '工装夹具台账',
                name: 'tools/Tools_Tool',
                url: "/Tools_Tool/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"ToolName":"","ToolCode":"","Brand":"","Spec":"","ToolTypeId":"","MaintenType":"","Quantity":"","QuantityAvail":"","NextMaintenDate":"","Status":"","Remark":""});
            const editFormOptions = ref([[{"title":"工装夹具名称","required":true,"field":"ToolName","type":"text"},
                               {"title":"工装夹具编码","field":"ToolCode","type":"text"}],
                              [{"title":"品牌","field":"Brand","type":"text"},
                               {"title":"型号","field":"Spec","type":"text"}],
                              [{"dataKey":"ToolTypeList","data":[],"title":"工装夹具类型","field":"ToolTypeId","type":"select"},
                               {"dataKey":"MaintenTypeList","data":[],"title":"保养维护方式","field":"MaintenType","type":"select"}],
                              [{"title":"可用数量","field":"QuantityAvail","type":"number"},
                               {"title":"数量","required":true,"field":"Quantity","type":"number"}],
                              [{"title":"下次保养日期","field":"NextMaintenDate","type":"date"},
                               {"dataKey":"ToolStatusList","data":[],"title":"状态","field":"Status","type":"radio"}],
                              [{"title":"备注","field":"Remark","colSize":12,"type":"textarea"}]]);
            const searchFormFields = ref({"ToolName":"","ToolCode":"","Brand":"","Spec":"","ToolTypeId":"","Quantity":[null,null],"QuantityAvail":[null,null],"MaintenType":"","NextMaintenDate":"","Status":"","Remark":"","CreateDate":""});
            const searchFormOptions = ref([[{"title":"工装夹具名称","field":"ToolName","type":"like"},{"title":"工装夹具编码","field":"ToolCode","type":"like"},{"title":"品牌","field":"Brand","type":"like"}],[{"title":"型号","field":"Spec","type":"like"},{"dataKey":"ToolTypeList","data":[],"title":"工装夹具类型","field":"ToolTypeId","type":"select"},{"title":"数量","field":"Quantity","type":"range"}],[{"dataKey":"MaintenTypeList","data":[],"title":"保养维护方式","field":"MaintenType","type":"select"},{"title":"下次保养日期","field":"NextMaintenDate","type":"date"},{"dataKey":"ToolStatusList","data":[],"title":"状态","field":"Status","type":"radio"}],[{"title":"可用数量","field":"QuantityAvail","type":"range"},{"title":"备注","field":"Remark","type":"like"},{"title":"创建时间","field":"CreateDate","type":"date"}]]);
            const columns = ref([{field:'ToolId',title:'工装夹具主键',type:'guid',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ToolName',title:'工装夹具名称',type:'string',link:true,sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'ToolCode',title:'工装夹具编码',type:'string',sort:true,width:120,align:'left'},
                       {field:'Brand',title:'品牌',type:'string',width:120,align:'left'},
                       {field:'Spec',title:'型号',type:'string',width:120,align:'left'},
                       {field:'ToolTypeId',title:'工装夹具类型',type:'guid',bind:{ key:'ToolTypeList',data:[]},width:110,align:'left'},
                       {field:'Quantity',title:'数量',type:'int',width:110,require:true,align:'left'},
                       {field:'QuantityAvail',title:'可用数量',type:'int',width:110,align:'left'},
                       {field:'MaintenType',title:'保养维护方式',type:'string',bind:{ key:'MaintenTypeList',data:[]},width:120,align:'left'},
                       {field:'NextMaintenDate',title:'下次保养日期',type:'date',sort:true,width:110,align:'left'},
                       {field:'Status',title:'状态',type:'string',bind:{ key:'ToolStatusList',data:[]},width:120,align:'left'},
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
