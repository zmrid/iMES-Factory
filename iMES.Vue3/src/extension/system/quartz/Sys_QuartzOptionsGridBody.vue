<template>
  <imes-box
    :lazy="true"
    v-model="model"
    title="执行日志"
    :height="500"
    :width="1200"
    :padding="0"
  >
    <QuartzLog ref="log"></QuartzLog>
    <template #footer>
      <div>
        <el-button type="default" size="mini" @click="model = false"
          >关闭</el-button
        >
      </div></template
    >
  </imes-box>
</template>
<script>
import MesBox from '@/components/basic/MesBox.vue';
import QuartzLog from '@/views/system/quartz/Sys_QuartzLog';
//这里使用的vue2语法，也可以写成vue3语法
export default {
  components: { 'imes-box': MesBox, QuartzLog },
  methods: {},
  data() {
    return {
      model: false
    };
  },
  methods: {
    open() {
      this.model = true;
      this.$nextTick(() => {
        this.$refs.log.$refs.grid.search();
      });
    }
  }
};
</script>
