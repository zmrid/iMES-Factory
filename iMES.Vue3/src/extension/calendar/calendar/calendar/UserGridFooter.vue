<template>
  <div class="detail-table">
    <div class="detail-title">
      <i class="el-icon-s-grid" />
      <span>班组-成员</span>
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
      columns:[{field:'TeamMemberId',title:'成员主键',type:'guid',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'TeamId',title:'班组主键',type:'guid',width:110,hidden:true,require:true,align:'left'},
                       {field:'User_Id',title:'成员',type:'int',sort:true,width:110,hidden:true,require:true,align:'left'},
                       {field:'UserName',title:'成员名称',type:'string',sort:true,width:120,require:true,align:'left',sort:true},
                       {field:'UserTrueName',title:'成员姓名',type:'string',sort:true,width:110,require:true,align:'left'},
                       {field:'PhoneNo',title:'电话号码',type:'string',width:110,align:'left'},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',sort:true,width:110,align:'left',sort:true}],
      rows: []
    };
  },
  methods:{
      rowClick(row){
          let url="api/Cal_Team/getDetailRows?TeamId=" + row.TeamId;
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