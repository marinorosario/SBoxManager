using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBoxManager.Data
{
    public enum TipoSexo
    {
        Masculino = 1,
        Femenino
    }

    public enum TipoEstadoCivil
    {
        Soltero = 1,
        Casado
    }

    public enum TipoDocumento
    {
        Ninguno,
        Cedula,
        Pasaporte
    }

    public enum TipoTelefono
    {
        Ninguno,
        Casa,
        Trabajo,
        Celular
    }
}
