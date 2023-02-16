<template>
    
  <div class="home-contianer">
    <div>
    <div class="order-title">
      <h2>看板列表</h2>
    </div>
    <div
      data-v-542f4644
      class="ivu-row"
      style="padding: 15px; background: white"
    >
      <div
        v-for="item in topColor"
        :key="item.ItemName"
        class="ivu-col ivu-col-span-6"
        style="padding-left: 20px; padding-right: 20px;padding-top: 20px;padding-bottom: 20px;"
        @click="openUrl(item)"
      >
        <div
          data-v-542f4644
          class="ivu-card"
          :style="{ background: item.Background }"
        >
          <div class="icon-left">
            <i class="el-icon-s-data" />
          </div>
          <div class="ivu-card-body">
                <div class="demo-color-desc">{{ item.ItemName }}</div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </template>
  <script>
  import { ref, onMounted, onUnmounted } from "vue";
  var $chart2;
  export default {
    components: {},
    data() {
      return {
        beginDate: "",
        endDate: "",
        topColor: [
            {
              "ItemName": "车间生产管控",
              "Background": "#f2b458",
              "URL": "http://116.204.79.68:9095/index.html#/aj/4dZChFrB"
            },
            {
              "ItemName": "工单执行进度",
              "Background": "rgb(45, 183, 245)",
              "URL": "http://116.204.79.68:9095/index.html#/aj/0WSQnwFm"
            },
            {
                "ItemName": "待添加",
                "Background": "rgb(25, 190, 107)",
                "URL": "",
            },
            {
                "ItemName": "待添加",
                "Background": "rgb(237, 64, 20)",
                "URL": "",
            },
            {
                "ItemName": "待添加",
                "Background": "rgb(84, 110, 122)",
                "URL": "",
            },
            {
                "ItemName": "待添加",
                "Background": "rgb(45, 183, 245)",
                "URL": "",
            }
        ],
        totalRange: [],
        titleLeft: "",
        dateNow: "",
       
        n: 90,
        value1: "1",
      };
    },
    methods: {
      openUrl(item){
        if(item.URL)
        {
          window.open(item.URL, "_blank");
        }
      }
    },
    created() {
    },
    setup() {
      let open = (item) => {
        window.open(item.url, "_blank");
      };
      let interval;
      onMounted(() => {
      });
      return { open };
    },
  };
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
    .h-top > div {
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
          margin-top:-10px;
        }
      }
    }
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
    margin-bottom: 1px;
    display: flex;
  }
  
  .ivu-row > div {
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
  
  