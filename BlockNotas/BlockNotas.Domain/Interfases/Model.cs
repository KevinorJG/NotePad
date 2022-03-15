using System;
using System.Collections.Generic;
using System.Text;

namespace BlockNotas.Domain.Interfases
{
    public interface Model
    {
        void Crear(string name);
        void Directorio(string path);

        void Sobreescribir(string path, string name);
    }
}
