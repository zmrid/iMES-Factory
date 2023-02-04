<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/quality/quality/Quality_TestItem.js此处编写
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
    import extend from "@/extension/quality/quality/Quality_TestItem.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'TestItemId',
                footer: "Foots",
                cnName: '检测项管理',
                name: 'quality/Quality_TestItem',
                url: "/Quality_TestItem/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"TestItemCode":"","TestItemName":"","TestItemType":"","QCTool":"","Remark":""});
            const editFormOptions = ref([[{"title":"检测项编码","field":"TestItemCode","type":"text"}],
                              [{"title":"检测项名称","required":true,"field":"TestItemName","type":"text"}],
                              [{"dataKey":"QCDefectType","data":[],"title":"检测项类型","required":true,"field":"TestItemType","type":"select"}],
                              [{"title":"检测工具","field":"QCTool","type":"text"}],
                              [{"title":"备注","field":"Remark","type":"textarea"}]]);
            const searchFormFields = ref({"TestItemCode":"","TestItemName":"","TestItemType":"","QCTool":"","Remark":"","CreateDate":""});
            const searchFormOptions = ref([[{"title":"检测项编码","field":"TestItemCode","type":"like"},{"title":"检测项名称","field":"TestItemName","type":"like"},{"dataKey":"QCDefectType","data":[],"title":"检测项类型","field":"TestItemType","type":"select"}],[{"title":"检测工具","field":"QCTool","type":"like"},{"title":"备注","field":"Remark","type":"like"},{"title":"创建时间","field":"CreateDate","type":"date"}]]);
            const columns = ref([{field:'TestItemId',title:'检测项主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'TestItemCode',title:'检测项编码',type:'string',link:true,sort:true,width:180,align:'left',sort:true},
                       {field:'TestItemName',title:'检测项名称',type:'string',sort:true,width:180,require:true,align:'left'},
                       {field:'TestItemType',title:'检测项类型',type:'string',bind:{ key:'QCDefectType',data:[]},width:180,require:true,align:'left'},
                       {field:'QCTool',title:'检测工具',type:'string',width:180,align:'left'},
                       {field:'Remark',title:'备注',type:'string',width:220,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
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
