using System;
using System.Collections.Generic;
namespace ModeloDatos
{
	public class TipoDocumento : ICloneable
	{

		private int mID = 0;
		private string mDescripcion = string.Empty;
		private int mFactor = 0;

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
				return mDescripcion;
			}
			set
			{
				mDescripcion = value;
			}
		}

		public int Factor
		{
			get
			{
				return mFactor;
			}
			set
			{
				mFactor = value;
			}
		}

		public TipoDocumento()
		{

		}

		public object Clone()
		{
			return base.MemberwiseClone();
		}

	}
}