using System.Data.SqlClient;
using System.Data;
using DeTablaALista;
using System;
using System.Collections.Generic;

public class DALAuxiliarDetalle
{

    private string oConexion = null;

    public DALAuxiliarDetalle(string oConexion)
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

    public void Cargar(ref AuxiliarDetalle oBeAuxiliarDetalle, DataRow dr)
    {
        try
        {
            oBeAuxiliarDetalle.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
            oBeAuxiliarDetalle.IDAuxiliar = dr["IDAuxiliar"] == DBNull.Value ? 0 : int.Parse(dr["IDAuxiliar"].ToString());
            oBeAuxiliarDetalle.Descripcion = dr["Descripcion"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Descripcion"].ToString());
            oBeAuxiliarDetalle.Ruta = dr["Descripcion"] == DBNull.Value ? null: Convert.ToString(dr["Descripcion"].ToString());
            oBeAuxiliarDetalle.Archivo = dr["Ruta"] == DBNull.Value ? null : (byte[])(dr["Ruta"]);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Insertar(AuxiliarDetalle oBeAuxiliarDetalle)
    {
        try
        {
            string sp = "SpAuxiliarDetalleInsertar";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID", oBeAuxiliarDetalle.ID));
                cmd.Parameters.Add(new SqlParameter("@IDAUXILIAR", oBeAuxiliarDetalle.IDAuxiliar));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", oBeAuxiliarDetalle.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@RUTA", oBeAuxiliarDetalle.Ruta));

                rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());
                oBeAuxiliarDetalle.ID = rowsAffected;

                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Actualizar(AuxiliarDetalle oBeAuxiliarDetalle)
    {
        try
        {
            string sp = "SpAuxiliarDetalleActualizar";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);

                cmd.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID", oBeAuxiliarDetalle.ID));
                cmd.Parameters.Add(new SqlParameter("@IDAUXILIAR", oBeAuxiliarDetalle.IDAuxiliar));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", oBeAuxiliarDetalle.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@RUTA", oBeAuxiliarDetalle.Ruta));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Eliminar(int ID)
    {
        try
        {
            string sp = "SpAuxiliarDetalleEliminar";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);

                cmd.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID", ID));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<AuxiliarDetalle> Listar(int IdAuxiliar)
    {
        try
        {
            string sp = "SpAuxiliarDetalleListar";

            List<AuxiliarDetalle> lista = new List<AuxiliarDetalle>();

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@IdAuxiliar", IdAuxiliar));
                DataTable dt = new DataTable();
                dad.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    AuxiliarDetalle rol = new AuxiliarDetalle();
                    Cargar(ref rol, item);
                    lista.Add(rol);
                }
           
                return lista;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool Obtener(ref AuxiliarDetalle oBeAuxiliarDetalle)
    {
        try
        {
            string sp = "SpAuxiliarDetalleObtener";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@ID", oBeAuxiliarDetalle.ID));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    Cargar(ref oBeAuxiliarDetalle, dt.Rows[0]);
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
