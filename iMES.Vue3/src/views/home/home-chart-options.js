import { h, resolveComponent } from 'vue';
import http from '../../api/http';
var chart2 = {
  title: {
    text: '工序计划数Top5'
  },
  tooltip: {
    trigger: 'axis',
    axisPointer: {            // 坐标轴指示器，坐标轴触发有效
      type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
    }
  },
  legend: {
    data: ['工序计划数'],
    padding: [0, 0, 15, 0] //图例距离
  },
  grid: {
    left: '3%',
    right: '4%',
    bottom: '3%',
    top: '13%',
    containLabel: true
  },
  xAxis: [
    {
      type: 'category',
      data: []
    }
  ],
  yAxis: [
    {
      type: 'value'
    }
  ],
  series: [
    {
      name: '工序计划数',
      type: 'bar',
      showBackground: true,
      backgroundStyle: {
        color: 'rgba(80, 180, 180, 0.2)'
      },
      itemStyle: {

        normal: {
          barBorderRadius: [4, 4, 0, 0]
        }
      },
      data: []
    }
  ]
}
var chart3 = {
  title: {
    text: '不良品项分布',
    left: 'center'
  },
  tooltip: {
    trigger: 'item'
  },
  legend: {
    top: 'bottom',
    icon: "circle",   //  这个字段控制形状  类型包括 circle，rect ，roundRect，triangle，diamond，pin，arrow，none
    itemWidth: 10,  // 设置宽度
    itemHeight: 10, // 设置高度
    itemGap: 7,// 设置间距
    padding: [0, 0, 10, 0] //图例距离
  },
  series: [
    {

      name: '不良品项分布',
      type: 'pie',
      radius: '55%',
      data: [],
      emphasis: {
        itemStyle: {
          shadowBlur: 10,
          shadowOffsetX: 0,
          shadowColor: 'rgba(0, 0, 0, 0.5)'
        }
      }
    }
  ]
}
// http.get('api/Base_Process/getAppHomeProcessTop5',{},true).then((result) => {
//   let categories = result.map(item => (item.name));
//   let data = result.map(item => (item.data));
//   chart2.xAxis[0].data = categories;
//   chart2.series[0].data = data;
// });

// http.get('api/Base_DefectItem/getAppHomeDefectValue',{},true).then((item) => {
//   let dataDefect = item.map(key => ({ name: key.name, value: key.data }));
//     chart3.series[0].data = dataDefect
// });

export { chart2, chart3 }