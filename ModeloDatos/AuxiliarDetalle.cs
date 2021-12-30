using System;
using System.Collections.Generic;

public class AuxiliarDetalle : ICloneable
{

    private int mID = 0;
    private int mIDAuxiliar = 0;
    private string mDescripcion = string.Empty;
    private String mRuta = string.Empty;
    private byte[] archivo;
    public byte[] Archivo
    {
        get { return archivo; }
        set { archivo = value; }
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

    public String Ruta
    {
        get
        {
            return mRuta;
        }
        set
        {
            mRuta = value;
        }
    }

    public AuxiliarDetalle()
    {

    }

    public object Clone()
    {
        return base.MemberwiseClone();
    }

}
