var swiper = new Swiper('.swiper-container', {
    mode: 'vertical',
    speed: 600,
    onSlideChangeStart: function (swiper) {
        var index = swiper.activeIndex;//下标
        $(".tabDivs div").eq(index).click();
    }
});
$(".tabDivs div").width(($(window).width() - ($(".tabDivs div").length - 1)) / $(".tabDivs div").length);
$(".tabDivs div").each(function (index) {
    if (index == 0) {
        $(this).addClass("tabOn");
    }
    this.onclick = function () {
        $(".tabDivs div").removeClass("tabOn");
        $(this).addClass("tabOn");
        swiper.slideTo(index, 1000, false);//切换到第一个slide，速度为1秒
    }
});