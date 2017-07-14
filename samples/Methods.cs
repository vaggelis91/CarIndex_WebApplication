using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Formatting;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;

namespace samples
{
	public class Methods
	{

		public static string BuidQuery(string brand, string model, string engineCapacity, string fuelType, string type, string condition, string price)
		{
			StringBuilder queryBuilder = new StringBuilder();

			if (!string.IsNullOrEmpty(brand))
			{
				queryBuilder.Append(" Brand = '").Append(brand).Append("'");
			}

			if (!string.IsNullOrEmpty(model))
			{
				if (!string.IsNullOrEmpty(queryBuilder.ToString()))
				{
					queryBuilder.Append(" AND Model = '").Append(model).Append("'");
				}
				else
				{
					queryBuilder.Append(" Model = '").Append(model).Append("'");
				}
			}

			if (!string.IsNullOrEmpty(engineCapacity))
			{
				string[] engineCapacity_array = engineCapacity.Split('-');
				if (!string.IsNullOrEmpty(queryBuilder.ToString()))
				{
					queryBuilder.Append(" AND [Engine Capacity] BETWEEN ").Append(engineCapacity_array[0]).Append(" AND ").Append(engineCapacity_array[1]);
				}
				else
				{
					queryBuilder.Append(" [Engine Capacity] BETWEEN ").Append(engineCapacity_array[0]).Append(" AND ").Append(engineCapacity_array[1]);
				}
			}

			if (!string.IsNullOrEmpty(fuelType))
			{
				if (!string.IsNullOrEmpty(queryBuilder.ToString()))
				{
					queryBuilder.Append(" AND Fuel = '").Append(fuelType).Append("'");
				}
				else
				{
					queryBuilder.Append(" Fuel = '").Append(fuelType).Append("'");
				}
			}

			if (!string.IsNullOrEmpty(type))
			{
				if (!string.IsNullOrEmpty(queryBuilder.ToString()))
				{
					queryBuilder.Append(" AND Type = '").Append(type).Append("'");
				}
				else
				{
					queryBuilder.Append(" Type = '").Append(type).Append("'");
				}
			}

			if (!string.IsNullOrEmpty(price))
			{
				string[] price_array = price.Split('-');
				if (!string.IsNullOrEmpty(queryBuilder.ToString()))
				{
					queryBuilder.Append(" AND [Price(€)] BETWEEN ").Append(price_array[0]).Append(" AND ").Append(price_array[1]);
				}
				else
				{
					queryBuilder.Append(" [Price(€)] BETWEEN ").Append(price_array[0]).Append(" AND ").Append(price_array[1]);
				}
			}

			if (!string.IsNullOrEmpty(queryBuilder.ToString()))
			{
				if (condition == "New")
				{
					queryBuilder.Append(" AND Reused = 'No'");
				}
				else
				{
					queryBuilder.Append(" AND Reused = 'Yes'");
				}
			}
			else
			{
				if (condition == "New")
				{
					queryBuilder.Append(" Reused = 'No'");
				}
				else
				{
					queryBuilder.Append(" Reused = 'Yes'");
				}
			}
			return queryBuilder.ToString();
		}

		public static List<Car> ExecuteQuery(string buildQuery)
		{
			List<Car> listOfCars = new List<Car>();

			SqlConnection con = new SqlConnection("connection string");
			SqlCommand cmd = new SqlCommand("SELECT Brand, Model, [Engine Type], [Engine Capacity], [Max Speed], Acceleration, [Horse Power], Fuel, [Fuel Consumption], Type, Doors, [Price(€)] FROM MycarsTB WHERE" + buildQuery, con);
			con.Open();
			SqlDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				listOfCars.Add(new Car()
				{
					Brand = dr.GetString(0),
					Model = dr.GetString(1),
					Engine_Type = dr.GetString(2),
					Engine_Capacity = Convert.ToString(dr.GetSqlInt32(3)),
					Max_Speed = dr.GetString(4),
					Acceleration = dr.GetString(5),
					Horse_Power = dr.GetString(6),
					Fuel_Type = dr.GetString(7),
					Fuel_Consuption = dr.GetString(8),
					Type = dr.GetString(9),
					Doors = Convert.ToString(dr.GetSqlInt16(10)),
					Price = Convert.ToString(dr.GetSqlInt32(11))
				});
			}
			con.Close();

			return listOfCars;
		}


		public static bool CreateEmail(string name, string email, string comments)
		{
			try
			{
				SmtpClient SmtpServer;
				if (email.Contains("@live"))
				{
					SmtpServer = new SmtpClient("smtp.live.com");
				}
				else if (email.Contains("@gmail"))
				{
					SmtpServer = new SmtpClient("smtp.gmail.com");
				}
				else if (email.Contains("@yahoo"))
				{
					SmtpServer = new SmtpClient("smtp.mail.yahoo.com");
				}
				else
				{
					return false;
				}

				MailMessage mail = new MailMessage("mail@mail.com", "mail@mail.com", " CarIndex Comments " + name, comments + "\n" + email);
				SmtpServer.Port = 587;
				SmtpServer.Credentials = new NetworkCredential("email", "password");
				SmtpServer.EnableSsl = true;
				SmtpServer.Send(mail);

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}



	}
}