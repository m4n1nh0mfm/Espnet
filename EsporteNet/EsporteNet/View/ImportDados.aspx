<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="ImportDados.aspx.cs" Inherits="EsporteNet.View.ImportDados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center">Importação de Arquivo HTML</h2>
    <asp:Panel CssClass="form-group" runat="server">
        <label for="DATAIMP" class="col-sm-3 control-label">Data Importação</label>
        <asp:Panel runat="server" CssClass="col-sm-5">
            <asp:TextBox runat="server" ID="DATAIMP" CssClass="form-control" MaxLength="30" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" Display="Dynamic" ID="rfvNome" SetFocusOnError="true" ControlToValidate="DATAIMP" ErrorMessage="*Campo Obrigatorio!" ToolTip="Campo Obrigatorio!" BackColor="Red"></asp:RequiredFieldValidator>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel CssClass="form-group" runat="server">
        <label for="FILEUPLOAD" class="col-sm-3 control-label">Selecione o Aquivo</label>
        <asp:Panel runat="server" CssClass="col-sm-9">
            <asp:FileUpload ID="FILEUPLOAD" CssClass="form-control" runat="server" />
        </asp:Panel>
    </asp:Panel>
    <asp:Panel CssClass="form-group" runat="server">
        <asp:Panel runat="server" CssClass="col-sm-3">
        </asp:Panel>
        <asp:Panel runat="server" CssClass="col-sm-6">
            <asp:Button runat="server" ID="BtnCarregar" CssClass="btn btn-success btn-block" Text="Carregar"></asp:Button>
        </asp:Panel>
        <asp:Panel runat="server" CssClass="col-sm-3">
        </asp:Panel>
    </asp:Panel>
</asp:Content>
