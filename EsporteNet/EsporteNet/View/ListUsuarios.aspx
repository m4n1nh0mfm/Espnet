<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListUsuarios.aspx.cs" Inherits="EsporteNet.View.ListUsuarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">Filtros</div>
        <div class="panel-body">
            <div class="form-group">
                <label class="col-sm-2 control-label" for="email">Estado</label>
                <asp:Panel runat="server" CssClass="col-sm-2">
                    <asp:DropDownList ID="LsESTADO" CssClass="form-control" runat="server" Style="padding-top: 0px; padding-bottom: 0px;">
                        <asp:ListItem></asp:ListItem>
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
                <label for="CIDADE" class="col-sm-2  control-label">Cidade</label>
                <asp:Panel runat="server" CssClass="col-sm-6">
                    <asp:TextBox runat="server" ID="LsCIDADE" CssClass="form-control" MaxLength="50" TextMode="SingleLine"></asp:TextBox>
                </asp:Panel>
            </div>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="BAIRRO" class="col-sm-2 control-label">Bairro</label>
                <asp:Panel runat="server" CssClass="col-sm-5">
                    <asp:TextBox runat="server" ID="LsBAIRRO" CssClass="form-control" MaxLength="50" TextMode="SingleLine"></asp:TextBox>
                </asp:Panel>
                <label for="CEP" class="col-sm-2 control-label">CEP</label>
                <asp:Panel runat="server" CssClass="col-sm-3">
                    <asp:TextBox runat="server" ID="LsCEP" CssClass="form-control" MaxLength="10" TextMode="SingleLine" AutoPostBack="true"></asp:TextBox>
                    <asp:RegularExpressionValidator runat="server" ID="revCEP"
                        ControlToValidate="LsCEP"
                        Display="Dynamic"
                        ValidationExpression="^\d{5}\-?\d{3}$"
                        ErrorMessage="Por Favor Preencher Com um CEP Valido!" />
                </asp:Panel>
            </asp:Panel>
        </div>
    </div>
    <asp:Panel CssClass="form-group" runat="server">
        <asp:Panel runat="server" CssClass="col-sm-3">
        </asp:Panel>
        <asp:Panel runat="server" CssClass="col-sm-6">
            <asp:Button runat="server" ID="BtnConsultar" CssClass="btn btn-success btn-block" Text="Consultar"/>
        </asp:Panel>
        <asp:Panel runat="server" CssClass="col-sm-3">
        </asp:Panel>
    </asp:Panel>
    <asp:GridView ID="LsUsuarios" CssClass="table table-hover table-striped" DataKeyNames="Cod_usu" GridLines="None" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:BoundField DataField="Cod_usu" HeaderText="ID" SortExpression="Cod_usu"></asp:BoundField>
            <asp:BoundField DataField="Dsc_nome_usu" HeaderText="Nome" SortExpression="Dsc_nome_usu"></asp:BoundField>
            <asp:BoundField DataField="Cep" HeaderText="Cep" SortExpression="Cep"></asp:BoundField>
            <asp:BoundField DataField="Endereco" HeaderText="Endereco" SortExpression="Endereco"></asp:BoundField>
            <asp:BoundField DataField="Numero" HeaderText="Numero" SortExpression="Numero"></asp:BoundField>
            <asp:BoundField DataField="Bairro" HeaderText="Bairro" SortExpression="Bairro"></asp:BoundField>
            <asp:BoundField DataField="Cidade" HeaderText="Cidade" SortExpression="Cidade"></asp:BoundField>
            <asp:BoundField DataField="Uf" HeaderText="UF" SortExpression="Uf"></asp:BoundField>
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:BoundField>
            <asp:BoundField DataField="Celular" HeaderText="Celular" SortExpression="Celular"></asp:BoundField>
            <asp:TemplateField HeaderText="AÇÕES">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%# string.Format("~/View/UpdateUsuario.aspx?Cod_usu={0}", Eval("Cod_usu")) %>'>Editar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" OldValuesParameterFormatString="original_{0}" SelectMethod="ListarLocal" TypeName="EsporteNet.Models.Usuario.UsuarioDAO">
        <SelectParameters>
            <asp:ControlParameter ControlID="LsCEP" PropertyName="Text" Name="cep" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="LsBAIRRO" PropertyName="Text" Name="bairro" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="LsCIDADE" PropertyName="Text" Name="cidade" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="LsESTADO" PropertyName="SelectedValue" Name="uf" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
