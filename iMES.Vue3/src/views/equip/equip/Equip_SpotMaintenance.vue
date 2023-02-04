<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/equip/equip/Equip_SpotMaintenance.js此处编写
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
    import extend from "@/extension/equip/equip/Equip_SpotMaintenance.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'SpotMaintenanceId',
                footer: "Foots",
                cnName: '点检保养项目',
                name: 'equip/Equip_SpotMaintenance',
                url: "/Equip_SpotMaintenance/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"SpotMaintenanceName":"","SpotMaintenanceCode":"","ItemType":"","Enable":"","ItemContent":"","ItemStandard":""});
            const editFormOptions = ref([[{"title":"项目名称","required":true,"field":"SpotMaintenanceName","type":"text"}],
                              [{"title":"项目编码","field":"SpotMaintenanceCode","type":"text"}],
                              [{"dataKey":"DeviceItemType","data":[],"title":"项目类型","required":true,"field":"ItemType","type":"radio"}],
                              [{"dataKey":"enable","data":[],"title":"是否启用","field":"Enable","type":"radio"}],
                              [{"title":"项目内容","field":"ItemContent","type":"textarea"}],
                              [{"title":"标准","field":"ItemStandard","type":"textarea"}]]);
            const searchFormFields = ref({"SpotMaintenanceName":"","SpotMaintenanceCode":"","ItemType":"","Enable":"","ItemContent":"","ItemStandard":""});
            const searchFormOptions = ref([[{"title":"项目名称","field":"SpotMaintenanceName","type":"like"},{"title":"项目编码","field":"SpotMaintenanceCode","type":"like"},{"dataKey":"DeviceItemType","data":[],"title":"项目类型","field":"ItemType","type":"radio"}],[{"dataKey":"enable","data":[],"title":"是否启用","field":"Enable","type":"radio"},{"title":"项目内容","field":"ItemContent","type":"like"},{"title":"标准","field":"ItemStandard","type":"like"}]]);
            const columns = ref([{field:'SpotMaintenanceId',title:'点检保养项目主键',type:'guid',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'SpotMaintenanceName',title:'项目名称',type:'string',link:true,sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'SpotMaintenanceCode',title:'项目编码',type:'string',sort:true,width:120,align:'left'},
                       {field:'ItemType',title:'项目类型',type:'int',bind:{ key:'DeviceItemType',data:[]},sort:true,width:110,require:true,align:'left'},
                       {field:'Enable',title:'是否启用',type:'int',bind:{ key:'enable',data:[]},sort:true,width:110,align:'left'},
                       {field:'ItemContent',title:'项目内容',type:'string',width:220,align:'left'},
                       {field:'ItemStandard',title:'标准',type:'string',width:220,align:'left'},
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
