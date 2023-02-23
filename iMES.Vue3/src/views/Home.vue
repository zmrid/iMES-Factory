<template>
  <div class="home-contianer">
    <div>
      <!-- <div class="order-title">
        <h2>快捷菜单</h2>
      </div>
      <div data-v-542f4644  style="padding: 15px; background: white;display: flex;
      flex-wrap: wrap;
      width: 100%;">
        <div v-for="item in topMenu" :key="item.MenuName" class="ivu-col ivu-col-span-6"
          style="padding-left: 8px;padding-right: 8px;padding-top: 8px;  width:16.6%;"  @click="openUrl(item)">
          <div data-v-542f4644 class="ivu-card" :style="{ background: item.Color }">
            <div class="icon-left">
              <i class="el-icon-wallet" />
            </div>
            <div class="ivu-card-body">
              <div class="demo-color-desc">{{ item.MenuName }}</div>
            </div>
          </div>
        </div>
      </div> -->
      <div class="order-title">
        <h2>数量统计</h2>
      </div>
      <div data-v-542f4644 class="ivu-row" style="padding: 15px; background: white">
        <div v-for="item in topNumber" :key="item.ItemName" class="ivu-col ivu-col-span-6"
          style="padding-left: 8px; padding-right: 8px">
          <div data-v-542f4644 class="ivu-card" :style="{ background: item.Background }">
            <div class="icon-left">
              <i class="el-icon-wallet" />
            </div>
            <div class="ivu-card-body">
              <div class="demo-color-name">{{ item.ItemName }}</div>
              <div class="demo-color-desc">{{ item.Qty }}</div>
            </div>
          </div>
        </div>
      </div>
      <div class="order-title">
        <h2>工序信息</h2>
      </div>
      <div class="order-range">
        <div class="order-item" v-for="(item, index) in totalRange" :key="index">
          <div class="total">
            <div class="number">
              {{item.ProcessName}}
            </div>
          </div>
          <!-- <div class="name">{{item.ProcessName }}</div> -->
          <div class="date">
            计划数:{{item.PlanQty}}
          </div>
          <div class="date">
            良品数:{{item.GoodQty}}
          </div>
          <div class="date">
            不良品数:{{item.NoGoodQty}}
          </div>
        </div>
      </div>
    </div>
  </div>
  <div class="home-contianer">

    <div class="h-chart">
      <div id="h-chart2"></div>
      <div id="h-chart3"></div>
    </div>
  </div>
  <div class="home-contianer">
    <div class="h-chart">
      <!-- <div class="h-left-grid">
        <div @click="open(item)" class="item" v-for="(item, index) in grid" :key="index">
          <div class="icon-text" style="margin-bottom:-15px">
            <span class="name" style="margin-top:20px;">{{ item.name }}</span>
          </div>
          <i :class="item.icon" ></i>
          <div class="desc">{{ item.desc }}</div>
        </div>
      </div> -->
      <div class="h-top-center" style="width: 23%">
        <div class="n-item">
          <div @click="openRouterUrl(item)" class="item" :class="'item' + (index + 1)" v-for="(item, index) in center"
            :key="index">
            <i style="font-size: 30px; padding-bottom: 10px" :class="item.icon" :size="20"></i>
            <br />
            {{ item.title }}
          </div>
        </div>
      </div>
      <!--联系信息-->
      <div class="h-top-center" style="width: 55%;">
        <div class="n-item">
          <div class="item" :class="'item1'" style="height: 100%;">
            联系作者
            <br />
            <img style="width: 200px; height: 199px;margin-top: 20px;" src="@/assets/imgs/wechat.jpg">
          </div>
          <div class="item" :class="'item2'" style="height: 100%;">
            交流讨论群
            <br />
            <img style="width: 200px; height: 238px;margin-top: 5px;" src="@/assets/imgs/qq.png">
          </div>
          <div class="item" :class="'item3'" style="height: 100%;">
            微信小程序
            <br />
            <img style="width: 200px; height: 238px;margin-top: 5px;" src="@/assets/imgs/miniapp.png">
          </div>
        </div>
      </div>
      <div class="h-top-right task-table" style="width: 22%">
        <h3 class="h3">#【iMES工厂管家】版本变更说明</h3>
        <table border="0" cellspacing="0" cellpadding="0">
          <tr v-for="(row, index) in list" :key="index" @click="open(row)">
            <td>{{ index + 1 }}</td>
            <td>{{ row.title }}</td>
          </tr>
        </table>
      </div>
    </div>
  </div>
