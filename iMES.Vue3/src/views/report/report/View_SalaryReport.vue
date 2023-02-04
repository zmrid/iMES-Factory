<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/report/View_SalaryReport.js此处编写
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
    import extend from "@/extension/report/report/View_SalaryReport.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ID',
                footer: "Foots",
                cnName: '工资报表',
                name: 'report/View_SalaryReport',
                url: "/View_SalaryReport/",
                sortName: "ReportDate"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({"ReportDate":"","ProductUser":""});
            const searchFormOptions = ref([[{"title":"报工时间","field":"ReportDate","type":"date"},{"dataKey":"users","data":[],"title":"生产人员","field":"ProductUser","type":"select"}]]);
            const columns = ref([{field:'ID',title:'ID',type:'guid',width:110,hidden:true,require:true,align:'left'},
                       {field:'ReportDate',title:'报工时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ProductUser',title:'生产人员',type:'string',bind:{ key:'users',data:[]},width:180,hidden:true,require:true,align:'left'},
                       {field:'UserName',title:'账号',type:'string',sort:true,width:120,align:'left'},
                       {field:'UserTrueName',title:'姓名',type:'string',sort:true,width:110,align:'left'},
                       {field:'ReportAll',title:'报工总数',type:'int',sort:true,width:110,align:'left'},
                       {field:'NoAlreadyAppNumber',title:'未审批计件数',type:'int',sort:true,width:110,align:'left'},
                       {field:'NoAlreadyAppTime',title:'未审批计时数',type:'int',sort:true,width:110,align:'left'},
                       {field:'AlreadyAppNumber',title:'已审批计件数',type:'int',sort:true,width:110,align:'left'},
                       {field:'AlreadyAppTime',title:'已审批计时数',type:'int',sort:true,width:110,align:'left'},
                       {field:'Salary',title:'工资小计',type:'decimal',sort:true,width:110,align:'left'}]);
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
