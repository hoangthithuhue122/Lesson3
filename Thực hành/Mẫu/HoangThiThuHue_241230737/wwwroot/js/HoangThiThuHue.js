$(document).on("click", ".loai-link", function (e) {
    e.preventDefault();
    $("#mainContent").load($(this).data("url"));
    $(".menu li").removeClass("active");
    $(this).parent().addClass("active");
});