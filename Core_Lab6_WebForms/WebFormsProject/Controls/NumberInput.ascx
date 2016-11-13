<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NumberInput.ascx.cs" Inherits="WebFormsProject.NumberInput" %>

<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="txtNumber" CssClass="col-md-2 control-label">Number <%= this.myID %></asp:Label>
    <div class="col-md-10">
        <asp:TextBox runat="server" ID="txtNumber" CssClass="form-control" TextMode="Number"/>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNumber"
                                    CssClass="text-danger" ErrorMessage="This input should not be empty."/>
        <asp:CompareValidator ErrorMessage="This input should be a number." ControlToValidate="txtNumber" runat="server" Operator="DataTypeCheck" Type="Double" />
    </div>
</div>