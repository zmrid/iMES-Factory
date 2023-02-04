/*****************************************************************************************
**  Author:COCO 2022
*****************************************************************************************/
//此js文件是用来自定义扩展业务代码，可以扩展一些自定义页面或者重新配置生成的代码
import { h, resolveComponent, defineAsyncComponent } from 'vue';
import modelBody from "./quality_extend/Quality_TemplateModelBody.vue"
import modelHeader from "./quality_extend/Quality_TemplateModelHeader.vue"
import modelFooter from "./quality_extend/Quality_TemplateModelFooter.vue"
let extension = {
  components: {
    //查询界面扩展组件
    gridHeader: '',
    gridBody: '',
    gridFooter: '',
    //新建、编辑弹出框扩展组件
    modelHeader: modelHeader,
    modelBody: modelBody,
    modelFooter: modelFooter
  },
  tableAction: '', //指定某张表的权限(这里填写表名,默认不用填写)
  buttons: { view: [], box: [], detail: [] }, //扩展的按钮
  methods: {
     //下面这些方法可以保留也可以删除
    onInit() {  //框架初始化配置前，
        //示例：在按钮的最前面添加一个按钮
        //   this.buttons.unshift({  //也可以用push或者splice方法来修改buttons数组
        //     name: '按钮', //按钮名称
        //     icon: 'el-icon-document', //按钮图标vue2版本见iview文档icon，vue3版本见element ui文档icon(注意不是element puls文档)
        //     type: 'primary', //按钮样式vue2版本见iview文档button，vue3版本见element ui文档button
        //     onClick: function () {
        //       this.$Message.success('点击了按钮');
        //     }
        //   });

        //示例：设置修改新建、编辑弹出框字段标签的长度
        // this.boxOptions.labelWidth = 150;
        //显示序号(默认隐藏)
        this.columnIndex = true;
        this.height = this.height - 100;
        //自定义弹出框的高与宽
        this.boxOptions.height = document.body.clientHeight * 0.9;
        this.boxOptions.width = document.body.clientWidth * 0.8;
    },
    onInited() {
      //框架初始化配置后
      //如果要配置明细表,在此方法操作
      //this.detailOptions.columns.forEach(column=>{ });
    },
    searchBefore(param) {
      //界面查询前,可以给param.wheres添加查询参数
      //返回false，则不会执行查询
      return true;
    },
    searchAfter(result) {
      //查询后，result返回的查询数据,可以在显示到表格前处理表格的值
      return true;
    },
    addBefore(formData) {
      //新建保存前formData为对象，包括明细表，可以给给表单设置值，自己输出看formData的值
      this.setFormData(formData);
      return true;
    },
    updateBefore(formData) {
      //编辑保存前formData为对象，包括明细表、删除行的Id
      this.setFormData(formData);
      return true;
    },
    setFormData(formData) { //新建或编辑时，将从表1、2的数据提交到后台,见后台Equip_SpotMaintPlanService的新建方法
      //后台从对象里直接取extra的值
      let extra = {
        table1List: this.$refs.modelBody.$refs.table1.rowData,//获取从表1的行数据
        table2List: this.$refs.modelBody.$refs.table2.rowData//获取从表2的行数据
      }
      formData.extra = JSON.stringify(extra);
    },
    rowClick({ row, column, event }) {
      //查询界面点击行事件
      // this.$refs.table.$refs.table.toggleRowSelection(row); //单击行时选中当前行;
    },
    modelOpenAfter(row) {
      //点击编辑、新建按钮弹出框后，可以在此处写逻辑，如，从后台获取数据
      //(1)判断是编辑还是新建操作： this.currentAction=='Add';
      //(2)给弹出框设置默认值
      //(3)this.editFormFields.字段='xxx';
      //如果需要给下拉框设置默认值，请遍历this.editFormOptions找到字段配置对应data属性的key值
      //看不懂就把输出看：console.log(this.editFormOptions)
      this.editFormOptions.forEach(item => {
        item.forEach(x => {
          //如果是编辑设置为只读
          if (x.field == "TemplateCode") {
            x.placeholder = "请输入，忽略将自动生成";
          }
        })
      })
      this.$nextTick(() => {
        //这里没有给弹出框中的表格传参，如果需要参数可以通过 this.$emit("parentCall", 获取页面的参数
        //具体见自定义页面Equip_SpotMaintPlanModelBody.vue中的modelOpen方法的使用 this.$emit("parentCall", ($this) => {
        this.$refs.modelBody.modelOpen();
      })
    }
  }
};
export default extension;
