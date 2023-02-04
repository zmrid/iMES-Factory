<template>
      <div class="app-container">
            <el-container>
                  <el-aside width="150px">
                        <el-radio-group v-model="selectedType" class="x-fillitem el-group-list" @change="onSelected">
                              <el-radio-button v-for="item in teamList" :key="item.TeamId" :label="item.TeamId">
                                    {{item.TeamName}}</el-radio-button>
                        </el-radio-group>
                  </el-aside>
                  <el-main>
                        <el-calendar v-loading="loading" v-model="date">
                              <template #dateCell="{data}">
                                    <div>
                                          <el-row>
                                                <el-col :span="16">
                                                      <div class="solar">
                                                            {{ data.day.split('-').slice(1).join('-') }}
                                                      </div>
                                                </el-col>
                                                <el-col :span="8">
                                                      <el-tag v-if="holidayList.indexOf(data.day) ==-1" effect="dark">班
                                                      </el-tag>
                                                      <el-tag v-else effect="dark" type="success">休</el-tag>
                                                </el-col>
                                          </el-row>
                                          <el-row>
                                                <el-col :span="24">
                                                      <div class="lunar" :class="{ festival : isFestival(date, data) }">
                                                            {{ solarDate2lunar(data.day)
                                                            }}
                                                      </div>
                                                </el-col>
                                          </el-row>
                                          <el-row v-for="calendarDay in calendarDayList " :key="calendarDay.theDay">
                                                <el-col :span="24"
                                                      v-if="calendarDay.theDay == data.day && holidayList.indexOf(data.day) ==-1">
                                                      <div v-for="teamShift in calendarDay.list" class="grid-content">
                                                            <el-button size="small" type="success">{{teamShift.ShiftName
                                                                  }}-{{ teamShift.TeamName }}
                                                            </el-button>
                                                      </div>
                                                </el-col>
                                          </el-row>
                                    </div>
                              </template>
                        </el-calendar>
                  </el-main>
            </el-container>
      </div>
</template>

