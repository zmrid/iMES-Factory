import { ConsoleLogger } from "@microsoft/signalr/dist/esm/Utils";
import { stringifyStyle } from "@vue/shared";
import { defineAsyncComponent } from "vue";
import FileSaver from 'file-saver';
let extension = {
    components: { //动态扩充组件或组件路径
        //表单header、content、footer对应位置扩充的组件
        gridHeader: defineAsyncComponent(() =>
            import("./Sys_User/Sys_UserGridHeader.vue")),
        gridBody: '',
        gridFooter: '',
        //弹出框(修改、编辑、查看)header、content、footer对应位置扩充的组件
        modelHeader: '',
        modelBody: '',
        modelFooter: ''
    },
    text: "只能看到当前角色下的所有帐号",
    buttons: [], //扩展的按钮
    methods: { //事件扩展
        getNowTime() {
            let dt = new Date()
            var y = dt.getFullYear()
            var mt = (dt.getMonth() + 1).toString().padStart(2,'0')
            var day = dt.getDate().toString().padStart(2,'0')
            var h = dt.getHours().toString().padStart(2,'0')
            var m = dt.getMinutes().toString().padStart(2,'0')
            return y + mt  + day + h + m 
        },
        onInit() {
             //显示序号(默认隐藏)
            this.columnIndex = true;
            this.buttons.splice(5,0,{  //也可以用push或者splice方法来修改buttons数组
                name: '导出PDF', //按钮名称
                icon: 'el-icon-printer', //按钮图标vue2版本见iview文档icon，vue3版本见element ui文档icon(注意不是element puls文档)
                type: 'warning', //按钮样式vue2版本见iview文档button，vue3版本见element ui文档button
                onClick: function () {
                    let  url="/api/User/ExportPDF";
                    this.http.get(url,{}, '正在导出数据....').then(content=>{
                        //window.location.href = "https://wechat.625sc.com:8891/PDF/User/" + content
                        var URL = "https://imesopen.625sc.com/PDF/User/" + content // URL 为URL地址
                        FileSaver.saveAs(URL, content);
                    })
                }
              });
            this.boxOptions.height = 530;
            this.columns.push({
                title: '操作',
                hidden: false,
                align: "center",
                fixed: 'right',
                width: 120,
                render: (h, { row, column, index }) => {
                    return h(
                        "div", { style: { 'font-size': '13px', 'cursor': 'pointer', 'color': '#409eff' } }, [
                        h(
                            "a", {
                            style: { 'margin-right': '15px' },
                            onClick: (e) => {
                                e.stopPropagation()
                                this.$refs.gridHeader.open(row);
                            }
                        }, "修改密码"
                        ),
                        h(
                            "a", {
                            style: {},
                            onClick: (e) => {
                                e.stopPropagation()
                                this.edit(row);
                            }
                        },
                            "编辑"
                        ),
                    ])
                }
            })
        },
        searchAfter(result) { //查询ViewGird表数据后param查询参数,result回返查询的结果
            return true;
        },
        nodeClick(catalogIds, nodes, nodesList) {      //左边树节点点击事件
            //左边树节点的甩有子节点，用于查询数据
            this.nodesList = nodesList;
            this.catalogIds = catalogIds.join(',');
            //左侧树选中节点的所有父节点,用于新建时设置级联的默认值
            this.nodes = nodes;
            this.search();
          },
        onInited() { },
        addAfter(result) { //用户新建后，显示随机生成的密码
            if (!result.status) {
                return true;
            }
            //显示新建用户的密码
            //2020.08.28优化新建成后提示方式
            this.$confirm(result.message, '新建用户成功', {
                confirmButtonText: '确定',
                type: 'success',
                center: true
            }).then(() => { })

            this.boxModel = false;
            this.refresh();
            return false;
        },
        modelOpenAfter() {
            //点击弹出框后，如果是编辑状态，禁止编辑用户名，如果新建状态，将用户名字段设置为可编辑
            let isEDIT = this.currentAction == this.const.EDIT;
            this.editFormOptions.forEach(item => {
                item.forEach(x => {
                    if (x.field == "UserName") {
                        x.disabled = isEDIT;
                    }
                })
                //不是新建，性别默认值设置为男
                if (!isEDIT) {
                    this.editFormFields.Gender = "0";
                }
            })
        },
        addBefore(formData) { //弹出框新建或编辑功能点保存时可以将从表1，从表2的数据提到后台
            return true;
        },
        updateBefore(formData) { //编辑时功能点保存时可以将从表1，从表2的数据提到后台
            return true;
        },
        searchBefore(param) {
            //界面查询前,可以给param.wheres添加查询参数
            //返回false，则不会执行查询
            //查询前方法，如果是左边树选择了商品分类，直接查询商品分类
            if (this.catalogIds) {
              param.wheres.push({
                name: 'Dept_Id',
                value: this.catalogIds
              });
            }
            return true;
          },
    }
};
export default extension;