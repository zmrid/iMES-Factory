<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/custom/View_Base_MaterialDetail.js此处编写
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
    import extend from "@/extension/custom/custom/View_Base_MaterialDetail.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'MaterialDetail_Id',
                footer: "Foots",
                cnName: '物料清单',
                name: 'custom/View_Base_MaterialDetail',
                url: "/View_Base_MaterialDetail/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"ParentProduct_Id":"","ChildProduct_Id":"","QuantityPer":"","Remark":""});
            const editFormOptions = ref([[{"dataKey":"productList","data":[],"title":"父项产品","required":true,"field":"ParentProduct_Id","type":"select"}],
                              [{"dataKey":"productList","data":[],"title":"子项产品","required":true,"field":"ChildProduct_Id","type":"select"}],
                              [{"title":"单位用量","required":true,"field":"QuantityPer","type":"number"}],
                              [{"title":"备注","field":"Remark","type":"textarea"}]]);
            const searchFormFields = ref({"PProductCode":"","PProductName":"","PProductStandard":"","CProductCode":"","CProductName":"","CProductStandard":"","QuantityPer":[null,null],"Remark":"","CreateDate":""});
            const searchFormOptions = ref([[{"title":"父项产品编号","field":"PProductCode","type":"like"},{"title":"父项产品名称","field":"PProductName","type":"like"},{"title":"父项产品规格","field":"PProductStandard","type":"like"}],[{"title":"子项产品编号","field":"CProductCode","type":"like"},{"title":"子项产品名称","field":"CProductName","type":"like"},{"title":"子项产品规格","field":"CProductStandard","type":"like"}],[{"title":"单位用量","field":"QuantityPer","type":"range"},{"title":"备注","field":"Remark","type":"like"},{"title":"创建时间","field":"CreateDate","type":"date"}]]);
            const columns = ref([{field:'MaterialDetail_Id',title:'MaterialDetail_Id',type:'int',width:110,hidden:true,require:true,align:'left'},
                       {field:'ParentProduct_Id',title:'父项产品',type:'int',bind:{ key:'productList',data:[]},sort:true,width:110,hidden:true,require:true,align:'left'},
                       {field:'PProductCode',title:'父项产品编号',type:'string',link:true,sort:true,width:250,align:'left',sort:true},
                       {field:'PProductName',title:'父项产品名称',type:'string',sort:true,width:180,align:'left'},
                       {field:'PProductStandard',title:'父项产品规格',type:'string',width:180,align:'left'},
                       {field:'PUnit_Id',title:'父项单位',type:'int',bind:{ key:'unitList',data:[]},width:110,align:'left'},
                       {field:'ChildProduct_Id',title:'子项产品',type:'int',bind:{ key:'productList',data:[]},sort:true,width:110,hidden:true,require:true,align:'left'},
                       {field:'CProductCode',title:'子项产品编号',type:'string',sort:true,width:250,align:'left'},
                       {field:'CProductName',title:'子项产品名称',type:'string',sort:true,width:180,align:'left'},
                       {field:'CProductStandard',title:'子项产品规格',type:'string',width:180,align:'left'},
                       {field:'CUnit_Id',title:'子项单位',type:'int',bind:{ key:'unitList',data:[]},width:110,align:'left'},
                       {field:'QuantityPer',title:'单位用量',type:'int',sort:true,width:110,require:true,align:'left'},
                       {field:'Remark',title:'备注',type:'string',width:220,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'CreateID',title:'CreateID',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'ModifyID',type:'int',width:80,hidden:true,align:'left'}]);
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
