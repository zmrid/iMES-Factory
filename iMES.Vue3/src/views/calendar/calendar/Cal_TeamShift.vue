<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/calendar/calendar/Cal_TeamShift.js此处编写
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
    import extend from "@/extension/calendar/calendar/Cal_TeamShift.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'TeamShiftId',
                footer: "Foots",
                cnName: '班组排班',
                name: 'calendar/Cal_TeamShift',
                url: "/Cal_TeamShift/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'TeamShiftId',title:'班组排版主键',type:'guid',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'TheDate',title:'日期',type:'datetime',link:true,sort:true,width:110,require:true,align:'left',sort:true},
                       {field:'TeamId',title:'班组主键',type:'string',width:120,require:true,align:'left'},
                       {field:'TeamName',title:'班组名称',type:'string',sort:true,width:120,align:'left'},
                       {field:'ShiftId',title:'班次主键',type:'guid',sort:true,width:110,require:true,align:'left'},
                       {field:'ShiftName',title:'班次名称',type:'string',width:120,align:'left'},
                       {field:'Sequence',title:'顺序',type:'int',sort:true,width:110,align:'left'},
                       {field:'PlanId',title:'排班计划主键',type:'guid',width:110,require:true,align:'left'},
                       {field:'ChangeShiftType',title:'轮班方式',type:'string',width:120,align:'left'},
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
