<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/equip/equip/Equip_SpotMaintWorkOrder.js此处编写
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
    import extend from "@/extension/equip/equip/Equip_SpotMaintWorkOrder.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'SpotMaintWorkOrderId',
                footer: "Foots",
                cnName: '点检保养工单',
                name: 'equip/Equip_SpotMaintWorkOrder',
                url: "/Equip_SpotMaintWorkOrder/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"SpotMaintWorkOrderCode":"","SpotMaintPlanId":"","SpotMaintPlanName":"","SpotMaintPlanCode":"","PlanItemType":"","PlanStartDate":"","PlanEndDate":"","Status":"","Remark":""});
            const editFormOptions = ref([[{"title":"工单编码","field":"SpotMaintWorkOrderCode","type":"text"}],
                              [{"title":"点检保养计划","required":true,"field":"SpotMaintPlanId","disabled":true}],
                              [{"title":"计划名称","required":true,"field":"SpotMaintPlanName","disabled":true,"type":"text"}],
                              [{"title":"计划编码","required":true,"field":"SpotMaintPlanCode","disabled":true,"type":"text"}],
                              [{"dataKey":"DevicePlanType","data":[],"title":"计划类型","required":true,"field":"PlanItemType","disabled":true,"type":"select"}],
                              [{"title":"计划开始时间","required":true,"field":"PlanStartDate","type":"date"}],
                              [{"title":"计划结束时间","required":true,"field":"PlanEndDate","type":"date"}],
                              [{"dataKey":"DeviceWorkOrderStatus","data":[],"title":"状态","required":true,"field":"Status","type":"radio"}],
                              [{"title":"备注","field":"Remark","type":"textarea"}]]);
            const searchFormFields = ref({"SpotMaintWorkOrderCode":"","SpotMaintPlanName":"","SpotMaintPlanCode":"","PlanItemType":"","PlanStartDate":"","PlanEndDate":"","Status":"","Remark":"","CreateDate":""});
            const searchFormOptions = ref([[{"title":"工单编码","field":"SpotMaintWorkOrderCode","type":"like"},{"title":"计划名称","field":"SpotMaintPlanName","type":"like"},{"title":"计划编码","field":"SpotMaintPlanCode","type":"like"}],[{"dataKey":"DevicePlanType","data":[],"title":"计划类型","field":"PlanItemType","type":"select"},{"title":"计划开始时间","field":"PlanStartDate","type":"date"},{"title":"计划结束时间","field":"PlanEndDate","type":"date"}],[{"dataKey":"DeviceWorkOrderStatus","data":[],"title":"状态","field":"Status","type":"select"},{"title":"备注","field":"Remark","type":"like"},{"title":"创建时间","field":"CreateDate","type":"date"}]]);
            const columns = ref([{field:'SpotMaintWorkOrderId',title:'点检保养工单主键',type:'guid',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'SpotMaintWorkOrderCode',title:'工单编码',type:'string',link:true,sort:true,width:120,align:'left',sort:true},
                       {field:'SpotMaintPlanId',title:'点检保养计划',type:'guid',sort:true,width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'SpotMaintPlanName',title:'计划名称',type:'string',sort:true,width:120,readonly:true,require:true,align:'left'},
                       {field:'SpotMaintPlanCode',title:'计划编码',type:'string',sort:true,width:120,readonly:true,require:true,align:'left'},
                       {field:'PlanItemType',title:'计划类型',type:'int',bind:{ key:'DevicePlanType',data:[]},sort:true,width:110,readonly:true,require:true,align:'left'},
                       {field:'PlanStartDate',title:'计划开始时间',type:'date',sort:true,width:110,require:true,align:'left'},
                       {field:'PlanEndDate',title:'计划结束时间',type:'date',sort:true,width:110,require:true,align:'left'},
                       {field:'Status',title:'状态',type:'int',bind:{ key:'DeviceWorkOrderStatus',data:[]},width:110,require:true,align:'left'},
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
