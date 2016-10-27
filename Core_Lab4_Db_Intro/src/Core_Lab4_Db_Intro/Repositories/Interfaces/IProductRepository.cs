﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Lab4_Db_Intro.Repositories.Interfaces
{
    public interface IProductRepository: IRepository<Product>
    {
        Product GetProductByPrice(int price);
    }
}
