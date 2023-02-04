<template>
    <MesBox
      v-model="model"
      :lazy="true"
      title="选择检测项"
      :height="700"
      :width="1500"
      :padding="15"
    >
      <!-- 设置查询条件 -->
      <div style="padding-bottom: 10px">
        <span style="margin-right: 10px;">检测项编码：</span>
        <el-input
        
          placeholder="请输入检测项编码："
          style="width: 200px"
          v-model="TestItemCode"
        />
        <span style="margin-right: 10px;margin-left: 20px;">检测项名称：</span>
        <el-input
        
          placeholder="请输入设备名称"
          style="width: 200px"
          v-model="TestItemName"
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
        TestItemCode: "", //查询条件字段
        TestItemName: "", //查询条件字段
        modelType:"",
        url: "api/Quality_TestItem/getSelectorTestItem",//加载数据的接口
        columns:[{field:'TestItemId',title:'检测项主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
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
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'}],
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
      openPaper(type) {
        this.modelType = type;
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
        if(this.modelType=="MaintainPaperId" && rows.length >1 )
        {
          return this.$message.error("请选择一条数据");
        }
        this.model = false;
           //获取回写到明细表的字段
        let _rows = rows.map((row) => {
            return {
              TestItemId:row.TestItemId,
              TestItemCode: row.TestItemCode,
              TestItemName: row.TestItemName,
              TestItemType: row.TestItemType,
              QCTool:row.QCTool
            };
        });
          this.$parent.setTable1Rows(this.modelType,_rows);
       
        ///this.$refs.table1.rowData.unshift(..._rows);
        // this.$emit('parentCall', ($parent) => {
        //   console.log($parent);
        //   $parent.$refs.table1.rowData.unshift(..._rows);
        // });
        //关闭当前窗口
        
      },
      //这里是从api查询后返回数据的方法
      loadTableAfter(row) {},
      loadTableBefore(params) {
        //查询前，设置查询条件
        if (this.TestItemCode) {
          params.wheres.push({ name: "TestItemCode", value: this.TestItemCode, displayType:"like"});
        }
        if (this.TestItemName) {
          params.wheres.push({ name: "TestItemName", value: this.TestItemName, displayType:"like"});
        }
        return true;
      },
    },
  };
  </script>
  