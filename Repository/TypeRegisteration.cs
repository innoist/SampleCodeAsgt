﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Repository.Product;
namespace Repository
{
    public static class TypeRegisteration

    {
        public static void RegisterType(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IProductRepository, ProductRepository>();
        }
    }
}
