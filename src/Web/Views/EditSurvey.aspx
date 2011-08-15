<%@ Page Language="C#" Inherits="ResourceView<SurveyResource>" MasterPageFile="~/Views/Survey.Master"
    Title="Home Page" %>

<script runat="server">
    protected void Page_Load()
    {
        Page.Title = Resource.Title;
    }
</script>
<asp:Content ContentPlaceHolderID="Content" ID="content" runat="server">
    <div>
        <% using (
            scope(Xhtml.Form(Resource).Method("put")))
           {
               using (scope(p))
               {
        %>
        <input type="text" name="Name" value="<%= Resource.Name %>" />
        <input type="text" name="Title" value="<%= Resource.Title %>" />
        <textarea name="Description" rows="4" cols="10"><%= Resource.Description %></textarea>
        <input type="submit" value="Save" /> <a href="<%= Resource.CreateUri() %>">Cancel</a>
        <% }
            } %>
    </div>
</asp:Content>
