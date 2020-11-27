using PharmaGo.BOL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.DAL
{
    public interface IMedDemandDb
    {
        IEnumerable<MedDemand> GetMedDemands();
    }
    public class MedDemandDb
    {

    }
}
