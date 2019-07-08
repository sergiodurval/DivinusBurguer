using Divinus.Domain.Entities;
using Divinus.Domain.Interfaces.Repositories;
using Divinus.Infra.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Divinus.Infra.Persistence.Repositories
{
    public class RepositoryOrder : RepositoryBase<Order,Guid> ,IRepositoryOrder
    {
        protected readonly DivinusContext _context;
        protected string strConnection = ConfigurationManager.ConnectionStrings["Divinus"].ConnectionString;
        protected SqlConnection conn;

        public RepositoryOrder(DbContext context) : base(context)
        {

        }

        public long InsertOrder(Order order)
        {
            try
            {
                using (conn = new SqlConnection(strConnection))
                {
                    string purchaseOrder = CreateXmlOrder(order);
                    SqlCommand command = new SqlCommand("sp_insert_order", conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", order.Id);
                    command.Parameters.AddWithValue("@idUser",order.IdUser);
                    command.Parameters.AddWithValue("@PurchaseOrder", purchaseOrder);
                    command.Parameters.AddWithValue("OrderDate", order.OrderDate);
                    command.Parameters.AddWithValue("@OrderNumber", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                    conn.Open();
                    command.ExecuteNonQuery();
                    long orderNumber = Convert.ToInt64(command.Parameters["@OrderNumber"].Value);
                    command.Dispose();
                    return orderNumber;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Order ObterPedidoById(Guid idOrder)
        {
            throw new NotImplementedException();
        }

        public List<Order> ObterTodosPedidos(Guid idUser)
        {
            throw new NotImplementedException();
        }

        public string CreateXmlOrder(Order order)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter writer = new XmlTextWriter(sw);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartDocument(true);
            writer.WriteStartElement("Order");
            writer.WriteStartElement("cartItens");
            foreach (Food food in order.PurchaseOrder)
            {
                writer.WriteStartElement("Food");
                writer.WriteStartElement("id");
                writer.WriteString(food.Id.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("name");
                writer.WriteString(food.Name);
                writer.WriteEndElement();
                writer.WriteStartElement("description");
                writer.WriteString(food.Description);
                writer.WriteEndElement();
                writer.WriteStartElement("price");
                writer.WriteString(food.Price.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("imageName");
                writer.WriteString(food.ImageName);
                writer.WriteEndElement();
                writer.WriteStartElement("category");
                writer.WriteString(food.Category);
                writer.WriteEndElement();
                writer.WriteStartElement("quantity");
                writer.WriteString(food.Quantity.ToString());
                writer.WriteEndElement();
                writer.WriteEndElement();
            }

            //writer.WriteEndElement();// fim food
            writer.WriteEndElement();// fim orderItem
            writer.WriteStartElement("address");//endereço
            writer.WriteStartElement("zipCode");
            writer.WriteString(order.Address.ZipCode);
            writer.WriteEndElement();
            writer.WriteStartElement("publicPlace");
            writer.WriteString(order.Address.PublicPlace);
            writer.WriteEndElement();
            writer.WriteStartElement("neighborhood");
            writer.WriteString(order.Address.Neighborhood);
            writer.WriteEndElement();
            writer.WriteStartElement("state");
            writer.WriteString(order.Address.State);
            writer.WriteEndElement();
            writer.WriteStartElement("locality");
            writer.WriteString(order.Address.Locality);
            writer.WriteEndElement();
            writer.WriteStartElement("gia");
            writer.WriteString(order.Address.Gia.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("ibge");
            writer.WriteString(order.Address.Ibge.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("complement");
            writer.WriteString(order.Address.Complement);
            writer.WriteEndElement();
            writer.WriteStartElement("number");
            writer.WriteString(order.Address.Number.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("reference");
            writer.WriteString(order.Address.Reference);
            writer.WriteEndElement();
            writer.WriteEndElement();//fim endereço

            //paymentMethod
            writer.WriteStartElement("paymentMethod");
            writer.WriteString(order.PaymentMethod);
            writer.WriteEndElement();

            //valortotal
            writer.WriteStartElement("totalValue");
            writer.WriteString(order.TotalValue.ToString());
            writer.WriteEndElement();

            //idUser
            writer.WriteStartElement("idUser");
            writer.WriteString(order.IdUser.ToString());
            writer.WriteEndElement();

            //fim do xml
            writer.WriteEndDocument();
            writer.Flush();
            string orderXml = sw.ToString();
            return orderXml;
        }
    }
}
