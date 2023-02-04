<template>
  <div class="detail-table">
    <div class="detail-title">
      <i class="el-icon-s-grid" />
      <span>工艺路线-工序列表</span>
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
      columns: [{field:'ProcessLineList_Id',title:'工艺路线工序列表主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'ProcessLine_Id',title:'工艺路线',type:'int',bind:{ key:'processLineList',data:[]},width:110,require:true,align:'left',sort:true},
                       {field:'ProcessLineType',title:'类型',readonly:true,type:'string',bind:{ key:'processLineType',data:[]},width:100,edit:{type:'select'},require:true,align:'left'},
                       {field:'Process_Id',title:'工序',type:'int',readonly:true,bind:{ key:'process',data:[]},width:150,edit:{type:'select'},align:'left'},
                       {field:'ProcessLineDown_Id',title:'工艺路线',readonly:true,type:'int',bind:{ key:'processLineList',data:[]},width:150,edit:{type:'select'},align:'left'},
                       {field:'Sequence',title:'顺序',type:'int',width:80,hidden:true,edit:{type:'number'},require:true,align:'left'},
                       {field:'SubmitWorkMatch',title:'报工数配比',type:'decimal',readonly:true,width:110,edit:{type:'text'},align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'}],
      rows: []
    };
  },
  methods:{
      rowClick(row){
          let url="api/Base_ProcessLine/getDetailRows?ProcessLine_Id=" + row.ProcessLine_Id
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