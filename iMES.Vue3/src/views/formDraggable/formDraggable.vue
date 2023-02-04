<template>

  <MesFormDraggable @save="save" :userComponents="userComponents"></MesFormDraggable>
</template>

<script>
// 
import MesFormDraggable from "@/components/basic/MesFormDraggable/index.js";
export default {
  components: {
    MesFormDraggable,
  },
  methods: {
    save(options) {
      this.$Message.success("可以将当前配置保存到数据库中用于二次维护");
      console.log(JSON.stringify(options))
    },
  },
  data(){
      return{
          userComponents:[]
      }
  },
  created() {
    //收起左侧菜单
    this.menu.hide();
  },
};
</script>
<style lang="less" scoped>
</style>