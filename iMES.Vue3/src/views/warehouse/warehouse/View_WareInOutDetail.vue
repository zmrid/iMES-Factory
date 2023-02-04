<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/warehouse/View_WareInOutDetail.js此处编写
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
    import extend from "@/extension/warehouse/warehouse/View_WareInOutDetail.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ID',
                footer: "Foots",
                cnName: '库存收发明细',
                name: 'warehouse/View_WareInOutDetail',
                url: "/View_WareInOutDetail/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({"ProductCode":"","ProductName":"","ProductStandard":"","Unit_Id":"","FormQty":"","WareHouseDate":"","WareHouseBillCode":"","WareHouseBillType":"","InventoryQty":[null,null]});
            const searchFormOptions = ref([[{"title":"产品编号","field":"ProductCode","type":"like"},{"title":"产品名称","field":"ProductName","type":"like"},{"title":"产品规格","field":"ProductStandard","type":"like"}],[{"dataKey":"unitList","data":[],"title":"库存单位","field":"Unit_Id","type":"select"},{"title":"单据数量","field":"FormQty","type":"number"},{"title":"库存收发时间","field":"WareHouseDate","type":"date"}],[{"title":"来源单据编号","field":"WareHouseBillCode","type":"like"},{"dataKey":"allInOutType","data":[],"title":"库存类型","field":"WareHouseBillType","type":"select"},{"title":"当前库存数量","field":"InventoryQty","type":"range"}]]);
            const columns = ref([{field:'ProductCode',title:'产品编号',type:'string',sort:true,width:250,align:'left',sort:true},
                       {field:'ProductName',title:'产品名称',type:'string',sort:true,width:180,align:'left'},
                       {field:'ProductStandard',title:'产品规格',type:'string',width:180,align:'left'},
                       {field:'Unit_Id',title:'库存单位',type:'int',bind:{ key:'unitList',data:[]},sort:true,width:110,align:'left'},
                       {field:'FormQty',title:'单据数量',type:'int',sort:true,width:110,require:true,align:'left'},
                       {field:'ChangeQty',title:'库存变更数量',type:'int',sort:true,width:150,align:'left'},
                       {field:'WareHouseDate',title:'库存收发时间',type:'datetime',sort:true,width:200,align:'left',sort:true},
                       {field:'FromType',title:'来源单据类型',type:'string',sort:true,width:150,require:true,align:'left'},
                       {field:'WareHouseBillCode',title:'来源单据编号',type:'string',sort:true,width:250,align:'left'},
                       {field:'WareHouseBillType',title:'库存类型',type:'string',bind:{ key:'allInOutType',data:[]},width:180,align:'left'},
                       {field:'Remark',title:'备注',type:'string',width:220,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:200,align:'left',sort:true},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'最后更新时间',type:'datetime',width:200,align:'left',sort:true},
                       {field:'MinInventory',title:'最小库存',type:'int',width:110,align:'left'},
                       {field:'MaxInventory',title:'最大库存',type:'int',width:110,align:'left'},
                       {field:'SafeInventory',title:'安全库存',type:'int',width:110,align:'left'},
                       {field:'InventoryQty',title:'当前库存数量',type:'int',width:110,align:'left'},
                       {field:'ID',title:'主键ID',type:'guid',width:110,hidden:true,require:true,align:'left'}]);
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
