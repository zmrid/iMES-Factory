<template>
    <MesBox
      v-model="model"
      :lazy="true"
      title="选择数据"
      :height="700"
      :width="1500"
      :padding="15"
    >
      <!-- 设置查询条件 -->
      <div style="padding-bottom: 10px">
        <span style="margin-right: 20px">工单编码</span>
        <el-input
        
          placeholder="请输入工单编码"
          style="width: 200px"
          v-model="WorkOrderCode"
        />
        <el-button
          type="primary"
          style="margin-left:10px"
          size="medium"
          icon="el-icon-zoom-out"
          @click="search"
          >搜索</el-button
        >
      </div>
  
      <!-- mes-table配置的这些属性见MesTable组件api文件 -->
      <mes-table
        ref="mytable"
        :loadKey="true"
        :columns="columns"
        :pagination="pagination"
        :pagination-hide="false"
        :max-height="700"
        :url="url"
        :index="true"
        :single="true"
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
          <el-button size="mini"  @click="model = false"
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
        WorkOrderCode: "", //查询条件字段
        modelType:"",
        url: "api/Production_WorkOrder/getSelectorWorkOrder",//加载数据的接口
        columns: [{field:'WorkOrder_Id',title:'工单主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'WorkOrderCode',title:'工单编号',type:'string',link:true,sort:true,width:250,require:true,align:'left',sort:true},
                       {field:'Product_Id',title:'产品',type:'int',bind:{ key:'productList',data:[]},width:80,require:true,align:'left'},
                       {field:'ProductCode',title:'产品编号',type:'string',sort:true,width:250,readonly:true,require:true,align:'left'},
                       {field:'ProductName',title:'产品名称',type:'string',sort:true,width:180,readonly:true,require:true,align:'left'},
                       {field:'ProductStandard',title:'产品规格',type:'string',width:180,readonly:true,align:'left'},
                       {field:'Unit_Id',title:'单位',type:'int',bind:{ key:'unitList',data:[]},width:110,readonly:true,require:true,align:'left'},
                       {field:'AssociatedForm',title:'关联单据',type:'string',width:250,align:'left'},
                       {field:'Status',title:'状态',type:'string',bind:{ key:'workOrderStatus',data:[]},width:180,readonly:true,require:true,align:'left'},
                       {field:'PlanStartDate',title:'计划开始时间',type:'datetime',sort:true,width:200,require:true,align:'left',sort:true},
                       {field:'PlanEndDate',title:'计划结束时间',type:'datetime',sort:true,width:200,require:true,align:'left',sort:true},
                       {field:'PlanQty',title:'计划数',type:'int',sort:true,width:110,require:true,align:'left'},
                       {field:'RealQty',title:'实际数',type:'int',width:110,require:true,align:'left'},
                       {field:'GoodQty',title:'良品数',type:'int',width:110,require:true,align:'left'},
                       {field:'NoGoodQty',title:'不良品数',type:'int',width:110,require:true,align:'left'},
                       {field:'ReportTime',title:'报工时长',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ProductionSchedule',title:'生产进度',type:'string',width:180,align:'left'},
                       {field:'ActualStartDate',title:'实际开始时间',type:'datetime',sort:true,width:200,align:'left',sort:true},
                       {field:'ActualEndDate',title:'实际结束时间',type:'datetime',width:200,align:'left',sort:true},
                       {field:'Remark',title:'备注',type:'string',width:220,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'}],
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
        //回写数据到表单
        this.$emit("parentCall", ($parent) => {
          $parent.getRowWorkOrder(rows);
        });
        //关闭当前窗口
        this.model = false;
      },
      //这里是从api查询后返回数据的方法
      loadTableAfter(row) {},
      loadTableBefore(params) {
        //查询前，设置查询条件
        if (this.productCode) {
          params.wheres = [{ name: "ProductCode", value: this.productCode }];
        }
        return true;
      },
    },
  };
  </script>
  