/*****************************************************************************************
**  Author:COCO 2022
*****************************************************************************************/
//此js文件是用来自定义扩展业务代码，可以扩展一些自定义页面或者重新配置生成的代码
import FileSaver from 'file-saver';
let extension = {
  components: {
    //查询界面扩展组件
    gridHeader: '',
    gridBody: '',
    gridFooter: '',
    //新建、编辑弹出框扩展组件
    modelHeader: '',
    modelBody: '',
    modelFooter: ''
  },
  tableAction: '', //指定某张表的权限(这里填写表名,默认不用填写)
  buttons: { view: [], box: [], detail: [] }, //扩展的按钮
  methods: {
    getNowTime() {
      let dt = new Date()
      var y = dt.getFullYear()
      var mt = (dt.getMonth() + 1).toString().padStart(2,'0')
      var day = dt.getDate().toString().padStart(2,'0')
      var h = dt.getHours().toString().padStart(2,'0')
      var m = dt.getMinutes().toString().padStart(2,'0')
      return y + mt  + day + h + m 
    },
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
        this.boxOptions.height = 450;
        this.buttons.splice(4,0,{  //也可以用push或者splice方法来修改buttons数组
          name: '导出PDF', //按钮名称
          icon: 'el-icon-printer', //按钮图标vue2版本见iview文档icon，vue3版本见element ui文档icon(注意不是element puls文档)
          type: 'warning', //按钮样式vue2版本见iview文档button，vue3版本见element ui文档button
          onClick: function () {
              let  url="/api/Equip_Device/ExportPDF";
              this.http.get(url,{}, '正在导出数据....').then(content=>{
                var URL = "https://imesopen.625sc.com/PDF/Device/" + content // URL 为URL地址
                FileSaver.saveAs(URL, content);
              })
          }
        });
    },
    nodeClick(catalogIds, nodes, nodesList) {      //左边树节点点击事件
      //左边树节点的甩有子节点，用于查询数据
      this.nodesList = nodesList;
      this.catalogIds = catalogIds.join(',');
      //左侧树选中节点的所有父节点,用于新建时设置级联的默认值
      this.nodes = nodes;
      this.search();
    },
    onInited() {
      //框架初始化配置后
      //如果要配置明细表,在此方法操作
      //this.detailOptions.columns.forEach(column=>{ });
    },
    searchBefore(param) {
      //界面查询前,可以给param.wheres添加查询参数
      //返回false，则不会执行查询
      //查询前方法，如果是左边树选择了分类，直接查询分类
      if (this.catalogIds) {
        param.wheres.push({
          name: 'ParentId',
          value: this.catalogIds,
          displayType: 'selectList'
        });
      }
      return true;
    },
    searchAfter(result) {
      //查询后，result返回的查询数据,可以在显示到表格前处理表格的值
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
          if (x.field == "DeviceCode") {
            x.placeholder = "请输入，忽略将自动生成";
          }
        })
      })
    }
  }
};
export default extension;
