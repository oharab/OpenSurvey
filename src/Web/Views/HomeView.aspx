<%@ Page Language="C#" Inherits="ResourceView<HomeResource>" MasterPageFile="~/Views/HomeView.Master" Title="Home Page" %>

<asp:Content ContentPlaceHolderID="Content" ID="content" runat="server">
    <div>
        <h1>Welcome to OpenSurvey</h1>
        <p>
            <a href="<%= typeof(NewSurveyResource).CreateUri() %>">Create a new Survey</a>
        </p>
        
    </div>
</asp:Content>