<script>
      import calendar from '@/uitils/calendar';
      export default {
            name: 'TeamView',
            dicts: ['mes_calendar_type'],
            data() {
                  return {
                        // 遮罩层
                        loading: false,
                        date: new Date(),
                        teamList: [], //所有的班组
                        holidayList: [],//假日
                        workdayList: [],//工作日
                        selectedType: null,
                        calendarDayList: [
                        ],
                        teamShiftQueryParams: {
                              queryType: 'TEAM'
                        },
                        queryParams: {
                              theDay: null,
                              holidayType: null,
                              startTime: null,
                              endTime: null,
                        },
                  }
            },
            watch: {
                  date: {
                        handler(newVal, oldVal) {
                              console.log(newVal.getFullYear() + '-' + (newVal.getMonth() + 1) + '-' + newVal.getDate());
                              this.teamShiftQueryParams.date = newVal.getFullYear() + '-' + (newVal.getMonth() + 1) + '-' + newVal.getDate();
                              this.onSelected(this.teamShiftQueryParams.teamId);
                        }
                  }
            },
            created() {
                  this.getList();
                  this.getTeams();
            },
            methods: {
                  // 计算续住的总日期列表
                  getAll(begin, end) {
                        let arr1 = begin.split("-");
                        let arr2 = end.split("-");
                        let arr1_ = new Date();
                        let arrTime = [];
                        arr1_.setUTCFullYear(arr1[0], arr1[1] - 1, arr1[2]);
                        let arr2_ = new Date();
                        arr2_.setUTCFullYear(arr2[0], arr2[1] - 1, arr2[2]);
                        let unixDb = arr1_.getTime();
                        let unixDe = arr2_.getTime();
                        for (let k = unixDb; k <= unixDe;) {
                              arrTime.push(this.datetimeparse(k, 'YYYY-MM-DD'));
                              k = k + 24 * 60 * 60 * 1000;
                        }
                        return arrTime;
                  },

                  // 时间格式处理
                  datetimeparse(timestamp, format, prefix) {
                        if (typeof timestamp == 'string') {
                              timestamp = Number(timestamp)
                        };
                        //转换时区
                        let currentZoneTime = new Date(timestamp);
                        let currentTimestamp = currentZoneTime.getTime();
                        let offsetZone = currentZoneTime.getTimezoneOffset() / 60;//如果offsetZone>0是西区，西区晚
                        let offset = null;
                        //客户端时间与服务器时间保持一致，固定北京时间东八区。
                        offset = offsetZone + 8;
                        currentTimestamp = currentTimestamp + offset * 3600 * 1000

                        let newtimestamp = null;
                        if (currentTimestamp) {
                              if (currentTimestamp.toString().length === 13) {
                                    newtimestamp = currentTimestamp.toString()
                              } else if (currentTimestamp.toString().length === 10) {
                                    newtimestamp = currentTimestamp + '000'
                              } else {
                                    newtimestamp = null
                              }
                        } else {
                              newtimestamp = null
                        }
                        ;
                        let dateobj = newtimestamp ? new Date(parseInt(newtimestamp)) : new Date()
                        let YYYY = dateobj.getFullYear()
                        let MM = dateobj.getMonth() > 8 ? dateobj.getMonth() + 1 : '0' + (dateobj.getMonth() + 1)
                        let DD = dateobj.getDate() > 9 ? dateobj.getDate() : '0' + dateobj.getDate()
                        let HH = dateobj.getHours() > 9 ? dateobj.getHours() : '0' + dateobj.getHours()
                        let mm = dateobj.getMinutes() > 9 ? dateobj.getMinutes() : '0' + dateobj.getMinutes()
                        let ss = dateobj.getSeconds() > 9 ? dateobj.getSeconds() : '0' + dateobj.getSeconds()
                        let output = '';
                        let separator = '/'
                        if (format) {
                              separator = format.match(/-/) ? '-' : '/'
                              output += format.match(/yy/i) ? YYYY : ''
                              output += format.match(/MM/) ? (output.length ? separator : '') + MM : ''
                              output += format.match(/dd/i) ? (output.length ? separator : '') + DD : ''
                              output += format.match(/hh/i) ? (output.length ? ' ' : '') + HH : ''
                              output += format.match(/mm/) ? (output.length ? ':' : '') + mm : ''
                              output += format.match(/ss/i) ? (output.length ? ':' : '') + ss : ''
                        } else {
                              output += YYYY + separator + MM + separator + DD
                        }
                        output = prefix ? (prefix + output) : output

                        return newtimestamp ? output : ''
                  },
                  getTeams() {
                        this.loading = true;
                        var param = {
                              order: "desc",
                              page: 1,
                              rows: 1000,
                              sort: "CreateDate",
                              wheres: "[{}]"
                        };
                        this.http.post('/api/Cal_Team/getPageData', param, true).then((result) => {
                              this.teamList = result.rows;
                              this.loading = false;
                        })
                  },
                  /** 查询节假日设置列表 */
                  getList() {
                        //this.loading = true;
                        this.holidayList = [];
                        this.workdayList = [];
                        let that = this;
                  },
                  //点击班组类型
                  onSelected(TeamId) {
                        this.loading = true;
                        this.teamShiftQueryParams.teamId = TeamId;
                        var new_year = this.date.getFullYear() // 取当前的年份
                        var month = this.date.getMonth()
                        var new_month = month + 1 // 取当前的月份
                        if (month > 12) {
                              new_month -= 12 // 月份减
                              new_year++ // 年份增
                        }
                        var firstDay = new Date(new_year, new_month, 1) // 取当年当月中的第一天
                        var lastDay = new Date(firstDay.getTime() - 1000 * 60 * 60 * 24).getDate() // 获取当月最后一天日期
                        if (firstDay.getMonth() < 10) {
                              var mon = "0" + firstDay.getMonth()
                        } else {
                              var mon = firstDay.getMonth()
                        }
                        var startDate = firstDay.getFullYear() + '-' + mon + '-' + "0" + firstDay.getDate();
                        var endDate = firstDay.getFullYear() + '-' + mon + '-' + lastDay;
                        var allDataList = this.getAll(startDate, endDate);
                        var param = {
                              order: "desc",
                              page: 1,
                              rows: 10000,
                              sort: "CreateDate",
                              wheres: "[{}]"
                        };
                        this.http.post('/api/Cal_Holiday/getPageData', param, true).then((result) => {
                              result.rows.forEach(theDay => {

                                    var timearr = theDay.TheDay.replace(" ", ":").replace(/\:/g, "-").split("-");
                                    var timestr = timearr[0] + "-" + Number(timearr[1]) + "-" + timearr[2];
                                    if (theDay.HolidayType == 'HOLIDAY') {
                                          this.holidayList.push(timestr);
                                          let index = allDataList.indexOf(theDay.TheDay.substring(0, 10));
                                          allDataList.splice(index, 1)
                                    } else {
                                          this.workdayList.push(timestr);
                                    }

                              });
                              var lastDateList = [];
                              var paramTwo = {
                                    order: "desc",
                                    page: 1,
                                    rows: 300,
                                    sort: "CreateDate",
                                    wheres: "[{\"name\":\"TeamId\",\"value\":\"" + TeamId + "\"},{\"name\":\"TheDate\",\"value\":\"" + startDate + "\",\"displayType\":\"thanorequal\"},{\"name\":\"TheDate\",\"value\":\"" + endDate + "\",\"displayType\":\"lessorequal\"}]"
                              };
                              this.http.post('/api/Cal_TeamShift/getPageData', paramTwo, true).then((res) => {
                                    allDataList.forEach(function (value, key, arr) {
                                          var list = res.rows.filter(item => {
                                                if (item.TheDate.substring(0, 10) === value) {
                                                      return item
                                                }
                                          })
                                          lastDateList.push({ theDay: value, list: list })
                                    });
                                    this.calendarDayList = lastDateList
                              });
                              this.loading = false;
                        });
                  },
                  isFestival(slotDate, slotData) {
                        let solarDayArr = slotData.day.split('-');
                        let lunarDay = calendar.solar2lunar(solarDayArr[0], solarDayArr[1], solarDayArr[2])

                        // 公历节日\农历节日\农历节气
                        let festAndTerm = [];
                        festAndTerm.push(lunarDay.festival == null ? '' : ' ' + lunarDay.festival)
                        festAndTerm.push(lunarDay.lunarFestival == null ? '' : '' + lunarDay.lunarFestival)
                        festAndTerm.push(lunarDay.Term == null ? '' : '' + lunarDay.Term)
                        festAndTerm = festAndTerm.join('')

                        return festAndTerm != ''
                  },
                  solarDate2lunar(solarDate) {
                        var solar = solarDate.split('-')
                        var lunar = calendar.solar2lunar(solar[0], solar[1], solar[2])

                        let lunarMD = lunar.IMonthCn + lunar.IDayCn;
                        // 公历节日\农历节日\农历节气
                        let festAndTerm = [];
                        festAndTerm.push(lunar.festival == null ? '' : ' ' + lunar.festival)
                        festAndTerm.push(lunar.lunarFestival == null ? '' : '' + lunar.lunarFestival)
                        festAndTerm.push(lunar.Term == null ? '' : '' + lunar.Term)
                        festAndTerm = festAndTerm.join('')

                        return festAndTerm == '' ? lunarMD : festAndTerm

                  }
            }
      }
