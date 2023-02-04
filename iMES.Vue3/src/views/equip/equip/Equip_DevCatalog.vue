<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/equip/equip/Equip_DevCatalog.js此处编写
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
    import extend from "@/extension/equip/equip/Equip_DevCatalog.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'DevCatalogId',
                footer: "Foots",
                cnName: '设备分类设置',
                name: 'equip/Equip_DevCatalog',
                url: "/Equip_DevCatalog/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"DevCatalogName":"","DevCatalogCode":"","Enable":"","ParentId":[],"Remark":""});
            const editFormOptions = ref([[{"title":"设备类型名称","required":true,"field":"DevCatalogName","type":"text"}],
                              [{"title":"设备类型编码","field":"DevCatalogCode","type":"text"}],
                              [{"dataKey":"enable","data":[],"title":"是否启用","required":true,"field":"Enable","type":"radio"}],
                              [{"dataKey":"equipCatalog","data":[],"title":"父分类","field":"ParentId","type":"cascader"}],
                              [{"title":"备注","field":"Remark","type":"textarea"}]]);
            const searchFormFields = ref({"DevCatalogName":"","DevCatalogCode":"","Enable":"","ParentId":[],"Remark":"","CreateDate":[null,null]});
            const searchFormOptions = ref([[{"title":"设备类型名称","field":"DevCatalogName","type":"like"},{"title":"设备类型编码","field":"DevCatalogCode","type":"like"},{"dataKey":"enable","data":[],"title":"是否启用","field":"Enable","type":"radio"}],[{"dataKey":"equipCatalog","data":[],"title":"父分类","field":"ParentId","type":"cascader"},{"title":"备注","field":"Remark","type":"like"},{"title":"创建时间","field":"CreateDate","type":"range"}]]);
            const columns = ref([{field:'DevCatalogId',title:'设备类型主键',type:'guid',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'DevCatalogName',title:'设备类型名称',type:'string',link:true,sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'DevCatalogCode',title:'设备类型编码',type:'string',width:120,align:'left'},
                       {field:'Enable',title:'是否启用',type:'int',bind:{ key:'enable',data:[]},width:110,require:true,align:'left'},
                       {field:'ParentId',title:'父分类',type:'guid',bind:{ key:'equipCatalog',data:[]},width:110,align:'left'},
                       {field:'Remark',title:'备注',type:'string',width:220,align:'left'},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,align:'left',sort:true}]);
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
