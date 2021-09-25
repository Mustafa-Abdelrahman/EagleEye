using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EagleEye.DataAccess.Entities.Enums
{
    public enum ProjectStatuses
    {
        InProgress = 1,
        Finished = 2,
        OnHold = 3,
        PassedDeadLine = 4,
        Problematic = 5
    }
}
