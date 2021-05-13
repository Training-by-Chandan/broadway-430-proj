
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadway.DesktopApp.CodeFirst
{
    public class UtilitiesContext : DbContext
    {
        public UtilitiesContext():base("name=UtilitiesConnection")
        {

        }
    }
}
