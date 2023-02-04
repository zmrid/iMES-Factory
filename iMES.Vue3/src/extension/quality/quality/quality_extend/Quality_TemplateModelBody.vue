<template>
  <div class="vol-tabs">
    <el-tabs
      type="border-card"
      style="
        min-height: 370px;
        box-shadow: none;
        border-bottom: 0;
        border-top: 10px solid #eee;
      "
    >
      <el-tab-pane>
        <template #label>
          <span><i class="el-icon-date"></i> 检测项</span>
        </template>
        <!-- 显示操作按钮 -->
        <div>
          <el-button
          type="success"
          size="mini"
          ghost
          @click="add"
          ><i class="el-icon-plus"></i>添加行</el-button
        >
          <el-button
            type="primary"
            size="mini"
            ghost
            @click="del"
            ><i class="el-icon-close"></i> 删除行</el-button
          >
          <!-- <el-button
            type="info"
            size="mini"
            @click="$refs.table1.load()"
            ><i class="el-icon-refresh"></i> 刷新</el-button
          > -->
        </div>
        <el-alert
          title="双击行可以编辑"
          type="warning"
          style="margin: 10px 0"
          show-icon
        >
        </el-alert>
        <!-- :defaultLoadPage="false"打开窗口禁用默认加载数据 -->
        <mes-table
          ref="table1"
          :clickEdit="true"
          :loadKey="true"
          :columns="tableColumns1"
          :pagination-hide="false"
          :height="230"
          :url="table1Url"
          :index="true"
          :defaultLoadPage="false"
          @loadBefore="loadTableBefore1"
          @loadAfter="loadTableAfter1"
        ></mes-table>
      </el-tab-pane>

      <!-- 从表2 -->
      <el-tab-pane :lazy="false" label="产品信息">
        <template #label>
          <span><i class="el-icon-date"></i> 产品信息</span>
        </template>
        <!-- 从表2配置 ,双击可以开启编辑-->
        <div style="padding-bottom: 10px">
          <el-button
          type="success"
          size="mini"
          ghost
          @click="add2"
          ><i class="el-icon-plus"></i> 添加行</el-button
        >
          <el-button
          type="primary"
          size="mini"
          ghost
          @click="del2"
          ><i class="el-icon-close"></i> 删除行</el-button
        >
        <!-- <el-button
          type="info"
          size="mini"
          @click="$refs.table2.load()"
          ><i class="el-icon-refresh"></i> 刷新</el-button
        >
         -->
        </div>
        <el-alert
        title="双击行可以编辑"
        type="warning"
        style="margin-bottom: 10px;"
        show-icon
      >
      </el-alert>
        <mes-table
          ref="table2"
          :loadKey="true"
          :clickEdit="true"
          :columns="tableColumns2"
          :pagination-hide="false"
          :height="275"
          :url="table2Ur"
          :defaultLoadPage="false"
          @loadBefore="loadTableBefore2"
          :index="true"
        ></mes-table>
      </el-tab-pane>
    </el-tabs>
  </div>
  <modelHeader ref="modelHeader"/>
  <modelFooter ref="modelFooter"/>