</template>
<script>
  // import * as echarts from "echarts";
  import "echarts/lib/chart/bar";
  import "echarts/lib/chart/line";

  import "echarts/lib/chart/pie";
  import "echarts/lib/component/legend";
  import "echarts/lib/component/tooltip";
  import "echarts/lib/component/title";
  import "echarts/lib/component/grid";
  let echarts = require("echarts/lib/echarts");
  import { chart2, chart3 } from "./home/home-chart-options";
  import { ref, onMounted, onUnmounted } from "vue";
  var $chart2;
  export default {
    components: {},
    data() {
      return {
        beginDate: "",
        endDate: "",
        topMenu: [],    //快捷菜单
        topNumber: [],  //数量统计
        totalRange: [],
        titleLeft: "",
        dateNow: "",
        center: [
          {
            title: "员工绩效",
            icon: "el-icon-s-data",
            url: "/View_EmployeePerformance",
          },
          {
            title: "工资报表",
            icon: "el-icon-s-data",
            url: "/View_SalaryReport",
          },
          {
            title: "不良品项分布",
            icon: "el-icon-s-data",
            url: "/View_DefectItemDistribute",
          },

          {
            title: "不良品项汇总",
            icon: "el-icon-s-data",
            url: "/View_DefectItemSummary"
          },

          {
            title: "生产报表",
            icon: "el-icon-s-data",
            url: "/View_ProductionReport",
          },
          {
            title: "产量统计",
            icon: "el-icon-s-data",
            url: "/View_OutputStatistics",
          },
        ],
        contectcenter: [
          {
            title: "员工绩效",
            icon: "el-icon-s-data",
            url: "/View_EmployeePerformance",
          },
          {
            title: "工资报表",
            icon: "el-icon-s-data",
            url: "/View_SalaryReport",
          },
          {
            title: "不良品项分布",
            icon: "el-icon-s-data",
            url: "/View_DefectItemDistribute",
          }
        ],
        n: 90,
        value1: "1",
        list: [], //版本发布记录
        grid: [
          {
            name: "智能车间生产管控看板",
            desc: "车间全方位生产信息展示。",
            url: "http://board.625sc.com:9095/index.html#/aj/bP3fTAG8",
            icon: "el-icon-s-marketing",
          },
          {
            name: "工单执行进度看板",
            desc: "工单执行全周期信息展示。",
            url: "http://board.625sc.com:9095/index.html#/aj/2kEYF9UY",
            icon: "el-icon-s-marketing",
          },
          {
            name: "紧锣密鼓的开发中",
            desc: "待添加",
            url: "#",
            icon: "el-icon-s-marketing",
          }
        ],
      };
    },
    methods: {
      openUrl(item) {
        this.$tabs.open({
          text: item.MenuName,
          path: item.MenuUrl,
          query: {}
        });
      },
      getDate() {
        var date = new Date();
        var year = date.getFullYear();
        var month = date.getMonth() + 1;
        var day = date.getDate();
        var hour = date.getHours();
        var minutes = date.getMinutes();
        var second = date.getSeconds();
        this.beginDate =
          year +
          "-" +
          (month < 10 ? "0" + month : month) +
          "-" +
          (day < 10 ? "0" + day : day);
        this.endDate = this.beginDate;
        this.dateNow = this.beginDate;
      },
      getTopNumber() {
        this.topNumber = [{ "ItemName": "装配工单", "Background": "#f2b458", "ItemCode": "AssembleWorkOrder", "Qty": "2856" }, { "ItemName": "生产计划", "Background": "rgb(45, 183, 245)", "ItemCode": "ProductPlan", "Qty": "108223" }, { "ItemName": "销售订单", "Background": "rgb(25, 190, 107)", "ItemCode": "SalesOrder", "Qty": "1239203" }, { "ItemName": "不良品总数", "Background": "rgb(237, 64, 20)", "ItemCode": "DefectItem", "Qty": "181" }, { "ItemName": "良品率", "Background": "rgb(84, 110, 122)", "ItemCode": "YieldRate", "Qty": "100%" }, { "ItemName": "销售订单占比", "Background": "rgb(45, 183, 245)", "ItemCode": "SalesRate", "Qty": "40%" }];
      },
      getVersionInfo() {
        let urlWo = 'api/Sys_VersionInfo/getVersionInfo';
        //给工序名称重新绑定数据源
        this.http.get(urlWo, {}, true).then((result) => {
          this.list = result;
        });
      },
      getDesktopMenu() {
        let urlWo = 'api/Base_DesktopMenu/getDesktopMenu';
        //给工序名称重新绑定数据源
        this.http.get(urlWo, {}, true).then((result) => {
          this.topMenu = result;
          console.log("9999",result);
        });
      },
      getTopProcessNumber() {
        this.totalRange = [{ "ProcessName": "成品入库", "PlanQty": "1904", "GoodQty": "1190", "NoGoodQty": "27" }, { "ProcessName": "打磨", "PlanQty": "1460", "GoodQty": "233", "NoGoodQty": "4" }, { "ProcessName": "焊接", "PlanQty": "647", "GoodQty": "880", "NoGoodQty": "19" }, { "ProcessName": "激光切割", "PlanQty": "1200", "GoodQty": "1199", "NoGoodQty": "1" }, { "ProcessName": "破洞", "PlanQty": "2225", "GoodQty": "945", "NoGoodQty": "15" }, { "ProcessName": "清洗消毒", "PlanQty": "1706", "GoodQty": "1475", "NoGoodQty": "0" }, { "ProcessName": "涮涂料", "PlanQty": "1410", "GoodQty": "510", "NoGoodQty": "12" }];

      },
      openRouterUrl(item) {
        this.$tabs.open({
          text: item.title,
          path: item.url,
          query: {}
        });
      }
    },
    created() {
      this.getDate();
      //this.getDesktopMenu();
      this.getTopNumber();
      this.getTopProcessNumber();
      this.getVersionInfo();
      this.http.get('api/Base_Process/getAppHomeProcessTop5', {}, true).then((result) => {
        let categories = result.map(item => (item.name));
        let data = result.map(item => (item.data));
        chart2.xAxis[0].data = categories;
        chart2.series[0].data = data;
        $chart2 = echarts.init(document.getElementById("h-chart2"));
        $chart2.setOption(chart2);
      });

      this.http.get('api/Base_DefectItem/getAppHomeDefectValue', {}, true).then((item) => {
        let dataDefect = item.map(key => ({ name: key.name, value: key.data }));
        chart3.series[0].data = dataDefect
        $chart3 = echarts.init(document.getElementById("h-chart3"));
        $chart3.setOption(chart3);
      });
    },
    setup() {
      let open = (item) => {
        window.open(item.url, "_blank");
      };
      let interval;
      onMounted(() => {
      });
      onUnmounted(() => {
        interval && clearInterval(interval);
        if ($chart) {
          $chart.dispose();
          $chart2.dispose();
          $chart3.dispose();
        }
      });
      return { open };
    },
    destroyed() {
      $chart2 = null;
    },
  };
  var $chart, $chart2, $chart3;
