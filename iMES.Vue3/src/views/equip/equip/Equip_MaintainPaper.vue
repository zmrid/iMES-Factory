<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/equip/equip/Equip_MaintainPaper.js此处编写
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
    import extend from "@/extension/equip/equip/Equip_MaintainPaper.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'MaintainPaperId',
                footer: "Foots",
                cnName: '维修单',
                name: 'equip/Equip_MaintainPaper',
                url: "/Equip_MaintainPaper/",
                sortName: "CreateDate"
            });
            const editFormFields = ref({"MaintainPaperName":"","MaintainPaperCode":"","DeviceName":"","DeviceCode":"","DeviceBrand":"","ReportDate":"","Remark":""});
            const editFormOptions = ref([[{"title":"维修单名称","required":true,"field":"MaintainPaperName","type":"text"}],
                              [{"title":"维修单编号","field":"MaintainPaperCode","type":"text"}],
                              [{"title":"设备名称","required":true,"field":"DeviceName","disabled":true,"type":"text"}],
                              [{"title":"设备编号","required":true,"field":"DeviceCode","disabled":true,"type":"text"}],
                              [{"title":"品牌","field":"DeviceBrand","disabled":true,"type":"text"}],
                              [{"title":"报修日期","field":"ReportDate","type":"date"}],
                              [{"title":"备注","field":"Remark","type":"textarea"}]]);
            const searchFormFields = ref({"MaintainPaperName":"","MaintainPaperCode":"","DeviceName":"","DeviceCode":"","ReportDate":"","Remark":""});
            const searchFormOptions = ref([[{"title":"维修单名称","field":"MaintainPaperName","type":"like"},{"title":"维修单编号","field":"MaintainPaperCode","type":"like"},{"title":"设备名称","field":"DeviceName","type":"like"}],[{"title":"设备编号","field":"DeviceCode","type":"like"},{"title":"报修日期","field":"ReportDate","type":"date"},{"title":"备注","field":"Remark","type":"like"}]]);
            const columns = ref([{field:'MaintainPaperId',title:'维修单主键',type:'guid',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'MaintainPaperName',title:'维修单名称',type:'string',link:true,sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'MaintainPaperCode',title:'维修单编号',type:'string',sort:true,width:120,align:'left'},
                       {field:'DeviceName',title:'设备名称',type:'string',sort:true,width:120,readonly:true,require:true,align:'left'},
                       {field:'DeviceCode',title:'设备编号',type:'string',sort:true,width:120,readonly:true,require:true,align:'left'},
                       {field:'DeviceBrand',title:'品牌',type:'string',width:120,readonly:true,align:'left'},
                       {field:'ReportDate',title:'报修日期',type:'date',sort:true,width:110,align:'left'},
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
