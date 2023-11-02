using System.IO;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Globalization;

public class DefaultController : Page
{

    public ListBox cboMenu;
    public ListBox cboOrden;
    public ListBox cboVer;
    public ArrayList listaComidas;
    public ArrayList listaOrden;
    public TextBox txtName;
    public TextBox txtPrice;
    public TextBox txtTotal;
    public double total;

    protected void Page_Load(Object sender, EventArgs e)
    {
        // if is the firts time that the page is loaded
        if (!IsPostBack)
        {
            // initialize the variables
            total = 0.0;
            listaOrden = new ArrayList();
            listaComidas = new ArrayList();

            // add the items to the arraylist
            listaComidas.Add(new Comida("Hamburguesa", 22.0));
            listaComidas.Add(new Comida("Papas", 15.0));
            listaComidas.Add(new Comida("Refresco", 17.5));
            listaComidas.Add(new Comida("Hotdog", 10.0));
            listaComidas.Add(new Comida("Jugo", 15.0));
            listaComidas.Add(new Comida("Cilindro", 25.0));
            
            // add the items to the listbox
            foreach (Comida comida in listaComidas)
            {
                cboMenu.Items.Add(comida.Nombre);
            }

            // save the data in the session
            Session["listaComidas"] = listaComidas;
            Session["listaOrden"] = listaOrden;
            Session["total"] = total;
        } else {
            // if is not the first time that the page is loaded
            listaOrden = (ArrayList)Session["listaOrden"];
            listaComidas = (ArrayList)Session["listaComidas"];
            total = (double)Session["total"];
        }

    }

    public void btn_Agregar_Click(Object sender, EventArgs e)
    {
        // if the user has selected an item
        if (cboMenu.SelectedIndex > -1)
        {
            Comida comida = (Comida)listaComidas[cboMenu.SelectedIndex];

            // add the item to the listbox
            cboOrden.Items.Add(comida.ToString());
            listaOrden.Add(comida);

            // add the price to the total
            total += comida.Precio;
            txtTotal.Text = string.Format("{0:C2}", total);

            // save the data in the session
            Session["listaOrden"] = listaOrden;
            Session["total"] = total;
        }
    }

    public void Menu_SelectedIndexChanged_Click(Object sender, EventArgs e)
    {
        // if the user has selected an item
        if (cboMenu.SelectedIndex > -1)
        {
            Comida comida = (Comida)listaComidas[cboMenu.SelectedIndex];
            // show the name and the price of the item
            txtName.Text = comida.Nombre;
            txtPrice.Text = string.Format("{0:C2}", comida.Precio);
        }
    }

    public void btn_Quitar_Click(Object sender, EventArgs e)
    {
        // if the user has selected an item
        if (cboOrden.SelectedIndex > -1)
        {
            Comida comida = (Comida)listaComidas[cboOrden.SelectedIndex];

            // remove the item from the listbox
            cboOrden.Items.RemoveAt(cboOrden.SelectedIndex);
            // remove the item from the arraylist
            listaOrden.Remove(comida);

            // remove the price from the total
            total -= comida.Precio;
            txtTotal.Text = string.Format("{0:C2}", total);

            // save the data in the session
            Session["listaOrden"] = listaOrden;
            Session["total"] = total;
        }

    }

    public void btn_Limpiar_Click(Object sender, EventArgs e)
    {
        // clear the listbox and the arraylist
        cboOrden.Items.Clear();
        // clear the arraylist
        listaOrden.Clear();
        // clear the total
        total = 0.0;

        // clear the textboxes
        txtTotal.Text = "";
        txtName.Text = "";
        txtPrice.Text = "";

        // save the data in the session
        Session["listaOrden"] = listaOrden;
        Session["total"] = total;
    }
}

public class Comida
{

    public string Nombre
    {
        set;
        get;
    }

    public double Precio
    {
        set;
        get;
    }

    public Comida()
    {

    }

    public Comida(string nombre, double precio)
    {
        Nombre = nombre;
        Precio = precio;
    }

    public override string ToString()
    {
        return string.Format("{0:C2} {1}", Precio, Nombre);

    }
}