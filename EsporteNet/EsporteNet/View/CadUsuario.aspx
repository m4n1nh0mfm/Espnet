<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="CadUsuario.aspx.cs" Inherits="EsporteNet.View.CadUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FormView ID="FormView2" DefaultMode="Insert" Width="100%" runat="server">
        <InsertItemTemplate>
            <asp:Panel ID="USUARIO" CssClass="form-group" runat="server">
                <h2 class="text-center">Cadastro de Usuário</h2>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="USER" class="col-sm-3 control-label">Usuario</label>
                    <asp:Panel runat="server" CssClass="col-sm-9">
                        <asp:TextBox runat="server" ID="USER" CssClass="form-control" MaxLength="30" TextMode="SingleLine"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ID="rfvUSER" SetFocusOnError="true"  ControlToValidate="USER" ErrorMessage="*Campo Obrigatorio!" ToolTip="Campo Obrigatorio!" BackColor="Red"></asp:RequiredFieldValidator>
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="SENHA" class="col-sm-3 control-label">Senha</label>
                    <asp:Panel runat="server" CssClass="col-sm-9">
                        <asp:TextBox runat="server" ID="SENHA" CssClass="form-control" MaxLength="32" TextMode="Password"></asp:TextBox>
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="RSENHA" class="col-sm-3 control-label">Repetir Senha</label>
                    <asp:Panel runat="server" CssClass="col-sm-9">
                        <asp:TextBox runat="server" ID="RSENHA" CssClass="form-control" MaxLength="32" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator runat="server" ID="cvRSENHA" ControlToCompare="SENHA" ControlToValidate="RSENHA" Display="Dynamic" ForeColor="Red" ErrorMessage="*A senha não confere"></asp:CompareValidator>
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="LOCALIZACAO" CssClass="form-group" runat="server">
                <h2 class="text-center">Localização</h2>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="CEP" class="col-sm-3 control-label">CEP</label>
                    <asp:Panel runat="server" CssClass="col-sm-9">
                        <asp:TextBox runat="server" ID="CEP" CssClass="form-control" MaxLength="10" TextMode="SingleLine"></asp:TextBox>
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="ESTADO" class="col-sm-3 control-label">Estado</label>
                    <asp:Panel runat="server" CssClass="col-sm-2">
                        <asp:DropDownList ID="ESTADO" CssClass="form-control" runat="server" Style="padding-top: 0px; padding-bottom: 0px;">
                            <asp:ListItem>AC</asp:ListItem>
                            <asp:ListItem>AL</asp:ListItem>
                            <asp:ListItem>AP</asp:ListItem>
                            <asp:ListItem>AM</asp:ListItem>
                            <asp:ListItem>BA</asp:ListItem>
                            <asp:ListItem>CE</asp:ListItem>
                            <asp:ListItem>DF</asp:ListItem>
                            <asp:ListItem>ES</asp:ListItem>
                            <asp:ListItem>GO</asp:ListItem>
                            <asp:ListItem>MA</asp:ListItem>
                            <asp:ListItem>MT</asp:ListItem>
                            <asp:ListItem>MS</asp:ListItem>
                            <asp:ListItem>MG</asp:ListItem>
                            <asp:ListItem>PA</asp:ListItem>
                            <asp:ListItem>PB</asp:ListItem>
                            <asp:ListItem>PR</asp:ListItem>
                            <asp:ListItem>PE</asp:ListItem>
                            <asp:ListItem>PI</asp:ListItem>
                            <asp:ListItem>RJ</asp:ListItem>
                            <asp:ListItem>RN</asp:ListItem>
                            <asp:ListItem>RS</asp:ListItem>
                            <asp:ListItem>RO</asp:ListItem>
                            <asp:ListItem>RR</asp:ListItem>
                            <asp:ListItem>SC</asp:ListItem>
                            <asp:ListItem>SP</asp:ListItem>
                            <asp:ListItem>SE</asp:ListItem>
                            <asp:ListItem>TO</asp:ListItem>
                        </asp:DropDownList>
                    </asp:Panel>
                    <label for="CIDADE" class="col-sm-2 control-label">Cidade</label>
                    <asp:Panel runat="server" CssClass="col-sm-5">
                        <asp:TextBox runat="server" ID="CIDADE" CssClass="form-control" MaxLength="50" TextMode="SingleLine"></asp:TextBox>
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="BAIRRO" class="col-sm-3 control-label">Bairro</label>
                    <asp:Panel runat="server" CssClass="col-sm-3">
                        <asp:TextBox runat="server" ID="BAIRRO" CssClass="form-control" MaxLength="50" TextMode="SingleLine"></asp:TextBox>
                    </asp:Panel>
                    <label for="ENDERECO" class="col-sm-2 control-label">Endereço</label>
                    <asp:Panel runat="server" CssClass="col-sm-4">
                        <asp:TextBox runat="server" ID="ENDERECO" CssClass="form-control" MaxLength="50" TextMode="SingleLine"></asp:TextBox>
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="NUMERO" class="col-sm-3 control-label">Número</label>
                    <asp:Panel runat="server" CssClass="col-sm-3">
                        <asp:TextBox runat="server" ID="NUMERO" CssClass="form-control" MaxLength="6" TextMode="SingleLine"></asp:TextBox>
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="Contato" CssClass="form-group" runat="server">
                <h2 class="text-center">Contado</h2>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="EMAIL" class="col-sm-3 control-label">Email</label>
                    <asp:Panel runat="server" CssClass="col-sm-9">
                        <asp:TextBox runat="server" ID="EMAIL" CssClass="form-control" MaxLength="200" TextMode="Email"></asp:TextBox>
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="FIXO1" class="col-sm-3 control-label">Fone Fixo</label>
                    <asp:Panel runat="server" CssClass="col-sm-9">
                        <asp:TextBox runat="server" ID="FIXO" CssClass="form-control" MaxLength="20" TextMode="Phone"></asp:TextBox>
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="CELULAR1" class="col-sm-3 control-label">Celular</label>
                    <asp:Panel runat="server" CssClass="col-sm-9">
                        <asp:TextBox runat="server" ID="CELULAR" CssClass="form-control" MaxLength="20" TextMode="Phone"></asp:TextBox>
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <asp:Panel runat="server" CssClass="col-sm-3">
                </asp:Panel>
                <asp:Panel runat="server" CssClass="col-sm-6">
                    <asp:Button runat="server" ID="BtnSalvar" CssClass="btn btn-success btn-block" CommandName="Insert" Text="Salvar"></asp:Button>
                </asp:Panel>
                <asp:Panel runat="server" CssClass="col-sm-3">
                </asp:Panel>
            </asp:Panel>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
