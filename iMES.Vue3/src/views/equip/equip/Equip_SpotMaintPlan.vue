<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/equip/equip/Equip_SpotMaintPlan.js此处编写
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
    import extend from "@/extension/equip/equip/Equip_SpotMaintPlan.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'SpotMaintPlanId',
                footer: "Foots",
                cnName: '点检保养计划',
                name: 'equip/Equip_SpotMaintPlan',
                url: "/Equip_SpotMaintPlan/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"SpotMaintPlanName":"","SpotMaintPlanCode":"","PlanItemType":"","Status":"","GhzQty":"","GhzQtyLat":"","StartDate":"","EndDate":"","Remark":""});
            const editFormOptions = ref([[{"title":"计划名称","required":true,"field":"SpotMaintPlanName","type":"text"},
                               {"title":"计划编码","field":"SpotMaintPlanCode","type":"text"}],
                              [{"dataKey":"DevicePlanStatus","data":[],"title":"状态","field":"Status","type":"radio"},
                               {"dataKey":"DevicePlanType","data":[],"title":"计划类型","required":true,"field":"PlanItemType","type":"radio"}],
                              [{"title":"频率","required":true,"field":"GhzQty","type":"number"},
                               {"dataKey":"DevicePlanCycle","data":[],"title":"纬度","required":true,"field":"GhzQtyLat","type":"select"}],
                              [{"title":"开始时间","field":"StartDate","type":"date"},
                               {"title":"结束时间","field":"EndDate","type":"date"}],
                              [{"title":"备注","field":"Remark","colSize":12,"type":"textarea"}]]);
            const searchFormFields = ref({"SpotMaintPlanName":"","SpotMaintPlanCode":"","PlanItemType":"","StartDate":"","EndDate":"","Status":""});
            const searchFormOptions = ref([[{"title":"计划名称","field":"SpotMaintPlanName","type":"like"},{"title":"计划编码","field":"SpotMaintPlanCode","type":"like"},{"dataKey":"DevicePlanType","data":[],"title":"计划类型","field":"PlanItemType","type":"select"}],[{"title":"开始时间","field":"StartDate","type":"date"},{"title":"结束时间","field":"EndDate","type":"date"},{"dataKey":"DevicePlanStatus","data":[],"title":"状态","field":"Status","type":"select"}]]);
            const columns = ref([{field:'SpotMaintPlanId',title:'点检保养主键',type:'guid',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'SpotMaintPlanName',title:'计划名称',type:'string',link:true,sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'SpotMaintPlanCode',title:'计划编码',type:'string',sort:true,width:120,align:'left'},
                       {field:'PlanItemType',title:'计划类型',type:'int',bind:{ key:'DevicePlanType',data:[]},sort:true,width:110,require:true,align:'left'},
                       {field:'GhzQty',title:'频率',type:'int',width:110,require:true,align:'left'},
                       {field:'GhzQtyLat',title:'纬度',type:'int',bind:{ key:'DevicePlanCycle',data:[]},width:110,require:true,align:'left'},
                       {field:'StartDate',title:'开始时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'EndDate',title:'结束时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'Status',title:'状态',type:'int',bind:{ key:'DevicePlanStatus',data:[]},width:110,align:'left'},
                       {field:'NextCheckDate',title:'上次生成时间',type:'datetime',width:150,align:'left',sort:true},
                       {field:'Remark',title:'备注',type:'string',width:220,align:'left'},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',sort:true,width:110,align:'left',sort:true}]);
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
