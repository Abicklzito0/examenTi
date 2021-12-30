using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModeloDatos
{
    public class Auxiliar : ICloneable
    {

        private int mID = 0;
        private string mNombre = string.Empty;
        private string mApellidoPaterno = string.Empty;
        private string mApellidoMaterno = string.Empty;
        private string mCalle = string.Empty;
        private string mColonia = string.Empty;
        private string mNumero = string.Empty;
        private string mCodigoPostal = string.Empty;
        private string mTelefono = string.Empty;
        private string mRfc = string.Empty;
        private int mIDEstado = 0;
        private string mNombreCompleto;
        private string mObservaciones;
        private string mEstado;
        private List<int> mAuxiliarDetalleEliminado;
        public List<int> AuxiliarDetalleEliminado
        {
            get
            {
                return mAuxiliarDetalleEliminado;
            }
            set
            {
                mAuxiliarDetalleEliminado = value;
            }

        }
        private List<AuxiliarDetalle> mAuxiliarDetalle;
        public List<AuxiliarDetalle> AuxiliarDetalle
        {
            get
            {
                return mAuxiliarDetalle;
            }
            set
            {
                mAuxiliarDetalle = value;
            }

        }
        public string Observaciones
        {
            get
            {
                return mObservaciones;
            }
            set {
                mObservaciones = value;
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
        public string NombreCompleto
        {
            get
            {
                return Nombre+" "+ApellidoPaterno+" "+ApellidoMaterno;
            }
            
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
        [Required]
        public string Nombre
        {
            get
            {
                return mNombre;
            }
            set
            {
                mNombre = value;
            }
        }
        [Required]
        public string ApellidoPaterno
        {
            get
            {
                return mApellidoPaterno;
            }
            set
            {
                mApellidoPaterno = value;
            }
        }
       
        public string ApellidoMaterno
        {
            get
            {
                return mApellidoMaterno;
            }
            set
            {
                mApellidoMaterno = value;
            }
        }
        [Required]
        public string Calle
        {
            get
            {
                return mCalle;
            }
            set
            {
                mCalle = value;
            }
        }
        [Required]
        public string Colonia
        {
            get
            {
                return mColonia;
            }
            set
            {
                mColonia = value;
            }
        }
        [Required]
        public string Numero
        {
            get
            {
                return mNumero;
            }
            set
            {
                mNumero = value;
            }
        }
        [Required]
        public string CodigoPostal
        {
            get
            {
                return mCodigoPostal;
            }
            set
            {
                mCodigoPostal = value;
            }
        }
        [Required]
        public string Telefono
        {
            get
            {
                return mTelefono;
            }
            set
            {
                mTelefono = value;
            }
        }
        [Required]
        public string Rfc
        {
            get
            {
                return mRfc;
            }
            set
            {
                mRfc = value;
            }
        }
      
        public int IDEstado
        {
            get
            {
                return mIDEstado;
            }
            set
            {
                mIDEstado = value;
            }
        }

        public Auxiliar()
        {
            AuxiliarDetalle = new List<AuxiliarDetalle>();
            AuxiliarDetalleEliminado = new List<int>();
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

    }
}