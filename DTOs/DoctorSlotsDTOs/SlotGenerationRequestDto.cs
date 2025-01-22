using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs.DoctorSlotsDTOs
{
    public class SlotGenerationRequestDto
    {
        public int DoctorId { get; set; }
        public List<int> DayOfWeek { get; set; }
        public DateOnly StartDate {  get; set; }
        public DateOnly EndDate { get; set; }
        public TimeOnly StartTimeSchedule { get; set; }
        public TimeOnly EndTimeSchedule { get; set; }
    }
}
