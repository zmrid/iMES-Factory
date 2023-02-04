//对vue参数进行扩展
var extend = function ($vueParam) {
    $vueParam.methods.mesBoxFrom = function () {
        this.$Message.info("扩展js,增加弹出消息");
        this.$refs.mesBoxFrom.show();
    }
    //修改data属性:
    let data = $vueParam.data();
    data.formFileds['extend'] = "动态扩展字段";
    data.formOptions.splice(0,0,{ filed: "extend", title: "动态增加字段", type: "text", required: true });
    $vueParam.data = function () {
        return data;
    }
}
export { extend }