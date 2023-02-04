 // 当前日期
 let now = new Date();
 // 今天本周的第几天
 let nowDayOfWeek = now.getDay();
 // 当前日
 let nowDay = now.getDate();
 // 当前月
 let nowMonth = now.getMonth();
 // 当前年
 let nowYear = now.getFullYear();
 nowYear += (nowYear < 2000) ? 1900 : 0;
 // 上月日期
 let lastMonthDate = new Date();
 lastMonthDate.setDate(1);
 lastMonthDate.setMonth(lastMonthDate.getMonth() - 1);
 let lastMonth = lastMonthDate.getMonth();
 // 日期格式化,时间戳 时分秒 hh:mm:ss
 export function formatTimeStamp(date, fmt = 'yyyy-MM-dd hh:mm:ss') {
   if(!date) {
     return '-';
   }
   date = new Date(date);
   if (/(y+)/.test(fmt)) {
     fmt = fmt.replace(RegExp.$1, (date.getFullYear() + '').substr(4 - RegExp.$1.length));
   }
   let o = {
     'M+': date.getMonth() + 1,
     'd+': date.getDate(),
     'h+': date.getHours(),
     'm+': date.getMinutes(),
     's+': date.getSeconds()
   };
   for (let k in o) {
     if (new RegExp(`(${k})`).test(fmt)) {
       let str = o[k] + '';
       fmt = fmt.replace(RegExp.$1, (RegExp.$1.length === 1) ? str : padLeftZero(str));
     }
   }
   return fmt;
 }
 function padLeftZero(str) {
   return ('00' + str).substr(str.length);
 }
 // 获取当前时间
 export function getNowDate() {
   return formatTimeStamp(new Date());
 }
 // 获得某月的天数
 export function getMonthDays(myMonth) {
   let monthStartDate = new Date(nowYear, myMonth, 1);
   let monthEndDate = new Date(nowYear, myMonth + 1, 1);
   let days = (monthEndDate - monthStartDate) / (1000 * 60 * 60 * 24);
   return days;
 }
 // 获得本季度的开始月份
 export function getQuarterStartMonth() {
   let quarterStartMonth = 0;
   if (nowMonth < 3) {
     quarterStartMonth = 0;
   }
   if (2 < nowMonth && nowMonth < 6) {
     quarterStartMonth = 3;
   }
   if (5 < nowMonth && nowMonth < 9) {
     quarterStartMonth = 6;
   }
   if (nowMonth > 8) {
     quarterStartMonth = 9;
   }
   return quarterStartMonth;
 }
 // 获得本周的开始日期
 export function getWeekStartDate() {
   let weekStartDate = new Date(nowYear, nowMonth, nowDay - nowDayOfWeek);
   return formatTimeStamp(weekStartDate);
 }
 // 获得本周的结束日期
 export function getWeekEndDate() {
   let weekEndDate = new Date(nowYear, nowMonth, nowDay + (6 - nowDayOfWeek));
   return formatTimeStamp(weekEndDate);
 }
 // 获得上周的开始日期
 export function getLastWeekStartDate() {
   let weekStartDate = new Date(nowYear, nowMonth, nowDay - nowDayOfWeek - 6);
   return formatTimeStamp(weekStartDate);
 }
 // 获得上周的结束日期
 export function getLastWeekEndDate() {
   let weekEndDate = new Date(nowYear, nowMonth, nowDay - nowDayOfWeek);
   return formatTimeStamp(weekEndDate);
 }
 // 获得本月的开始日期
 export function getMonthStartDate() {
   let monthStartDate = new Date(nowYear, nowMonth, 1);
   return formatTimeStamp(monthStartDate);
 }
 // 获得本月的结束日期
 export function getMonthEndDate() {
   let monthEndDate = new Date(nowYear, nowMonth, getMonthDays(nowMonth));
   return formatTimeStamp(monthEndDate);
 }
 // 获得上月开始时间
 export function getLastMonthStartDate() {
   let lastMonthStartDate = new Date(nowYear, lastMonth, 1);
   return formatTimeStamp(lastMonthStartDate);
 }
 // 获得上月结束时间
 export function getLastMonthEndDate() {
   let lastMonthEndDate = new Date(nowYear, lastMonth, getMonthDays(lastMonth));
   return formatTimeStamp(lastMonthEndDate);
 }
 // 获得本季度的开始日期
 export function getQuarterStartDate() {
   let quarterStartDate = new Date(nowYear, getQuarterStartMonth(), 1);
   return formatTimeStamp(quarterStartDate);
 }
 // 或的本季度的结束日期
 export function getQuarterEndDate() {
   let quarterEndMonth = getQuarterStartMonth() + 2;
   let quarterStartDate = new Date(nowYear, quarterEndMonth, getMonthDays(quarterEndMonth));
   return formatTimeStamp(quarterStartDate);
 }
 // 当时时间减去天数
 export function getNowDateSubtraction(day) {
   let nowDateSubtraction = new Date().setDate((new Date().getDate() - day));
   return formatTimeStamp(nowDateSubtraction);
 }