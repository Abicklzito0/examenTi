using System;
using System.Collections.Generic;
namespace ModeloDatos
{
    public class Documento : ICloneable
    {

        private int mID = 0;
        private int mIDCuenta = 0;
        private int mIDTipoDocumento = 0;
        private DateTime mFechaRegistro =DateTime.Now;
        private DateTime mFechaModificacion = DateTime.Now;
        private int mIDAuxiliar = 0;
        private double mImporte = 0.0;
        private double mParidad = 0.0;
        private int mIDMoneda = 0;
        private string mEstado = string.Empty;
        private string mDescripcion = string.Empty;
        private string mAuxilair = "";
        private string mTipoDocumento = "";
        public string TipoDocumento
        {
            get { return mTipoDocumento; }
            set { mTipoDocumento = value; }
        }
        public string Auxiliar
        {
            get { return mAuxilair; }
            set { mAuxilair = value; }
        }
        public int ID
        {
            get
            {
                return mID;
            }
            set
            {
                mID = value;
            }
        }
        public int IDCuenta
        {
            get
            {
                return mIDCuenta;
            }
            set
            {
                mIDCuenta = value;
            }
        }
        public int IDTipoDocumento
        {
            get
            {
                return mIDTipoDocumento;
            }
            set
            {
                mIDTipoDocumento = value;
            }
        }

        public DateTime FechaRegistro
        {
            get
            {
                return mFechaRegistro;
            }
            set
            {
                mFechaRegistro = value;
            }
        }

        public DateTime FechaModificacion
        {
            get
            {
                return mFechaModificacion;
            }
            set
            {
                mFechaModificacion = value;
            }
        }

        public int IDAuxiliar
        {
            get
            {
                return mIDAuxiliar;
            }
            set
            {
                mIDAuxiliar = value;
            }
        }

        public double Importe
        {
            get
            {
                return mImporte;
            }
            set
            {
                mImporte = value;
            }
        }

        public double Paridad
        {
            get
            {
                return mParidad;
            }
            set
            {
                mParidad = value;
            }
        }

        public int IDMoneda
        {
            get
            {
                return mIDMoneda;
            }
            set
            {
                mIDMoneda = value;
            }
        }

        public string Estado
        {
            get
            {
                return mEstado;
            }
            set
            {
                mEstado = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return mDescripcion;
            }
            set
            {
                mDescripcion = value;
            }
        }

        public Documento()
        {

        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

    }
}