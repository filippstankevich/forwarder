<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table id="EmployeeTable">
    </table>
    <div id="EmployeeTablePager">
    </div>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery('#GridTable').jqGrid({
                url: '/GridModel/GridView',
                datatype: "json",
                mtype: 'POST',
                jsonReader: {
                    page: "page",
                    total: "total",
                    records: "records",
                    root: "rows",
                    repeatitems: false,
                    id: ""
                },
                colNames: ['Id', 'Регистрационный номер', 'Станция отправления', 'Станция прибытия', 'Классификатор груза по ГНГ', 'Классификатор груза по ЕТСНГ', 'Количество транспортных средств', 'Общий вес перевозки', 'Комментарии',''],
                colModel: [
                { name: 'Id', width: 20 },
                { name: 'RegNumber', width: 105 },
                { name: 'DispatchStation', width: 100 },
                { name: 'ArriveStattion', width: 150 },
                { name: 'GHGClassificator', width: 150 },
                { name: 'ETSNGClassificator', width: 150 },
                { name: 'TransportCount', width: 150 },
                { name: 'FullWeight', width: 150 },
                { name: 'Comments', width: 150 },
                { name: 'RegDate', width: 150 }
                ],
                pager: '#GridTablePager',
                viewrecords: true
            });
        });
        
    </script>

<h2>Index</h2>

</asp:Content>
