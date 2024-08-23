﻿using FrameWork.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.BaseRepositories
{
    public  interface IBaseRepository<TModel,TKey>
    {
        TModel Get(TKey id);
        OperationResult Remove(TKey id);
        OperationResult Update(TModel current);
        OperationResult Register(TModel current);
        List<TModel> GetAll();

    }
}
