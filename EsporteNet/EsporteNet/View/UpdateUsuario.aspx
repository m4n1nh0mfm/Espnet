<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateUsuario.aspx.cs" Inherits="EsporteNet.View.UpdateUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FormView ID="FormView2" DataKeyNames="Cod_usu" DefaultMode="Edit" Width="100%" runat="server" DataSourceID="ObjectDataSource1">
        <EditItemTemplate>
            <asp:Panel ID="USUARIO" CssClass="form-group" runat="server">
                <h2 class="text-center">Cadastro de Usuário</h2>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="NOME" class="col-sm-3 control-label">Nome do Usuário</label>
                    <asp:Panel runat="server" CssClass="col-sm-9">
                        <asp:TextBox runat="server" ID="NOME" Text='<%# Bind("Dsc_nome_usu") %>' CssClass="form-control" MaxLength="30" TextMode="SingleLine"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ID="rfvNome" SetFocusOnError="true" ControlToValidate="NOME" ErrorMessage="*Campo Obrigatorio!" ToolTip="Campo Obrigatorio!" BackColor="Red"></asp:RequiredFieldValidator>
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="USER" class="col-sm-3 control-label">Usuario</label>
                    <asp:Panel runat="server" CssClass="col-sm-9">
                        <asp:TextBox runat="server" ID="USER" ReadOnly="true" Text='<%# Bind("Dsc_username") %>' CssClass="form-control" MaxLength="30" TextMode="SingleLine"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ID="RequiredFieldValidator1" SetFocusOnError="true" ControlToValidate="USER" ErrorMessage="*Campo Obrigatorio!" ToolTip="Campo Obrigatorio!" BackColor="Red"></asp:RequiredFieldValidator>
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="CODSUP" class="col-sm-3 control-label">Codigo do Supervisor</label>
                    <asp:Panel runat="server" CssClass="col-sm-3">
                        <asp:TextBox runat="server" ID="CODSUP" Text='<%# Bind("Cod_sup") %>' CssClass="form-control" MaxLength="30" TextMode="SingleLine"></asp:TextBox>
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="LOCALIZACAO" CssClass="form-group" runat="server">
                <h2 class="text-center">Localização</h2>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="CEP" class="col-sm-3 control-label">CEP</label>
                    <asp:Panel runat="server" CssClass="col-sm-9">
                        <asp:TextBox runat="server" ID="CEP" Text='<%# Bind("Cep") %>' CssClass="form-control" MaxLength="10" TextMode="SingleLine" AutoPostBack="true" OnTextChanged="CEP_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvCEP" Display="Dynamic" SetFocusOnError="true" ControlToValidate="CEP" ErrorMessage="*" ToolTip="CEP Obrigatorio" BackColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="revCEP"
                            ControlToValidate="CEP"
                            Display="Dynamic"
                            ValidationExpression="^\d{5}\-?\d{3}$"
                            ErrorMessage="Por Favor Preencher Com um CEP Valido!" />
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="ESTADO" class="col-sm-3 control-label">Estado</label>
                    <asp:Panel runat="server" CssClass="col-sm-2">
                        <asp:DropDownList ID="ESTADO" Text='<%# Bind("Uf") %>' CssClass="form-control" runat="server" Style="padding-top: 0px; padding-bottom: 0px;">
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
                        <asp:TextBox runat="server" ID="CIDADE" Text='<%# Bind("Cidade") %>' CssClass="form-control" MaxLength="50" TextMode="SingleLine"></asp:TextBox>
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="BAIRRO" class="col-sm-3 control-label">Bairro</label>
                    <asp:Panel runat="server" CssClass="col-sm-3">
                        <asp:TextBox runat="server" ID="BAIRRO" Text='<%# Bind("Bairro") %>' CssClass="form-control" MaxLength="50" TextMode="SingleLine"></asp:TextBox>
                    </asp:Panel>
                    <label for="ENDERECO" class="col-sm-2 control-label">Endereço</label>
                    <asp:Panel runat="server" CssClass="col-sm-4">
                        <asp:TextBox runat="server" ID="ENDERECO" Text='<%# Bind("Endereco") %>' CssClass="form-control" MaxLength="50" TextMode="SingleLine"></asp:TextBox>
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="NUMERO" class="col-sm-3 control-label">Número</label>
                    <asp:Panel runat="server" CssClass="col-sm-3">
                        <asp:TextBox runat="server" ID="NUMERO" Text='<%# Bind("Numero") %>' CssClass="form-control" MaxLength="6" TextMode="SingleLine"></asp:TextBox>
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="Contato" CssClass="form-group" runat="server">
                <h2 class="text-center">Contado</h2>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="EMAIL" class="col-sm-3 control-label">Email</label>
                    <asp:Panel runat="server" CssClass="col-sm-9">
                        <asp:TextBox runat="server" ID="EMAIL" Text='<%# Bind("Email") %>' CssClass="form-control" MaxLength="200" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ID="rfvEMAIL" SetFocusOnError="true" ControlToValidate="EMAIL" ErrorMessage="*Campo Obrigatorio!" ToolTip="Campo Obrigatorio!" BackColor="Red">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="revEMAIL1"
                            ControlToValidate="EMAIL"
                            Display="Dynamic"
                            ValidationExpression="^([\w\-]+\.)*[\w\- ]+@([\w\- ]+\.)+([\w\-]{2,3})$"
                            ErrorMessage="Por Favor Preencher Com um Email Valido!" />
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="FIXO1" class="col-sm-3 control-label">Fone Fixo</label>
                    <asp:Panel runat="server" CssClass="col-sm-9">
                        <asp:TextBox runat="server" ID="FIXO" Text='<%# Bind("Telefone") %>' CssClass="form-control" MaxLength="20" TextMode="Phone"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvFixo" Display="Dynamic" ControlToValidate="FIXO" ErrorMessage="(*) O telefone fixo é obrigatório!" ToolTip="O telefone fixo é obrigatório!" BackColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="rqvFixo1"
                            ControlToValidate="FIXO"
                            Display="Dynamic"
                            ValidationExpression="^[0-9]{2}[0-9]{4}[0-9]{4}$"
                            ErrorMessage="Por Favor Preencher Com um Telefone Valido!" />
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel CssClass="form-group" runat="server">
                    <label for="CELULAR1" class="col-sm-3 control-label">Celular</label>
                    <asp:Panel runat="server" CssClass="col-sm-9">
                        <asp:TextBox runat="server" ID="CELULAR" Text='<%# Bind("Celular") %>' CssClass="form-control" MaxLength="20" TextMode="Phone"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvCelular" Display="Dynamic" ControlToValidate="CELULAR" ErrorMessage="(*) O celular é obrigatório!" ToolTip="O celular é obrigatório!" BackColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="rfvCelular1"
                            ControlToValidate="CELULAR"
                            Display="Dynamic"
                            ValidationExpression="^[0-9]{2}[0-9]{5}[0-9]{4}$"
                            ErrorMessage="Por Favor Preencher Com um Celular Valido!" />
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <asp:Panel runat="server" CssClass="col-sm-3">
                </asp:Panel>
                <asp:Panel runat="server" CssClass="col-sm-6">
                    <asp:Button runat="server" ID="BtnSalvar" CssClass="btn btn-success btn-block" CommandName="Update" Text="Salvar"></asp:Button>
                </asp:Panel>
                <asp:Panel runat="server" CssClass="col-sm-3">
                </asp:Panel>
            </asp:Panel>
        </EditItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" DataObjectTypeName="EsporteNet.Models.Usuario.Usuario" OldValuesParameterFormatString="original_{0}" SelectMethod="ObterUsuario" TypeName="EsporteNet.Models.Usuario.UsuarioDAO" UpdateMethod="Update">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="Cod_usu" Name="chave" Type="Int64"></asp:QueryStringParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
