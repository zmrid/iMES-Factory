<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/quality/quality/Quality_Template.js此处编写
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
    import extend from "@/extension/quality/quality/Quality_Template.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'TemplateId',
                footer: "Foots",
                cnName: '检测模版',
                name: 'quality/Quality_Template',
                url: "/Quality_Template/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"TemplateName":"","TemplateCode":"","QcType":[],"Enable":"","Remark":""});
            const editFormOptions = ref([[{"title":"模版名称","required":true,"field":"TemplateName","type":"text"}],
                              [{"title":"模版编码","field":"TemplateCode","type":"text"}],
                              [{"dataKey":"QcTypeList","data":[],"title":"检测种类","required":true,"field":"QcType","type":"checkbox"}],
                              [{"dataKey":"enable","data":[],"title":"是否启用","required":true,"field":"Enable","type":"radio"}],
                              [{"title":"备注","field":"Remark","type":"textarea"}]]);
            const searchFormFields = ref({"TemplateName":"","TemplateCode":"","QcType":[],"Enable":"","Remark":"","CreateDate":""});
            const searchFormOptions = ref([[{"title":"模版名称","field":"TemplateName","type":"like"},{"title":"模版编码","field":"TemplateCode","type":"like"},{"dataKey":"QcTypeList","data":[],"title":"检测种类","field":"QcType","type":"checkbox"}],[{"dataKey":"enable","data":[],"title":"是否启用","field":"Enable","type":"radio"},{"title":"备注","field":"Remark","type":"like"},{"title":"创建时间","field":"CreateDate","type":"date"}]]);
            const columns = ref([{field:'TemplateId',title:'模版主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'TemplateName',title:'模版名称',type:'string',link:true,sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'TemplateCode',title:'模版编码',type:'string',sort:true,width:120,align:'left'},
                       {field:'QcType',title:'检测种类',type:'string',bind:{ key:'QcTypeList',data:[]},width:180,require:true,align:'left'},
                       {field:'Enable',title:'是否启用',type:'int',bind:{ key:'enable',data:[]},sort:true,width:110,require:true,align:'left'},
                       {field:'Remark',title:'备注',type:'string',width:220,align:'left'},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'NextCheckDate',title:'下次截至时间',type:'datetime',width:110,align:'left',sort:true}]);
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
