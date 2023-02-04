/*****************************************************************************************
**  Author:COCO 2022
*****************************************************************************************/
//此js文件是用来自定义扩展业务代码，可以扩展一些自定义页面或者重新配置生成的代码
//自定义选择数据源页面
import Base_MaterialDetailModelBody from './custom_extend/Base_MaterialDetailModelBody'
let extension = {
  data() {
    return {
      dicData: []
    };
  },
  components: {
    //查询界面扩展组件
    gridHeader: '',
    gridBody: '',
    gridFooter: '',
    //新建、编辑弹出框扩展组件
    modelHeader: '',
    modelBody: Base_MaterialDetailModelBody,
    modelFooter: ''
  },
  tableAction: '', //指定某张表的权限(这里填写表名,默认不用填写)
  buttons: { view: [], box: [], detail: [] }, //扩展的按钮
  methods: {
    getDicDate() {
      var keys = ["productAttr", "unitList", "processLineList"];
      this.http.post('/api/Sys_Dictionary/GetVueDictionary', keys)
        .then((dic) => {
          this.dicData = dic
        });
    },
    getFormOption(field) {
      let option;
      this.editFormOptions.forEach(x => {
        x.forEach(item => {
          if (item.field == field) {
            option = item;
          }
        })
      })
      return option;
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
       this.boxOptions.labelWidth = 120;
      //显示序号(默认隐藏)
      this.columnIndex = true;
      this.labelWidth = 120;
      var parentProduct = this.getFormOption('ParentProduct_Id');
      var childProduct = this.getFormOption('ChildProduct_Id');
      var that = this;
      this.getDicDate();
      parentProduct.onChange = (val, item) => {
        that.http.ajax({
          url: "api/Base_Product/getProductInfoByProductID?productId=" + val,
          json: true,
          success: function (data) {
            that.setProductAreaValue(data, "Parent");
          },
          type: "get",
          async: false,
        });
      };
      childProduct.onChange = (val, item) => {
        that.http.ajax({
          url: "api/Base_Product/getProductInfoByProductID?productId=" + val,
          json: true,
          success: function (data) {
            that.setProductAreaValue(data, "Childen");
          },
          type: "get",
          async: false,
        });
      };

      //选择数据源功能
      this.editFormOptions.forEach(x => {
        x.forEach(item => {
          if (item.field == 'ParentProduct_Id') {
            //给编辑表单设置[选择数据]操作,extra具体配置见mesform组件api
            item.extra = {
              icon: "el-icon-zoom-out",
              text: "高级选择",
              style: "color:blue;font-size: 14px;cursor: pointer;",
              click: item => {
                this.$refs.modelBody.openDemo("ParentProduct_Id");
              }
            }
          }
          if (item.field == 'ChildProduct_Id') {
            //给编辑表单设置[选择数据]操作,extra具体配置见mesform组件api
            item.extra = {
              icon: "el-icon-zoom-out",
              text: "高级选择",
              style: "color:blue;font-size: 14px;cursor: pointer;",
              click: item => {
                this.$refs.modelBody.openDemo("ChildProduct_Id");
              }
            }
          }
        })
      })
      this.editFormOptions.splice(1, 0, [{ //往新数组对象中添加新的属性 属性名对应属性值
        title: "父项产品属性",
        field: "Parent",
        readonly: true,
        type: "textarea",
        minRows: 5
      }])
      this.editFormOptions.splice(3, 0, [{ //往新数组对象中添加新的属性 属性名对应属性值
        title: "子项产品属性",
        field: "Childen",
        readonly: true,
        type: "textarea",
        minRows: 5
      }])
    },
    getRow(rows, modelType) {
      if (modelType == "ParentProduct_Id") {
        //将选择的数据合并到表单中(注意框架生成的代码都是大写，后台自己写的接口是小写的)
        this.editFormFields.ParentProduct_Id = rows[0].Product_Id;
        this.setProductAreaValue(rows, "Parent")
      }
      if (modelType == "ChildProduct_Id") {
        //将选择的数据合并到表单中(注意框架生成的代码都是大写，后台自己写的接口是小写的)
        this.editFormFields.ChildProduct_Id = rows[0].Product_Id;
        this.setProductAreaValue(rows, "Childen")
      }
    },
    setProductAreaValue(rows, type) {
      var productAttributeDic = this.dicData.find(val => val.dicNo == "productAttr")
      var productAttributeResult = "";
      var unitResult = "";
      var unitDic = this.dicData.find(val => val.dicNo == "unitList")
      var processResult = "";
      var processDic = this.dicData.find(val => val.dicNo == "processLineList")
      this.$refs.modelBody.columns.forEach(item => {
        if (item.field == "ProductAttribute") {
          if (rows[0].ProductAttribute) {
            var result = productAttributeDic.data.find(val => val.key == rows[0].ProductAttribute)
            productAttributeResult = result.value;
          }
        }
        if (item.field == "Unit_Id") {
          if (rows[0].Unit_Id) {
            var result = unitDic.data.find(val => val.key == rows[0].Unit_Id)
            unitResult = result.value;
          }
        }
        if (item.field == "Process_Id") {
          if (rows[0].Process_Id) {
            var result = processDic.data.find(val => val.key == rows[0].Process_Id)
            processResult = result.value;
          }
        }
      })
      this.editFormFields[type] = "产品编码：" + rows[0].ProductCode + "\r产品名称：" + rows[0].ProductName + "\r产品规格：" + (rows[0].ProductStandard == null ? "" : rows[0].ProductStandard) + "\r产品属性：" + productAttributeResult + "\r库存单位：" + unitResult + "\r工艺路线：" + processResult;
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
      var that = this;
      if(this.currentAction == "update")
      {
        that.http.ajax({
          url: "api/Base_Product/getProductInfoByProductID?productId=" + row.ParentProduct_Id,
          json: true,
          success: function (data) {
            that.setProductAreaValue(data, "Parent");
          },
          type: "get",
          async: false,
        });
        that.http.ajax({
          url: "api/Base_Product/getProductInfoByProductID?productId=" + row.ChildProduct_Id,
          json: true,
          success: function (data) {
            that.setProductAreaValue(data, "Childen");
          },
          type: "get",
          async: false,
        });
      }
    }
  }
};
export default extension;
