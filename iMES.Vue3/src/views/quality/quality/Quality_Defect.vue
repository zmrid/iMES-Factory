<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/quality/quality/Quality_Defect.js此处编写
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
    import extend from "@/extension/quality/quality/Quality_Defect.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'DefectId',
                footer: "Foots",
                cnName: '常见缺陷',
                name: 'quality/Quality_Defect',
                url: "/Quality_Defect/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"DefectName":"","DefectType":"","DefectLevel":"","Remark":""});
            const editFormOptions = ref([[{"title":"检测项描述","required":true,"field":"DefectName","type":"textarea"}],
                              [{"dataKey":"QCDefectType","data":[],"title":"检测项类型","required":true,"field":"DefectType","type":"select"}],
                              [{"dataKey":"QCDefectLevel","data":[],"title":"缺陷等级","required":true,"field":"DefectLevel","type":"select"}],
                              [{"title":"备注","field":"Remark","type":"textarea"}]]);
            const searchFormFields = ref({"DefectName":"","DefectType":"","DefectLevel":"","Remark":"","CreateDate":""});
            const searchFormOptions = ref([[{"title":"检测项描述","field":"DefectName","type":"like"},{"dataKey":"QCDefectType","data":[],"title":"检测项类型","field":"DefectType","type":"select"},{"dataKey":"QCDefectLevel","data":[],"title":"缺陷等级","field":"DefectLevel","type":"select"}],[{"title":"备注","field":"Remark","type":"like"},{"title":"创建时间","field":"CreateDate","type":"date"}]]);
            const columns = ref([{field:'DefectId',title:'检测项主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'DefectName',title:'检测项描述',type:'string',link:true,sort:true,width:180,require:true,align:'left',sort:true},
                       {field:'DefectType',title:'检测项类型',type:'string',bind:{ key:'QCDefectType',data:[]},width:180,require:true,align:'left'},
                       {field:'DefectLevel',title:'缺陷等级',type:'string',bind:{ key:'QCDefectLevel',data:[]},sort:true,width:180,require:true,align:'left'},
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
