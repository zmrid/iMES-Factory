<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/warehouse/warehouse/Ware_WareHouseBill.js此处编写
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
    import extend from "@/extension/warehouse/warehouse/Ware_WareHouseBill.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'WareHouseBill_Id',
                footer: "Foots",
                cnName: '入库单',
                name: 'warehouse/Ware_WareHouseBill',
                url: "/Ware_WareHouseBill/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"WareHouseBillCode":"","WareHouseBillType":"","WareHouseDate":"","Remark":""});
            const editFormOptions = ref([[{"title":"入库单号","field":"WareHouseBillCode","type":"text"},
                               {"dataKey":"inStoreType","data":[],"title":"入库类型","required":true,"field":"WareHouseBillType","type":"select"}],
                              [{"title":"备注","field":"Remark","type":"textarea"},
                               {"title":"入库时间","required":true,"field":"WareHouseDate","type":"datetime"}]]);
            const searchFormFields = ref({"WareHouseBillCode":"","WareHouseBillType":"","WareHouseDate":"","Remark":"","CreateDate":""});
            const searchFormOptions = ref([[{"title":"入库单号","field":"WareHouseBillCode","type":"like"},{"dataKey":"inStoreType","data":[],"title":"入库类型","field":"WareHouseBillType","type":"select"},{"title":"入库时间","field":"WareHouseDate","type":"date"}],[{"title":"备注","field":"Remark","type":"like"},{"title":"创建时间","field":"CreateDate","type":"date"}]]);
            const columns = ref([{field:'WareHouseBill_Id',title:'入库单主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'WareHouseBillCode',title:'入库单号',type:'string',link:true,sort:true,width:180,align:'left',sort:true},
                       {field:'WareHouseBillType',title:'入库类型',type:'string',bind:{ key:'inStoreType',data:[]},sort:true,width:180,require:true,align:'left'},
                       {field:'WareHouseDate',title:'入库时间',type:'datetime',sort:true,width:110,require:true,align:'left',sort:true},
                       {field:'Remark',title:'备注',type:'string',width:220,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'}]);
            const detail = ref({
                cnName: "入库单明细",
                table: "Ware_WareHouseBillList",
                columns: [{field:'WareHouseBillList_Id',title:'入库单产品明细表主键ID',type:'int',width:80,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'WareHouseBill_Id',title:'入库单',type:'int',width:80,hidden:true,require:true,align:'left'},
                       {field:'ProductName',title:'产品名称',type:'string',sort:true,width:150,readonly:true,edit:{type:'text'},require:true,align:'left',sort:true},
                       {field:'ProductCode',title:'产品编号',type:'string',sort:true,width:200,readonly:true,edit:{type:'text'},require:true,align:'left'},
                       {field:'Unit_Id',title:'库存单位',type:'int',bind:{ key:'unitList',data:[]},width:120,readonly:true,edit:{type:'select'},require:true,align:'left'},
                       {field:'ProductStandard',title:'产品规格',type:'string',width:120,readonly:true,edit:{type:''},align:'left'},
                       {field:'MaxInventory',title:'最大库存',type:'int',sort:true,width:120,readonly:true,edit:{type:''},align:'left'},
                       {field:'MinInventory',title:'最小库存',type:'int',sort:true,width:120,readonly:true,edit:{type:''},align:'left'},
                       {field:'SafeInventory',title:'安全库存',type:'int',sort:true,width:120,readonly:true,edit:{type:''},align:'left'},
                       {field:'InStoreQty',title:'入库数量',type:'int',sort:true,width:120,edit:{type:'number'},require:true,align:'left'},
                       {field:'InventoryQty',title:'当前库存数量',type:'int',sort:true,width:120,readonly:true,edit:{type:''},align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:150,align:'left',sort:true},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:150,align:'left',sort:true},
                       {field:'Product_Id',title:'产品ID',type:'int',width:80,readonly:true,edit:{type:'text'},require:true,align:'left'}],
                sortName: "WareHouseBillList_Id",
                key: "WareHouseBillList_Id"
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
