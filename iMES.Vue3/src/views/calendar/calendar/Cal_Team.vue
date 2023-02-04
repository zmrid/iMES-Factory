<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/calendar/calendar/Cal_Team.js此处编写
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
    import extend from "@/extension/calendar/calendar/Cal_Team.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'TeamId',
                footer: "Foots",
                cnName: '班组',
                name: 'calendar/Cal_Team',
                url: "/Cal_Team/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"TeamName":"","TeamCode":"","TeamType":"","Remark":""});
            const editFormOptions = ref([[{"title":"班组名称","required":true,"field":"TeamName","type":"text"}],
                              [{"title":"编组编码","field":"TeamCode","type":"text"}],
                              [{"dataKey":"TeamType","data":[],"title":"班组类型","field":"TeamType","type":"select"}],
                              [{"title":"备注","field":"Remark","type":"textarea"}]]);
            const searchFormFields = ref({"TeamName":"","TeamCode":"","TeamType":""});
            const searchFormOptions = ref([[{"title":"班组名称","field":"TeamName","type":"like"},{"title":"编组编码","field":"TeamCode","type":"like"},{"dataKey":"TeamType","data":[],"title":"班组类型","field":"TeamType","type":"select"}]]);
            const columns = ref([{field:'TeamId',title:'班组主键',type:'guid',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'TeamName',title:'班组名称',type:'string',link:true,sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'TeamCode',title:'编组编码',type:'string',sort:true,width:120,align:'left'},
                       {field:'TeamType',title:'班组类型',type:'string',bind:{ key:'TeamType',data:[]},sort:true,width:120,align:'left'},
                       {field:'Remark',title:'备注',type:'string',width:220,align:'left'},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',sort:true,width:110,align:'left',sort:true}]);
            const detail = ref({
                cnName: "班组成员",
                table: "Cal_TeamMember",
                columns: [{field:'TeamMemberId',title:'成员主键',type:'guid',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'TeamId',title:'班组主键',type:'guid',width:110,hidden:true,require:true,align:'left'},
                       {field:'User_Id',title:'成员',type:'int',sort:true,width:110,hidden:true,require:true,align:'left'},
                       {field:'UserName',title:'成员名称',type:'string',sort:true,width:120,edit:{type:'text'},require:true,align:'left',sort:true},
                       {field:'UserTrueName',title:'成员姓名',type:'string',sort:true,width:110,edit:{type:'text'},require:true,align:'left'},
                       {field:'PhoneNo',title:'电话号码',type:'string',width:110,edit:{type:'text'},align:'left'},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',sort:true,width:110,align:'left',sort:true}],
                sortName: "CreateDate",
                key: "TeamMemberId"
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
