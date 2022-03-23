<%@ Page Title="" Language="C#" MasterPageFile="~/pag_plantilla.Master" AutoEventWireup="true" CodeBehind="modCliente.aspx.cs" Inherits="Portafolio22.modCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
     <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="Clientes.aspx">Clientes</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="Productos.aspx">Productos</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="Facturas.aspx">Facturas</a>
        </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-5 col-sm-12">
                <div class="col input-group p-3">
                    <asp:Label ID="lblId" CssClass="input-group-text" runat="server" Text="Id:"></asp:Label>
                    <asp:TextBox ID="txtId" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>                        
                </div>   
                <div class="col input-group p-3">
                    <asp:Label ID="lblNombre" CssClass="input-group-text" runat="server" Text="Nombre:"></asp:Label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" ReadOnly="false"></asp:TextBox>                        
                </div>
                <div class="col input-group p-3">
                    <asp:Label ID="lbltelefono" CssClass="input-group-text" runat="server" Text="Telefóno:"></asp:Label>
                    <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server" ReadOnly="false"></asp:TextBox>                        
                </div>
                <div class="col input-group p-3">
                    <asp:Label ID="lblDireccion" CssClass="input-group-text" runat="server" Text="Dirección:"></asp:Label>
                    <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server" ReadOnly="false"></asp:TextBox>                        
                </div>
            </div>
        </div>
        <div class="row justify-content-center p-3">
            <div class="col-lg-5 col-sm-12">
                <div class="card card-body">
                    <div class="caption-top d-flex justify-content-center">
                        <asp:Button class="btn btn-primary m-3" ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                        <asp:Button CssClass="btn btn-primary m-3" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
