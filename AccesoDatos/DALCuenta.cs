using System.Data.SqlClient;
using System.Data;
using DeTablaALista;
using System;
using System.Collections.Generic;
using ModeloDatos;

public class DALCuenta
{

    private string oConexion = null;

    public DALCuenta(string oConexion)
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

    public void Cargar(ref Cuenta oBeCuenta, DataRow dr)
    {
        try
        {
            oBeCuenta.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
            oBeCuenta.Descripcion = dr["Cuenta"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Cuenta"].ToString());
            oBeCuenta.IDAuxiliar = dr["IDAuxiliar"] == DBNull.Value ? 0 : int.Parse(dr["IDAuxiliar"].ToString());
            oBeCuenta.SaldoInicial = dr["SaldoInicial"] == DBNull.Value ? 0.0 : double.Parse(dr["SaldoInicial"].ToString());
            oBeCuenta.FechaRegistro = dr["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime((dr["FechaRegistro"].ToString()));
            oBeCuenta.FechaModificacion = dr["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime((dr["FechaModificacion"].ToString()));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Insertar(Cuenta oBeCuenta)
    {
        try
        {
            string sp = "SpCuentaInsertar";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID", oBeCuenta.ID));
                cmd.Parameters.Add(new SqlParameter("@CUENTA", oBeCuenta.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@IDAUXILIAR", oBeCuenta.IDAuxiliar));
                cmd.Parameters.Add(new SqlParameter("@SALDOINICIAL", oBeCuenta.SaldoInicial));
                cmd.Parameters.Add(new SqlParameter("@FECHAREGISTRO", oBeCuenta.FechaRegistro));
                cmd.Parameters.Add(new SqlParameter("@FECHAMODIFICACION", oBeCuenta.FechaModificacion));
                cmd.Parameters.Add(new SqlParameter("@Estado", oBeCuenta.Estado));
                rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());
                oBeCuenta.ID = rowsAffected;

                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Actualizar(Cuenta oBeCuenta)
    {
        try
        {
            string sp = "SpCuentaActualizar";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);

                cmd.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID", oBeCuenta.ID));
                cmd.Parameters.Add(new SqlParameter("@CUENTA", oBeCuenta.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@IDAUXILIAR", oBeCuenta.IDAuxiliar));
                cmd.Parameters.Add(new SqlParameter("@SALDOINICIAL", oBeCuenta.SaldoInicial));
                cmd.Parameters.Add(new SqlParameter("@FECHAREGISTRO", oBeCuenta.FechaRegistro));
                cmd.Parameters.Add(new SqlParameter("@FECHAMODIFICACION", oBeCuenta.FechaModificacion));
                cmd.Parameters.Add(new SqlParameter("@Estado", oBeCuenta.Estado));
                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Eliminar(Cuenta oBeCuenta)
    {
        try
        {
            string sp = "SpCuentaEliminar";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);

                cmd.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID", oBeCuenta.ID));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<Cuenta> Listar()
    {
        try
        {
            string sp = "SpCuentaListar";
            DALAuxiliar dalAuxiliar = new DALAuxiliar(oConexion);
            List<Cuenta> lista = new List<Cuenta>();
            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                dad.Fill(dt);
                tableToLista dal = new tableToLista();
                lista = dal.ConvertToList<Cuenta>(dt);
                foreach (var item in lista)
                {
                    Auxiliar Auxiliar = new Auxiliar() { ID = item.IDAuxiliar };
                    item.AuxiliarDescripcion = dalAuxiliar.Obtener(Auxiliar).NombreCompleto;
                
                }
                return lista;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Cuenta> Listar(int idAuxiliar)
    {
        try
        {
            string sp = "SpCuentaListarPorAuxiliar";
            DALAuxiliar dalAuxiliar = new DALAuxiliar(oConexion);
            List<Cuenta> lista = new List<Cuenta>();
            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@idAuxilair", idAuxiliar));
                SqlDataAdapter dad = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                dad.Fill(dt);
                tableToLista dal = new tableToLista();
                lista = dal.ConvertToList<Cuenta>(dt);
                foreach (var item in lista)
                {
                    Auxiliar Auxiliar = new Auxiliar() { ID = item.IDAuxiliar };
                    item.AuxiliarDescripcion = dalAuxiliar.Obtener(Auxiliar).NombreCompleto;

                }
                return lista;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public Cuenta Obtener( Cuenta oBeCuenta)
    {
        try
        {
            string sp = "SpCuentaObtener";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@ID", oBeCuenta.ID));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    Cargar(ref oBeCuenta, dt.Rows[0]);
                }

                return oBeCuenta;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
