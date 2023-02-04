<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/custom/Base_Product.js此处编写
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
    import extend from "@/extension/custom/custom/Base_Product.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'Product_Id',
                footer: "Foots",
                cnName: '产品定义',
                name: 'custom/Base_Product',
                url: "/Base_Product/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"ProductCode":"","ProductName":"","Unit_Id":"","ProductStandard":"","ProductAttribute":"","Process_Id":"","MaxInventory":"","MinInventory":"","SafeInventory":"","InventoryQty":"","FinishedProduct":""});
            const editFormOptions = ref([[{"title":"产品编号","field":"ProductCode"},
                               {"title":"产品名称","required":true,"field":"ProductName"}],
                              [{"title":"产品规格","field":"ProductStandard","type":"text"},
                               {"dataKey":"unitList","data":[],"title":"库存单位","required":true,"field":"Unit_Id","type":"select"}],
                              [{"dataKey":"processLineList","data":[],"title":"工艺路线","field":"Process_Id","type":"select"},
                               {"dataKey":"productAttr","data":[],"title":"产品属性","required":true,"field":"ProductAttribute","type":"select"}],
                              [{"title":"最大库存","field":"MaxInventory","type":"number"},
                               {"title":"最小库存","field":"MinInventory","type":"number"}],
                              [{"title":"安全库存","field":"SafeInventory","type":"number"},
                               {"title":"库存数量","field":"InventoryQty","type":"number"}],
                              [{"title":"成品图","field":"FinishedProduct","colSize":12,"type":"img"}]]);
            const searchFormFields = ref({"ProductCode":"","ProductName":"","Unit_Id":"","ProductStandard":"","ProductAttribute":"","Process_Id":"","MaxInventory":"","MinInventory":"","SafeInventory":"","InventoryQty":"","CreateDate":"","ModifyDate":""});
            const searchFormOptions = ref([[{"title":"产品编号","field":"ProductCode","type":"like"},{"title":"产品名称","field":"ProductName","type":"like"},{"dataKey":"unitList","data":[],"title":"库存单位","field":"Unit_Id","type":"select"}],[{"title":"产品规格","field":"ProductStandard","type":"like"},{"dataKey":"productAttr","data":[],"title":"产品属性","field":"ProductAttribute","type":"select"},{"dataKey":"processLineList","data":[],"title":"工艺路线","field":"Process_Id","type":"select"}],[{"title":"最大库存","field":"MaxInventory","type":"number"},{"title":"最小库存","field":"MinInventory","type":"number"},{"title":"安全库存","field":"SafeInventory","type":"number"}],[{"title":"库存数量","field":"InventoryQty","type":"number"},{"title":"创建时间","field":"CreateDate","type":"date"},{"title":"修改时间","field":"ModifyDate","type":"date"}]]);
            const columns = ref([{field:'Product_Id',title:'产品定义主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ProductCode',title:'产品编号',type:'string',sort:true,width:180,align:'left',sort:true},
                       {field:'ProductName',title:'产品名称',type:'string',link:true,sort:true,width:180,require:true,align:'left'},
                       {field:'Unit_Id',title:'库存单位',type:'int',bind:{ key:'unitList',data:[]},width:110,require:true,align:'left'},
                       {field:'ProductStandard',title:'产品规格',type:'string',width:180,align:'left'},
                       {field:'ProductAttribute',title:'产品属性',type:'string',bind:{ key:'productAttr',data:[]},width:180,require:true,align:'left'},
                       {field:'Process_Id',title:'工艺路线',type:'int',bind:{ key:'processLineList',data:[]},width:110,align:'left'},
                       {field:'MaxInventory',title:'最大库存',type:'int',sort:true,width:110,align:'left'},
                       {field:'MinInventory',title:'最小库存',type:'int',sort:true,width:110,align:'left'},
                       {field:'SafeInventory',title:'安全库存',type:'int',sort:true,width:110,align:'left'},
                       {field:'InventoryQty',title:'库存数量',type:'int',sort:true,width:110,align:'left'},
                       {field:'FinishedProduct',title:'成品图',type:'img',width:180,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'}]);
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
