<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/warehouse/warehouse/Ware_WareHouseBillList.js此处编写
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
    import extend from "@/extension/warehouse/warehouse/Ware_WareHouseBillList.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'WareHouseBillList_Id',
                footer: "Foots",
                cnName: '入库单明细',
                name: 'warehouse/Ware_WareHouseBillList',
                url: "/Ware_WareHouseBillList/",
                sortName: "WareHouseBillList_Id"
            });
            const editFormFields = ref({"ProductName":"","ProductCode":"","Unit_Id":"","ProductStandard":"","MaxInventory":"","MinInventory":"","SafeInventory":"","InStoreQty":"","InventoryQty":"","Product_Id":""});
            const editFormOptions = ref([[{"title":"产品规格","field":"ProductStandard","disabled":true},
                               {"title":"最大库存","field":"MaxInventory","disabled":true,"type":"number"},
                               {"title":"最小库存","field":"MinInventory","disabled":true,"type":"number"},
                               {"title":"安全库存","field":"SafeInventory","disabled":true,"type":"number"},
                               {"title":"当前库存数量","field":"InventoryQty","disabled":true,"type":"number"},
                               {"title":"产品名称","required":true,"field":"ProductName","disabled":true,"type":"text"},
                               {"title":"产品编号","required":true,"field":"ProductCode","disabled":true,"type":"text"},
                               {"dataKey":"unitList","data":[],"title":"库存单位","required":true,"field":"Unit_Id","disabled":true,"type":"select"},
                               {"title":"入库数量","required":true,"field":"InStoreQty","type":"number"},
                               {"title":"产品ID","required":true,"field":"Product_Id","disabled":true,"type":"text"}]]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'WareHouseBillList_Id',title:'入库单产品明细表主键ID',type:'int',width:80,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'WareHouseBill_Id',title:'入库单',type:'int',width:80,hidden:true,require:true,align:'left'},
                       {field:'ProductName',title:'产品名称',type:'string',sort:true,width:150,readonly:true,require:true,align:'left',sort:true},
                       {field:'ProductCode',title:'产品编号',type:'string',sort:true,width:200,readonly:true,require:true,align:'left'},
                       {field:'Unit_Id',title:'库存单位',type:'int',bind:{ key:'unitList',data:[]},width:120,readonly:true,require:true,align:'left'},
                       {field:'ProductStandard',title:'产品规格',type:'string',width:120,readonly:true,align:'left'},
                       {field:'MaxInventory',title:'最大库存',type:'int',sort:true,width:120,readonly:true,align:'left'},
                       {field:'MinInventory',title:'最小库存',type:'int',sort:true,width:120,readonly:true,align:'left'},
                       {field:'SafeInventory',title:'安全库存',type:'int',sort:true,width:120,readonly:true,align:'left'},
                       {field:'InStoreQty',title:'入库数量',type:'int',sort:true,width:120,require:true,align:'left'},
                       {field:'InventoryQty',title:'当前库存数量',type:'int',sort:true,width:120,readonly:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:150,align:'left',sort:true},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:150,align:'left',sort:true},
                       {field:'Product_Id',title:'产品ID',type:'int',width:80,readonly:true,require:true,align:'left'}]);
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
