 $(document).ready(function () {
        $(function() {
            $("#tabs").tabs();
        });

        $( "#dialog" ).dialog({
            autoOpen: false,
            show: {
                effect: "blind",
                duration: 100
            },
            hide: {
                effect: "explode",
                duration: 100
            },
            buttons: {
                "Ok":function() {
                    alert($('#dialog').attr('action'));
                },
                "Отмена": function() {
                    $('#dialog').empty();
                    $(this).dialog("close");
                }
            }
        });

        $('#BUTTON_dialog').click(function() {
            var action = $('#dialog').attr('action');
            $.get($('#dialog').attr('action'), null, function(data) {
                $('#dialog').html(data);}, 'html').complete(function() { $("#dialog").dialog("open"); 
                });
        });

        $('#list2').jqGrid({
            url: '/Grid/GridView',
            datatype: "json",
            colNames: ['№', 'Регистрационный номер', 'Станция отправления', 'Станция прибытия', 'Классификатор груза по ГНГ', 'Классификатор груза по ЕТСНГ', 'Количество транспортных средств', 'Общий вес перевозки', 'Комментарии', 'Дата регистрации'],
            colModel: [
                { name: 'Id', width: 20, align: "center" },
                { name: 'RegNumber', width: 150, align: "center" },
                { name: 'DispatchStation', width: 150, align: "center" },
                { name: 'ArriveStattion', width: 150, align: "center" },
                { name: 'GHGClassificator', width: 200, align: "center" },
                { name: 'ETSNGClassificator', width: 200, align: "center" },
                { name: 'TransportCount', width: 200, align: "center" },
                { name: 'FullWeight', width: 150, align: "center" },
                { name: 'Comments', width: 150, align: "center" },
                { name: 'RegDate', width: 150, align: "center" }
            ],
            height: 'auto',
            rowNum: 10,
            rowList: [10, 20, 30],
            pager: '#pager2',
            sortname: 'Id',
            viewrecords: true,
            sortorder: "desc",
            caption: "Перевозка",
            onSelectRow: function(id) {
                alert(id);
            },
        });

        $('#search_btn').click(function() {
            var url = '/Grid/GridView?' + 'RegNumber=' + $('#RegNumber').val()+'&DispatchStation=' + $('#DispatchStation').val()+'&ArriveStation=' + $('#ArriveStation').val()+
                '&GHGClassificator=' + $('#GHGClassificator').val()+'&ETSNGClassificator=' + $('#ETSNGClassificator').val()+'&RegDate=' + $('#RegDate').val();
            $('#list2').jqGrid('setGridParam', { url: url });
            $('#list2').trigger('reloadGrid');
        });

        $("#list2").jqGrid('navGrid', '#pager2', 
            { edit: false, add: false, del: false },
            {}, // Опции окон редактирования
            {}, // Опции окон добавления
            {}, // Опции окон удаления
            {
                width:700,        
            }  // Опции окон поиска
        
        );

    });