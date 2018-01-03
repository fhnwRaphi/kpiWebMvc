$(document).ready(function () {
    $("#btnSidebar").click(function () {
        $('.ui.labeled.icon.sidebar')
            .sidebar('toggle')
            ;
    });
    $('table').tablesort()
});