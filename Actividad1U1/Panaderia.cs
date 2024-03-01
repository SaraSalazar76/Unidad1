using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Actividad1U1
{
    public class Panaderia : INotifyPropertyChanged
    {
        public List<Producto> PanesEnVenta { get; set; } = new();
        public decimal MontoTotal 
        { 
            get { return ListaCompra.Sum(x => x.Precio); }
        }
        public Panaderia()
        {
            AgregarCommand = new RelayCommand<Producto>(Agregar);
            EliminarCommand = new RelayCommand<Producto>(Eliminar);
            ComprarCommand = new RelayCommand(Comprar);


                PanesEnVenta.Add(new Producto
                {
                    Nombre = "Dona de chocolate",
                    Cantidad = 50,
                    Precio = 9.30m,
                    Imagen = "https://www.krispykreme.mx/wp-content/uploads/2021/08/krispykreme-donas-chispas.png"
                });
                PanesEnVenta.Add(new Producto
                {
                    Nombre = "Concha de vainilla",
                    Cantidad = 50,
                    Precio = 10.50m,
                    Imagen = "https://m.media-amazon.com/images/I/61s1PzG2TbL._AC_UF350,350_QL80_.jpg"
                });
                PanesEnVenta.Add(new Producto
                {
                    Nombre = "Dona de azucar",
                    Cantidad = 50,
                    Precio = 7.50m,
                    Imagen = "https://www.elglobo.com.mx/cdn/shop/products/41213-2_800x.jpg?v=1618602954"
                });
                PanesEnVenta.Add(new Producto
                {
                    Nombre = "Empanada",
                    Cantidad = 50,
                    Precio = 5.50m,
                    Imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ0Uk2ikUxonMo9a75FV5Sv5d-sVu7Fat0VkLFiwcZF8jBu54cIpO_T2fO0dF3p1dmFdIg&usqp=CAU"
                });
                PanesEnVenta.Add(new Producto
                {
                    Nombre = "Cuernito",
                    Cantidad = 50,
                    Precio = 13.50m,
                    Imagen = "https://png.pngtree.com/png-clipart/20230927/original/pngtree-cutout-croissant-bread-png-image_13000334.png"
                });
                PanesEnVenta.Add(new Producto
                {
                    Nombre = "Cortadillo",
                    Cantidad = 50,
                    Precio = 17.90m,
                    Imagen = "https://www.maricruzavalos.com/wp-content/uploads/2020/11/cortadillos-mexicanos-recipe.jpg"
                });
            
        }

        private void Comprar()
        {
            ListaCompra.Clear();
            PropertyChanged?.Invoke(this, new(nameof(MontoTotal)));
        }

        private void Eliminar(Producto? pan)
        {
            if (pan!=null)
            {
                ListaCompra.Remove(pan);
                PropertyChanged?.Invoke(this, new(nameof(MontoTotal)));
            }
        }

        private void Agregar(Producto? pan)
        {
            if (pan!=null)
            {
                ListaCompra.Add(pan);
                PropertyChanged?.Invoke(this, new(nameof(MontoTotal)));
            }
        }


        public ObservableCollection<Producto> ListaCompra { get; set; } = new();
        public ICommand AgregarCommand { get; set; }
        public ICommand EliminarCommand { get; set; }
        public ICommand ComprarCommand { get; set; }
       
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
