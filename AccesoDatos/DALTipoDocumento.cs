using System.Data.SqlClient;
using System.Data;
using DeTablaALista;
using System;
using System.Collections.Generic;
using ModeloDatos;
public class DALTipoDocumento
{

    private string oConexion = null;

    public DALTipoDocumento(string oConexion)
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

    public void Cargar(ref TipoDocumento oBeTipoDocumento, DataRow dr)
    {
        try
        {
            oBeTipoDocumento.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
            oBeTipoDocumento.Descripcion = dr["Descripcion"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Descripcion"].ToString());
            oBeTipoDocumento.Factor = dr["Factor"] == DBNull.Value ? 0 : int.Parse(dr["Factor"].ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Insertar(TipoDocumento oBeTipoDocumento)
    {
        try
        {
            string sp = "SpTipoDocumentoInsertar";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID", oBeTipoDocumento.ID));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", oBeTipoDocumento.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@FACTOR", oBeTipoDocumento.Factor));

                rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());
                oBeTipoDocumento.ID = rowsAffected;

                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Actualizar(TipoDocumento oBeTipoDocumento)
    {
        try
        {
            string sp = "SpTipoDocumentoActualizar";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);

                cmd.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID", oBeTipoDocumento.ID));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", oBeTipoDocumento.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@FACTOR", oBeTipoDocumento.Factor));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Eliminar(TipoDocumento oBeTipoDocumento)
    {
        try
        {
            string sp = "SpTipoDocumentoEliminar";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);

                cmd.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID", oBeTipoDocumento.ID));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<TipoDocumento> Listar()
    {
        try
        {
            string sp = "SpTipoDocumentoListar";

            List<TipoDocumento> lista = new List<TipoDocumento>();
            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                dad.Fill(dt);
                tableToLista dal = new tableToLista();
                lista = dal.ConvertToList<TipoDocumento>(dt);
                return lista;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public TipoDocumento Obtener( TipoDocumento oBeTipoDocumento)
    {
        try
        {
            string sp = "SpTipoDocumentoObtener";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@ID", oBeTipoDocumento.ID));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    Cargar(ref oBeTipoDocumento, dt.Rows[0]);
                }

                return oBeTipoDocumento;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
