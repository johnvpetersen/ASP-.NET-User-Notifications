<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<UserNotifications.alerts.AlertMetaData>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    User Notification Example
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">




<%using (Html.BeginForm("Index"))
  { %>
<table>
    <tr>
       <th>Type</th>
       <th>Message</th>
       <th>Fade Out Time</th>
       <th>Click to Close</th>
    </tr>
    <tr>
       <td>Error</td>
       <td><%=Html.TextBox("ErrorMessage", Model.ErrorMessage)%></td>
       <td><%=Html.TextBox("ErrorFadeOut", Model.ErrorFadeOut, new { style = "width: 50px;" })%></td>
       <td><%=Html.CheckBox("ErrorClickToClose", Model.ErrorClickToClose)%></td>
    </tr>

    <tr>
      <td>Info</td>
       <td><%=Html.TextBox("InfoMessage", Model.InfoMessage)%></td>
       <td><%=Html.TextBox("InfoFadeOut", Model.InfoFadeOut, new { style = "width: 50px;" })%></td>
       <td><%=Html.CheckBox("InfoClickToClose", Model.InfoClickToClose)%></td>
    </tr>

    <tr>
       <td>OK</td>
       <td><%=Html.TextBox("OKMessage", Model.OKMessage)%></td>
       <td><%=Html.TextBox("OKFadeOut", Model.OKFadeOut, new { style = "width: 50px;" })%></td>
       <td><%=Html.CheckBox("OKClickToClose", Model.OKClickToClose)%></td>
    </tr>

    <tr>
      <td>Warning</td>
       <td><%=Html.TextBox("WarningMessage", Model.WarningMessage)%></td>
       <td><%=Html.TextBox("WarningFadeOut", Model.WarningFadeOut, new { style = "width: 50px;" })%></td>
       <td><%=Html.CheckBox("WarningClickToClose", Model.WarningClickToClose)%></td>
    </tr>

</table>

<input type="submit" value= "Get User Notifications" />

<%} %>


<h1>User Notifications:</h1>
<br />
<%=new UserNotifications.alerts.Alerts(Model).RenderHTML() %>

 </asp:Content>
