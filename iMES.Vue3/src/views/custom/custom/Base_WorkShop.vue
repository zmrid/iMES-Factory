<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/custom/custom/Base_WorkShop.js此处编写
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
    import extend from "@/extension/custom/custom/Base_WorkShop.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'WorkShopId',
                footer: "Foots",
                cnName: '车间设置',
                name: 'custom/Base_WorkShop',
                url: "/Base_WorkShop/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"WorkShopName":"","WorkShopCode":"","MainPerson":"","Area":"","Enable":"","Remark":""});
            const editFormOptions = ref([[{"title":"车间名称","required":true,"field":"WorkShopName","type":"text"}],
                              [{"title":"车间编码","field":"WorkShopCode","type":"text"}],
                              [{"title":"负责人","field":"MainPerson","type":"text"}],
                              [{"title":"面积","field":"Area","type":"number"}],
                              [{"dataKey":"enable","data":[],"title":"是否启用","required":true,"field":"Enable","type":"radio"}],
                              [{"title":"备注","field":"Remark","type":"textarea"}]]);
            const searchFormFields = ref({"WorkShopName":"","WorkShopCode":"","MainPerson":"","Area":"","Enable":"","Remark":""});
            const searchFormOptions = ref([[{"title":"车间名称","field":"WorkShopName","type":"like"},{"title":"车间编码","field":"WorkShopCode","type":"like"},{"title":"负责人","field":"MainPerson","type":"like"}],[{"title":"面积","field":"Area","type":"number"},{"dataKey":"enable","data":[],"title":"是否启用","field":"Enable","type":"radio"},{"title":"备注","field":"Remark","type":"like"}]]);
            const columns = ref([{field:'WorkShopId',title:'车间主键',type:'guid',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'WorkShopName',title:'车间名称',type:'string',link:true,sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'WorkShopCode',title:'车间编码',type:'string',sort:true,width:120,align:'left'},
                       {field:'MainPerson',title:'负责人',type:'string',sort:true,width:120,align:'left'},
                       {field:'Area',title:'面积',type:'int',sort:true,width:110,align:'left'},
                       {field:'Enable',title:'是否启用',type:'int',bind:{ key:'enable',data:[]},width:110,require:true,align:'left'},
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
