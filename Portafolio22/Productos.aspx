<%@ Page Title="" Language="C#" MasterPageFile="~/pag_plantilla.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Portafolio22.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
    <li class="nav-item">
          <a class="nav-link"href="Clientes.aspx">Clientes</a>
        </li>
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="Productos.aspx">Productos</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="Facturas.aspx">Facturas</a>
        </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-5 col-sm-12 p-3">
                <asp:GridView ID="grdProductos" runat="server" CssClass="table table-dark table-bordered table-condensed table-responsive" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton class="btn btn-primary" 
                                    ID="lnkModificar" runat="server" CommandArgument='<%# Eval("ID_PRODUCTO").ToString() %>' OnCommand="lnkModificar_Command">Modificar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField> 
                            <ItemTemplate>
                                <asp:LinkButton class="btn btn-primary" ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("ID_PRODUCTO").ToString() %>' OnCommand="lnkEliminar_Command">Eliminar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripción" /> 
                        <asp:BoundField DataField="PRECIOVENTA" HeaderText="Precio Venta" /> 
                        <asp:BoundField DataField="PRECIOCOMPRA" HeaderText="Precio Compra" />
                        <asp:BoundField DataField="GRAVADO" HeaderText="Gravado" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