</script>
<style>
      .grid-content {
            padding: 5px 0;
      }

      .el-group-list.el-radio-group {
            display: flex;
            flex-direction: column;
            align-items: stretch;
      }

      .el-group-list.el-radio-group .el-radio-button:first-child .el-radio-button__inner,
      .el-group-list.el-radio-group .el-radio-button:last-child .el-radio-button__inner,
      .el-group-list.el-radio-group .el-radio-button:first-child .el-radio-button__inner,
      .el-group-list.el-radio-group .el-radio-button__inner {
            border-radius: 0px !important;
            border: none !important;
      }

      .el-group-list.el-radio-group .el-radio-button {
            border-bottom: 1px solid #F7F7F7 !important;
      }

      .el-group-list.el-radio-group {
            border: 1px solid #dcdfe6;
      }

      .el-group-list.el-radio-group>label>span {
            width: 100%;
            text-align: left;
            padding-left: 20px;
      }

      /**本月周末设置为红色*/
      .el-calendar-table .current:nth-last-child(-n+1) .solar {
            color: red;
      }

      .el-calendar-table .current:first-child .solar {
            color: red;
      }

      /**本月农历设置为灰色*/
      .el-calendar-table .current .lunar {
            color: #606266;
            font-size: small;
      }

      /**本月农历设置为灰色*/
      .el-calendar-table .current .lunar {
            color: #606266;
            font-size: small;
      }

      /**本月农历节日设置为红色*/
      .el-calendar-table .current .lunar.festival {
            color: green;
            font-size: small;
      }

      /**节假日背景设置为绿色 */
      .el-calendar-table .holiday {
            background-color: #88E325;
      }

      .el-calendar-table .el-calendar-day {
            box-sizing: border-box;
            padding: 8px;
            height: 100px;
      }
</style>