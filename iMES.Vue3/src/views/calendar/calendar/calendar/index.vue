<template>
    <div class="app-container">
        <el-tabs type="border-card">
            <el-tab-pane label="分类">
                <CalendarTypeView></CalendarTypeView>
            </el-tab-pane>
            <el-tab-pane label="班组">
                <TeamView></TeamView>
            </el-tab-pane>
        </el-tabs>
    </div>
</template>

<script>
import CalendarTypeView from "./calendarType.vue"
import TeamView from "./team.vue"
export default {
    components:{CalendarTypeView,TeamView},
    data(){
        return {

        }
    }
}
</script>

<style>

</style>