using System.Data.SqlClient;
using System.Data;
using DeTablaALista;
using System;
using System.Collections.Generic;
using ModeloDatos;

public class DALAuxiliar
{

    private string oConexion = null;

    public DALAuxiliar(string oConexion)
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


    public void Cargar(ref Auxiliar oBeAuxiliar, DataRow dr)
    {
        try
        {
            oBeAuxiliar.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
            oBeAuxiliar.Nombre = dr["Nombre"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Nombre"].ToString());
            oBeAuxiliar.ApellidoPaterno = dr["ApellidoPaterno"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ApellidoPaterno"].ToString());
            oBeAuxiliar.ApellidoMaterno = dr["ApellidoMaterno"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ApellidoMaterno"].ToString());
            oBeAuxiliar.Calle = dr["Calle"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Calle"].ToString());
            oBeAuxiliar.Colonia = dr["Colonia"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Colonia"].ToString());
            oBeAuxiliar.Numero = dr["Numero"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Numero"].ToString());
            oBeAuxiliar.CodigoPostal = dr["CodigoPostal"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CodigoPostal"].ToString());
            oBeAuxiliar.Telefono = dr["Telefono"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Telefono"].ToString());
            oBeAuxiliar.Rfc = dr["Rfc"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Rfc"].ToString());
            oBeAuxiliar.IDEstado = dr["IDEstado"] == DBNull.Value ? 0 : int.Parse(dr["IDEstado"].ToString());
            oBeAuxiliar.Observaciones = dr["Observaciones"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Observaciones"].ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Insertar(Auxiliar oBeAuxiliar)
    {
        SqlTransaction tran = null;
        try
        {
            string sp = "SpAuxiliarInsertar";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);

                cmd.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                cnn.Open();
                tran = cnn.BeginTransaction();
                cmd.Parameters.Add(new SqlParameter("@ID", oBeAuxiliar.ID));
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", oBeAuxiliar.Nombre));
                cmd.Parameters.Add(new SqlParameter("@APELLIDOPATERNO", oBeAuxiliar.ApellidoPaterno));
                cmd.Parameters.Add(new SqlParameter("@APELLIDOMATERNO", oBeAuxiliar.ApellidoMaterno));
                cmd.Parameters.Add(new SqlParameter("@CALLE", oBeAuxiliar.Calle));
                cmd.Parameters.Add(new SqlParameter("@COLONIA", oBeAuxiliar.Colonia));
                cmd.Parameters.Add(new SqlParameter("@NUMERO", oBeAuxiliar.Numero));
                cmd.Parameters.Add(new SqlParameter("@CODIGOPOSTAL", oBeAuxiliar.CodigoPostal));
                cmd.Parameters.Add(new SqlParameter("@TELEFONO", oBeAuxiliar.Telefono));
                cmd.Parameters.Add(new SqlParameter("@RFC", oBeAuxiliar.Rfc));
                cmd.Parameters.Add(new SqlParameter("@IDESTADO", oBeAuxiliar.IDEstado));
                cmd.Parameters.Add(new SqlParameter("@OBSERVACIONES", oBeAuxiliar.Observaciones));
                cmd.Transaction = tran;
                rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());
                oBeAuxiliar.ID = rowsAffected;

                foreach (var item in oBeAuxiliar.AuxiliarDetalle)
                {
                    item.IDAuxiliar = oBeAuxiliar.ID;
                }


                InsertarDetalle(oBeAuxiliar.AuxiliarDetalle, cmd);

                tran.Commit();
                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            tran.Rollback();
            throw ex;
        }
    }
    public void InsertarDetalle(List<AuxiliarDetalle> lista, SqlCommand cmd)
    {
        try
        {
            string sp = "SpAuxiliarDetalleInsertar";

            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            int rowsAffected = 0;
            cmd.CommandText = sp;
            foreach (var oBeAuxiliarDetalle in lista)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@IDAUXILIAR", oBeAuxiliarDetalle.IDAuxiliar));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", oBeAuxiliarDetalle.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@RUTA", oBeAuxiliarDetalle.Archivo));

                rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());
                oBeAuxiliarDetalle.ID = rowsAffected;


            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int InsertarDetalle(AuxiliarDetalle oBeAuxiliarDetalle)
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
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@IDAUXILIAR", oBeAuxiliarDetalle.IDAuxiliar));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", oBeAuxiliarDetalle.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@RUTA", oBeAuxiliarDetalle.Archivo));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int Actualizar(Auxiliar oBeAuxiliar)
    {
        try
        {
            string sp = "SpAuxiliarActualizar";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);

                cmd.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID", oBeAuxiliar.ID));
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", oBeAuxiliar.Nombre));
                cmd.Parameters.Add(new SqlParameter("@APELLIDOPATERNO", oBeAuxiliar.ApellidoPaterno));
                cmd.Parameters.Add(new SqlParameter("@APELLIDOMATERNO", oBeAuxiliar.ApellidoMaterno));
                cmd.Parameters.Add(new SqlParameter("@CALLE", oBeAuxiliar.Calle));
                cmd.Parameters.Add(new SqlParameter("@COLONIA", oBeAuxiliar.Colonia));
                cmd.Parameters.Add(new SqlParameter("@NUMERO", oBeAuxiliar.Numero));
                cmd.Parameters.Add(new SqlParameter("@CODIGOPOSTAL", oBeAuxiliar.CodigoPostal));
                cmd.Parameters.Add(new SqlParameter("@TELEFONO", oBeAuxiliar.Telefono));
                cmd.Parameters.Add(new SqlParameter("@RFC", oBeAuxiliar.Rfc));
                cmd.Parameters.Add(new SqlParameter("@IDESTADO", oBeAuxiliar.IDEstado));
                cmd.Parameters.Add(new SqlParameter("@OBSERVACIONES", oBeAuxiliar.Observaciones));
                rowsAffected = cmd.ExecuteNonQuery();


                if (oBeAuxiliar.AuxiliarDetalle.Count > 0)
                {
                    foreach (var item in oBeAuxiliar.AuxiliarDetalle)
                    {
                        if (item.ID > 0)
                            ActualizaDetalle(item);
                        else
                        {
                            item.IDAuxiliar = oBeAuxiliar.ID;
                            InsertarDetalle(item);
                        }

                    }
                }
                if (oBeAuxiliar.AuxiliarDetalleEliminado != null)
                    if (oBeAuxiliar.AuxiliarDetalleEliminado.Count > 0)
                    {
                        foreach (var itemDetalle in oBeAuxiliar.AuxiliarDetalleEliminado)
                        {
                            DALAuxiliarDetalle dalDetalle = new DALAuxiliarDetalle(oConexion);
                            dalDetalle.Eliminar(itemDetalle);
                        }

                    }
                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int ActualizaDetalle(AuxiliarDetalle oBeAuxiliarDetalle)
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
                cmd.Parameters.Add(new SqlParameter("@RUTA", oBeAuxiliarDetalle.Archivo));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int Eliminar(Auxiliar oBeAuxiliar)
    {
        try
        {
            string sp = "SpAuxiliarEliminar";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);

                cmd.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID", oBeAuxiliar.ID));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<Auxiliar> Listar()
    {
        try
        {
            string sp = "SpAuxiliarListar";

            List<Auxiliar> lista = new List<Auxiliar>();
            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                dad.Fill(dt);
                tableToLista dal = new tableToLista();
                lista = dal.ConvertToList<Auxiliar>(dt);
                return lista;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public Auxiliar Obtener( Auxiliar oBeAuxiliar)
    {
        try
        {
            string sp = "SpAuxiliarObtener";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@ID", oBeAuxiliar.ID));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    Cargar(ref oBeAuxiliar, dt.Rows[0]);
                }
                //agregar los archivos
                DALAuxiliarDetalle dalDetalle = new DALAuxiliarDetalle(oConexion);
                oBeAuxiliar.AuxiliarDetalle = dalDetalle.Listar(oBeAuxiliar.ID);
                return oBeAuxiliar;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
