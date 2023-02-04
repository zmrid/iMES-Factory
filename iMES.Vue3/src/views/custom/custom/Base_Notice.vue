<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/system/custom/Base_Notice.js此处编写
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
    import extend from "@/extension/custom/custom/Base_Notice.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'Notice_Id',
                footer: "Foots",
                cnName: '通知管理',
                name: 'custom/Base_Notice',
                url: "/Base_Notice/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"NoticeType":"","NoticeTitle":"","NoticeContent":""});
            const editFormOptions = ref([[{"dataKey":"noticeType","data":[],"title":"通知类型","required":true,"field":"NoticeType","colSize":6,"type":"select"},
                               {"title":"标题","required":true,"field":"NoticeTitle","colSize":6,"type":"text"}],
                              [{"title":"内容","required":true,"field":"NoticeContent","colSize":12,"type":"textarea"}]]);
            const searchFormFields = ref({"NoticeType":"","NoticeTitle":"","CreateDate":""});
            const searchFormOptions = ref([[{"dataKey":"noticeType","data":[],"title":"通知类型","field":"NoticeType","type":"select"},{"title":"标题","field":"NoticeTitle","type":"like"},{"title":"创建时间","field":"CreateDate","type":"date"}]]);
            const columns = ref([{field:'Notice_Id',title:'通知表主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'NoticeType',title:'通知类型',type:'string',bind:{ key:'noticeType',data:[]},width:180,require:true,align:'left',sort:true},
                       {field:'NoticeTitle',title:'标题',type:'string',link:true,width:220,require:true,align:'left'},
                       {field:'NoticeContent',title:'内容',type:'string',width:220,require:true,align:'left'},
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
