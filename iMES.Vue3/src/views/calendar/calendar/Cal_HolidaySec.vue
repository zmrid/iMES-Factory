<template>
    <el-alert :title="'鼠标右键点击进行节假日设置'" type="success" :closable="false" show-icon>
    </el-alert>
    <el-calendar>
        <template #dateCell="{data}">
            <div @contextmenu.prevent="onRightClick(data)">
                <el-row>
                    <el-col :span="16">
                        <div class="solar">
                            {{ data.day.split('-').slice(1).join('-') }}
                        </div>
                    </el-col>
                    <el-col :span="8">
                        <el-tag v-if="holidayList.indexOf(data.day) ==-1" effect="dark">班</el-tag>
                        <el-tag v-else effect="dark" type="success">休</el-tag>
                    </el-col>
                </el-row>
                <el-row>
                    <el-col :span="24">
                        <div class="lunar" :class="{ festival : isFestival(date, data) }">{{ solarDate2lunar(data.day)
                            }}
                        </div>
                    </el-col>
                </el-row>
            </div>
        </template>
    </el-calendar>
    <!-- 添加或修改节假日设置对话框 -->
    <el-dialog :title="title" v-model="open" width="500px" append-to-body>
        <el-form ref="form" :rules="rules" label-width="80px">
            <el-row>
                <el-col :span="12">
                    <el-form-item label="日期" prop="currntTheDay">
                        <el-input v-model="currntTheDay" readonly="readonly"></el-input>
                    </el-form-item>
                </el-col>
                <el-col :span="12">
                    <el-form-item label="类型" prop="holidayType">
                        <el-radio-group v-model="currntHolidayType">
                            <el-radio label="HOLIDAY">假</el-radio>
                            <el-radio label="WORKDAY">班</el-radio>
                        </el-radio-group>
                    </el-form-item>
                </el-col>
                <el-col :span="24">
                    <el-form-item label="备注" prop="remark">
                        <el-input :rows="3" type="textarea" v-model="remark"></el-input>
                    </el-form-item>
                </el-col>
            </el-row>
        </el-form>
        <div slot="footer" style="text-align: center;" class="dialog-footer">
            <el-button type="primary" @click="submitForm">确 定</el-button>
            <el-button @click="cancel">取 消</el-button>
        </div>
    </el-dialog>
</template>
<script>
    import calendar from '@/uitils/calendar';
    export default {
        data() {
            return {
                // 遮罩层
                loading: true,
                date: new Date(),
                holidayList: [],//假日
                workdayList: [],//工作日
                // 弹出层标题
                title: "节假日设置",
                // 是否显示弹出层
                open: false,
                form: {},
                currntHolidayType: "",
                currntTheDay: "",
                remark: "",
                queryParams: {
                    theDay: null,
                    holidayType: null,
                    startTime: null,
                    endTime: null,
                },
                // 表单校验
                rules: {
                    holidayType: [
                        { required: true, message: "请选择类型", trigger: "blur" }
                    ],
                }
            }
        },
        created() {
            this.getList();
        },
        methods: {
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
                        var timestr = timearr[0] + "-" + timearr[1] + "-" + timearr[2];
                        if (theDay.HolidayType == 'HOLIDAY') {
                            this.holidayList.push(timestr);
                        } else {
                            this.workdayList.push(timestr);
                        }
                    });
                    this.loading = false;
                });
            },
            onRightClick(date) {
                this.currntTheDay = date.day;
                this.open = true;
                this.reset();
            },
            submitForm() {
                var that = this;
                if (this.currntHolidayType == "") {
                    return this.$message.error("请先设置类型");
                }
                else {
                    let params = {
                        mainData: { TheDay: this.currntTheDay, StartDate: this.currntTheDay, EndDate: this.currntTheDay, Remark: this.remark, HolidayType: this.currntHolidayType },
                        detailData: [],
                        delKeys: null
                    };
                    let url = 'api/Cal_Holiday/add';
                    this.http.post(url, params, true).then((result) => {
                        this.$message.info("设置成功");
                        that.open = false;
                        that.getList();
                    });
                }
            },
            // 取消按钮
            cancel() {
                this.open = false;
                this.reset();
            },
            // 表单重置
            reset() {
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
    .is-selected {
        color: #1989fa;
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