// window.addEventListener("resize", function () {
//   $chart2.setOption(chart2);
// });

</script>
<style lang="less" scoped>
  .home-contianer {
    padding: 6px;
    background: #eee;
    width: 100%;
    height: 100%;
    // max-width: 800px;
    // position: absolute;
    top: 0;
    right: 0;
    left: 0;
    margin: 0 auto;

    .h-top {
      display: flex;

      .h-top-left {
        height: 100%;
        width: 300px;
        background: white;
      }

      height: 300px;
    }

    .h-top>div {
      border: 1px solid #e8e7e7;
      border-radius: 5px;
      // margin: 6px;
    }

    .h-top-center {
      height: 100%;
      background: white;
      margin: 0 6px;
      display: flex;
      flex-direction: column;

      .item1 .num {
        padding-top: 28px;
      }

      .item2 .num {
        padding-bottom: 20px;
      }

      .n-item {
        width: 100%;
        height: 100%;
        text-align: center;
        cursor: pointer;

        // display: flex;
        .item {
          border-right: 1px solid #e5e5e5;
          width: 33.3333333%;
          float: left;
          height: 50%;
          border-bottom: 1px solid #e5e5e5;
          padding: 47px 0;
          font-size: 13px;
        }

        .item:hover {
          background: #f9f9f9;
          cursor: pointer;
        }

        .item:last-child {
          border-right: 0;
        }

        .item3,
        .item6 {
          border-right: 0;
        }

        .num {
          word-break: break-all;
          color: #282727;
          font-size: 30px;
          transition: transform 0.8s;
        }

        .num:hover {
          color: #55ce80;
          transform: scale(1.2);
        }

        .text {
          font-size: 13px;
          color: #777;
        }
      }
    }

    .h-top-right {
      // flex: 1;

      width: 20%;
      height: 100%;
      background: white;
    }

    .h3 {
      padding: 7px 15px;
      font-weight: 500;
      background: #fff;
      border-bottom: 1px dotted #d4d4d4;
    }
  }

  .task-table {
    table {
      width: 100%;

      .thead {
        font-weight: bold;
      }

      tr {
        cursor: pointer;

        td {
          border-bottom: 1px solid #f3f3f3;
          padding: 9px 8px;
          font-size: 12px;
        }
      }

      tr:hover {
        background: #eee;
      }
    }
  }

  .h-chart {
    height: 340px;
    margin: 6px 0px;
    display: flex;

    .h-left-grid {
      width: 16%;
      height: 100%;
      background: white;
      display: inline-block;

      .name {
        margin-left: 40px;
      }

      .item:hover {
        background: #f9f9f9;
        cursor: pointer;
      }

      .item {
        padding: 30px 30px;
        float: left;
        width: 99%;
        height: 33.33333%;
        border-bottom: 1px solid #eee;
        border-right: 1px solid #eee;

        i {
          font-size: 30px;
        }

        .desc {
          font-size: 12px;
          color: #2b2525;
          padding: 0px 0 0 40px;
          line-height: 1.5;
          margin-top: -10px;
        }
      }
    }
  }

  #h-chart2 {
    border-radius: 3px;
    background: white;
    padding-top: 10px;
    height: 100%;
    width: 0;
    flex: 1;
    margin: 0 7px;
  }

  #h-chart3 {
    border-radius: 3px;
    padding: 10px 10px 0 10px;
    background: white;
    // padding-top: 10px;
    height: 100%;

    width: 600px;
  }

  .ivu-card-body {
    text-align: center;
    padding: 20px 5px;
    /* padding-left: 80px; */
    font-size: 16px;
  }

  .demo-color-name {
    color: #fff;
    font-size: 14px;
  }

  .demo-color-desc {
    color: white;
    /* opacity: 0.7; */
    font-size: 20px;
    margin-top: 2px;
  }

  .ivu-card {
    box-shadow: 0 3px 13px rgba(117, 114, 114, 0.47);
    display: flex;
    position: relative;
    padding-top: 10px;
    border-radius: 5px;
  }

  .ivu-card .icon-left {
    width: 85px;
  }

  .ivu-card .ivu-card-body {
    flex: 1;
  }

  .ivu-card .icon-left {
    text-align: center;
    border-right: 1px solid;
    padding: 8px 0px;
    height: 100%;

    font-size: 50px;
    color: white;
  }

  .ivu-row {
    border-bottom: 2px dotted #eee;
    padding: 15px;
    margin-bottom: 15px;
    display: flex;
  }

  .ivu-row>div {
    flex: 1;
  }

  .h5-desc {
    padding-top: 10px;
  }
