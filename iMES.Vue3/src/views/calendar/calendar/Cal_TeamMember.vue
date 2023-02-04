<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/calendar/calendar/Cal_TeamMember.js此处编写
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
    import extend from "@/extension/calendar/calendar/Cal_TeamMember.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'TeamMemberId',
                footer: "Foots",
                cnName: '班组成员',
                name: 'calendar/Cal_TeamMember',
                url: "/Cal_TeamMember/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"UserName":"","UserTrueName":"","PhoneNo":""});
            const editFormOptions = ref([[{"title":"电话号码","field":"PhoneNo","type":"text"},
                               {"title":"成员名称","required":true,"field":"UserName","type":"text"},
                               {"title":"成员姓名","required":true,"field":"UserTrueName","type":"text"}]]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'TeamMemberId',title:'成员主键',type:'guid',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'TeamId',title:'班组主键',type:'guid',width:110,hidden:true,require:true,align:'left'},
                       {field:'User_Id',title:'成员',type:'int',sort:true,width:110,hidden:true,require:true,align:'left'},
                       {field:'UserName',title:'成员名称',type:'string',sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'UserTrueName',title:'成员姓名',type:'string',sort:true,width:110,require:true,align:'left'},
                       {field:'PhoneNo',title:'电话号码',type:'string',width:110,align:'left'},
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
