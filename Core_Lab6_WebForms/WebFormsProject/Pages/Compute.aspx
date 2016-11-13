<%@ Page Title="Sum of Numbers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compute.aspx.cs" Inherits="WebFormsProject.Compute" %>

<%@ Register TagPrefix="fx" TagName="NumberInputControl" Src="~/Controls/NumberInput.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-8">
            <asp:PlaceHolder id="computeForm" runat="server">
                <div class="form-horizontal">
                    <h4>Compute Sum of Numbers</h4>
                    <hr/>
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText"/>
                        </p>
                    </asp:PlaceHolder>
                    <fx:NumberInputControl runat="server" ID="numberInput1" myID="1" />
                    <fx:NumberInputControl runat="server" ID="numberInput2" myID="2" />
                    <fx:NumberInputControl runat="server" ID="numberInput3" myID="3" />
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="btnCompute" runat="server" OnClick="AddNumbers" Text="Compute" CssClass="btn btn-default"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblResult" runat="server" CssClass="col-md-2 col-md-offset-1 control-label" Visible="false"></asp:Label>
                    </div>
                </div>
            </asp:PlaceHolder>
        </div>
    </div>
</asp:Content>
