// Write your Javascript code.
jQuery(document).on("scroll", function () {
    if ($(document).scrollTop() > 70) {
        $("#meniu-id").removeClass("navbar-inverse");
        $("#meniu-id").addClass("navbar-inverse-in-jos");
    } else {
        $("#meniu-id").addClass("navbar-inverse");
        $("#meniu-id").removeClass("navbar-inverse-in-jos");
    }
});