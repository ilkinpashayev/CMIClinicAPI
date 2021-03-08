using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Models
{
    public enum StatusEnum
    {
        Issued = 1,
        Pending = 2,
        Cancelled = 3,
        Terminated = 4,
        Expired = 5
    }
}
