    class Linea {
            Producto producto;
            float importe;
            int cantidad;
            public float Importe { get => importe; set => importe = value; }
            public int Cantidad { get => cantidad; set => cantidad = value; }
            internal Producto Producto { get => producto; set => producto = value; }

            public Linea(Producto producto, int cantidad, float importe)
            {
                this.producto = producto;
                this.importe = importe;
                this.cantidad = cantidad;
            }

            public float Importe { get => importe; set => importe = value; }
            public int Cantidad { get => cantidad; set => cantidad = value; }
            internal Producto Producto { get => producto; set => producto = value; }
        }

        class Linea {
            internal Producto Producto {get;set;}
            public int Cantidad {get;set;}

            public Linea1(Producto producto, int cantidad) {
                Producto = producto;
                Cantidad = cantidad;
            }

            public float Importe => Producto.Precio * Cantidad;
        }