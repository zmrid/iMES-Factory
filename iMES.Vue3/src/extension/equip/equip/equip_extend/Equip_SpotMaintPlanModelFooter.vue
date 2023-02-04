<template>
    <MesBox
      v-model="model"
      :lazy="true"
      title="选择点检项目"
      :height="700"
      :width="1500"
      :padding="15"
    >
      <!-- 设置查询条件 -->
      <div style="padding-bottom: 10px">
        <span style="margin-right: 10px;">项目编码：</span>
        <el-input
        
          placeholder="请输入项目编码"
          style="width: 200px"
          v-model="spotMaintenanceCode"
        />
        <span style="margin-right: 10px;margin-left: 20px;">项目名称：</span>
        <el-input
        
          placeholder="请输入项目名称"
          style="width: 200px"
          v-model="spotMaintenanceName"
        />
        <el-button
          type="primary"
          style="margin-left:20px"
          size="medium"
          @click="search"
          ><i class="el-icon-search"></i>搜索</el-button
        >
       
      </div>
  
      <!-- imes-table配置的这些属性见MesTable组件api文件 -->
      <mes-table
        ref="mytable"
        :loadKey="true"
        :columns="columns"
        :pagination="pagination"
        :pagination-hide="false"
        :max-height="600"
        :url="url"
        :index="true"
        :single="false"
        :defaultLoadPage="defaultLoadPage"
        @loadBefore="loadTableBefore"
        @loadAfter="loadTableAfter"
      ></mes-table>
      <!-- 设置弹出框的操作按钮 -->
      <template #footer>
        <div>
          <el-button
            size="mini"
            type="primary"
            @click="addRow()"
            ><i class="el-icon-plus"></i>添加选择的数据</el-button
          >
          <el-button size="mini" @click="model = false"
            ><i class="el-icon-close"></i>关闭</el-button
          >
        </div>
      </template>
    </MesBox>
  </template>
  <script>
  import MesBox from "@/components/basic/MesBox.vue";
  import MesTable from "@/components/basic/MesTable.vue";
  import { thisTypeAnnotation } from "@babel/types";
  export default {
    components: {
        MesBox: MesBox,
        MesTable: MesTable,
    },
    data() {
      return {
        model: false,
        defaultLoadPage: false, //第一次打开时不加载table数据，openDemo手动调用查询table数据
        deviceCode: "", //查询条件字段
        deviceName: "", //查询条件字段
        url: "api/Equip_SpotMaintenance/getSelectorSpotMaintenance",//加载数据的接口
        columns: [
                       {field:'SpotMaintenanceId',title:'项目主键',type:'string',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'SpotMaintenanceName',title:'项目名称',type:'string',sort:true,width:250,align:'left',sort:true},
                       {field:'SpotMaintenanceCode',title:'项目编码',type:'string',link:true,sort:true,width:180,require:true,align:'left'},
                       {field:'ItemType',title:'项目类型',type:'int',bind:{ key:'DeviceItemType',data:[]},width:110,require:true,align:'left'},
                       {field:'Enable',title:'是否可用',type:'int',bind:{ key:'enable',data:[]},width:180,align:'left'},
                       {field:'ItemContent',title:'项目内容',type:'string',width:180,require:true,align:'left'},
                       {field:'ItemStandard',title:'标准',type:'datetime',width:110,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:110,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',sort:true,width:110,align:'left'}
        ],
        pagination: {}, //分页配置，见mestable组件api
      };
    },
    methods: {
      open() {
        this.model = true;
        //打开弹出框时，加载table数据
        this.$nextTick(() => {
          this.$refs.mytable.load();
        });
      },
      search() {
        //点击搜索
        this.$refs.mytable.load();
      },
      getFieldDicValue(fieldName,fieldValue){
        this.columns.forEach(item => {
          if (item.field == fieldName) {
            var result =  item.bind.data.find(val => val.key == fieldValue)
            return result;
          }
        })
      },
      addRow() {
        var rows = this.$refs.mytable.getSelected();
        if (!rows || rows.length == 0) {
          return this.$message.error("请选择行数据");
        }
        this.model = false;
           //获取回写到明细表的字段
        let _rows = rows.map((row) => {
            return {
              SpotMaintenanceId:row.SpotMaintenanceId,
              SpotMaintenanceName: row.SpotMaintenanceName,
              SpotMaintenanceCode: row.SpotMaintenanceCode,
              ItemType: row.ItemType,
              ItemContent: row.ItemContent,
              ItemStandard: row.ItemStandard
            };
        });
        this.$parent.setTable2Rows(_rows);
      },
      //这里是从api查询后返回数据的方法
      loadTableAfter(row) {},
      loadTableBefore(params) {
        //查询前，设置查询条件
        if (this.spotMaintenanceCode) {
          params.wheres.push({ name: "SpotMaintenanceCode", value: this.spotMaintenanceCode, displayType:"like"});
        }
        if (this.spotMaintenanceName) {
          params.wheres.push({ name: "SpotMaintenanceName", value: this.spotMaintenanceName, displayType:"like"});
        }
        return true;
      },
    },
  };
  </script>
  