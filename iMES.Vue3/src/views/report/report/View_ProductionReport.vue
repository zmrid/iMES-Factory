<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/report/View_ProductionReport.js此处编写
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
    import extend from "@/extension/report/report/View_ProductionReport.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ID',
                footer: "Foots",
                cnName: '生产报表',
                name: 'report/View_ProductionReport',
                url: "/View_ProductionReport/",
                sortName: "PlanStartDate"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({"ProductCode":"","ProductName":"","ProductStandard":"","Unit_Id":"","WorkOrderCode":"","PlanQty":[null,null],"RealQty":[null,null],"Status":"","PlanStartDate":"","PlanEndDate":"","ActualStartDate":"","ActualEndDate":"","ProcessCode":"","ProcessName":""});
            const searchFormOptions = ref([[{"title":"产品编号","field":"ProductCode","type":"like"},{"title":"产品名称","field":"ProductName","type":"like"},{"title":"产品规格","field":"ProductStandard","type":"like"}],[{"dataKey":"unitList","data":[],"title":"产品单位","field":"Unit_Id","type":"select"},{"title":"工单编号","field":"WorkOrderCode","type":"like"},{"title":"工单计划数","field":"PlanQty","type":"range"}],[{"title":"工单实际数","field":"RealQty","type":"range"},{"dataKey":"workOrderStatus","data":[],"title":"工单状态","field":"Status","type":"radio"},{"title":"工单计划开始时间","field":"PlanStartDate","type":"date"},{"title":"工单计划结束时间","field":"PlanEndDate","type":"date"}],[{"title":"工单实际开始时间","field":"ActualStartDate","type":"date"},{"title":"工单实际结束时间","field":"ActualEndDate","type":"date"},{"title":"工序编号","field":"ProcessCode","type":"like"},{"title":"工序名称","field":"ProcessName","type":"like"}]]);
            const columns = ref([{field:'ID',title:'ID',type:'guid',width:110,hidden:true,require:true,align:'left'},
                       {field:'ProductCode',title:'产品编号',type:'string',width:250,align:'left',sort:true},
                       {field:'ProductName',title:'产品名称',type:'string',width:180,align:'left'},
                       {field:'ProductStandard',title:'产品规格',type:'string',width:180,align:'left'},
                       {field:'Unit_Id',title:'产品单位',type:'int',bind:{ key:'unitList',data:[]},width:110,hidden:true,align:'left'},
                       {field:'UnitName',title:'产品单位',type:'string',width:180,align:'left'},
                       {field:'WorkOrderCode',title:'工单编号',type:'string',width:250,align:'left'},
                       {field:'PlanQty',title:'工单计划数',type:'int',width:110,align:'left'},
                       {field:'RealQty',title:'工单实际数',type:'int',width:110,align:'left'},
                       {field:'Status',title:'工单状态',type:'string',bind:{ key:'workOrderStatus',data:[]},width:180,align:'left'},
                       {field:'PlanStartDate',title:'工单计划开始时间',type:'datetime',width:200,align:'left',sort:true},
                       {field:'PlanEndDate',title:'工单计划结束时间',type:'datetime',width:200,align:'left',sort:true},
                       {field:'ActualStartDate',title:'工单实际开始时间',type:'datetime',width:200,align:'left',sort:true},
                       {field:'ActualEndDate',title:'工单实际结束时间',type:'datetime',width:200,align:'left',sort:true},
                       {field:'Remark',title:'工单备注',type:'string',width:220,align:'left'},
                       {field:'ProcessCode',title:'工序编号',type:'string',width:180,require:true,align:'left'},
                       {field:'ProcessName',title:'工序名称',type:'string',width:180,require:true,align:'left'},
                       {field:'SubmitWorkMatch',title:'报工数配比',type:'decimal',width:110,require:true,align:'left'},
                       {field:'TaskPlanStartDate',title:'任务计划开始时间',type:'datetime',width:200,require:true,align:'left',sort:true},
                       {field:'TaskPlanEndDate',title:'任务计划结束时间',type:'datetime',width:200,require:true,align:'left',sort:true},
                       {field:'TaskActualStartDate',title:'任务实际开始时间',type:'datetime',width:200,align:'left',sort:true},
                       {field:'TaskActualEndDate',title:'任务实际结束时间',type:'datetime',width:200,align:'left',sort:true},
                       {field:'TaskPlanQty',title:'任务计划数',type:'int',width:110,require:true,align:'left'},
                       {field:'TaskRealQty',title:'任务实际数',type:'int',width:110,align:'left'}]);
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
