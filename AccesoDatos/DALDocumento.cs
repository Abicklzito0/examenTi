using System.Data.SqlClient;
using System.Data;
using DeTablaALista;
using System;
using System.Collections.Generic;
using ModeloDatos;
public class DALDocumento
{

    private string oConexion = null;

    public DALDocumento(string oConexion)
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

    public void Cargar(ref Documento oBeDocumento, DataRow dr)
    {
        try
        {
            oBeDocumento.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
            oBeDocumento.IDTipoDocumento = dr["IDTipoDocumento"] == DBNull.Value ? 0 : int.Parse(dr["IDTipoDocumento"].ToString());
            oBeDocumento.FechaRegistro = dr["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime((dr["FechaRegistro"].ToString()));
            oBeDocumento.FechaModificacion = dr["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime((dr["FechaModificacion"].ToString()));
            oBeDocumento.IDAuxiliar = dr["IDAuxiliar"] == DBNull.Value ? 0 : int.Parse(dr["IDAuxiliar"].ToString());
            oBeDocumento.Importe = dr["Importe"] == DBNull.Value ? 0.0 : double.Parse(dr["Importe"].ToString());
            oBeDocumento.Paridad = dr["Paridad"] == DBNull.Value ? 0.0 : double.Parse(dr["Paridad"].ToString());
            oBeDocumento.IDMoneda = dr["IDMoneda"] == DBNull.Value ? 0 : int.Parse(dr["IDMoneda"].ToString());
            oBeDocumento.Estado = dr["Estado"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Estado"].ToString());
            oBeDocumento.Descripcion = dr["Descripcion"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Descripcion"].ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Insertar(Documento oBeDocumento)
    {
        try
        {
            string sp = "SpDocumentoInsertar";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID", oBeDocumento.ID));
                cmd.Parameters.Add(new SqlParameter("@IDTIPODOCUMENTO", oBeDocumento.IDTipoDocumento));
                cmd.Parameters.Add(new SqlParameter("@FECHAREGISTRO", oBeDocumento.FechaRegistro));
                cmd.Parameters.Add(new SqlParameter("@FECHAMODIFICACION", oBeDocumento.FechaModificacion));
                cmd.Parameters.Add(new SqlParameter("@IDAUXILIAR", oBeDocumento.IDAuxiliar));
                cmd.Parameters.Add(new SqlParameter("@IMPORTE", oBeDocumento.Importe));
                cmd.Parameters.Add(new SqlParameter("@PARIDAD", oBeDocumento.Paridad));
                cmd.Parameters.Add(new SqlParameter("@IDMONEDA", oBeDocumento.IDMoneda));
                cmd.Parameters.Add(new SqlParameter("@ESTADO", oBeDocumento.Estado));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", oBeDocumento.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@IdCuenta", oBeDocumento.IDCuenta));
                rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());
                oBeDocumento.ID = rowsAffected;

                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Actualizar(Documento oBeDocumento)
    {
        try
        {
            string sp = "SpDocumentoActualizar";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);

                cmd.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID", oBeDocumento.ID));
                cmd.Parameters.Add(new SqlParameter("@IDTIPODOCUMENTO", oBeDocumento.IDTipoDocumento));
                cmd.Parameters.Add(new SqlParameter("@FECHAREGISTRO", oBeDocumento.FechaRegistro));
                cmd.Parameters.Add(new SqlParameter("@FECHAMODIFICACION", oBeDocumento.FechaModificacion));
                cmd.Parameters.Add(new SqlParameter("@IDAUXILIAR", oBeDocumento.IDAuxiliar));
                cmd.Parameters.Add(new SqlParameter("@IMPORTE", oBeDocumento.Importe));
                cmd.Parameters.Add(new SqlParameter("@PARIDAD", oBeDocumento.Paridad));
                cmd.Parameters.Add(new SqlParameter("@IDMONEDA", oBeDocumento.IDMoneda));
                cmd.Parameters.Add(new SqlParameter("@ESTADO", oBeDocumento.Estado));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", oBeDocumento.Descripcion));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Eliminar(Documento oBeDocumento)
    {
        try
        {
            string sp = "SpDocumentoEliminar";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);

                cmd.CommandType = CommandType.StoredProcedure;
                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@ID", oBeDocumento.ID));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<Documento> Listar()
    {
        try
        {
            DALAuxiliar dalAuxiliar = new DALAuxiliar(oConexion);
            DALTipoDocumento dalTipoDocumento = new DALTipoDocumento(oConexion);
            string sp = "SpDocumentoListar";

            List<Documento> lista = new List<Documento>();
            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                dad.Fill(dt);
                tableToLista dal = new tableToLista();
                lista = dal.ConvertToList<Documento>(dt);
                foreach (var item in lista)
                {
                    Auxiliar Auxiliar = new Auxiliar() { ID = item.IDAuxiliar };
                    item.Auxiliar = dalAuxiliar.Obtener(Auxiliar).NombreCompleto;
                    TipoDocumento TipoDocumento = new TipoDocumento() { ID = item.IDTipoDocumento };
                    item.TipoDocumento = dalTipoDocumento.Obtener(TipoDocumento).Descripcion;
                }
                return lista;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AntiguedadSaldo> ReporteAntiguedadSaldo(AntiguedadSaldo anti)
    {
        try
        {
            DALAuxiliar dalAuxiliar = new DALAuxiliar(oConexion);
            DALTipoDocumento dalTipoDocumento = new DALTipoDocumento(oConexion);
            string sp = "AntiguedadSAldo";

            List<AntiguedadSaldo> lista = new List<AntiguedadSaldo>();
            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@Inicio", anti.FechaInicio));
                cmd.Parameters.Add(new SqlParameter("@Fin", anti.FechaFin));
                cmd.Parameters.Add(new SqlParameter("@IdAuxiliar", anti.IdAuxiliar));
                cmd.Parameters.Add(new SqlParameter("@IDCuenta", anti.IdCuenta));
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                dad.Fill(dt);
                tableToLista dal = new tableToLista();
                lista = dal.ConvertToList<AntiguedadSaldo>(dt);
            

                for (int i = 0; i < lista.Count; i++)
                {
                    if (i == 0)
                        lista[i].SaldoActual = lista[i].SaldoInicial + lista[i].Importe;
                    else
                    {
                        lista[i].SaldoInicial = lista[i - 1].SaldoActual;
                        lista[i].SaldoActual= lista[i].SaldoInicial + lista[i].Importe;
                    }

                }
                return lista;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Obtener(ref Documento oBeDocumento)
    {
        try
        {
            string sp = "SpDocumentoObtener";

            using (SqlConnection cnn = new SqlConnection(oConexion))
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@ID", oBeDocumento.ID));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    Cargar(ref oBeDocumento, dt.Rows[0]);
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
