<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/system/Sys_VersionInfo.js此处编写
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
    import extend from "@/extension/system/system/Sys_VersionInfo.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'VersionInfo_Id',
                footer: "Foots",
                cnName: '版本发布记录',
                name: 'system/Sys_VersionInfo',
                url: "/Sys_VersionInfo/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"Title":"","Url":""});
            const editFormOptions = ref([[{"title":"标题","required":true,"field":"Title","type":"textarea"}],
                              [{"title":"链接网址","required":true,"field":"Url","type":"text"}]]);
            const searchFormFields = ref({"Title":"","Url":"","CreateDate":""});
            const searchFormOptions = ref([[{"title":"标题","field":"Title","type":"like"},{"title":"链接网址","field":"Url","type":"like"},{"title":"创建时间","field":"CreateDate","type":"date"}]]);
            const columns = ref([{field:'VersionInfo_Id',title:'版本更新表主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'Title',title:'标题',type:'string',link:true,sort:true,width:220,require:true,align:'left',sort:true},
                       {field:'Url',title:'链接网址',type:'string',sort:true,width:220,require:true,align:'left'},
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
