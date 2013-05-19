$(document).ready(function () {

    //     if ($('#OpenDialogEx').val() == 'True') {
    //         var urlStr = $('#consumpt_dialog').attr('action') + '?id=' + $('#Id').val() + '&routeId=' + $('#RoutId').val();
    //         $.get(urlStr , null, function(data) { $('#consumpt_dialog').html(data); }, 'html').complete(function() {
    //                 $("#consumpt_dialog").dialog("open");
    //             });
    //     }

    $("#spoilerClick").dblclick(function () {
        $("#spoiler").toggle("slow");
    });

    $("#consumpt_dialog").dialog({
        autoOpen: false,
        minWidth: 800,

        show: {
            effect: "blind",
            duration: 100
        },
        hide: {
            effect: "explode",
            duration: 100
        }
    });

    $('#file').change(function () {
        $('#upload_form').submit();
    });

    $("#shipping_dialog").dialog({
        autoOpen: false,
        minWidth: 1200,

        show: {
            effect: "blind",
            duration: 100
        },
        hide: {
            effect: "explode",
            duration: 100
        }
    });

    $('#consumpt_edit').dialog({
        autoOpen: false,

        show: {
            effect: "blind",
            duration: 100
        },
        hide: {
            effect: "explode",
            duration: 100
        }
    });

    $("#route_dialog").dialog({
        autoOpen: false,

        show: {
            effect: "blind",
            duration: 100
        },
        hide: {
            effect: "explode",
            duration: 100
        }

    });

    $('#add_route').click(function () {

        $.ajax({
            url: $('#route_dialog').attr('action') + '?id=' + $('#Id').val(),
            type: "POST",
            success: function (data) {
                $('#route_dialog').html(data);
                $("#route_dialog").dialog("open");
            }
        });

    });

    $('#add_consumpt').click(function () {

        $.ajax({
            url: $('#consumpt_edit').attr('action') + '?id=' + $('#Id').val() + '&routeId=' + $('#RouteId').val(),
            type: "POST",
            success: function (data) {
                $('#consumpt_edit').html(data);
                $("#consumpt_edit").dialog("open");
            }
        });
    });

    $('#delno_dialog').dialog({
        autoOpen: false,
        minWidth: 500,
        show: {
            effect: "blind",
            duration: 100
        },
        hide: {
            effect: "explode",
            duration: 100
        },
        buttons: {
            "Ок": function () {
                var id = $("#loaders").jqGrid('getGridParam', 'selrow');
                $.ajax({
                    url: $('#delete_loading').attr('action') + '?loaderId=' + id,
                    type: "POST",
                    success: function (data) {
                        if (data.toString() == "True") {
                            $('#loaders').trigger('reloadGrid');
                            $('#delno_dialog').empty();
                            $('#delno_dialog').dialog("close");
                        } else {
                            $('#infoLoadDel').text("Ошибка удаления загрузки");
                        }
                    }
                });
            },
            "Отмена": function () {
                $('#delno_dialog').empty();
                $(this).dialog("close");
            }
        }
    });

    $('#delRoute_dialog').dialog({
        autoOpen: false,
        minWidth: 500,
        show: {
            effect: "blind",
            duration: 100
        },
        hide: {
            effect: "explode",
            duration: 100
        },
        buttons: {
            "Ок": function () {
                var id = $("#route").jqGrid('getGridParam', 'selrow');
                $.ajax({
                    url: $('#delete_route').attr('action') + '?routeId=' + id,
                    type: "POST",
                    success: function (data) {
                        if (data.toString() == "True") {
                            $('#route').trigger('reloadGrid');
                            $('#delRoute_dialog').empty();
                            $('#delRoute_dialog').dialog("close");
                        } else {
                            $('#infoRouteDel').text("Ошибка удаления маршрута");
                        }
                    }
                });
            },
            "Отмена": function () {
                $('#delRoute_dialog').empty();
                $(this).dialog("close");
            }
        }
    });


    $("#loader_dialog").dialog({
        autoOpen: false,
        show: {
            effect: "blind",
            duration: 100
        },
        hide: {
            effect: "explode",
            duration: 100
        }
    });


    $('#list2').jqGrid({
        url: '/Transportation/GridView',
        datatype: "json",
        colNames: ['№', 'Рег. номер', 'Станция отправления', 'Станция прибытия', 'ГНГ', 'ЕТСНГ', 'Кол-во', 'Дата', 'Комментарий'],
        colModel: [
             { name: 'RowNumber', width: 20, align: "center" },
             { name: 'RegNumber', width: 100, align: "center" },
             { name: 'DispatchStation', width: 150, align: "center" },
             { name: 'ArriveStattion', width: 150, align: "center" },
             { name: 'GHGClassificator', width: 150, align: "center" },
             { name: 'ETSNGClassificator', width: 150, align: "center" },
             { name: 'TransportCount', width: 100, align: "center" },
             { name: 'RegDate', width: 150, align: "center" },
             { name: 'Comments', width: 150, align: "center" }
         ],
        height: 'auto',
        rowNum: 10,
        rowList: [10, 20, 30],
        pager: '#pager2',
        sortname: 'RowNumber',
        viewrecords: true,
        sortorder: "desc",
        caption: "Перевозка",
        ondblClickRow: function (id) {
            //             var RegNumber = $('#list2').jqGrid('getCell', id, 'RegNumber');

            var url = '/Transportation/TransportationEdit?' + 'id=' + id;
            //                                                                + '&RegNumber=' +  RegNumber;
            document.location = url;
        }
    });

    $('#search_btn').click(function () {
        var url = '/Transportation/GridView?' + 'RegNumber=' + $('#RegNumber').val() + '&DispatchStation=' + $('#DispatchStation').val() + '&ArriveStation=' + $('#ArriveStation').val() +
             '&GHGClassificator=' + $('#GHGClassificator').val() + '&ETSNGClassificator=' + $('#ETSNGClassificator').val() + '&RegDate=' + $('#RegDate').val();
        $('#list2').jqGrid('setGridParam', { url: url });
        $('#list2').trigger('reloadGrid');
    });

    $('#add_loading').click(function () {

        $.ajax({
            url: $('#loader_dialog').attr('action') + '?id=' + $('#Id').val(),
            type: "POST",
            success: function (data) {
                $('#loader_dialog').html(data);
                $("#loader_dialog").dialog("open");
            }
        });

    });

    $('#delete_loading').click(function () {
        if ($("#loaders").jqGrid('getGridParam', 'selrow')) {
            $("#delno_dialog").dialog("open");
        } else
            alert("Нет выделенных строк для удаления!");
    });

    $('#delete_route').click(function () {

        if ($("#route").jqGrid('getGridParam', 'selrow')) {
            $("#delRoute_dialog").dialog("open");
        } else
            alert("Нет выделенных строк для удаления!");
    });

    $("#list2").jqGrid('navGrid', '#pager2',
         { edit: false, add: false, del: false },
         {}, // Опции окон редактирования
         {}, // Опции окон добавления
         {}, // Опции окон удаления
         {
         width: 700
     }  // Опции окон поиска

     );

    $('#loaders').jqGrid({
        url: '/Transportation/LoadersView?id=' + $('#Id').val(),
        datatype: "json",
        colNames: ['№', 'Загрузка', 'Ставка', 'Расход', 'Метод расчета', 'Количество'],
        colModel: [
             { name: 'Id', width: 20, align: "center" },
             { name: 'Volume', width: 100, align: "center" },
             { name: 'Rate', width: 100, align: "center" },
             { name: 'Expense', width: 100, align: "center" },
             { name: 'Method', width: 200, align: "center" },
             { name: 'Count', width: 100, align: "center" }
         ],
        height: 'auto',
        sortorder: "desc",
        caption: "Загрузки",
        ondblClickRow: function (id) {
            $.ajax({
                url: $('#loader_dialog').attr('action') + "?id=" + $('#Id').val() + '&loadId=' + id,
                type: "POST",
                data: {

                    Volume: $('#loaders').jqGrid('getCell', id, 'Volume'),
                    Rate: $('#loaders').jqGrid('getCell', id, 'Rate'),
                    Expense: $('#loaders').jqGrid('getCell', id, 'Expense'),
                    Method: $('#loaders').jqGrid('getCell', id, 'Method'),
                    Count: $('#loaders').jqGrid('getCell', id, 'Count')
                },
                success: function (data) {
                    $('#loader_dialog').html(data);
                    $("#loader_dialog").dialog("open");
                }
            });
        }

    });


    $('#route').jqGrid({
        url: '/Transportation/RouteView?id=' + $('#Id').val(),
        datatype: "json",
        colNames: ['№', 'Дорога', 'Перевозчик', 'Расход'],
        colModel: [
            { name: 'RowNumber', width: 30, align: "center" },
            { name: 'Road', width: 200, align: "center" },
            { name: 'Carrier', width: 200, align: "center" },
            { name: 'Expense', width: 200, align: "center" }
        ],
        height: 'auto',
        sortorder: "desc",
        caption: "Маршрут",
        onCellSelect: function (id, iCol) {
            if (iCol == 3) {

                $.get($('#consumpt_dialog').attr('action') + '?id=' + $('#Id').val() + '&routeId=' + id,
                    null, function (data) {

                        $('#consumpt_dialog').html(data);
                    }, 'html').complete(function () {
                        $("#consumpt_dialog").dialog("open");

                        $('#consumption2').jqGrid({
                            url: '/Transportation/ConsumptionView?id=' + id,
                            datatype: "json",
                            colNames: ['№', 'Тип', 'Загрузка', 'Расход', 'Метод расчета'],
                            colModel: [
                                { name: 'RowNumber', index: 'id', align: "center" },
                                { name: 'Type', index: 'Type', align: "center" },
                                { name: 'Load', index: 'Load', align: "center" },
                                { name: 'Expense', index: 'Expense', align: "center" },
                                { name: 'Method', index: 'Method', align: "center" },
                            ],
                            height: 'auto',
                            sortorder: "desc",
                            sortname: 'id',
                            ondblClickRow: function (id) {

                                $.ajax({
                                    url: $('#consumpt_edit').attr('action') + '?id=' + $('#Id').val() +
                                        '&routeId=' + $('#RouteId').val() + '&expenseId=' + id,
                                    type: "POST",
                                    data: {
                                        Type: $('#consumption2').jqGrid('getCell', id, 'Type'),
                                        Expense: $('#consumption2').jqGrid('getCell', id, 'Expense'),
                                        Method: $('#consumption2').jqGrid('getCell', id, 'Method')
                                    },
                                    success: function (data) {
                                        $('#consumpt_edit').html(data);
                                        $('#consumpt_edit').dialog("open");
                                    }
                                });

                            }
                        });

                    });
            }

        },
        ondblClickRow: function (id) {
            $.ajax({
                url: $('#route_dialog').attr('action') + '?id=' + $('#Id').val() + '&routeId=' + id,
                type: "POST",
                data: {
                    Road: $('#route').jqGrid('getCell', id, 'Road'),
                    Carrier: $('#route').jqGrid('getCell', id, 'Carrier')
                },
                success: function (data) {
                    $('#route_dialog').html(data);
                    $("#route_dialog").dialog("open");
                }
            });
        }
    });

    $('#consumption').jqGrid({
        url: '/Transportation/ConsumptionView',
        datatype: "json",
        colNames: ['№', 'Загрузка', 'Тип', 'Расход', 'Метод расчета'],
        colModel: [
             { name: 'Id', width: 20, align: "center" },
             { name: 'Load', width: 20, align: "center" },
             { name: 'Type', width: 150, align: "center" },
             { name: 'Expense', width: 150, align: "center" },
             { name: 'Method', width: 150, align: "center" },
         ],
        height: 'auto',
        sortorder: "desc",
        caption: "Расход"
    });

    $('#shipping').jqGrid({
        url: '/Transportation/ShippingView?id=' + $('#Id').val(),
        datatype: "json",
        colNames: ['№', 'Номер вагона', 'Номер накладной', 'Вес', 'Грузоподъемность', 'Дата', 'Дата прибытия'],
        colModel: [
                     { name: 'Id', index: 'id', align: "center", width: 30 },
                     { name: 'ContainerNumber', index: 'ContainerNumber', align: "center" },
                     { name: 'InvoiceNumber', index: 'InvoiceNumber', align: "center", width: 180 },
                     { name: 'Weight', index: 'Weight', align: "center", width: 50 },
                     { name: 'Capacity', index: 'Capacity', align: "center", width: 180 },
                     { name: 'Date', index: 'Date', align: "center", width: 100 },
                     { name: 'ArriveDate', index: 'ArriveDate', align: "center" }
                 ],
        height: 'auto',
        sortorder: "desc",
        sortname: 'id',
        caption: "Отгрузка"
    });

});