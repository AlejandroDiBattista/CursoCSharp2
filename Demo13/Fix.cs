public void Vender1(int codigo, int cantidad)
{
    var producto = Catalogo.Busqueda(codigo);

    if (producto == null) return;

    if (items.Count() >= 1)
    {

        bool bandera = false;
        foreach (var Li in items)
        {
            if (Li.producto == producto)
            {
                Li.cantidad += cantidad;
                bandera = true;
                break;
            }
            else
            {
                bandera = false;
            }
        }
        if (bandera == false)
        {
            items.Add(new Item() { cantidad = cantidad, producto = producto });
        }
    }
    else
    {
        items.Add(new Item() { cantidad = cantidad, producto = producto });      //  Primer Producto
    }
}

public void Vender(int codigo, int cantidad){
    var producto = Catalogo.Busqueda(codigo);
    if (producto == null) return;

    foreach(var Li in items) {
        if (Li.producto == producto) {
            Li.cantidad += cantidad;
            return;
        }
    }
    items.Add(new Item() { cantidad = cantidad, producto = producto });
}