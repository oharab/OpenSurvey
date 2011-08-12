<%@ Page Language="C#" Inherits="ResourceView<SurveyResource>" MasterPageFile="~/Views/Survey.Master" Title="Home Page" %>

<asp:Content ContentPlaceHolderID="Content" ID="content" runat="server">
    <div>
        <h1><%= Resource.Title %></h1>
        <p><%= Resource.Description %></p>
        
        <a href="<%= Resource.CreateUri() %>">Permalink</a>
    </div>
</asp:Content>
