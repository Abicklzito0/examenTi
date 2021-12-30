using System;
using System.Collections.Generic;
namespace ModeloDatos
{
	public class Cuenta : ICloneable
	{
		private DateTime mFechaRegistro = DateTime.Now;
		private DateTime mFechaModificacion = DateTime.Now;
		private int mID = 0;
		private string mCuenta = string.Empty;
		private int mIDAuxiliar = 0;
		private double mSaldoInicial = 0.0;
		private double mSaldoActual = 0.0;
		private string mestado = "";
		private string auxiliar = "";
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
		public string Estado
		{
			get
			{
				return mestado;
			}
			set
			{
				mestado = value;
			}
		}
		public string AuxiliarDescripcion
		{
			get
			{
				return auxiliar;
			}
			set
			{
				auxiliar = value;
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

		public string Descripcion
		{
			get
			{
				return mCuenta;
			}
			set
			{
				mCuenta = value;
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
		public double SaldoActual
		{
			get
			{
				return mSaldoActual;
			}
			set
			{
				mSaldoActual = value;
			}
		}
		public double SaldoInicial
		{
			get
			{
				return mSaldoInicial;
			}
			set
			{
				mSaldoInicial = value;
			}
		}

		public Cuenta()
		{

		}

		public object Clone()
		{
			return base.MemberwiseClone();
		}

	}
}