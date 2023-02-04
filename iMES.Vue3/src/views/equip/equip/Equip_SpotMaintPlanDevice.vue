<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/equip/equip/Equip_SpotMaintPlanDevice.js此处编写
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
    import extend from "@/extension/equip/equip/Equip_SpotMaintPlanDevice.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'SpotMaintPlanDeviceId',
                footer: "Foots",
                cnName: '设备清单',
                name: 'equip/Equip_SpotMaintPlanDevice',
                url: "/Equip_SpotMaintPlanDevice/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'SpotMaintPlanDeviceId',title:'点检保养计划设备清单主键',type:'guid',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'SpotMaintPlanId',title:'点检保养计划主键',type:'guid',width:110,require:true,align:'left',sort:true},
                       {field:'DeviceId',title:'设备主键',type:'guid',width:110,require:true,align:'left'},
                       {field:'DeviceName',title:'设备名称',type:'string',link:true,width:120,require:true,align:'left'},
                       {field:'DeviceCode',title:'设备编码',type:'string',width:120,require:true,align:'left'},
                       {field:'DeviceBrand',title:'品牌',type:'string',width:120,align:'left'},
                       {field:'ModelType',title:'规格型号',type:'string',width:120,align:'left'},
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
