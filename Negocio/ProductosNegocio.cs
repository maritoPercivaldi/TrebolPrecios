using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;


namespace Negocio
{
    public class ProductosNegocio
    {
        public List<Productos> listar()
        {
            AccesoDatos conexion = null;
            List<Productos> lista = new List<Productos>();
            Productos aux;
            try
            {
                conexion = new AccesoDatos();
                conexion.setearConsulta("select pro.productoid,pro.descrip,pro.descripad,pro.descreduc,convert(money,pro.precultcpa) as 'Precio_Ult_Compra',mon.codigo,convert(date,pro.fecultcpa) as 'Fecha_Ult_Compra' from dbo.Producto as pro inner join dbo.Moneda as mon on pro.multcpaid = mon.monedaid where habilitado = 1 and pro.fecultcpa is not null");
                conexion.abrirConexion();
                conexion.ejecutarConsulta();
                while(conexion.Lector.Read())
                {
                    aux = new Productos();
                    aux.productoId = conexion.Lector.GetString(0);
                    aux.descrip = conexion.Lector.GetString(1);
                    aux.descripad = conexion.Lector.GetString(2);
                    aux.descreduc = conexion.Lector.GetString(3);
                    //aux.precioUltimaCompra = conexion.Lector.GetDecimal(4);
                    aux.precioUltimaCompra = System.Math.Round((conexion.Lector.GetDecimal(4)),2);
                    aux.moneda = conexion.Lector.GetString(5);
                    aux.fechaUltimaCompra = conexion.Lector.GetDateTime(6);
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if(conexion != null)
                {
                    conexion.cerrarConexion();
                }
            }
        }
        
    }
}
