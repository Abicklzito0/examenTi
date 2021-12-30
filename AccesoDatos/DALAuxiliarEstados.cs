using System.Data.SqlClient;
using System.Data;
using DeTablaALista;
using System;
using System.Collections.Generic;

public class DALAuxiliarEstados
{

    private string oConexion = null;

    public DALAuxiliarEstados(string oConexion)
    {
        try
        {
            this.oConexion = oConexion;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void Cargar(ref AuxiliarEstados oBeAuxiliarEstados, DataRow dr)
    {
        try
        {
            oBeAuxiliarEstados.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
            oBeAuxiliarEstados.Descripcion = dr["Descripcion"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Descripcion"].ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Insertar(AuxiliarEstados oBeAuxiliarEstados)
    {
        try
        {
            string sp = "SpAuxiliarEstadosInsertar";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID", oBeAuxiliarEstados.ID));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", oBeAuxiliarEstados.Descripcion));

                rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());
                oBeAuxiliarEstados.ID = rowsAffected;

                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Actualizar(AuxiliarEstados oBeAuxiliarEstados)
    {
        try
        {
            string sp = "SpAuxiliarEstadosActualizar";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);

                cmd.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID", oBeAuxiliarEstados.ID));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", oBeAuxiliarEstados.Descripcion));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Eliminar(AuxiliarEstados oBeAuxiliarEstados)
    {
        try
        {
            string sp = "SpAuxiliarEstadosEliminar";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);

                cmd.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID", oBeAuxiliarEstados.ID));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<AuxiliarEstados> Listar()
    {
        try
        {
            string sp = "SpAuxiliarEstadosListar";

            List<AuxiliarEstados> lista = new List<AuxiliarEstados>();
            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataAdapter dad = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                dad.Fill(dt);
                tableToLista dal = new tableToLista();
                lista = dal.ConvertToList<AuxiliarEstados>(dt);
                return lista;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool Obtener(ref AuxiliarEstados oBeAuxiliarEstados)
    {
        try
        {
            string sp = "SpAuxiliarEstadosObtener";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@ID", oBeAuxiliarEstados.ID));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    Cargar(ref oBeAuxiliarEstados, dt.Rows[0]);
                }

                return true;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
