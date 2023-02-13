<template>
  <MesBox v-model="model" :lazy="true" title="选择颜色" :height="250" :width="250" :padding="15">
    <div class="block">
      <span class="demonstration">有默认值</span>
      <el-color-picker v-model="color"></el-color-picker>
    </div>
    <!-- 设置弹出框的操作按钮 -->
    <template #footer>
      <div>
        <el-button size="mini" type="primary" @click="addRow()"><i class="el-icon-plus" />添加选择的数据</el-button>
        <el-button size="mini" icon="el-icon-close" @click="model = false">关闭</el-button>
      </div>
    </template>
  </MesBox>
</template>
<script>
  import MesBox from "@/components/basic/MesBox.vue";
  import { thisTypeAnnotation } from "@babel/types";
  export default {
    components: {
      MesBox: MesBox
    },
    data() {
      return {
        color: '#409EFF',
        model: false
      };
    },
    methods: {
      open() {
        this.model = true;
      },
      addRow() {
        //回写数据到表单
        this.$emit("parentCall", ($parent) => {
          $parent.getRow(this.color);
        });
        //关闭当前窗口
        this.model = false;
      }
    },
  };
</script>