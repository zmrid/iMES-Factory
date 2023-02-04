<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/equip/equip/Equip_Device.js此处编写
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
    import extend from "@/extension/equip/equip/Equip_Device.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'DeviceId',
                footer: "Foots",
                cnName: '设备台账',
                name: 'equip/Equip_Device',
                url: "/Equip_Device/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"DeviceName":"","DeviceCode":"","DeviceBrand":"","ModelType":"","WorkShopId":"","ParentId":[]});
            const editFormOptions = ref([[{"title":"设备名称","required":true,"field":"DeviceName","type":"text"}],
                              [{"title":"设备编码","field":"DeviceCode","type":"text"}],
                              [{"title":"品牌","field":"DeviceBrand","type":"text"}],
                              [{"title":"规格型号","field":"ModelType","type":"text"}],
                              [{"dataKey":"workShopList","data":[],"title":"所属车间","field":"WorkShopId","type":"select"}],
                              [{"dataKey":"equipCatalog","data":[],"title":"设备分类","required":true,"field":"ParentId","type":"cascader"}]]);
            const searchFormFields = ref({"DeviceName":"","DeviceCode":"","DeviceBrand":"","ModelType":"","WorkShopId":"","ParentId":[]});
            const searchFormOptions = ref([[{"title":"设备名称","field":"DeviceName","type":"like"},{"title":"设备编码","field":"DeviceCode","type":"like"},{"title":"品牌","field":"DeviceBrand","type":"like"}],[{"title":"规格型号","field":"ModelType","type":"like"},{"dataKey":"workShopList","data":[],"title":"所属车间","field":"WorkShopId","type":"select"},{"dataKey":"equipCatalog","data":[],"title":"设备分类","field":"ParentId","type":"cascader"}]]);
            const columns = ref([{field:'DeviceId',title:'设备主键',type:'guid',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'DeviceName',title:'设备名称',type:'string',link:true,sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'DeviceCode',title:'设备编码',type:'string',sort:true,width:120,align:'left'},
                       {field:'DeviceBrand',title:'品牌',type:'string',sort:true,width:120,align:'left'},
                       {field:'ModelType',title:'规格型号',type:'string',sort:true,width:120,align:'left'},
                       {field:'WorkShopId',title:'所属车间',type:'guid',bind:{ key:'workShopList',data:[]},width:110,align:'left'},
                       {field:'ParentId',title:'设备分类',type:'guid',bind:{ key:'equipCatalog',data:[]},width:110,require:true,align:'left'},
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
