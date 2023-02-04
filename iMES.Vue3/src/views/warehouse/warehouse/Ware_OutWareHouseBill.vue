<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/warehouse/warehouse/Ware_OutWareHouseBill.js此处编写
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
    import extend from "@/extension/warehouse/warehouse/Ware_OutWareHouseBill.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'OutWareHouseBill_Id',
                footer: "Foots",
                cnName: '出库单',
                name: 'warehouse/Ware_OutWareHouseBill',
                url: "/Ware_OutWareHouseBill/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"OutWareHouseBillCode":"","OutWareHouseBillType":"","OutWareHouseDate":"","Remark":"","ImageUrl":"","Attachement":""});
            const editFormOptions = ref([[{"title":"出库单号","field":"OutWareHouseBillCode","type":"text"},
                               {"dataKey":"outStoreType","data":[],"title":"出库类型","required":true,"field":"OutWareHouseBillType","type":"select"}],
                              [{"title":"备注","field":"Remark","type":"textarea"},
                               {"title":"出库时间","required":true,"field":"OutWareHouseDate","type":"datetime"}],
                              [{"title":"缩略图","field":"ImageUrl","type":"img"},
                               {"title":"附件","field":"Attachement","type":"file"}]]);
            const searchFormFields = ref({"OutWareHouseBillCode":"","OutWareHouseBillType":"","OutWareHouseDate":"","AuditStatus":"","Remark":"","CreateDate":""});
            const searchFormOptions = ref([[{"title":"出库单号","field":"OutWareHouseBillCode","type":"like"},{"dataKey":"outStoreType","data":[],"title":"出库类型","field":"OutWareHouseBillType","type":"select"},{"title":"出库时间","field":"OutWareHouseDate","type":"date"}],[{"dataKey":"audit","data":[],"title":"审批状态","field":"AuditStatus","type":"select"},{"title":"备注","field":"Remark","type":"like"},{"title":"创建时间","field":"CreateDate","type":"date"}]]);
            const columns = ref([{field:'OutWareHouseBill_Id',title:'出库单主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'OutWareHouseBillCode',title:'出库单号',type:'string',link:true,sort:true,width:180,align:'left',sort:true},
                       {field:'OutWareHouseBillType',title:'出库类型',type:'string',bind:{ key:'outStoreType',data:[]},sort:true,width:180,require:true,align:'left'},
                       {field:'OutWareHouseDate',title:'出库时间',type:'datetime',sort:true,width:110,require:true,align:'left',sort:true},
                       {field:'AuditStatus',title:'审批状态',type:'int',bind:{ key:'audit',data:[]},width:80,align:'left'},
                       {field:'ImageUrl',title:'缩略图',type:'img',width:220,align:'left'},
                       {field:'Attachement',title:'附件',type:'file',width:220,align:'left'},
                       {field:'Remark',title:'备注',type:'string',width:220,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'}]);
            const detail = ref({
                cnName: "出库单明细",
                table: "Ware_OutWareHouseBillList",
                columns: [{field:'OutWareHouseBillList_Id',title:'出库单产品明细表主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'OutWareHouseBill_Id',title:'出库单',type:'int',width:200,hidden:true,require:true,align:'left'},
                       {field:'ProductCode',title:'产品编号',type:'string',link:true,sort:true,width:250,readonly:true,edit:{type:'text'},require:true,align:'left',sort:true},
                       {field:'ProductName',title:'产品名称',type:'string',width:180,readonly:true,edit:{type:'text'},require:true,align:'left'},
                       {field:'Unit_Id',title:'库存单位',type:'int',bind:{ key:'unitList',data:[]},width:110,readonly:true,edit:{type:'select'},require:true,align:'left'},
                       {field:'ProductStandard',title:'产品规格',type:'string',sort:true,width:180,readonly:true,edit:{type:''},align:'left'},
                       {field:'MaxInventory',title:'最大库存',type:'int',sort:true,width:110,readonly:true,edit:{type:''},align:'left'},
                       {field:'MinInventory',title:'最小库存',type:'int',sort:true,width:110,readonly:true,edit:{type:''},align:'left'},
                       {field:'SafeInventory',title:'安全库存',type:'int',sort:true,width:110,edit:{type:''},align:'left'},
                       {field:'InventoryQty',title:'当前库存数量',type:'int',sort:true,width:110,readonly:true,edit:{type:''},align:'left'},
                       {field:'OutStoreQty',title:'出库数量',type:'int',width:110,edit:{type:'text'},require:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Product_Id',title:'产品ID',type:'int',width:110,readonly:true,edit:{type:'text'},require:true,align:'left'}],
                sortName: "OutWareHouseBillList_Id",
                key: "OutWareHouseBillList_Id"
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
