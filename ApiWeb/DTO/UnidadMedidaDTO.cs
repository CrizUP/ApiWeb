using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ApiWeb.DTO
{
    //[DataContract]
    public class UnidadMedidaDTO
    {
        //[DataMember]
        public string IdUnidadMedida { get; set; }
        //[DataMember]
        public string Descripcion { get; set; }
        //[DataMember]
        public DateTime FechaModifico { get; set; }
        //[ScriptIgnore]
        //[JsonIgnore]
        //[IgnoreDataMember]
        public ICollection<ProductoDTO> Productos { get; set; }
    }
}
