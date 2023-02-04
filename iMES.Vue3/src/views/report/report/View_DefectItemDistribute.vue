<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/report/View_DefectItemDistribute.js此处编写
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
    import extend from "@/extension/report/report/View_DefectItemDistribute.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ID',
                footer: "Foots",
                cnName: '不良品项分布',
                name: 'report/View_DefectItemDistribute',
                url: "/View_DefectItemDistribute/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({"CreateDate":"","DefectItemCode":"","DefectItemName":""});
            const searchFormOptions = ref([[{"title":"时间","field":"CreateDate","type":"date"},{"title":"不良品项编号","field":"DefectItemCode","type":"like"},{"title":"不良品项名称","field":"DefectItemName","type":"like"}]]);
            const columns = ref([{field:'ID',title:'主键ID',type:'guid',width:110,hidden:true,require:true,align:'left'},
                       {field:'CreateDate',title:'时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'DefectItemCode',title:'不良品项编号',type:'string',sort:true,width:180,align:'left'},
                       {field:'DefectItemName',title:'不良品项名称',type:'string',sort:true,width:180,align:'left'},
                       {field:'Qty',title:'数量',type:'int',sort:true,width:110,align:'left'},
                       {field:'AllQty',title:'总数量',type:'int',sort:true,width:110,align:'left'},
                       {field:'PassPercent',title:'占比',type:'string',width:120,align:'left'}]);
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
