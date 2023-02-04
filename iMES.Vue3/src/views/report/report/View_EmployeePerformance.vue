<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/report/View_EmployeePerformance.js此处编写
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
    import extend from "@/extension/report/report/View_EmployeePerformance.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ID',
                footer: "Foots",
                cnName: '员工绩效',
                name: 'report/View_EmployeePerformance',
                url: "/View_EmployeePerformance/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({"ProductUser":"","ProcessCode":"","ProcessName":"","ProductCode":"","ProductName":"","ProductStandard":"","GoodQty":[null,null],"NoGoodQty":[null,null],"CreateDate":""});
            const searchFormOptions = ref([[{"dataKey":"users","data":[],"title":"生产人员","field":"ProductUser","type":"select"},{"title":"工序编号","field":"ProcessCode","type":"like"},{"title":"工序名称","field":"ProcessName","type":"like"}],[{"title":"产品编号","field":"ProductCode","type":"like"},{"title":"产品名称","field":"ProductName","type":"like"},{"title":"产品规格","field":"ProductStandard","type":"like"}],[{"title":"良品数","field":"GoodQty","type":"range"},{"title":"不良品数","field":"NoGoodQty","type":"range"},{"title":"报工时间","field":"CreateDate","type":"date"}]]);
            const columns = ref([{field:'ID',title:'ID',type:'guid',width:110,hidden:true,require:true,align:'left'},
                       {field:'ProductUser',title:'生产人员',type:'string',bind:{ key:'users',data:[]},width:180,hidden:true,require:true,align:'left'},
                       {field:'UserTrueName',title:'生产人员',type:'string',sort:true,width:110,align:'left',sort:true},
                       {field:'ProcessCode',title:'工序编号',type:'string',sort:true,width:180,align:'left'},
                       {field:'ProcessName',title:'工序名称',type:'string',sort:true,width:180,align:'left'},
                       {field:'ProductCode',title:'产品编号',type:'string',sort:true,width:180,require:true,align:'left'},
                       {field:'ProductName',title:'产品名称',type:'string',width:180,require:true,align:'left'},
                       {field:'ProductStandard',title:'产品规格',type:'string',width:180,align:'left'},
                       {field:'Unit_Id',title:'单位',type:'int',bind:{ key:'unitList',data:[]},width:110,hidden:true,align:'left'},
                       {field:'UnitName',title:'单位',type:'string',width:100,align:'left'},
                       {field:'GoodQty',title:'良品数',type:'int',sort:true,width:110,align:'left'},
                       {field:'NoGoodQty',title:'不良品数',type:'int',sort:true,width:110,require:true,align:'left'},
                       {field:'PassPercent',title:'合格率',type:'string',width:100,align:'left'},
                       {field:'AllQty',title:'合计',type:'int',width:100,align:'left'},
                       {field:'CreateDate',title:'报工时间',type:'datetime',width:200,align:'left',sort:true}]);
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
