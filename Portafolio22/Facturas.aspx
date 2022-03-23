<%@ Page Title="" Language="C#" MasterPageFile="~/pag_plantilla.Master" AutoEventWireup="true" CodeBehind="Facturas.aspx.cs" Inherits="Portafolio22.Facturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
    <li class="nav-item">
          <a class="nav-link"href="Clientes.aspx">Clientes</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="Productos.aspx">Productos</a>
        </li>
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="Facturas.aspx">Facturas</a>
        </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-8 col-sm-12 p-3">
                <asp:GridView ID="grdFacturas" runat="server" CssClass="table table-dark table-bordered table-condensed table-responsive" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton class="btn btn-primary" 
                                    ID="lnkDetalle" runat="server" OnCommand="lnkDetalle_Command" CommandArgument='<%# Eval("ID_FACTURA").ToString() %>' >Mostrar Detalle
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                        <asp:BoundField DataField="FECHA" HeaderText="Fecha" />
                        <asp:BoundField DataField="ID_CLIENTE" HeaderText="Id Cliente" />
                        <asp:BoundField DataField="SUBTOTAL" HeaderText="Subtotal" />
                        <asp:BoundField DataField="IMPUESTO" HeaderText="Impuesto" />
                        <asp:BoundField DataField="MONTODESCUENTO" HeaderText="Monto Descuento" />
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="grdDetalle" CssClass="table table-dark table-bordered table-condensed table-responsive" runat="server" AutoGenerateColumns="False" Visible="false">
                    <Columns>
                        <asp:BoundField DataField="ID_FACTURA" HeaderText="Id Factura" />
                        <asp:BoundField DataField="ID_PRODUCTO" HeaderText="Id Producto" />
                        <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-lg-5 col-sm-12 p-3">
                <div class="card card-body">
                    <div class="caption-top d-flex justify-content-center">
                        <asp:Button CssClass="btn btn-primary m-3" ID="btnCancelar" runat="server" Text="Cerrar Detalle" OnClick="btnCancelar_Click" Visible ="False" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
