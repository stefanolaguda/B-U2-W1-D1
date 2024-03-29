﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_U2_W1_D1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Dipendente.ListaDipendenti.Clear();
                SqlConnection connectionDB = new SqlConnection();
                connectionDB.ConnectionString = ConfigurationManager.ConnectionStrings["CMS_Edile"].ToString();


                connectionDB.Open();

                try
                {

                    SqlCommand command = new SqlCommand();
                    command.CommandText = "Select * From Dipendente";
                    command.Connection = connectionDB;

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Dipendente dipendente = new Dipendente();
                            dipendente.ID_Dipendente = Convert.ToInt32(reader["ID_Dipendente"]);
                            dipendente.Nome = reader["Nome"].ToString();
                            dipendente.Cognome = reader["Cognome"].ToString();
                            dipendente.Indirizzo = reader["Indirizzo"].ToString();
                            dipendente.CodiceFiscale = reader["CodiceFiscale"].ToString();
                            dipendente.Coniugato = Convert.ToBoolean(reader["Coniugato"]);
                            dipendente.NumFigliCarico = Convert.ToInt32(reader["NumFigliCarico"]);
                            dipendente.Mansione = reader["Mansione"].ToString();
                            Dipendente.ListaDipendenti.Add(dipendente);
                        }

                    }


                    GridView_Dipendenti.DataSource = Dipendente.ListaDipendenti;
                    GridView_Dipendenti.DataBind();


                }
                catch (Exception ex)
                {
                    connectionDB.Close();
                }

                connectionDB.Close();
            }
            
        }

        protected void Btn_Dettagli_Click(object sender, EventArgs e)
        {
            Button DettagliBtn = (Button)sender;
            int IdDipendente = Convert.ToInt32(DettagliBtn.CommandArgument);
            Response.Redirect($"DettagliDipendente.aspx?ID_Dipendente={IdDipendente}");
        }

        protected void Btn_Dettagli_Click1(object sender, EventArgs e)
        {
            Button DettagliBtn = (Button)sender;
            int IdDipendente = Convert.ToInt32(DettagliBtn.CommandArgument);
            Response.Redirect($"DettagliDipendente.aspx?ID_Dipendente={IdDipendente}");
        }
    }
}
 