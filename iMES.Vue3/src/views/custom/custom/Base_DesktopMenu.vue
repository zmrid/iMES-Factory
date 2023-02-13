<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/custom/custom/Base_DesktopMenu.js此处编写
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
    import extend from "@/extension/custom/custom/Base_DesktopMenu.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'DesktopMenu_Id',
                footer: "Foots",
                cnName: '主页菜单配置',
                name: 'custom/Base_DesktopMenu',
                url: "/Base_DesktopMenu/",
                sortName: "DesktopMenu_Id"
            });
            const editFormFields = ref({"MenuId":"","MenuUrl":"","MenuName":"","Color":"","Enable":""});
            const editFormOptions = ref([[{"dataKey":"MenuList","data":[],"title":"菜单","required":true,"field":"MenuId","type":"select"}],
                              [{"title":"路由地址","required":true,"field":"MenuUrl","disabled":true}],
                              [{"title":"菜单名称","required":true,"field":"MenuName","disabled":true}],
                              [{"title":"背景颜色","required":true,"field":"Color","disabled":true}],
                              [{"dataKey":"cq","data":[],"title":"是否启用","required":true,"field":"Enable","type":"switch"}]]);
            const searchFormFields = ref({"MenuName":""});
            const searchFormOptions = ref([[{"title":"菜单名称","field":"MenuName","type":"like"}]]);
            const columns = ref([{field:'DesktopMenu_Id',title:'主页菜单表主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'MenuId',title:'菜单',type:'int',bind:{ key:'MenuList',data:[]},width:80,require:true,align:'left',sort:true},
                       {field:'MenuName',title:'菜单名称',type:'string',sort:true,width:180,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'MenuUrl',title:'路由地址',type:'string',link:true,width:120,readonly:true,require:true,align:'left'},
                       {field:'Color',title:'背景颜色',type:'string',width:120,readonly:true,require:true,align:'left'},
                       {field:'Enable',title:'是否启用',type:'byte',bind:{ key:'cq',data:[]},width:110,require:true,align:'left'},
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
