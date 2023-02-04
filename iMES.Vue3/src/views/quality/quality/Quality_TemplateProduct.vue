<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/quality/quality/Quality_TemplateProduct.js此处编写
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
    import extend from "@/extension/quality/quality/Quality_TemplateProduct.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'TemplateProductId',
                footer: "Foots",
                cnName: '检测模版-产品',
                name: 'quality/Quality_TemplateProduct',
                url: "/Quality_TemplateProduct/",
                sortName: "TemplateProductId"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'TemplateProductId',title:'检测模版产品主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'TemplateId',title:'模版主键',type:'int',width:110,require:true,align:'left',sort:true},
                       {field:'ProductId',title:'产品主键',type:'int',width:110,require:true,align:'left'},
                       {field:'ProductName',title:'产品名称',type:'string',sort:true,width:120,require:true,align:'left'},
                       {field:'ProductCode',title:'产品编码',type:'string',sort:true,width:120,require:true,align:'left'},
                       {field:'ProductStandard',title:'产品型号',type:'string',width:180,align:'left'},
                       {field:'CheckMin',title:'最低检测数',type:'int',sort:true,width:110,align:'left'},
                       {field:'DisQualityMax',title:'最大不合格数',type:'int',sort:true,width:110,align:'left'},
                       {field:'CrRate',title:'致命缺陷率',type:'decimal',sort:true,width:110,align:'left'},
                       {field:'MajRate',title:'严重缺陷率',type:'decimal',sort:true,width:110,align:'left'},
                       {field:'MinRate',title:'轻微缺陷率',type:'decimal',sort:true,width:110,align:'left'},
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
