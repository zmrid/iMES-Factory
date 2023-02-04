<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/report/View_OutputStatistics.js此处编写
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
    import extend from "@/extension/report/report/View_OutputStatistics.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ID',
                footer: "Foots",
                cnName: '产量统计',
                name: 'report/View_OutputStatistics',
                url: "/View_OutputStatistics/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({"CreateDate":"","PlanQty":"","ProductName":"","ProductCode":"","ProductStandard":"","Unit_Id":""});
            const searchFormOptions = ref([[{"title":"报工日期","field":"CreateDate","type":"date"},{"title":"工单计划数","field":"PlanQty","type":"number"},{"title":"产品名称","field":"ProductName","type":"like"}],[{"title":"产品编号","field":"ProductCode","type":"like"},{"title":"产品规格","field":"ProductStandard","type":"like"},{"dataKey":"unitList","data":[],"title":"单位","field":"Unit_Id","type":"select"}]]);
            const columns = ref([{field:'CreateDate',title:'报工日期',type:'datetime',sort:true,width:120,align:'left',sort:true},
                       {field:'PlanQty',title:'工单计划数',type:'int',sort:true,width:110,align:'left'},
                       {field:'ProductName',title:'产品名称',type:'string',width:180,require:true,align:'left'},
                       {field:'ProductCode',title:'产品编号',type:'string',width:180,require:true,align:'left'},
                       {field:'ProductStandard',title:'产品规格',type:'string',width:180,align:'left'},
                       {field:'Unit_Id',title:'单位',type:'int',bind:{ key:'unitList',data:[]},width:110,align:'left'},
                       {field:'GoodQty',title:'数量',type:'int',width:110,align:'left'},
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