</style>

<style lang="less" scoped>
  .jn-day-total {
    display: flex;
    padding: 15px;
    background: white;

    .date-text {
      line-height: 36px;
      padding: 0 15px;
    }

    .date {
      margin-right: 20px;
    }

    .btn {
      margin-left: 10px;
    }
  }

  .order-title {
    h2 {
      padding: 7px 15px;
      font-weight: 500;
      background: white;
      border-bottom: 1px dotted #d4d4d4;
    }
  }

  .order-range {
    padding: 0 15px;
    background: white;
    background: white;
    display: flex;
    // flex-direction: row-reverse;
  }

  .order-range .order-item {
    box-shadow: 0 3px 13px rgba(117, 114, 114, 0.47);
    flex: 1;
    border-radius: 6px;
    font-size: 14px;
    text-align: center;
    border: 1px solid #e6e6e6;
    margin: 7px;
  }

  .order-range .total {
    color: white;
    font-size: 30px;
    font-weight: bold;
    line-height: 60px;
    background: #55ce80;
    font-family: "Helvetica Neue", Helvetica, "PingFang SC", "Hiragino Sans GB",
      "Microsoft YaHei", "微软雅黑", Arial, sans-serif;
  }

  .order-range .number {
    transition: transform 0.8s;
  }

  .order-range .number:hover {
    cursor: pointer;
    transform: scale(1.2);
  }

  .order-range .name {
    font-size: 20px;
    padding: 10px;
  }

  .order-range .date {
    padding: 1px 0 5px 0;
    color: #282727;
    font-size: 15px;
  }
</style>


<style lang="less" scoped>
  .numbers {
    margin-bottom: 15px;
    border-radius: 5px;
    border: 1px solid #eaeaea;
    background: white;
    display: flex;

    padding: 20px 0px;

    .item {
      flex: 1;
      text-align: center;
      border-right: 1px solid #e5e5e5;
    }

    .item>div:first-child {
      word-break: break-all;
      color: #282727;
      font-size: 30px;
      // padding-bottom: 12px;
    }

    .item>div:last-child {
      font-size: 13px;
      color: #777;
    }

    .item:last-child {
      border-right: none;
    }

    .number {
      cursor: pointer;
      transition: transform 0.8s;
    }

    .number:hover {
      transform: scale(1.2);
      color: #03c10b !important;
    }
  }
</style>