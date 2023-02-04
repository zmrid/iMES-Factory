<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/custom/Base_NumberRule.js此处编写
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
    import extend from "@/extension/custom/custom/Base_NumberRule.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'NumberRule_Id',
                footer: "Foots",
                cnName: '自定义编号规则',
                name: 'custom/Base_NumberRule',
                url: "/Base_NumberRule/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"FormCode":"","Prefix":"","SubmitTime":"","SerialNumber":"","GenerativeRule":""});
            const editFormOptions = ref([[{"title":"编号前缀","field":"Prefix","type":"text"},
                               {"dataKey":"numberRuleForm","data":[],"title":"目标表单","required":true,"field":"FormCode","type":"select"}],
                              [{"dataKey":"submitTime","data":[],"title":"提交时间","required":true,"field":"SubmitTime","type":"radio"},
                               {"title":"流水号(位)","required":true,"field":"SerialNumber","type":"text"}],
                              [{"title":"编号生成规则","required":true,"field":"GenerativeRule","colSize":12,"type":"text"}]]);
            const searchFormFields = ref({"FormCode":"","Prefix":"","SubmitTime":"","CreateDate":""});
            const searchFormOptions = ref([[{"dataKey":"numberRuleForm","data":[],"title":"目标表单","field":"FormCode","type":"select"},{"title":"编号前缀","field":"Prefix","type":"like"}],[{"dataKey":"submitTime","data":[],"title":"提交时间","field":"SubmitTime","type":"radio"},{"title":"创建时间","field":"CreateDate","type":"date"}]]);
            const columns = ref([{field:'NumberRule_Id',title:'自定义编号规则主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'GenerativeRule',title:'编号生成规则',type:'string',link:true,width:180,require:true,align:'left',sort:true},
                       {field:'FormCode',title:'目标表单',type:'string',bind:{ key:'numberRuleForm',data:[]},sort:true,width:120,require:true,align:'left'},
                       {field:'Prefix',title:'编号前缀',type:'string',sort:true,width:120,align:'left'},
                       {field:'SubmitTime',title:'提交时间',type:'string',bind:{ key:'submitTime',data:[]},width:180,require:true,align:'left'},
                       {field:'SerialNumber',title:'流水号(位)',type:'int',width:110,require:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:180,align:'left',sort:true},
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
