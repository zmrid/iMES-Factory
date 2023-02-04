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
          <span><i class="el-icon-date"></i> 班次</span>
        </template>
        <!-- 显示操作按钮 -->
        <div>
          <!-- <el-button
          type="success"
          size="mini"
          ghost
          @click="add"
          ><i class="el-icon-plus"></i>添加行</el-button
        > -->
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
      <el-tab-pane :lazy="false" label="班组">
        <template #label>
          <span><i class="el-icon-date"></i> 班组</span>
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
        <!-- <el-alert
        title="双击行可以编辑"
        type="warning"
        style="margin-bottom: 10px;"
        show-icon
      > 
      </el-alert>-->
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
import modelHeader from "./Cal_PlanModelHeader.vue"
import modelFooter from "./Cal_PlanModelFooter.vue"
export default {
  components: { MesTable,modelHeader,modelFooter },
  data() {
    return {
      //从表1
      table1Url: "api/Cal_Plan/getTable1Data", //table1获取数据的接口
      //表配置的字段注意要与后台返回的查询字段大小写一致
      tableColumns1: [
        { field: "PlanShiftId", title: "主键ID", type: "int", width: 80, hidden: true },
        { field: "PlanId", title: "计划主键ID", type: "int", width: 80, hidden: true },
        {
          field: "PlanShiftName",
          title: "班次名称",
          type: "string",
          width: 300,
          require: true,
          sortable: true,
        },
        {
          field: "StartTime",
          title: "开始时间",
          type: "string",
          width: 300,
          require: true,
          sortable: true,
          edit: { type: "text" }, 
        }, 
        {
          field: "EndTime",
          title: "结束时间",
          type: "string",
          width: 200,
          sortable: true,
          edit: { type: "text" }, //keep:true始终开启编辑，false双击才能编辑
        }
      ],
      //从表2
      table2Ur: "api/Cal_Plan/getTable2Data", //table1获取数据的接口
      //表配置的字段注意要与后台返回的查询字段大小写一致
      tableColumns2: [
        { field: "PlanTeamId", title: "主键ID", type: "int", width: 80, hidden: true },
        { field: "PlanId", title: "项目主键ID", type: "int", width: 80, hidden: true },
        { field: "TeamId", title: "班组主键ID", type: "int", width: 80, hidden: true },
        {
          field: "TeamCode",
          title: "班组编码",
          type: "string",
          width: 200
        },
        {
          field: "TeamName",
          title: "班组名称",
          type: "text",
          width: 150,
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
      let PlanId = $parent.currentRow.PlanId;
      //添加从表的查询参数(条件)
      //将当前选中的行主键传到后台用于查询(后台在GetTable2Data(PageDataOptions loadData)会接收到此参数)
      param.wheres.push({ name: "PlanId", value: PlanId });
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
      let PlanId = $parent.currentRow.PlanId;
      //添加从表的查询参数(条件)
      //将当前选中的行主键传到后台用于查询(后台在GetTable2Data(PageDataOptions loadData)会接收到此参数)
      param.wheres.push({ name: "PlanId", value: PlanId });
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
      this.$refs.table1.delRow();
      //可以this.http.post调用后台实际执行查询
    },
    del2() {
      let rows = this.$refs.table2.getSelected();
      if (rows.length == 0) {
        return this.$Message.error("请先选中行");
      }
      this.$refs.table2.delRow();
      //可以this.http.post调用后台实际执行查询
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
