<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/equip/equip/Equip_SpotMaintPlanProject.js此处编写
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
    import extend from "@/extension/equip/equip/Equip_SpotMaintPlanProject.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'SpotMaintPlanProjectId',
                footer: "Foots",
                cnName: '点检项目',
                name: 'equip/Equip_SpotMaintPlanProject',
                url: "/Equip_SpotMaintPlanProject/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'SpotMaintPlanProjectId',title:'点检保养项目计划主键',type:'guid',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'SpotMaintPlanId',title:'点检保养项目计划ID',type:'guid',width:110,require:true,align:'left',sort:true},
                       {field:'SpotMaintenanceId',title:'项目主键',type:'guid',width:110,require:true,align:'left'},
                       {field:'SpotMaintenanceName',title:'项目名称',type:'string',link:true,width:120,require:true,align:'left'},
                       {field:'SpotMaintenanceCode',title:'项目编码',type:'string',width:120,require:true,align:'left'},
                       {field:'ItemType',title:'项目类型',type:'int',bind:{ key:'DeviceItemType',data:[]},width:110,require:true,align:'left'},
                       {field:'ItemContent',title:'项目内容',type:'string',width:220,align:'left'},
                       {field:'ItemStandard',title:'标准',type:'string',width:220,align:'left'},
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
