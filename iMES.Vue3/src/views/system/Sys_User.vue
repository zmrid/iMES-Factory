<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/Sys_User.js此处编写
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
    import extend from "@/extension/system/Sys_User.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'User_Id',
                footer: "Foots",
                cnName: '用户管理',
                name: 'Sys_User',
                url: "/Sys_User/",
                sortName: "User_Id"
            });
            const editFormFields = ref({"UserName":"","UserTrueName":"","Role_Id":"","IsRegregisterPhone":"","Gender":"","Enable":"","CreateDate":"","Creator":"","Dept_Id":"","Remark":"","HeadImageUrl":""});
            const editFormOptions = ref([[{"title":"帐号","required":true,"field":"UserName","disabled":true},
                               {"title":"真实姓名","required":true,"field":"UserTrueName","type":"text"}],
                              [{"dataKey":"roles","data":[],"title":"角色","required":true,"field":"Role_Id","type":"select"},
                               {"dataKey":"isphone","data":[],"title":"手机用户","required":true,"field":"IsRegregisterPhone","type":"select"}],
                              [{"dataKey":"gender","data":[],"title":"性别","field":"Gender","type":"select"},
                               {"dataKey":"enable","data":[],"title":"是否可用","required":true,"field":"Enable","type":"select"}],
                              [{"title":"注册时间","field":"CreateDate","disabled":true},
                               {"title":"创建人","field":"Creator","disabled":true}],
                              [{"dataKey":"dept","data":[],"title":"部门","required":true,"field":"Dept_Id","type":"select"},
                               {"title":"备注","field":"Remark","type":"textarea"}],
                              [{"title":"头像","required":true,"field":"HeadImageUrl","type":"img"}]]);
            const searchFormFields = ref({"UserName":"","Gender":"","Dept_Id":"","DeptName":"","Role_Id":"","Token":"","AppType":[],"UserTrueName":"","CreateDate":"","IsRegregisterPhone":"","PhoneNo":"","Enable":"","LastLoginDate":"","Address":"","Email":""});
            const searchFormOptions = ref([[{"title":"帐号","field":"UserName"},{"dataKey":"gender","data":[],"title":"性别","field":"Gender","type":"select"},{"title":"真实姓名","field":"UserTrueName"}],[{"title":"部门","field":"DeptName"},{"dataKey":"roles","data":[],"title":"角色","field":"Role_Id","type":"select"},{"title":"Token","field":"Token"}],[{"dataKey":"ut","data":[],"title":"登陆设备类型","field":"AppType","type":"selectList"},{"dataKey":"isphone","data":[],"title":"手机用户","field":"IsRegregisterPhone","type":"select"},{"title":"手机号","field":"PhoneNo"}],[{"dataKey":"enable","data":[],"title":"是否可用","field":"Enable","type":"select"},{"title":"地址","field":"Address"},{"title":"Email","field":"Email"}],[{"dataKey":"dept","data":[],"title":"部门","field":"Dept_Id","type":"select"},{"title":"注册时间","field":"CreateDate","type":"datetime"},{"title":"最后登陆时间","field":"LastLoginDate","type":"datetime"}]]);
            const columns = ref([{field:'UserName',title:'帐号',type:'string',link:true,width:120,readonly:true,require:true,align:'left',sort:true},
                       {field:'User_Id',title:'User_Id',type:'int',width:90,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'Gender',title:'性别',type:'int',bind:{ key:'gender',data:[]},width:100,align:'left'},
                       {field:'HeadImageUrl',title:'头像',type:'img',width:150,require:true,align:'left'},
                       {field:'Dept_Id',title:'部门',type:'int',bind:{ key:'dept',data:[]},width:90,require:true,align:'left'},
                       {field:'DeptName',title:'部门',type:'string',width:150,hidden:true,align:'left'},
                       {field:'Role_Id',title:'角色',type:'int',bind:{ key:'roles',data:[]},width:150,require:true,align:'left'},
                       {field:'RoleName',title:'RoleName',type:'string',width:90,hidden:true,require:true,align:'left'},
                       {field:'Token',title:'Token',type:'string',width:180,hidden:true,align:'left'},
                       {field:'AppType',title:'登陆设备类型',type:'int',bind:{ key:'ut',data:[]},width:150,hidden:true,align:'left'},
                       {field:'UserTrueName',title:'真实姓名',type:'string',width:150,require:true,align:'left'},
                       {field:'CreateDate',title:'注册时间',type:'datetime',width:150,readonly:true,align:'left',sort:true},
                       {field:'IsRegregisterPhone',title:'手机用户',type:'int',bind:{ key:'isphone',data:[]},width:120,hidden:true,require:true,align:'left'},
                       {field:'PhoneNo',title:'手机号',type:'string',width:150,hidden:true,require:true,align:'left'},
                       {field:'Tel',title:'Tel',type:'string',width:90,hidden:true,align:'left'},
                       {field:'CreateID',title:'CreateID',type:'int',width:90,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,readonly:true,align:'left'},
                       {field:'Enable',title:'是否可用',type:'byte',bind:{ key:'enable',data:[]},width:90,require:true,align:'left'},
                       {field:'ModifyID',title:'ModifyID',type:'int',width:90,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,hidden:true,readonly:true,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:90,readonly:true,align:'left',sort:true},
                       {field:'AuditStatus',title:'审核状态',type:'int',bind:{ key:'audit',data:[]},width:90,hidden:true,align:'left'},
                       {field:'Auditor',title:'审核人',type:'string',width:90,hidden:true,align:'left'},
                       {field:'AuditDate',title:'审核时间',type:'datetime',width:150,hidden:true,align:'left',sort:true},
                       {field:'LastLoginDate',title:'最后登陆时间',type:'datetime',width:150,hidden:true,align:'left',sort:true},
                       {field:'LastModifyPwdDate',title:'最后密码修改时间',type:'datetime',width:150,hidden:true,align:'left',sort:true},
                       {field:'Address',title:'地址',type:'string',width:190,hidden:true,align:'left'},
                       {field:'Mobile',title:'电话',type:'string',width:140,hidden:true,align:'left'},
                       {field:'Email',title:'Email',type:'string',width:140,hidden:true,align:'left'},
                       {field:'Remark',title:'备注',type:'string',width:180,hidden:true,align:'left'},
                       {field:'OrderNo',title:'排序号',type:'int',width:90,hidden:true,align:'left'}]);
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
