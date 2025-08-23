// Models/TruckEntry.cs
using System;

namespace TerminalContainerApp.Models
{
    public class TruckEntry
    {
        public int Id { get; set; }
        public string TruckPlate { get; set; } // placa do caminhão
        public string ContainerNumber { get; set; } // número do container
        public DateTime EntryTime { get; set; } // horário de entrada
        public DateTime? ExitTime { get; set; } // horário de saída (opcional)
    }
}
