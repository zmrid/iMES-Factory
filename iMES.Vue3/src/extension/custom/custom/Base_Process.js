/*****************************************************************************************
**  Author:COCO 2022
*****************************************************************************************/
//此js文件是用来自定义扩展业务代码，可以扩展一些自定义页面或者重新配置生成的代码
import gridFooter from './custom_extend/Base_ProcessGridFooter';
let extension = {
  components: {
    //查询界面扩展组件
    gridHeader: '',
    gridBody: '',
    gridFooter: gridFooter,
    //新建、编辑弹出框扩展组件
    modelHeader: '',
    modelBody: '',
    modelFooter: ''
  },
  tableAction: '', //指定某张表的权限(这里填写表名,默认不用填写)
  buttons: { view: [], box: [], detail: [] }, //扩展的按钮
  methods: {
    //下面这些方法可以保留也可以删除
    onInit() {  //框架初始化配置前，
      //示例：设置修改新建、编辑弹出框字段标签的长度
      // this.boxOptions.labelWidth = 150;
      //设置查询表单的标签文字宽度
      //设置界面上为单选
      this.single = true;
      this.labelWidth = 120;
      //this.tableHeight = (document.body.clientHeight-260)/2;
      this.tableMaxHeight = (document.body.clientHeight - 260) / 2;
      //示例：设置修改新建、编辑弹出框字段标签的长度
      this.boxOptions.labelWidth = 120;
      //显示序号(默认隐藏)
      this.columnIndex = true;
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
    searchAfter(rows) {
      //页面查询返回数据时，加载第一条数据的明细
      this.$nextTick(() => {
        this.$refs.gridFooter.rowClick(rows[0]);
      });
      return true;
    },
    addBefore(formData) {
      //新建保存前formData为对象，包括明细表，可以给给表单设置值，自己输出看formData的值
      return true;
    },
    updateBefore(formData) {
      //编辑保存前formData为对象，包括明细表、删除行的Id
      return true;
    },
    rowClick({ row, column, event }) {
      //查询界面点击行事件
      this.$refs.table.$refs.table.toggleRowSelection(row); //单击行时选中当前行;
      //调用Doc_Order1GridFooter.vue文件中(订单明细)的查询
      this.$refs.gridFooter.rowClick(row);
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
          if (x.field == "ProcessCode") {
            x.placeholder = "请输入，忽略将自动生成";
          };
          if (x.field == "SubmitWorkLimit" && this.currentAction == "Add") {
            this.editFormFields.SubmitWorkLimit = [x.data[0].key];
          }
        })
      })
    }
  }
};
export default extension;
