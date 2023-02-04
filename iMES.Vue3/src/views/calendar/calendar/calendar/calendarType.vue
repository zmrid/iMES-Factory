<template>
      <div class="app-container">
            <el-container>
                  <el-aside width="150px">
                        <el-radio-group v-model="selectedType" class="x-fillitem el-group-list" @change="onSelected">
                              <el-radio-button v-for="dict in dictList" :key="dict.key" :label="dict.key">{{dict.value}}
                              </el-radio-button>
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
                                    </div>
                              </template>
                        </el-calendar>
                  </el-main>
            </el-container>
      </div>
</template>

<script>
      // import { listCalholiday } from "@/api/mes/cal/calholiday";
      // import { listCalendars } from "@/api/mes/cal/calendar";
      import calendar from '@/uitils/calendar';
      export default {
            name: 'CalendarTypeView',
            data() {
                  return {
                        // 遮罩层
                        loading: false,
                        date: new Date(),
                        holidayList: [],//假日
                        workdayList: [],//工作日
                        dictList: [],
                        selectedType: null,
                        calendarDayList: [
                        ],
                        teamShiftQueryParams: {
                              queryType: 'TYPE',
                              calendarType: null
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
                              this.loading = false;
                              // listCalendars(this.teamShiftQueryParams).then(response =>{
                              //       this.calendarDayList = response.data;
                              //       this.loading = false;
                              // });
                        }
                  }
            },
            created() {
                  this.getDicDate();
                  this.getList();
            },
            methods: {
                  getDicDate() {
                        var keys = ["TeamType"];
                        this.http.post('/api/Sys_Dictionary/GetVueDictionary', keys)
                              .then((dic) => {
                                    this.dictList = dic[0].data;
                              });
                  },
                  /** 查询节假日设置列表 */
                  getList() {
                        this.loading = true;
                        this.holidayList = [];
                        this.workdayList = [];
                        let that = this;
                        var param = {
                              order: "desc",
                              page: 1,
                              rows: 300,
                              sort: "CreateDate",
                              wheres: "[{}]"
                        };
                        this.http.post('/api/Cal_Holiday/getPageData', param, true).then((result) => {
                              result.rows.forEach(theDay => {
                                    var timearr = theDay.TheDay.replace(" ", ":").replace(/\:/g, "-").split("-");
                                    var timestr = timearr[0] + "-" + Number(timearr[1]) + "-" + timearr[2];
                                    if (theDay.HolidayType == 'HOLIDAY') {
                                          this.holidayList.push(timestr);
                                    } else {
                                          this.workdayList.push(timestr);
                                    }
                                    this.loading = false;
                              });
                        })
                  },
                  //点击班组类型
                  onSelected(calType) {
                        this.loading = true;
                        this.teamShiftQueryParams.calendarType = calType;
                        this.teamShiftQueryParams.date = this.date;
                        var param = {
                              order: "desc",
                              page: 1,
                              rows: 300,
                              sort: "CreateDate",
                              wheres: "[{}]"
                        };
                        this.http.post('/api/Cal_Holiday/getPageData', param, true).then((result) => {
                              result.rows.forEach(theDay => {
                                    var timearr = theDay.TheDay.replace(" ", ":").replace(/\:/g, "-").split("-");
                                    var timestr = timearr[0] + "-" + Number(timearr[1]) + "-" + timearr[2];
                                    if (theDay.HolidayType == 'HOLIDAY') {
                                          this.holidayList.push(timestr);
                                    } else {
                                          this.workdayList.push(timestr);
                                    }
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

      /**本月农历节日设置为红色*/
      .el-calendar-table .current .lunar.festival {
            color: green;
            font-size: small;
      }

      /**节假日背景设置为绿色 */
      .el-calendar-table .holiday {
            background-color: #88E325;
      }
</style>