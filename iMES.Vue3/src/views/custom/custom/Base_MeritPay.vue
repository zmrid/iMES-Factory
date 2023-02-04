<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/custom/Base_MeritPay.js此处编写
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
    import extend from "@/extension/custom/custom/Base_MeritPay.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'MeritPay_Id',
                footer: "Foots",
                cnName: '绩效工资配置',
                name: 'custom/Base_MeritPay',
                url: "/Base_MeritPay/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"Process_Id":"","Unit_Id":"","Product_Id":"","UnitPrice":"","StandardNumber":"","StandardHour":"","StandardMin":"","StandardSec":""});
            const editFormOptions = ref([[{"dataKey":"process","data":[],"title":"工序名称","field":"Process_Id","colSize":12,"type":"select"}],
                              [{"dataKey":"unitList","data":[],"title":"报工单位","field":"Unit_Id","colSize":12,"type":"select"}],
                              [{"dataKey":"productList","data":[],"title":"产品名称","field":"Product_Id","colSize":12,"type":"select"}],
                              [{"title":"工资单价(元)","required":true,"field":"UnitPrice","colSize":12,"type":"decimal"}],
                              [{"title":"标准效率","field":"StandardNumber","colSize":3,"type":"number"},
                               {"title":"","field":"StandardHour","colSize":3,"type":"number"},
                               {"title":"","field":"StandardMin","colSize":3,"type":"number"},
                               {"title":"","field":"StandardSec","colSize":3,"type":"number"}]]);
            const searchFormFields = ref({"Process_Id":"","Unit_Id":"","Product_Id":"","UnitPrice":""});
            const searchFormOptions = ref([[{"dataKey":"process","data":[],"title":"工序名称","field":"Process_Id","type":"select"},{"dataKey":"unitList","data":[],"title":"报工单位","field":"Unit_Id","type":"select"}],[{"dataKey":"productList","data":[],"title":"产品名称","field":"Product_Id","type":"select"},{"title":"工资单价(元)","field":"UnitPrice","type":"number"}]]);
            const columns = ref([{field:'MeritPay_Id',title:'绩效工资配置主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'Process_Id',title:'工序名称',type:'int',bind:{ key:'process',data:[]},sort:true,width:110,align:'left',sort:true},
                       {field:'Unit_Id',title:'报工单位',type:'int',bind:{ key:'unitList',data:[]},sort:true,width:110,align:'left'},
                       {field:'Product_Id',title:'产品名称',type:'int',bind:{ key:'productList',data:[]},sort:true,width:110,align:'left'},
                       {field:'UnitPrice',title:'工资单价(元)',type:'decimal',link:true,sort:true,width:110,require:true,align:'left'},
                       {field:'StandardNumber',title:'标准效率',type:'int',width:110,align:'left'},
                       {field:'StandardHour',title:'StandardHour',type:'int',width:110,align:'left'},
                       {field:'StandardMin',title:'StandardMin',type:'int',width:110,align:'left'},
                       {field:'StandardSec',title:'StandardSec',type:'int',width:110,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'}]);
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
