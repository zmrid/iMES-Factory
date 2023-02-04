<template>
  <MesBox v-model="model" :lazy="true" title="选择用户" :height="700" :width="1500" :padding="15">
    <!-- 设置查询条件 -->
    <div style="padding-bottom: 10px">
      <span style="margin-right: 10px">帐号：</span>
      <el-input placeholder="请输入帐号" style="width: 200px" v-model="UserName" />
      <span style="margin-right: 10px;margin-left: 10px">真实姓名：</span>
      <el-input placeholder="请输入真实姓名" style="width: 200px" v-model="UserTrueName" />
      <el-button type="primary" style="margin-left:20px" size="medium" @click="search"><i class="el-icon-search"></i>搜索
      </el-button>
    </div>

    <!-- imes-table配置的这些属性见MesTable组件api文件 -->
    <mes-table ref="mytable" :loadKey="true" :columns="columns" :pagination="pagination" :pagination-hide="false"
      :max-height="600" :url="url" :index="true" :single="false" :defaultLoadPage="defaultLoadPage"
      @loadBefore="loadTableBefore" @loadAfter="loadTableAfter"></mes-table>
    <!-- 设置弹出框的操作按钮 -->
    <template #footer>
      <div>
        <el-button size="mini" type="primary" @click="addRow()"><i class="el-icon-plus"></i>添加选择的数据</el-button>
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
        UserTrueName: "", //查询条件字段
        UserName: "", //查询条件字段
        modelType: "",
        url: "api/Sys_User/getSelectorDemo",//加载数据的接口
        columns: [{ field: 'UserName', title: '帐号', type: 'string', link: true, width: 120, readonly: true, require: true, align: 'left', sort: true },
        { field: 'User_Id', title: 'User_Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
        { field: 'Gender', title: '性别', type: 'int', bind: { key: 'gender', data: [] }, width: 100, align: 'left' },
        { field: 'HeadImageUrl', title: '头像', type: 'img', width: 150, require: true, align: 'left' },
        { field: 'Dept_Id', title: '部门', type: 'int', bind: { key: 'dept', data: [] }, width: 90, require: true, align: 'left' },
        { field: 'DeptName', title: '部门', type: 'string', width: 150, hidden: true, align: 'left' },
        { field: 'Role_Id', title: '角色', type: 'int', bind: { key: 'roles', data: [] }, width: 150, require: true, align: 'left' },
        { field: 'AppType', title: '登陆设备类型', type: 'int', bind: { key: 'ut', data: [] }, width: 150, hidden: true, align: 'left' },
        { field: 'UserTrueName', title: '真实姓名', type: 'string', width: 150, require: true, align: 'left' },
        { field: 'CreateDate', title: '注册时间', type: 'datetime', width: 150, readonly: true, align: 'left', sort: true },
        { field: 'PhoneNo', title: '手机号', type: 'string', width: 150, hidden: true, require: true, align: 'left' },
        { field: 'Enable', title: '是否可用', type: 'byte', bind: { key: 'enable', data: [] }, width: 90, require: true, align: 'left' },
        { field: 'ModifyDate', title: '修改时间', type: 'datetime', width: 90, readonly: true, align: 'left', sort: true }],
        pagination: {}, //分页配置，见mestable组件api
      };
    },
    methods: {
      open() {
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
        //获取回写到明细表的字段
        let _rows = rows.map((row) => {
          return {
            UserName: row.UserName,
            User_Id: row.User_Id,
            UserTrueName: row.UserTrueName,
            PhoneNo: row.PhoneNo,
          };
        });
        this.$emit('parentCall', ($parent) => {
          $parent.$refs.detail.rowData.unshift(..._rows);
        });
        //关闭当前窗口
        this.model = false;
      },
      //这里是从api查询后返回数据的方法
      loadTableAfter(row) { },
      loadTableBefore(params) {
        //查询前，设置查询条件
        if (this.UserTrueName) {
          params.wheres.push({ name: "UserTrueName", value: this.UserTrueName, displayType: "like" });
        }
        if (this.UserName) {
          params.wheres.push({ name: "UserName", value: this.UserName, displayType: "like" });
        }
        return true;
      },
    },
  };
</script>