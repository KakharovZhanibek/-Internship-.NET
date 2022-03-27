using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.Interfaces
{
    public interface ITeacher
    {
        List<ICourse> courses { get; set; }
    }
}
