using BlogDAL.Repositories;
using BlogDAL;
using LightInject;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBL
{
    public static class BLLightInjectCongiguration
    {
        public static ServiceContainer Configuration(ServiceContainer container)
        {

            container.Register<DbContext>(factory => new BlogContext());
            container.Register(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            return container;
        }
    }
}
