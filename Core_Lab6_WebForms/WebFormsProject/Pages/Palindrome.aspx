<%@ Page Title="Palindrome" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Palindrome.aspx.cs" Inherits="WebFormsProject.Palindrome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-8">
            <asp:PlaceHolder id="computeForm" runat="server">
                <div class="form-horizontal">
                    <h4>Check if a word is palindrome</h4>
                    <hr/>
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText"/>
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtWord" CssClass="col-md-2 control-label">The word</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtWord" CssClass="form-control" TextMode="SingleLine"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtWord"
                                                        CssClass="text-danger" ErrorMessage="This input should not be empty."/>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="btnCompute" runat="server" OnClick="CheckIfPalindrome" Text="Check" CssClass="btn btn-default"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Label ID="lblResult" runat="server" CssClass="control-label" Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
        </div>
    </div>
</asp:Content>