</template>
<script>
//开发一对多从表需要参照MesTable与viewgrid组件api
import MesTable from "@/components/basic/MesTable.vue";
import modelHeader from "./Quality_TemplateModelHeader.vue"
import modelFooter from "./Quality_TemplateModelFooter.vue"
export default {
  components: { MesTable,modelHeader,modelFooter },
  data() {
    return {
      //从表1
      table1Url: "api/Quality_Template/getTable1Data", //table1获取数据的接口
      //表配置的字段注意要与后台返回的查询字段大小写一致
      tableColumns1: [
        { field: "TemplateTestItemId", title: "主键ID", type: "int", width: 80, hidden: true },
        { field: "TestItemId", title: "测试项主键ID", type: "int", width: 80, hidden: true },
        {
          field: "TestItemName",
          title: "检测项名称",
          type: "string",
          width: 150,
          require: true,
          sortable: true,
        },
        {
          field: "TestItemCode",
          title: "检测项编码",
          type: "string",
          width: 150,
          require: true,
          sortable: true,
        },
        {
          field: "TestItemType",
          title: "检测项类别",
          type: "string",
          width: 150,
          sortable: true,
          bind:{ key:'QCDefectType',data:[]},
          edit: { type: "select" }, //keep:true始终开启编辑，false双击才能编辑
        },
        {
          field: "QCTool",
          title: "检测工具",
          type: "string",
          width: 150,
          sortable: true,
          edit: { type: "text" }, //keep:true始终开启编辑，false双击才能编辑
        },
        {
          field: "CheckMethod",
          title: "检测要求",
          type: "string",
          width: 150,
          sortable: true,
          edit: { type: "text" }, //keep:true始终开启编辑，false双击才能编辑
        },
        {
          field: "StanderValue",
          title: "标准值",
          type: "int",
          width: 100,
          sortable: true,
          edit: { type: "text" }, //keep:true始终开启编辑，false双击才能编辑
        },
        {
          field: "ThresholdMax",
          title: "误差上限",
          type: "int",
          width: 100,
          sortable: true,
          edit: { type: "text" }, //keep:true始终开启编辑，false双击才能编辑
        },
        {
          field: "ThresholdMin",
          title: "误差下限",
          type: "int",
          width: 100,
          sortable: true,
          edit: { type: "text" }, //keep:true始终开启编辑，false双击才能编辑
        },
        {
          field: "Remark",
          title: "备注",
          type: "string",
          width: 200,
          sortable: true,
          edit: { type: "text" }, //keep:true始终开启编辑，false双击才能编辑
        }
      ],
      //从表2
      table2Ur: "api/Quality_Template/getTable2Data", //table1获取数据的接口
      //表配置的字段注意要与后台返回的查询字段大小写一致
      tableColumns2: [
        { field: "TemplateProductId", title: "主键ID", type: "int", width: 80, hidden: true },
        { field: "ProductId", title: "产品主键ID", type: "int", width: 80, hidden: true },
        {
          field: "ProductName",
          title: "产品名称",
          type: "string",
          width: 150
        },
        {
          field: "ProductCode",
          title: "产品编码",
          type: "text",
          width: 150,
        },

        {
          field: "ProductStandard",
          title: "规格型号",
          type: "text",
          width: 100,
        },
        {
          field: "CheckMin",
          title: "最低检测数",
          type: "int",
          edit: { type: "text" },
          width: 100,
        },
        {
          field: "DisQualityMax",
          title: "最大不合格数",
          type: "int",
          edit: { type: "text" },
          width: 100,
        },
        {
          field: "CrRate",
          title: "致命缺陷率",
          type: "int",
          edit: { type: "text" },
          width: 100,
        },
        {
          field: "MajRate",
          title: "严重缺陷率",
          type: "text",
          edit: { type: "text" },
          width: 100,
        }, {
          field: "MinRate",
          title: "轻微缺陷率",
          type: "text",
          edit: { type: "text" },
          width: 100,
        },
        {
          field: "Remark",
          title: "备注",
          type: "text",
          edit: { type: "text" },
          width: 200,
        }
      ],
    };
  },
  methods: {
    //如果要获取页面的参数请使用 this.$emit("parentCall",见下面的使用方法
    modelOpen() {
      let $parent;
      //获取生成页面viewgrid的对象
      this.$emit("parentCall", ($this) => {
        $parent = $this;
      });
      //当前如果是新建重置两个表格数据
      if ($parent.currentAction == "Add") {
        this.$refs.table1.reset();
        this.$refs.table2.reset();
      } else {
        //如果是编辑，添加两个表格的数据
        this.$refs.table1.load();
        this.$refs.table2.load();
      }
    },
    loadTableBefore1(param, callBack) {
      let $parent = null;
      //当前是子页面，获取查询viewgrid页面的对象()
      this.$emit("parentCall", ($this) => {
        $parent = $this;
      });
      //如果是新建功能，禁止刷新操作
      if ($parent.currentAction == "Add") {
        return callBack(false);
      }
      //获取当前编辑主键id值
      let TemplateId = $parent.currentRow.TemplateId;
      //添加从表的查询参数(条件)
      //将当前选中的行主键传到后台用于查询(后台在GetTable2Data(PageDataOptions loadData)会接收到此参数)
      param.wheres.push({ name: "TemplateId", value: TemplateId });
      callBack(true);
    },
    //从表2加载数据数前(操作与上面一样的,增加查询条件)
    loadTableBefore2(param, callBack) {
      let $parent = null;
      //当前是子页面，获取查询viewgrid页面的对象()
      this.$emit("parentCall", ($this) => {
        $parent = $this;
      });
      //如果是新建功能，禁止刷新操作
      if ($parent.currentAction == "Add") {
        return callBack(false);
      }
      //获取当前编辑主键id值
      let TemplateId = $parent.currentRow.TemplateId;
      //添加从表的查询参数(条件)
      //将当前选中的行主键传到后台用于查询(后台在GetTable2Data(PageDataOptions loadData)会接收到此参数)
      param.wheres.push({ name: "TemplateId", value: TemplateId });
      callBack(true);
    },
    //从后台加载从表1数据后
    loadTableAfter1(data, callBack) {
      return true;
    },


    del() {
      let rows = this.$refs.table1.getSelected();
      if (rows.length == 0) {
        return this.$Message.error("请先选中行");
      }
      if(rows.length>1)
      {
        return this.$Message.error("只能选择一项");
      }
      this.$refs.table1.delRow();
     
      //可以this.http.post调用后台执行删除
      var param = [rows[0].TemplateTestItemId];
      this.http.post('/api/Quality_TemplateTestItem/del', param, true).then((result) => {
        this.$Message.info("删除成功！");
      });
    },
    del2() {
      let rows = this.$refs.table2.getSelected();
      if (rows.length == 0) {
        return this.$Message.error("请先选中行");
      }
      if(rows.length>1)
      {
        return this.$Message.error("只能选择一项");
      }
      this.$refs.table2.delRow();
      //可以this.http.post调用后台执行删除
      var param = [rows[0].TemplateProductId];
      this.http.post('/api/Quality_TemplateProduct/del', param, true).then((result) => {
        this.$Message.info("删除成功！");
      });
    },
    add() {
      this.$refs.modelHeader.open();
    },
    add2() {
      this.$refs.modelFooter.open();
    },
    setTable1Rows(modelTyep,_rows){
      this.$refs.table1.rowData.unshift(..._rows);
    },
    setTable2Rows(_rows){
      this.$refs.table2.rowData.unshift(..._rows);
    },
    getRows() {
      //获取选中的行
      let rows = this.$refs.table1.getSelected();
      if (rows.length == 0) {
        return this.$Message.error("请先选中行");
      }
      this.$Message.error(JSON.stringify(rows));
    },
  },
};
</script>
<style lang="less" scoped>
.vol-tabs {
  background: white;
}
</style>
