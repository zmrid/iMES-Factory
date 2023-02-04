<template>
  <div class="goods-tree">
    <!-- 左边树结构 -->
    <div class="tree-left">
      <div class="tree-left-title">设备分类</div>
      <el-scrollbar style="flex:1;border-right: 1px solid #eee;">
        <!-- el-tree文档https://element-plus.gitee.io/zh-CN/component/tree.html#%E6%96%B9%E6%B3%95 -->
        <el-tree
          node-key="id"
          :default-expanded-keys="defaultExpandedKeys"
          :data="data"
          :props="defaultProps"
          :expand-on-click-node="false"
          @node-click="nodeClick"
        />
      </el-scrollbar>
    </div>
    <!-- 右边模版信息table数据 -->
    <div class="tree-right">
      <goods ref="table"></goods>
    </div>
  </div>
</template>

<script>
import { ConsoleLogger } from '@microsoft/signalr/dist/esm/Utils';
import goods from './Equip_Device.vue';
export default {
  components: {
    goods
  },
  data() {
    return {
      data: [],
      orginData: [], //原始数据
      defaultProps: {
        children: 'children',
        label: 'name' //树形结构显示名称的字段
      },
      defaultExpandedKeys: [] //默认展开的tree节点
    };
  },
  methods: {
    nodeClick(data) {//左侧树点击事件
      let ids = [];
      //获取分类的子节点
      //左边树节点的甩有子节点，用于查询数据
      this.getAllChildrenId(data, ids);

      //获取所有的父节点
      //左侧树选中节点的所有父节点,用于新建时设置级联的默认值
      let nodes = this.base.getTreeAllParent(data.id, this.orginData);
      let nodesList = nodes;
      //获取节点的id
      nodes = nodes.map((m) => {
        return m.id;
      });

      //调用右边商品信息的查询(见代码Demo_Goods.js)
      this.$refs.table.$refs.grid.nodeClick(ids,nodes,nodesList);
    },
    getAllChildrenId(data, ids) {
      //获取分类的子节点
      ids.push(data.id);
      if (!data.children || !data.children.length) {
        return;
      }
      data.children.forEach((x) => {
        ids.push(x.id);
        this.getAllChildrenId(x, ids);
      });
    }
  },
  created() {
    //从打印模版分类Equip_DevCatalogController加载左边tree数据
    this.http.get('api/Equip_DevCatalog/getList').then((result) => {
      //记录原始数据
      this.orginData = result;
      this.data = this.base.convertTree(result, (node, data, isRoot) => {});
      //商品分类有数据时加载右边商品信息
      if (this.data.length) {
        //默认展开经一个树节点
        this.defaultExpandedKeys = [this.data[0].children[0].id];
        //调用右边商品信息的查询
        this.$nextTick(() => {
          this.nodeClick(this.data[0].children[0]);
        });
      }
    });
  }
};
</script>
<style lang="less" scoped>
.goods-tree {
  position: absolute;
  display: flex;
  height: 100%;
  width: 100%;
  .tree-left {
    display: flex;
    flex-direction: column;
    width: 200px;
    .tree-left-title {
      line-height: 25px;
      font-size: 15px;
      background: rgba(102, 177, 255, 0.058823529411764705);
      padding: 6px 16px;
      border: 1px solid #ececec;
    }
  }
  .tree-right {
    flex: 1;
    width: 0;
  }
}
</style>
