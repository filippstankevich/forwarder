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
                colNames: ['Id', 'Имя', 'Фамилия', 'Email'],
                colModel: [
                { name: 'Id', width: 20 },
                { name: 'FirstName', width: 105 },
                { name: 'LastName', width: 100 },
                { name: 'Email', width: 150 }
                ],
                pager: '#GridTablePager',
                viewrecords: true
            });
        });
        
    </script>

<h2>Index</h2>

</asp:Content>
