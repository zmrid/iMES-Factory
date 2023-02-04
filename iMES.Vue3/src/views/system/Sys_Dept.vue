<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/Sys_Dept.js此处编写
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
    import extend from "@/extension/system/Sys_Dept.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'Dept_Id',
                footer: "Foots",
                cnName: '部门管理',
                name: 'Sys_Dept',
                url: "/Sys_Dept/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"DeptName":"","DeptCode":""});
            const editFormOptions = ref([[{"title":"部门名称","required":true,"field":"DeptName","type":"text"}],
                              [{"title":"部门编码","required":true,"field":"DeptCode","type":"text"}]]);
            const searchFormFields = ref({"DeptName":"","DeptCode":"","CreateDate":""});
            const searchFormOptions = ref([[{"title":"部门名称","field":"DeptName","type":"like"},{"title":"部门编码","field":"DeptCode","type":"like"},{"title":"创建时间","field":"CreateDate","type":"date"}]]);
            const columns = ref([{field:'Dept_Id',title:'部门表主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'DeptName',title:'部门名称',type:'string',link:true,sort:true,width:180,require:true,align:'left',sort:true},
                       {field:'DeptCode',title:'部门编码',type:'string',sort:true,width:180,require:true,align:'left'},
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
