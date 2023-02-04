<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/warehouse/warehouse/Ware_OutWareHouseBillList.js此处编写
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
    import extend from "@/extension/warehouse/warehouse/Ware_OutWareHouseBillList.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'OutWareHouseBillList_Id',
                footer: "Foots",
                cnName: '出库单明细',
                name: 'warehouse/Ware_OutWareHouseBillList',
                url: "/Ware_OutWareHouseBillList/",
                sortName: "OutWareHouseBillList_Id"
            });
            const editFormFields = ref({"ProductCode":"","ProductName":"","Unit_Id":"","ProductStandard":"","MaxInventory":"","MinInventory":"","SafeInventory":"","InventoryQty":"","OutStoreQty":"","Product_Id":""});
            const editFormOptions = ref([[{"title":"产品规格","field":"ProductStandard","disabled":true},
                               {"title":"最大库存","field":"MaxInventory","disabled":true,"type":"number"},
                               {"title":"最小库存","field":"MinInventory","disabled":true,"type":"number"},
                               {"title":"安全库存","field":"SafeInventory","type":"number"},
                               {"title":"当前库存数量","field":"InventoryQty","disabled":true,"type":"number"},
                               {"title":"产品编号","required":true,"field":"ProductCode","disabled":true,"type":"text"},
                               {"title":"产品名称","required":true,"field":"ProductName","disabled":true,"type":"text"},
                               {"dataKey":"unitList","data":[],"title":"库存单位","required":true,"field":"Unit_Id","disabled":true,"type":"select"},
                               {"title":"出库数量","required":true,"field":"OutStoreQty","type":"text"},
                               {"title":"产品ID","required":true,"field":"Product_Id","disabled":true,"type":"text"}]]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'OutWareHouseBillList_Id',title:'出库单产品明细表主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'OutWareHouseBill_Id',title:'出库单',type:'int',width:200,hidden:true,require:true,align:'left'},
                       {field:'ProductCode',title:'产品编号',type:'string',link:true,sort:true,width:250,readonly:true,require:true,align:'left',sort:true},
                       {field:'ProductName',title:'产品名称',type:'string',width:180,readonly:true,require:true,align:'left'},
                       {field:'Unit_Id',title:'库存单位',type:'int',bind:{ key:'unitList',data:[]},width:110,readonly:true,require:true,align:'left'},
                       {field:'ProductStandard',title:'产品规格',type:'string',sort:true,width:180,readonly:true,align:'left'},
                       {field:'MaxInventory',title:'最大库存',type:'int',sort:true,width:110,readonly:true,align:'left'},
                       {field:'MinInventory',title:'最小库存',type:'int',sort:true,width:110,readonly:true,align:'left'},
                       {field:'SafeInventory',title:'安全库存',type:'int',sort:true,width:110,align:'left'},
                       {field:'InventoryQty',title:'当前库存数量',type:'int',sort:true,width:110,readonly:true,align:'left'},
                       {field:'OutStoreQty',title:'出库数量',type:'int',width:110,require:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Product_Id',title:'产品ID',type:'int',width:110,readonly:true,require:true,align:'left'}]);
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
