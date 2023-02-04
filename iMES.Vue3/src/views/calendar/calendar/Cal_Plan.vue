<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/calendar/calendar/Cal_Plan.js此处编写
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
    import extend from "@/extension/calendar/calendar/Cal_Plan.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'PlanId',
                footer: "Foots",
                cnName: '排班计划',
                name: 'calendar/Cal_Plan',
                url: "/Cal_Plan/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"PlanName":"","PlanCode":"","TeamType":"","Status":"","StartDate":"","EndDate":"","ShiftType":"","ChangeShiftType":"","Remark":""});
            const editFormOptions = ref([[{"title":"计划名称","required":true,"field":"PlanName","type":"text"},
                               {"title":"计划编码","field":"PlanCode","type":"text"}],
                              [{"dataKey":"TeamType","data":[],"title":"班组类型","field":"TeamType","type":"select"},
                               {"dataKey":"CalendarStatusList","data":[],"title":"状态","field":"Status","type":"radio"}],
                              [{"title":"开始时间","field":"StartDate","type":"date"},
                               {"title":"结束时间","field":"EndDate","type":"date"}],
                              [{"dataKey":"ShiftTypeList","data":[],"title":"轮班方式","field":"ShiftType","type":"radio"},
                               {"dataKey":"ChangeShiftTypeList","data":[],"title":"倒班方式","field":"ChangeShiftType","type":"radio"}],
                              [{"title":"备注","field":"Remark","colSize":12,"type":"textarea"}]]);
            const searchFormFields = ref({"PlanName":"","PlanCode":"","TeamType":"","StartDate":"","EndDate":"","ShiftType":"","ChangeShiftType":"","Status":"","Remark":""});
            const searchFormOptions = ref([[{"title":"计划名称","field":"PlanName","type":"like"},{"title":"计划编码","field":"PlanCode","type":"like"},{"dataKey":"TeamType","data":[],"title":"班组类型","field":"TeamType","type":"select"}],[{"dataKey":"ShiftTypeList","data":[],"title":"轮班方式","field":"ShiftType","type":"radio"},{"dataKey":"ChangeShiftTypeList","data":[],"title":"倒班方式","field":"ChangeShiftType","type":"radio"},{"dataKey":"CalendarStatusList","data":[],"title":"状态","field":"Status","type":"radio"}],[{"title":"开始时间","field":"StartDate","type":"date"},{"title":"结束时间","field":"EndDate","type":"date"},{"title":"备注","field":"Remark","type":"like"}]]);
            const columns = ref([{field:'PlanId',title:'排版计划主键',type:'guid',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'PlanName',title:'计划名称',type:'string',link:true,sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'PlanCode',title:'计划编码',type:'string',sort:true,width:120,align:'left'},
                       {field:'TeamType',title:'班组类型',type:'string',bind:{ key:'TeamType',data:[]},width:120,align:'left'},
                       {field:'StartDate',title:'开始时间',type:'date',sort:true,width:110,align:'left'},
                       {field:'EndDate',title:'结束时间',type:'date',sort:true,width:110,align:'left'},
                       {field:'ShiftType',title:'轮班方式',type:'string',bind:{ key:'ShiftTypeList',data:[]},width:120,align:'left'},
                       {field:'ChangeShiftType',title:'倒班方式',type:'string',bind:{ key:'ChangeShiftTypeList',data:[]},width:120,align:'left'},
                       {field:'Status',title:'状态',type:'int',bind:{ key:'CalendarStatusList',data:[]},width:110,align:'left'},
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
