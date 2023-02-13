<template>
  <MesBox v-model="model" :lazy="true" title="选择数据" :height="700" :width="1500" :padding="15">
    <!-- 设置查询条件 -->
    <div style="padding-bottom: 10px">
      <span style="margin-right: 20px">产品编码</span>
      <el-input placeholder="请输入产品编码" style="width: 200px" v-model="productCode" />
      <el-button type="primary" style="margin-left:10px" size="medium" icon="el-icon-zoom-out" @click="search">搜索
      </el-button>
    </div>

    <!-- mes-table配置的这些属性见MesTable组件api文件 -->
    <mes-table ref="mytable" :loadKey="true" :columns="columns" :pagination="pagination" :pagination-hide="false"
      :max-height="700" :url="url" :index="true" :single="true" :defaultLoadPage="defaultLoadPage"
      @loadBefore="loadTableBefore" @loadAfter="loadTableAfter"></mes-table>
    <!-- 设置弹出框的操作按钮 -->
    <template #footer>
      <div>
        <el-button size="mini" type="primary" @click="addRow()"> <i class="el-icon-plus" />添加选择的数据</el-button>
        <el-button size="mini" icon="el-icon-close" @click="model = false">关闭</el-button>
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
        productCode: "", //查询条件字段
        modelType: "",
        url: "api/Base_Product/getSelectorDemo",//加载数据的接口
        columns: [
          { field: 'Product_Id', title: '产品定义主键ID', type: 'int', width: 110, hidden: true, readonly: true, require: true, align: 'left' },
          { field: 'ProductCode', title: '产品编号', type: 'string', sort: true, width: 250, align: 'left', sort: true },
          { field: 'ProductName', title: '产品名称', type: 'string', link: true, sort: true, width: 180, require: true, align: 'left' },
          { field: 'Unit_Id', title: '库存单位', type: 'int', bind: { key: 'unitList', data: [] }, width: 110, require: true, align: 'left' },
          { field: 'ProductStandard', title: '产品规格', type: 'string', width: 180, align: 'left' },
          { field: 'ProductAttribute', title: '产品属性', type: 'string', bind: { key: 'productAttr', data: [] }, width: 180, require: true, align: 'left' },
          { field: 'Process_Id', title: '工艺路线', type: 'int', bind: { key: 'processLineList', data: [] }, width: 110, align: 'left' },
          { field: 'MaxInventory', title: '最大库存', type: 'int', sort: true, width: 110, align: 'left' },
          { field: 'MinInventory', title: '最小库存', type: 'int', sort: true, width: 110, align: 'left' },
          { field: 'SafeInventory', title: '安全库存', type: 'int', sort: true, width: 110, align: 'left' },
          { field: 'InventoryQty', title: '库存数量', type: 'int', sort: true, width: 110, align: 'left' },
          { field: 'FinishedProduct', title: '成品图', type: 'img', width: 180, align: 'left' }
        ],
        pagination: {}, //分页配置，见mestable组件api
      };
    },
    methods: {
      openDemo(type) {
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
      getFieldDicValue(fieldName, fieldValue) {
        this.columns.forEach(item => {
          if (item.field == fieldName) {
            var result = item.bind.data.find(val => val.key == fieldValue)
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
          $parent.getRow(rows, this.modelType);
        });
        //关闭当前窗口
        this.model = false;
      },
      //这里是从api查询后返回数据的方法
      loadTableAfter(row) { },
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