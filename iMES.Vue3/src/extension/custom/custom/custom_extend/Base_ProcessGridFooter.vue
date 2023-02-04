<template>
  <div class="detail-table">
    <div class="detail-title">
      <i class="el-icon-s-grid" />
      <span>工序采集数据</span>
    </div>
    <mes-table
      style="padding: 0px 10px 10px;"
      ref="editTable1"
      :columns="columns"
      :max-height="270"
      :index="true"
      :tableData="rows"
      :pagination-hide="true"
    ></mes-table>
  </div>
</template>

<script>
import MesTable from "@/components/basic/MesTable.vue";
export default {
  components: { MesTable },
  data() {
    return {
      columns: [{field:'ProcessList_Id',title:'工序采集数据主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'Process_Id',title:'工序',type:'int',bind:{ key:'process',data:[]},width:110,require:true,align:'left'},
                       {field:'DataPointType',title:'类型',type:'string',readonly:true,bind:{ key:'dataPointType',data:[]},width:180,edit:{type:'select'},require:true,align:'left'},
                       {field:'DataPointName',title:'名称',type:'string',readonly:true,width:180,edit:{type:'text'},require:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:110,align:'left'},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,align:'left'},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'}],
      rows: []
    };
  },
  methods:{
      rowClick(row){
          let url="api/Base_Process/getDetailRows?Process_Id="+row.Process_Id
          this.http.get(url,{},true).then(rows=>{
              this.rows=rows;
          })
      }
  }
};
</script>

<style lang="less" scoped>
.detail-table{
    padding: 0px 4px;
    border-top: 10px solid rgb(238, 238, 238);
    h3{
        font-weight: 500;
        padding-left: 10px;
        background: #fff;
        margin-top: 8px;
        padding-bottom: 5px;
    }
}
.detail-title{
  padding: 10px;
  font-size: 15px;
  color:'#313131';
  font-weight: bold;
  
}
</style>