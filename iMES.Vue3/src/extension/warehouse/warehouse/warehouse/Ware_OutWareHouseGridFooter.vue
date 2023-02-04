<template>
  <div class="detail-table">
    <div class="detail-title">
      <i class="el-icon-s-grid" />
      <span>入库单-产品明细</span>
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
      columns: [{field:'OutWareHouseBillList_Id',title:'出库单产品明细表主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'OutWareHouseBill_Id',title:'出库单',type:'int',width:200,hidden:true,require:true,align:'left'},
                       {field:'ProductCode',title:'产品编号',type:'string',link:true,sort:true,width:250,readonly:true,edit:{type:'text'},require:true,align:'left',sort:true},
                       {field:'ProductName',title:'产品名称',type:'string',width:180,readonly:true,edit:{type:'text'},require:true,align:'left'},
                       {field:'Unit_Id',title:'库存单位',type:'int',bind:{ key:'unitList',data:[]},width:110,readonly:true,edit:{type:'select'},require:true,align:'left'},
                       {field:'ProductStandard',title:'产品规格',type:'string',sort:true,width:180,readonly:true,edit:{type:''},align:'left'},
                       {field:'MaxInventory',title:'最大库存',type:'int',sort:true,width:110,readonly:true,edit:{type:''},align:'left'},
                       {field:'MinInventory',title:'最小库存',type:'int',sort:true,width:110,readonly:true,edit:{type:''},align:'left'},
                       {field:'SafeInventory',title:'安全库存',type:'int',sort:true,width:110,edit:{type:''},align:'left'},
                       {field:'InventoryQty',title:'当前库存数量',type:'int',sort:true,width:110,readonly:true,edit:{type:''},align:'left'},
                       {field:'OutStoreQty',title:'出库数量',type:'int',width:110,edit:{type:'text'},require:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Product_Id',title:'产品ID',type:'int',width:110,hidden:true,edit:{type:'text'},require:true,align:'left'}],
      rows: []
    };
  },
  methods:{
      rowClick(row,type){
          let  url="api/Ware_OutWareHouseBill/getDetailRows?OutWareHouseBill_Id=" + row.OutWareHouseBill_Id
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