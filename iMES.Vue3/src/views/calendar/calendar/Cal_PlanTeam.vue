<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/calendar/calendar/Cal_PlanTeam.js此处编写
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
    import extend from "@/extension/calendar/calendar/Cal_PlanTeam.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'PlanTeamId',
                footer: "Foots",
                cnName: '计划班组',
                name: 'calendar/Cal_PlanTeam',
                url: "/Cal_PlanTeam/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'PlanTeamId',title:'计划班组主键',type:'guid',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'PlanId',title:'计划主键',type:'guid',width:110,require:true,align:'left',sort:true},
                       {field:'TeamId',title:'班组主键',type:'guid',width:110,require:true,align:'left'},
                       {field:'TeamCode',title:'班组编码',type:'string',link:true,width:120,require:true,align:'left'},
                       {field:'TeamName',title:'班组名称',type:'string',width:120,require:true,align:'left'},
                       {field:'Sequence',title:'显示顺序',type:'int',width:110,align:'left'},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,align:'left',sort:true}]);
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
