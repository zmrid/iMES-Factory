<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/custom/Sys_Unit.js此处编写
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
    import extend from "@/extension/custom/custom/Sys_Unit.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'Unit_Id',
                footer: "Foots",
                cnName: '单位管理',
                name: 'custom/Sys_Unit',
                url: "/Sys_Unit/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"UnitName":"","Remark":""});
            const editFormOptions = ref([[{"title":"名称","required":true,"field":"UnitName","type":"text"}],
                              [{"title":"备注","field":"Remark","type":"textarea"}]]);
            const searchFormFields = ref({"UnitName":"","Remark":""});
            const searchFormOptions = ref([[{"title":"名称","field":"UnitName","type":"like"},{"title":"备注","field":"Remark","type":"like"}]]);
            const columns = ref([{field:'Unit_Id',title:'单位表主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'UnitName',title:'名称',type:'string',link:true,sort:true,width:180,require:true,align:'left',sort:true},
                       {field:'Remark',title:'备注',type:'string',width:220,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
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
