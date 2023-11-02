<% @Page Language="C#" Inherits="DefaultController" src="Default.aspx.cs" %>
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Menu</title>
    <link rel="stylesheet" href="style.css" />
  </head>
  <body>
    <form runat="server" id="menu">
      <section>
        <h1>Menu</h1>
        <asp:ListBox runat="server" id="cboMenu" AutoPostBack="true" OnSelectedIndexChanged="Menu_SelectedIndexChanged_Click"/>
        <section>
          <label for="txtName"><b>Producto</b></label>
          <label for="txtPrice"><b>Precio</b></label>
          <asp:TextBox runat="server" id="txtName" Enabled="false"/>
          <asp:TextBox runat="server" id="txtPrice" Enabled="false" />
        </section>
      </section>
      <asp:Button runat="server" id="btnAgregar" Text=">" OnClick="btn_Agregar_Click"/>
      <section>
        <h1>Tu orden</h1>
        <asp:ListBox runat="server" id="cboOrden" />
        <section>
            <label for="txtTotal"><b>Total</b></label>
            <br>
          <asp:TextBox runat="server" id="txtTotal" Enabled="false" />
          <asp:Button runat="server" id="btnLimpiar" Text="Limpiar" OnClick="btn_Limpiar_Click"/>
        </section>
      </section>
      <asp:Button runat="server" id="btnQuitar" Text="X" OnClick="btn_Quitar_Click"/>
    </form>
  </body>
</html>
