<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/warehouse/warehouse/View_StockBalance.js此处编写
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
    import extend from "@/extension/warehouse/warehouse/View_StockBalance.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'Product_Id',
                footer: "Foots",
                cnName: '库存余额',
                name: 'warehouse/View_StockBalance',
                url: "/View_StockBalance/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({"ProductCode":"","ProductName":"","ProductStandard":"","InventoryQty":[null,null],"Unit_Id":"","Process_Id":"","MaxInventory":"","MinInventory":"","SafeInventory":""});
            const searchFormOptions = ref([[{"title":"产品编码","field":"ProductCode","type":"like"},{"title":"产品名称","field":"ProductName","type":"like"},{"title":"产品规格","field":"ProductStandard","type":"like"}],[{"title":"库存数量","field":"InventoryQty","type":"range"},{"dataKey":"unitList","data":[],"title":"单位","field":"Unit_Id","type":"select"},{"dataKey":"processLineList","data":[],"title":"工艺路线","field":"Process_Id","type":"select"}],[{"title":"最大库存","field":"MaxInventory","type":"number"},{"title":"最小库存","field":"MinInventory","type":"number"},{"title":"安全库存","field":"SafeInventory","type":"number"}]]);
            const columns = ref([{field:'ProductCode',title:'产品编码',type:'string',width:240,require:true,align:'left',sort:true},
                       {field:'ProductName',title:'产品名称',type:'string',sort:true,width:180,require:true,align:'left'},
                       {field:'ProductStandard',title:'产品规格',type:'string',sort:true,width:180,align:'left'},
                       {field:'InventoryQty',title:'库存数量',type:'int',sort:true,width:110,align:'left'},
                       {field:'Unit_Id',title:'单位',type:'int',bind:{ key:'unitList',data:[]},width:110,require:true,align:'left'},
                       {field:'Process_Id',title:'工艺路线',type:'int',bind:{ key:'processLineList',data:[]},width:150,align:'left'},
                       {field:'MaxInventory',title:'最大库存',type:'int',sort:true,width:110,align:'left'},
                       {field:'MinInventory',title:'最小库存',type:'int',sort:true,width:110,align:'left'},
                       {field:'SafeInventory',title:'安全库存',type:'int',sort:true,width:110,align:'left'},
                       {field:'ProductAttribute',title:'产品属性',type:'string',bind:{ key:'productAttr',data:[]},width:180,require:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:180,align:'left',sort:true},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'最后修改时间',type:'datetime',width:180,align:'left',sort:true},
                       {field:'Product_Id',title:'主键ID',type:'int',width:80,hidden:true,require:true,align:'left'}]);
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
