using System.Text.Json.Serialization;

namespace FrontEnt_GestionPortatiles_Blazor.DTOs.Catalogos
{
    public class FacultadDto
    {
        [JsonPropertyName("idFacultad")]
        public int IdFacultad { get; set; }

        [JsonPropertyName("nombreFacultad")]
        public string NombreFacultad { get; set; } = string.Empty;
    }

    public class CarreraDto
    {
        [JsonPropertyName("idCarrera")]
        public int IdCarrera { get; set; }

        [JsonPropertyName("nombreCarrera")]
        public string NombreCarrera { get; set; } = string.Empty;
    }

    public class MarcaDto
    {
        [JsonPropertyName("idMarca")]
        public int IdMarca { get; set; }

        [JsonPropertyName("nombreMarca")]
        public string NombreMarca { get; set; } = string.Empty;
    }

    public class TipoEquipoDto
    {
        [JsonPropertyName("idTipo")]
        public int IdTipo { get; set; }

        [JsonPropertyName("nombreTipo")]
        public string NombreTipo { get; set; } = string.Empty;
    }
}