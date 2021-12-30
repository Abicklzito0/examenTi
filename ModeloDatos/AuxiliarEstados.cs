using System;
using System.Collections.Generic;

public class AuxiliarEstados : ICloneable {

	private int mID = 0;
	private string mDescripcion = string.Empty;

	public int ID {
		get {
			return mID;
		}
		set {
			mID = value;
		}
	}

	public string Descripcion {
		get {
			return mDescripcion;
		}
		set {
			mDescripcion = value;
		}
	}

	public AuxiliarEstados(){

	}

	public object Clone() {
		return base.MemberwiseClone();
	}

}
