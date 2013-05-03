 $(document).ready(function() {

     $("#spoilerClick").click(function() {
         $("#spoiler").toggle("slow");
     });

     $("#consumpt_dialog").dialog({       
         autoOpen: false,
         minWidth: 800,

         show: {
             effect: "blind",
             duration: 100,
         },
         hide: {
             effect: "explode",
             duration: 100
         },
     });

     $('#delno_dialog').dialog({
          autoOpen: false,
    

         show: {
             effect: "blind",
             duration: 100,
         },
         hide: {
             effect: "explode",
             duration: 100
         },
          buttons: {
                "Ок":function() {
                   $('#loaders').jqGrid('delRowData',$("#loaders").jqGrid('getGridParam','selrow'));
                   $('#delno_dialog').empty();
                   $(this).dialog("close");
                },
                "Отмена": function() {
                    $('#delno_dialog').empty();
                    $(this).dialog("close");
                }
            }
          
     });


     $("#loader_dialog").dialog({       
         autoOpen: false,
         show: {
             effect: "blind",
             duration: 100,
         },
         hide: {
             effect: "explode",
             duration: 100
         },
         
       

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
         var url = '/Grid/GridView?' + 'RegNumber=' + $('#RegNumber').val() + '&DispatchStation=' + $('#DispatchStation').val() + '&ArriveStation=' + $('#ArriveStation').val() +
             '&GHGClassificator=' + $('#GHGClassificator').val() + '&ETSNGClassificator=' + $('#ETSNGClassificator').val() + '&RegDate=' + $('#RegDate').val();
         $('#list2').jqGrid('setGridParam', { url: url });
         $('#list2').trigger('reloadGrid');
     });

     $('#add_loading').click(function() {
                
                 $.ajax({
                 url: $('#loader_dialog').attr('action'),
                 type: "POST",
                 success: function(data) {
                     $('#loader_dialog').html(data);
                     $("#loader_dialog").dialog("open");
                 }
             });

     });

     $('#delete_loading').click(function() {

         if ($("#loaders").jqGrid('getGridParam', 'selrow')) {
             $("#delno_dialog").dialog("open");
         } else
             alert("Нет выделенных строк для удаления!");        

         
     });
        

     $("#list2").jqGrid('navGrid', '#pager2',
         { edit: false, add: false, del: false },
         {}, // Опции окон редактирования
         {}, // Опции окон добавления
         {}, // Опции окон удаления
         {
             width: 700,
         }  // Опции окон поиска
        
     );

     $('#loaders').jqGrid({
         url: '/Grid/LoadersView',
         datatype: "json",
         colNames: ['№', 'Загрузка', 'Ставка', 'Расход', 'Метод расчета', 'Количество'],
         colModel: [
             { name: 'Id', width: 20, align: "center" },
             { name: 'Loading', width: 100, align: "center" },
             { name: 'Rate', width: 100, align: "center" },
             { name: 'Сonsumption', width: 100, align: "center" },
             { name: 'Method', width: 200, align: "center" },
             { name: 'Count', width: 100, align: "center" }
         ],
         height: 'auto',
         sortorder: "desc",
         caption: "Загрузки",
         ondblClickRow: function(id) {
             $.ajax({
                 url: $('#loader_dialog').attr('action'),
                 type: "POST",
                 data: {
                     Loading: $('#loaders').jqGrid('getCell', id, 'Loading'),
                     Rate: $('#loaders').jqGrid('getCell', id, 'Rate'),
                     Сonsumption: $('#loaders').jqGrid('getCell', id, 'Сonsumption'),
                     Method: $('#loaders').jqGrid('getCell', id, 'Method'),
                     Count: $('#loaders').jqGrid('getCell', id, 'Count')
                 },
                 success: function(data) {
                     $('#loader_dialog').html(data);
                     $("#loader_dialog").dialog("open");
                 }
             });
         },
      
     });

        
     $('#route').jqGrid({
         url: '/Grid/RouteView',
         datatype: "json",
         colNames: ['№', 'Дорога', 'Перевозчик', 'Расход'],
         colModel: [
             { name: 'Id', width: 20, align: "center" },
             { name: 'Road', width: 150, align: "center" },
             { name: 'Carrier', width: 150, align: "center" },
             { name: 'Consumption', width: 150, align: "center" }
         ],
         height: 'auto',
         sortorder: "desc",
         caption: "Маршрут",
         onCellSelect : function(rowid, iCol, cellcontent) {
             if (iCol == 3) {
                 
                      $.get($('#consumpt_dialog').attr('action'), null, function(data) {

             $('#consumpt_dialog').html(data);
         }, 'html').complete(function() {
             var lastSel;
             $('#consumption2').jqGrid({                       
                 url: '/Grid/ConsumptionView',
                 datatype: "json",
                 colNames: ['№', 'Загрузка', 'Тип', 'Расход', 'Метод расчета'],
                 colModel: [
                     { name: 'Id', index: 'id', align: "center" },
                     { name: 'Loading', index: 'Loading', align: "center", editable: true, edittype: "text" },
                     { name: 'Type', index: 'Type', align: "center", editable: true, edittype: "text" },
                     { name: 'Consumption', index: 'Consumption', align: "center", editable: true, edittype: "text" },
                     { name: 'Method', index: 'Method', align: "center", editable: true, edittype: "text" },
                 ],
                 height: 'auto',
                 sortorder: "desc",
                 sortname: 'id',
                 ondblClickRow: function(id) {
                     if (id && id != lastSel) {
                         jQuery("#consumption2").restoreRow(lastSel);
                         jQuery("#consumption2").editRow(id, true);
                         lastSel = id;
                     }
                 },
                 editurl: '/Grid/EditView'
             });
             $("#consumpt_dialog").dialog("open");
         });
             }

         },
         
     });

     $('#consumption').jqGrid({
         url: '/Grid/ConsumptionView',
         datatype: "json",
         colNames: ['№', 'Загрузка', 'Тип', 'Расход', 'Метод расчета'],
         colModel: [
             { name: 'Id', width: 20, align: "center" },
             { name: 'Loading', width: 20, align: "center" },
             { name: 'Type', width: 150, align: "center" },
             { name: 'Consumption', width: 150, align: "center" },
             { name: 'Method', width: 150, align: "center" },
         ],
         height: 'auto',
         sortorder: "desc",
         caption: "Расход",
         onSelectRow: function(id) {
             alert(id);
         }
     });

          
 });