<%@ Page Language="C#" Inherits="ResourceView<SurveyResource>" MasterPageFile="~/Views/Survey.Master" Title="Home Page" %>
<script runat="server">
    protected void Page_Load()
    {
        Page.Title = Resource.Title;
    }
</script>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="server">
    <div>
        <h1><%= Resource.Title %></h1>
        <p><%= Resource.Description %></p>
        
        <a href="<%= Resource.CreateUri("edit") %>">Edit</a>
    </div>
</asp:Content>
