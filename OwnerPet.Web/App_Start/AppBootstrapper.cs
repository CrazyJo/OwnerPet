using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OwnerPet.Web.Mappings;

namespace OwnerPet.Web.App_Start
{
    public static class AppBootstrapper
    {
        public static void Configure()
        {
            AutoMapperConfiguration.Configure();
        }
    }
}