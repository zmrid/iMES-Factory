<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/report/View_DefectItemSummary.js此处编写
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
    import extend from "@/extension/report/report/View_DefectItemSummary.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ID',
                footer: "Foots",
                cnName: '不良品项汇总',
                name: 'report/View_DefectItemSummary',
                url: "/View_DefectItemSummary/",
                sortName: "StartDate"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({"WorkOrderCode":"","ProductCode":"","ProductName":"","ProcessCode":"","ProcessName":"","UserTrueName":"","StartDate":"","EndDate":"","DefectItem":"","PlanQty":"","ReportQty":"","GoodQty":""});
            const searchFormOptions = ref([[{"title":"工单编号","field":"WorkOrderCode","type":"like"},{"title":"产品编号","field":"ProductCode","type":"like"},{"title":"产品名称","field":"ProductName","type":"like"}],[{"title":"工序编号","field":"ProcessCode","type":"like"},{"title":"工序名称","field":"ProcessName","type":"like"},{"title":"生产人员","field":"UserTrueName","type":"like"}],[{"title":"生产开始时间","field":"StartDate","type":"date"},{"title":"生产结束时间","field":"EndDate","type":"date"},{"dataKey":"DefectItem","data":[],"title":"不良品项","field":"DefectItem","type":"select"}],[{"title":"工序计划数","field":"PlanQty","type":"number"},{"title":"报工数","field":"ReportQty","type":"number"},{"title":"良品数","field":"GoodQty","type":"number"}]]);
            const columns = ref([{field:'ID',title:'ID',type:'guid',width:110,hidden:true,require:true,align:'left'},
                       {field:'WorkOrderCode',title:'工单编号',type:'string',sort:true,width:180,align:'left',sort:true},
                       {field:'ProductCode',title:'产品编号',type:'string',sort:true,width:180,align:'left'},
                       {field:'ProductName',title:'产品名称',type:'string',sort:true,width:180,align:'left'},
                       {field:'ProductStandard',title:'产品规格',type:'string',sort:true,width:180,align:'left'},
                       {field:'ProcessCode',title:'工序编号',type:'string',sort:true,width:180,align:'left'},
                       {field:'ProcessName',title:'工序名称',type:'string',sort:true,width:180,align:'left'},
                       {field:'UserTrueName',title:'生产人员',type:'string',sort:true,width:110,align:'left'},
                       {field:'StartDate',title:'生产开始时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'EndDate',title:'生产结束时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'DefectItem',title:'不良品项',type:'string',bind:{ key:'DefectItem',data:[]},width:180,hidden:true,require:true,align:'left'},
                       {field:'DefectItemName',title:'不良品项',type:'string',sort:true,width:180,align:'left'},
                       {field:'PlanQty',title:'工序计划数',type:'int',sort:true,width:110,align:'left'},
                       {field:'ReportQty',title:'报工数',type:'int',sort:true,width:110,align:'left'},
                       {field:'GoodQty',title:'良品数',type:'int',sort:true,width:110,align:'left'},
                       {field:'NoGoodQty',title:'不良品数',type:'int',sort:true,width:110,require:true,align:'left'},
                       {field:'NoPassPercent',title:'不良品率',type:'string',width:120,align:'left'}]);
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
