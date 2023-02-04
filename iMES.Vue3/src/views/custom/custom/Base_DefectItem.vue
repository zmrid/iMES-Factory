<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/custom/custom/Base_DefectItem.js此处编写
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
    import extend from "@/extension/custom/custom/Base_DefectItem.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'DefectItem_Id',
                footer: "Foots",
                cnName: '不良品项',
                name: 'custom/Base_DefectItem',
                url: "/Base_DefectItem/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"DefectItemCode":"","DefectItemName":"","Attachment":"","ImageUrl":""});
            const editFormOptions = ref([[{"title":"不良品项编号","field":"DefectItemCode","type":"text"},
                               {"title":"不良品项名称","required":true,"field":"DefectItemName","type":"text"}],
                              [{"title":"附件","field":"Attachment","type":"file"},
                               {"title":"图片","field":"ImageUrl","type":"img"}]]);
            const searchFormFields = ref({"DefectItemCode":"","DefectItemName":""});
            const searchFormOptions = ref([[{"title":"不良品项编号","field":"DefectItemCode","type":"like"},{"title":"不良品项名称","field":"DefectItemName","type":"like"}]]);
            const columns = ref([{field:'DefectItem_Id',title:'不良品项表主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'DefectItemCode',title:'不良品项编号',type:'string',sort:true,width:180,align:'left',sort:true},
                       {field:'DefectItemName',title:'不良品项名称',type:'string',link:true,sort:true,width:180,require:true,align:'left'},
                       {field:'Attachment',title:'附件',type:'file',width:220,align:'left'},
                       {field:'ImageUrl',title:'图片',type:'img',width:220,align:'left'},
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
